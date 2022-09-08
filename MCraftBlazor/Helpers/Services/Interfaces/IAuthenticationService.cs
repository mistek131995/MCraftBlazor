using MCraftBlazor.Models;

namespace MCraftBlazor.Helpers.Services.Interfaces
{
    public interface IAuthenticationService
    {
        UserModel User { get; }
        Task Initialize();
        Task Login(string username, string password);
        Task Logout();
    }
}
