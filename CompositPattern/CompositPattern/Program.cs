using System;
using System.IO;
using System.Text;

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
            folder.Add(@"F:\Backup");
            folder.Display(0);
        }
    }
}
