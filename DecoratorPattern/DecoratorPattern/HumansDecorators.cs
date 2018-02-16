using System;

namespace DecoratorPattern
{
    class WarriorHuman : HumanProfessions
    {
        public WarriorHuman(HUMANS human)
        {
            if (!(human is Human))
                throw new ArgumentException("Only Human can become a Warrior!");
            Human = human;
            _damage = 20;
            _defence = 20;
            _speed = 10;
            _hp = 50;
        }
        public override string ToString()
        {
            return "Warrior";
        }
    }

    class SwordbearerHuman : HumanProfessions
    {
        public SwordbearerHuman(HUMANS human)
        {
            if (!(human is WarriorHuman))
                throw new ArgumentException("Only Warrior can become a Sword-Bearer!");
            Human = human;
            _damage = 40;
            _defence = 40;
            _speed = -10;
            _hp = 50;
        }

        public override string ToString()
        {
            return "Sword-Bearer";
        }
    }

    class ArcherHuman : HumanProfessions
    {
        public ArcherHuman(HUMANS human)
        {
            if (!(human is WarriorHuman))
                throw new ArgumentException("Only Warrior can become an Archer!");
            Human = human;
            _damage = 20;
            _defence = 10;
            _speed = 20;
            _hp = 50;
        }

        public override string ToString()
        {
            return "Archer";
        }
    }

    class KnightHuman : HumanProfessions
    {
        public KnightHuman(HUMANS human)
        {
            if (!(human is SwordbearerHuman))
                throw new ArgumentException("Only Sword-bearer can become a Knight!");
            Human = human;
            _damage = -10;
            _defence = 100;
            _speed = 40;
            _hp = 200;
        }

        public override string ToString()
        {
            return "Knight";
        }
    }
}
