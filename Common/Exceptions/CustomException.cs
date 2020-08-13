using System;

namespace Common.Exceptions
{
    public abstract class CustomException : Exception
    {
        protected CustomException()
        {
        }

        protected CustomException(int code, string message) : base(message)
        {
            HResult = code;
        }

        protected CustomException(int code, string message, Exception inner) : base(message, inner)
        {
            HResult = code;
        }
    }
}