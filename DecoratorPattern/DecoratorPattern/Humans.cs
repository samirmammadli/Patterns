
namespace DecoratorPattern
{
    abstract class Humans : Character
    {
        public Humans()
        {
            ClassName = "Human";
        }
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
}
