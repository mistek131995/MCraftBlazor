using MCraftBlazor;
using MCraftBlazor.Helpers.Services.Implementations;
using MCraftBlazor.Helpers.Services.Interfaces;
using MCraftBlazor.Repository.Implementation;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7132") });
builder.Services.AddScoped<IResponseErrorHandlerService, ResponseErrorHandlerService>();
builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IHttpService, HttpService>();

#region �����������
builder.Services.AddScoped<UserRepository>();
#endregion


await builder.Build().RunAsync();
