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
        abstract public void ErrorHandling(MyException ex);
        public ExceptionHandler(ExceptionHandler handler = null) { nextHandler = handler; }
    }

    class NormalExceptionHandler : ExceptionHandler
    {
        public NormalExceptionHandler(ExceptionHandler handler) : base(handler) { }
        public override void ErrorHandling(MyException ex)
        {
            Console.WriteLine("Console message: " + ex.Message);
            if (ex.Type != ExceptionType.Normal && nextHandler != null)
                nextHandler.ErrorHandling(ex);

        }
    }

    class CriticalExceptionHandler : ExceptionHandler
    {
        public CriticalExceptionHandler(ExceptionHandler handler = null) : base(handler) { }
        public override void ErrorHandling(MyException ex)
        {
            if (ex.Type == ExceptionType.Normal) return;
            Console.WriteLine("Write to file: " + ex.Message);
            if(nextHandler != null) nextHandler.ErrorHandling(ex);
        }
    }

    class FatalExceptionHandler : ExceptionHandler
    {
        public override void ErrorHandling(MyException ex)
        {
            if (ex.Type != ExceptionType.Fatal) return;
            Console.WriteLine("Send mail to administrator: " + ex.Message);
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
            var fatal = new FatalExceptionHandler();
            var critical = new CriticalExceptionHandler(fatal);
            var normal = new NormalExceptionHandler(critical);

            normal.ErrorHandling(new MyException("Salam", ExceptionType.Fatal));
        }
    }
}
