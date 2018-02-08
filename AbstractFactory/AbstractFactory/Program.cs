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
            Weight += 10;
        }
    }

    abstract class Carnivore
    {
        public int Strenght { get; set; }

        public void EatHerbivore(Herbivore animal)
        {
            if (animal.Weight > Strenght)
                Strenght -= 10;
            else
                Strenght += 10;
        }
    }

    class Wildebeest : Herbivore
    {
        public Wildebeest()
        {
            Life = true;
            Weight = 120;
        }
    }

    class Bison : Herbivore
    {
        public Bison()
        {
            Life = true;
            Weight = 300;
        }
    }

    class Leon : Carnivore
    {
        public Leon()
        {
            Strenght = 300;
        }
    }

    class Wolf : Carnivore
    {
        public Wolf()
        {
            Strenght = 150;
        }
    }

    interface IContinent
    {
        Carnivore BuildCarnivore();
        Herbivore BuildHerbivore();
    }

    class Africa : IContinent
    {
        public Carnivore BuildCarnivore()
        {
            return new Leon();
        }

        public Herbivore BuildHerbivore()
        {
            return new Wildebeest();
        }
    }

    class NorthAmerica : IContinent
    {
        public Carnivore BuildCarnivore()
        {
            return new Wolf();
        }

        public Herbivore BuildHerbivore()
        {
            return new Bison();
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
           
        }
    }
}
