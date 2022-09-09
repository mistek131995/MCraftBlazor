using MCraftBlazor.Models;

namespace MCraftBlazor.Helpers.Services.Interfaces
{
    public interface IAuthenticationService
    {
        UserModel User { get; }
        Task Initialize();
        Task Login(LoginModel model);
        Task Logout();
    }
}
