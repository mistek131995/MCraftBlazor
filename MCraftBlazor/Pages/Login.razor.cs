using MCraftBlazor.Helpers.Services.Implementations;
using MCraftBlazor.Models;
using Microsoft.AspNetCore.Components;
using System.Reflection;

namespace MCraftBlazor.Pages
{
    public partial class Login
    {
        public LoginModel loginModel = new LoginModel();

        protected override void OnInitialized()
        {
            if (AuthenticationService.User != null)
            {
                NavigationManager.NavigateTo("");
            }
        }

        private async Task OnValidAsync()
        {
            await AuthenticationService.Login(loginModel);
        }

    }
}
