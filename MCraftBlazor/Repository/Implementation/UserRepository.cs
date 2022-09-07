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

        public delegate void ResposeError();
        public event ResposeError HasError; 

        public UserRepository(NavigationManager navigation, HttpClient httpClient, ResponseErrorHandlerService responseHandler)
        {
            this.navigation = navigation;
            this.httpClient = httpClient;
            this.responseHandler = responseHandler;
        }

        public async Task CreateUserAsync(UserModel model)
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
            var responese = await httpClient.PostAsJsonAsync(httpClient.BaseAddress + "token/", model);

            if (responese.IsSuccessStatusCode)
            {
                var result = await responese.Content.ReadFromJsonAsync<ResponseModel>();

                Console.WriteLine(result.Payload);
            }
            else
            {
                var result = await responese.Content.ReadFromJsonAsync<ResponseModel>();

                await responseHandler.ResponseHandlerAsync(result);
                HasError?.Invoke();
            }
        }

        public Task UpdateUser(UserModel model)
        {
            throw new NotImplementedException();
        }
    }
}
