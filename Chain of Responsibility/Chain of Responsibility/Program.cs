using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chain_of_Responsibility
{
    enum ExceptionType { Normal, Critical, Fatal }
    class Program
    {
        static void Main(string[] args)
        {
            var fatal = new FatalExceptionHandler();
            var critical = new CriticalExceptionHandler(fatal);
            var normal = new NormalExceptionHandler(critical);

            normal.ErrorHandling(new MyException("Fatal Error", ExceptionType.Fatal));

            Console.WriteLine("\n");

            normal.ErrorHandling(new MyException("Critical Error", ExceptionType.Critical));

            Console.WriteLine("\n");

            normal.ErrorHandling(new MyException("Normal Error", ExceptionType.Normal));
        }
    }
}
