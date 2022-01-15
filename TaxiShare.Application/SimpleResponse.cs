namespace TaxiShare.Application
{
    public class SimpleResponse
    {
        public SimpleResponse(bool success)
        {
            Success = success;
        }

        public SimpleResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }
        public SimpleResponse(bool success, string message, int httpStatusCode)
        {
            Success = success;
            Message = message;
            HttpCode = httpStatusCode;
        }

        public SimpleResponse(bool success, int httpStatusCode)
        {
            Success = success;
            HttpCode = httpStatusCode;
        }

        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public int HttpCode { get; set; } = 418;
    }
}
