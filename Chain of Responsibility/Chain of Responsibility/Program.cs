using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chain_of_Responsibility
{
    abstract class ExceptionHandler
    {
        protected ExceptionHandler nextHandler;
        protected MyException Exception;
        abstract public void ErrorHandling(MyException ex);
        public ExceptionHandler(ExceptionHandler handler = null) { nextHandler = handler; }
    }

    class NormalExceptionHandler : ExceptionHandler
    {
        public NormalExceptionHandler(ExceptionHandler handler) : base(handler) { }
        public override void ErrorHandling(MyException ex)
        {
            
        }
    }

    class CriticalExceptionHandler : ExceptionHandler
    {
        public CriticalExceptionHandler(ExceptionHandler handler) : base(handler) { }
        public override void ErrorHandling(MyException ex)
        {

        }
    }

    enum ExceptionType { Normal, Critical, Fatal }
    class MyException : Exception
    {
        public ExceptionType Type { get; private set; }
        public MyException(string message, ExceptionType type = ExceptionType.Normal) : base(message)
        {
            Type = type;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
