using System;

namespace DecoratorPattern
{
    abstract class Character
    {
        public string ClassName { get; protected set; }
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
            Console.WriteLine("------------------------------");
            Console.WriteLine($"Class: {ClassName}");
            Console.WriteLine($"Profession: {this}");
            Console.WriteLine($"Damage: {Damage}");
            Console.WriteLine($"Defence: {Defence}");
            Console.WriteLine($"Speed: {Speed}");
            Console.WriteLine($"Health Power: {HP}");
            Console.WriteLine("------------------------------");
        }
    }
}
