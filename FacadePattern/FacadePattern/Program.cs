using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FacadePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var comp = new Computer(98);
            try
            {
                comp.PowerOn();
            }
            catch (Exception e)
            {

                Console.WriteLine("\n[-]ERROR[-]: "+e.Message); ;
            }
            Console.WriteLine("\n");

            try
            {
                comp.PowerOff();
            }
            catch (Exception e)
            {

                Console.WriteLine("\n[-]ERROR[-]: " + e.Message);
            }

        }
    }
}