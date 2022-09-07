using MCraftBlazor.Components.Common;
using MCraftBlazor.Helpers.Services;
using MCraftBlazor.Models;
using MCraftBlazor.Repository.Interfaces;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace MCraftBlazor.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly NavigationManager navigation;
        private readonly HttpClient httpClient;
        private readonly ResponseErrorHandlerService responseHandler;



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
            }

        }

        public Task DeleteUser(string guid)
        {
            throw new NotImplementedException();
        }

        public Task GetUser(string Login, string Password)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUser(UserModel model)
        {
            throw new NotImplementedException();
        }
    }
}
