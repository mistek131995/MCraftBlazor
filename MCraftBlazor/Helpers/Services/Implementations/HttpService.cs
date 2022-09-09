using MCraftBlazor.Helpers.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using MCraftBlazor.Models;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;

namespace MCraftBlazor.Helpers.Services.Implementations
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient httpClient;
        private readonly NavigationManager navigationManager;
        private readonly ILocalStorageService localStorage;

        public HttpService(HttpClient httpClient, NavigationManager navigationManager, ILocalStorageService localStorage)
        {
            this.httpClient = httpClient;
            this.navigationManager = navigationManager;
            this.localStorage = localStorage;
        }

        public async Task<T> Get<T>(string uri)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            return await sendRequest<T>(request);
        }

        public async Task<T> Post<T>(string uri, object value)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, uri);
            request.Content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");
            return await sendRequest<T>(request);
        }

        private async Task<T> sendRequest<T>(HttpRequestMessage request)
        {
            var user = await localStorage.GetItemAsync<UserModel>("user");
            var isApiUrl = !request.RequestUri.IsAbsoluteUri;
            if (user != null && isApiUrl)
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", user.Token);

            using var response = await httpClient.SendAsync(request);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                navigationManager.NavigateTo("/logout");
                return default;
            }

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                throw new Exception(error["message"]);
            }

            return await response.Content.ReadFromJsonAsync<T>();
        }
    }
}
