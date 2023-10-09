namespace SeatManagement1.GlobalException
{
    public class CustomResponse
    {
        public CustomResponse(int statusCode, string message, string details )
        {
            StatusCode = statusCode;
            Message = message;
            Details = details;
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }
    }
}
