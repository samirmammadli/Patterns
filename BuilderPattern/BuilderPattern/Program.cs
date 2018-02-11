using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var shop = new Shop();
            shop.CarBuilder = new DaewooLanosBuilder();
            shop.ConstructCar();
            Console.WriteLine(shop.GetCar);
            Console.WriteLine();

            shop.CarBuilder = new FordProbeBuilder();
            shop.ConstructCar();
            Console.WriteLine(shop.GetCar);
            Console.WriteLine();

            shop.CarBuilder = new UazPatriotBuilder();
            shop.ConstructCar();
            Console.WriteLine(shop.GetCar);
            Console.WriteLine();

            shop.CarBuilder = new HyndaiGetzBuilder();
            shop.ConstructCar();
            Console.WriteLine(shop.GetCar);
        }
    }
}
