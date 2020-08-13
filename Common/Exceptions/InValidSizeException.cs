namespace Common.Exceptions
{
    public class InValidSizeException : CustomException
    {
        private const int ErrorCode = -500;

        public InValidSizeException() : base(ErrorCode, "Invalid matrix, it must be square")
        {
            HResult = ErrorCode;
        }

        public InValidSizeException(string message) : base(ErrorCode, message)
        {
            HResult = ErrorCode;
        }
    }
}