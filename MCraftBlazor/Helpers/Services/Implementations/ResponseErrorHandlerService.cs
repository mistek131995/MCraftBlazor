using MCraftBlazor.Helpers.Services.Interfaces;
using MCraftBlazor.Models;

namespace MCraftBlazor.Helpers.Services.Implementations
{
    public class ResponseErrorHandlerService : IResponseErrorHandlerService
    {
        public async Task ResponseHandlerAsync(ResponseModel model)
        {
            switch (model.Type)
            {
                case ResponseModel.ResponseType.UserExistError:
                    Console.WriteLine("User exist");
                    break;
                case ResponseModel.ResponseType.UserNotExistError:
                    Console.WriteLine("User not exist");
                    break;
                default:
                    Console.WriteLine("Unhandled error");
                    break;
            }
        }
    }
}
