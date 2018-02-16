using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    class WarriorElf : ElfsProfessions
    {
        public WarriorElf(ELFS elf)
        {
            if (!(elf is Elf))
                throw new ArgumentException("Only Elf can become a Warrior!");
            Elf = elf;
            _damage = 20;
            _defence = 20;
            _speed = -10;
            _hp = 100;
        }
        public override string ToString()
        {
            return "Warrior";
        }
    }

    class WizardElf : ElfsProfessions
    {
        public WizardElf(ELFS elf)
        {
            if (!(elf is Elf))
                throw new ArgumentException("Only Elf can become a Wizard!");
            Elf = elf;
            _damage = 10;
            _defence = 10;
            _speed = 10;
            _hp = -50;
        }
        public override string ToString()
        {
            return "Wizard";
        }
    }

    class ArbalesterElf : ElfsProfessions
    {
        public ArbalesterElf(ELFS elf)
        {
            if (!(elf is WarriorElf))
                throw new ArgumentException("Only Warrior can become an Arbalester!");
            Elf = elf;
            _damage = 20;
            _defence = -10;
            _speed = 10;
            _hp = 50;
        }
        public override string ToString()
        {
            return "Arbalester";
        }
    }

    class DarkWizardElf : ElfsProfessions
    {
        public DarkWizardElf(ELFS elf)
        {
            if (!(elf is WizardElf))
                throw new ArgumentException("Only Wizard can become a Dark Wizard!");
            Elf = elf;
            _damage = 70;
            _defence = 0;
            _speed = 20;
            _hp = 0;
        }
        public override string ToString()
        {
            return "Dark Wizard";
        }
    }

    class WhiteWizardElf : ElfsProfessions
    {
        public WhiteWizardElf(ELFS elf)
        {
            if (!(elf is WizardElf))
                throw new ArgumentException("Only Wizard can become a White Wizard!");
            Elf = elf;
            _damage = 50;
            _defence = 30;
            _speed = 30;
            _hp = 100;
        }
        public override string ToString()
        {
            return "White Wizard";
        }
    }
}
