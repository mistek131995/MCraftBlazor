namespace MCraftBlazor.Pages
{
    public partial class Logout
    {
        protected override async void OnInitialized()
        {
            await AuthenticationService.Logout();
        }
    }
}
