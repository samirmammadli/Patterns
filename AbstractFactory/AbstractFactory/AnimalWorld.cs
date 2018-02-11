using System.Collections.Generic;

namespace AbstractFactory
{
    class AnimalWorld
    {
        public IContinent Continent { get; set; }
        public List<Carnivore> Carnivores { get; set; }
        public List<Herbivore> Herbivores { get; set; }

        public AnimalWorld()
        {
            Carnivores = new List<Carnivore>();
            Herbivores = new List<Herbivore>();
            Continent = null;
        }
        public void Addanimals()
        {
            Carnivores.Add(Continent?.BuildCarnivore());
            Herbivores.Add(Continent?.BuildHerbivore());
        }

        public void MealsHerbivore()
        {
            foreach (var animal in Herbivores)
            {
                animal.EatGrass();
            }
        }

        public void NutritionCarnivores()
        {
            foreach (var animal in Carnivores)
            {
                foreach (var herbivore in Herbivores)
                {
                    animal.EatHerbivore(herbivore);
                }
            }
        }
    }
}
