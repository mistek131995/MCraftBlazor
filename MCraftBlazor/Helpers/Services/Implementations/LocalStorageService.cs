using MCraftBlazor.Helpers.Services.Interfaces;
using Microsoft.JSInterop;
using System.Text.Json;

namespace MCraftBlazor.Helpers.Services.Implementations
{
    public class LocalStorageService : ILocalStorageService
    {
        private readonly IJSRuntime jSRuntime;
        public LocalStorageService(IJSRuntime jSRuntime)
        {
            this.jSRuntime = jSRuntime;
        }

        public async Task DeleteItemAsync(string key)
        {
            await jSRuntime.InvokeVoidAsync("localStorage.removeItem", key);
        }

        public async Task<T> GetItemAsync<T>(string key)
        {
            var result = await jSRuntime.InvokeAsync<string>("localStorage.getItem", key);

            if (result == null)
                return default;

            return JsonSerializer.Deserialize<T>(result);
        }

        public async Task SetItemAsync(string key, string value)
        {
            await jSRuntime.InvokeVoidAsync("localStorage.setItem", key, value);
        }
    }
}
