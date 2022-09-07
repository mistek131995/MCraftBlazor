using MCraftBlazor.Models;
using Microsoft.AspNetCore.Components;

namespace MCraftBlazor.Helpers.Services
{
    public class ResponseErrorHandlerService
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
