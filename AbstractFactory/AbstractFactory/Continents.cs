using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
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

    class Eurasia : IContinent
    {
        public Carnivore BuildCarnivore()
        {
            return new Tiger();
        }

        public Herbivore BuildHerbivore()
        {
            return new Elk();
        }
    }
}
