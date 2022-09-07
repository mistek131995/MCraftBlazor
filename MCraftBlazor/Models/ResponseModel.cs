namespace MCraftBlazor.Models
{
    public class ResponseModel
    {
        public enum ResponseType
        {
            Success,
            UserExistError,
            ValidationError,
            UserNotExistError,
            OtherError
        }

        public ResponseType Type { get; set; }
        public string Message { get; set; }
        public string Payload { get; set; }
    }

}
