using MCraftBlazor.Helpers.Services;
using MCraftBlazor.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace MCraftBlazor.Repository.Implementation
{
    public class UserRepository
    {
        private readonly NavigationManager navigation;
        private readonly HttpClient httpClient;
        private readonly ResponseErrorHandlerService responseHandler;
        private readonly LocalStorageService localSorage;

        public delegate void ResposeError();
        public event ResposeError HasError; 

        public UserRepository(NavigationManager navigation, HttpClient httpClient, ResponseErrorHandlerService responseHandler, LocalStorageService localSorage)
        {
            this.navigation = navigation;
            this.httpClient = httpClient;
            this.localSorage = localSorage;
            this.responseHandler = responseHandler;
        }

        public async Task CreateUserAsync(RegisterModel model)
        {

            var response = await httpClient.PostAsJsonAsync(httpClient.BaseAddress + "user/adduser", model);

            if (response.IsSuccessStatusCode)
            {
                navigation.NavigateTo("/login?register=success");
            } 
            else
            {
                var result = await response.Content.ReadFromJsonAsync<ResponseModel>();

                await responseHandler.ResponseHandlerAsync(result);
                HasError?.Invoke();
            }

        }

        public Task DeleteUser(string guid)
        {
            throw new NotImplementedException();
        }

        public async Task GetUser(LoginModel model)
        {
            var responese = await httpClient.PostAsJsonAsync(httpClient.BaseAddress + "token/auth", model);

            if (responese.IsSuccessStatusCode)
            {
                var result = await responese.Content.ReadFromJsonAsync<ResponseModel>();

                await localSorage.SetItemAsync("token", result.Payload);

                Console.WriteLine(result.Payload);
            }
            else
            {
                var result = await responese.Content.ReadFromJsonAsync<ResponseModel>();

                await responseHandler.ResponseHandlerAsync(result);
                HasError?.Invoke();
            }
        }

        public Task UpdateUser(RegisterModel model)
        {
            throw new NotImplementedException();
        }
    }
}
