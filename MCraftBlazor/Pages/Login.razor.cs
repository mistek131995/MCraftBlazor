using MCraftBlazor.Models;

namespace MCraftBlazor.Pages
{
    public partial class Login
    {
        public LoginModel loginModel = new LoginModel();

        private async Task OnValidAsync()
        {
            userRepository.HasError += Test;

            await userRepository.GetUser(loginModel);
        }

        private void Test()
        {
            Console.WriteLine("Ну тут какая-то ошибка...");
        }

    }
}
