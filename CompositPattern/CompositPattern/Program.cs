using System;

namespace CompositPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Component folder = new MyFolder(@"G:\a");
            folder.Add(Environment.CurrentDirectory);
            folder.Display(0);
            Console.WriteLine("\n\n\n");
            folder.Add(@"G:\a");
            folder.Display(0);
        }
    }
}
