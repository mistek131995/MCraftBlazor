using MCraftBlazor.Helpers.Services.Interfaces;
using MCraftBlazor.Models;

namespace MCraftBlazor.Helpers.Services.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        public UserModel User {get; private set;}
        public ILocalStorageService localStorageService;

        public AuthenticationService(ILocalStorageService localStorageService)
        {
            this.localStorageService = localStorageService;
        }

        public async Task Initialize()
        {
            User = await localStorageService.GetItemAsync("")
        }

        public Task Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task Logout()
        {
            throw new NotImplementedException();
        }
    }
}
