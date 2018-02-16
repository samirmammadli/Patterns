using System;

namespace DecoratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //Human Professions
            HUMANS human = new Human();
            human.PrintCharasteristics();
            Console.WriteLine();

            human = new WarriorHuman(human);
            human.PrintCharasteristics();
            Console.WriteLine();

            human = new SwordbearerHuman(human);
            human.PrintCharasteristics();
            Console.WriteLine();

            human = new KnightHuman(human);
            human.PrintCharasteristics();

            //Elfs Professions

            ELFS elf = new Elf();
            elf.PrintCharasteristics();
            Console.WriteLine();

            elf = new WizardElf(elf);
            elf.PrintCharasteristics();
            Console.WriteLine();

            elf = new DarkWizardElf(elf);
            elf.PrintCharasteristics();
            Console.WriteLine();
        }
    }
}
