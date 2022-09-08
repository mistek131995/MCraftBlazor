using MCraftBlazor.Models;

namespace MCraftBlazor.Helpers.Services.Interfaces
{
    public interface IResponseErrorHandlerService
    {
        Task ResponseHandlerAsync(ResponseModel model);
    }
}
