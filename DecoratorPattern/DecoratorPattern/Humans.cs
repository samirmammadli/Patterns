
namespace DecoratorPattern
{
    abstract class HUMANS : Character
    {
        public HUMANS()
        {
            ClassName = "Human";
        }
    }

    class Human : HUMANS
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
