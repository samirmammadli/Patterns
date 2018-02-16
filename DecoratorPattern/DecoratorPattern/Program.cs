using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    abstract class Character
    {
        protected int _damage { get; set; }
        protected int _defence { get; set; }
        protected int _speed { get; set; }
        protected int _hp { get; set; }

        virtual public int Damage { get => _damage; protected set => _damage = value; }
        virtual public int Defence { get => _defence; protected set => _defence = value; }
        virtual public int Speed { get => _speed; protected set => _speed = value; }
        virtual public int HP { get => _hp; protected set => _hp = value; }

        public void PrintCharasteristics()
        {
            Console.WriteLine($"Profession: {this}");
            Console.WriteLine($"Damage: {Damage}");
            Console.WriteLine($"Defence: {Defence}");
            Console.WriteLine($"Speed: {Speed}");
            Console.WriteLine($"Health Power: {HP}");
        }
    }

    abstract class Humans : Character
    {

    }

    abstract class Elfs : Character
    {

    }

    abstract class HumanProfessions : Humans
    {
        public Humans Human { get; protected set; }
        public override int Damage { get => Human.Damage + _damage; protected set => _damage = value; }
        public override int Defence { get => Human.Defence + _defence; protected set => _defence = value; }
        public override int Speed { get => Human.Speed + _speed; protected set => _speed = value; }
        public override int HP { get => Human.HP + _hp; protected set => _hp = value; }
    }

    class Human : Humans
    {
        public Human()
        {
            _damage = 20;
            _defence = 0;
            _speed = 20;
            _hp = 150;
        }
        public override string ToString()
        {
            return "No profession";
        }
    }

    class Warrior : HumanProfessions
    {
        public Warrior(Humans human)
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

    class Swordbearer : HumanProfessions
    {
        public Swordbearer(Humans human)
        {
            if (!(human is Warrior))
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

    class Archer : HumanProfessions
    {
        public Archer(Humans human)
        {
            if (!(human is Warrior))
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

    class Knight : HumanProfessions
    {
        public Knight(Humans human)
        {
            if (!(human is Swordbearer))
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

    class Program
    {
        static void Main(string[] args)
        {
            Humans chel = new Human();
            chel = new Warrior(chel);
            chel = new Swordbearer(chel);

            chel.PrintCharasteristics();
            Console.WriteLine();

            chel = new Knight(chel);
            chel.PrintCharasteristics();
        }
    }
}
