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

        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Body { get; set; }
    }
}
