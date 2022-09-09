using MCraftBlazor.Helpers.Services.Interfaces;
using MCraftBlazor.Models;
using Microsoft.AspNetCore.Components;
using System.Text.Json;

namespace MCraftBlazor.Helpers.Services.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        public UserModel User {get; private set;}
        private readonly ILocalStorageService localStorageService;
        private readonly IHttpService httpService;
        private readonly NavigationManager navigationManager;

        public AuthenticationService(ILocalStorageService localStorageService, NavigationManager navigationManager, IHttpService httpService)
        {
            this.localStorageService = localStorageService;
            this.navigationManager = navigationManager;
            this.httpService = httpService;
        }

        public async Task Initialize()
        {
            User = await localStorageService.GetItemAsync<UserModel>("user");
        }

        public async Task Login(LoginModel model)
        {
            var response = await httpService.Post<ResponseModel>("/token/auth", model);

            User = JsonSerializer.Deserialize<UserModel>(response.Payload);

            await localStorageService.SetItemAsync("user", User);
        }

        public async Task Logout()
        {
            User = null;
            await localStorageService.DeleteItemAsync("user");
            navigationManager.NavigateTo("/login");
        }
    }
}
