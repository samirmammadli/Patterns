using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    abstract class Herbivore
    {
        public int Weight { get; set; }
        public bool Life { get; set; }

        public void EatGrass()
        {
            if (!Life) return;
            Weight += 10;
            Console.WriteLine($"{this} ate grass.");
        }
    }

    class Wildebeest : Herbivore
    {
        public Wildebeest()
        {
            Life = true;
            Weight = 120;
        }
        public override string ToString()
        {
            return "Wildebeest";
        }
    }

    class Bison : Herbivore
    {
        public Bison()
        {
            Life = true;
            Weight = 300;
        }
        public override string ToString()
        {
            return "Bison";
        }
    }

    class Elk : Herbivore
    {
        public Elk()
        {
            Life = true;
            Weight = 130;
        }
        public override string ToString()
        {
            return "Elk";
        }
    }
}
