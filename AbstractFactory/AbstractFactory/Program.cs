using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{

    class Program
    {
        static void Main(string[] args)
        {
            var animalWorld = new AnimalWorld();

            animalWorld.Continent = new Africa();
            animalWorld.Addanimals();

            animalWorld.MealsHerbivore();
            animalWorld.NutritionCarnivores();

            Console.WriteLine();

            animalWorld.Continent = new NorthAmerica();
            animalWorld.Addanimals();

            animalWorld.MealsHerbivore();
            animalWorld.NutritionCarnivores();

            Console.WriteLine();

            animalWorld.Continent = new Eurasia();
            animalWorld.Addanimals();

            animalWorld.MealsHerbivore();
            animalWorld.NutritionCarnivores();
        }
    }
}
