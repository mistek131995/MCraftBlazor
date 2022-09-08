using Microsoft.JSInterop;

namespace MCraftBlazor.Helpers.Services
{
    public class LocalStorageService
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

        public async Task<string> GetItemAsync(string key)
        {
            var result = await jSRuntime.InvokeAsync<string>("localStorage.getItem", key);

            return result;
        }

        public async Task SetItemAsync(string key, string value)
        {
            await jSRuntime.InvokeVoidAsync("localStorage.setItem", key, value);
        }
    }
}
