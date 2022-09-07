using MCraftBlazor;
using MCraftBlazor.Helpers.Services;
using MCraftBlazor.Repository.Implementation;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7132") });
builder.Services.AddScoped<ResponseErrorHandlerService>();

#region Репозиторий
builder.Services.AddScoped<UserRepository>();
#endregion


await builder.Build().RunAsync();
