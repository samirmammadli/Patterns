using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    class Car
    {
        public string Name { get; set; }
        public string BodyType { get; set; }
        public string Engine { get; set; }
        public int Tyres { get; set; }
        public string Transmission { get; set; }
        public override string ToString()
        {
            return $"Car: {Name}\nBody: {BodyType}\nEngine: {Engine}\nTyres: {Tyres}\nTransmisson: {Transmission}";
        }
    }

    abstract class ConcreteBuilder
    {
        protected Car Car { get; set; }
        public void CreatNewCar() { Car = new Car();}
        public Car GetCar() { return Car; }
        public abstract void SetCarName();
        public abstract void SetCarBodyType();
        public abstract void SetCarEngine();
        public abstract void SetCarTyres();
        public abstract void SetCarTransmission();
    }

    class DaewooLanosBuilder : ConcreteBuilder
    {
        public override void SetCarBodyType()
        {
            Car.BodyType = "Sedan";
        }

        public override void SetCarEngine()
        {
            Car.Engine = "98 h.p.";
        }

        public override void SetCarName()
        {
            Car.Name = "Daewoo Lanos";
        }

        public override void SetCarTransmission()
        {
            Car.Transmission = "5 Manual";
        }

        public override void SetCarTyres()
        {
            Car.Tyres = 13;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
