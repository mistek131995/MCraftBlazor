using MCraftBlazor.Models;

namespace MCraftBlazor.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task CreateUserAsync(UserModel model);
        Task GetUser(string Login, string Password);
        Task UpdateUser(UserModel model);
        Task DeleteUser(string guid);
    }
}
