using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    abstract class Elfs : Character
    {
        public Elfs()
        {
            ClassName = "Elf";
        }
    }

    class Elf : Elfs
    {
        public Elf()
        {
            _damage = 15;
            _defence = 0;
            _speed = 30;
            _hp = 100;
        }
        public override string ToString()
        {
            return "No profession";
        }
    }
}
