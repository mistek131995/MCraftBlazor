using MCraftBlazor.Models;
using MCraftBlazor.Repository.Interfaces;
using System.Net.Http.Json;

namespace MCraftBlazor.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly HttpClient httpClient;
        private readonly Uri baseUrl;
        public UserRepository(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            baseUrl = httpClient.BaseAddress;
        }

        public async Task CreateUserAsync(UserModel model)
        {
            var response = await httpClient.PostAsJsonAsync(baseUrl + "user/adduser", model);

            if (response.IsSuccessStatusCode)
            {

            } else
            {

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
