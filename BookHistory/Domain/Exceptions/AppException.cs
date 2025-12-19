namespace BookHistory.Domain.Exceptions
{
    public class AppException(string message, int statusCode) : Exception(message)
    {
        public virtual int StatusCode { get; } = statusCode;
    }
}
