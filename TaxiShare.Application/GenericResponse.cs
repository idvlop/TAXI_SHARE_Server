namespace TaxiShare.Application
{
    public class GenericResponse<T>
    {
        public GenericResponse(bool success)
        {
            Success = success;
        }

        public GenericResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public GenericResponse(bool success, string message, T body)
        {
            Success = success;
            Message = message;
            Body = body;
        }

        public GenericResponse(bool success, T body)
        {
            Success = success;
            Body = body;
        }

        public GenericResponse(bool success, string message, int httpStatusCode)
        {
            Success = success;
            Message = message;
            HttpCode = httpStatusCode;
        }

        public GenericResponse(bool success, int httpStatusCode)
        {
            Success = success;
            HttpCode = httpStatusCode;
        }
        public GenericResponse(bool success, string message, T body, int httpStatusCode)
        {
            Success = success;
            Message = message;
            Body = body;
            HttpCode = httpStatusCode;
        }

        public GenericResponse(bool success, T body, int httpStatusCode)
        {
            Success = success;
            Body = body;
            HttpCode = httpStatusCode;
        }

        public bool Success { get; set; }
        public string Message { get; set; } = String.Empty;
        public T? Body { get; set; }
        public int HttpCode { get; set; } = 418;
    }
}
