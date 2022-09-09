namespace MCraftBlazor.Helpers.Services.Interfaces
{
    public interface ILocalStorageService
    {
        Task DeleteItemAsync(string key);
        Task<T> GetItemAsync<T>(string key);
        Task SetItemAsync<T>(string key, T value);
    }
}
