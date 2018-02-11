using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    abstract class Carnivore
    {
        public int Strenght { get; set; }

        public void EatHerbivore(Herbivore animal)
        {
            if (!animal.Life) return;
            if (animal.Weight > Strenght)
                Strenght -= 10;
            else
                Strenght += 10;
            animal.Life = false;
            Console.WriteLine($"{this} ate {animal}.");
        }
    }


    class Leon : Carnivore
    {
        public Leon()
        {
            Strenght = 300;
        }
        public override string ToString()
        {
            return "Leon";
        }
    }

    class Wolf : Carnivore
    {
        public Wolf()
        {
            Strenght = 150;
        }
        public override string ToString()
        {
            return "Wolf";
        }
    }


    class Tiger : Carnivore
    {
        public Tiger()
        {
            Strenght = 250;
        }
        public override string ToString()
        {
            return "Tiger";
        }
    }
}
