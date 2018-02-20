using System;
namespace Chain_of_Responsibility
{
    class MyException : Exception
    {
        public ExceptionType Type { get; private set; }
        public MyException(string message, ExceptionType type = ExceptionType.Normal) : base(message)
        {
            Type = type;
        }
    }
}
