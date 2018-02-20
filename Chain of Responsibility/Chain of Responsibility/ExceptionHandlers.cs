using System;
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
            Console.WriteLine(ex.Message + " - Handled by Normal exception handler");
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
            Console.WriteLine(ex.Message + " - Handled by Critical exception handler");
            if (nextHandler != null) nextHandler.ErrorHandling(ex);
        }
    }

    class FatalExceptionHandler : ExceptionHandler
    {
        public override void ErrorHandling(MyException ex)
        {
            if (ex.Type != ExceptionType.Fatal) return;
            Console.WriteLine(ex.Message + " - Handled by Fatal exception handler");
        }
    }
}
