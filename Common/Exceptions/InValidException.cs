namespace Common.Exceptions
{
    public class InValidException : CustomException
    {
        private const int ErrorCode = -501;

        public InValidException() : base(ErrorCode, "Invalid matrix, it must not be empty")
        {
            HResult = ErrorCode;
        }

        public InValidException(string message) : base(ErrorCode, message)
        {
            HResult = ErrorCode;
        }
    }
}