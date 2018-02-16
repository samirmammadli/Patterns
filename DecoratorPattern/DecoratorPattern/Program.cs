using System;

namespace DecoratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //Human Professions
            Humans chel = new Human();
            chel.PrintCharasteristics();
            Console.WriteLine();

            chel = new WarriorHuman(chel);
            chel.PrintCharasteristics();
            Console.WriteLine();

            chel = new SwordbearerHuman(chel);
            chel.PrintCharasteristics();
            Console.WriteLine();

            chel = new KnightHuman(chel);
            chel.PrintCharasteristics();

            //Elfs Professions

            Elfs elf = new Elf();
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
