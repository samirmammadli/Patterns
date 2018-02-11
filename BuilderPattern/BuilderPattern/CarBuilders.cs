using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    abstract class ConcreteBuilder
    {
        protected Car Car { get; set; }
        public void CreatNewCar() { Car = new Car(); }
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

    class FordProbeBuilder : ConcreteBuilder
    {
        public override void SetCarBodyType()
        {
            Car.BodyType = "Coupe";
        }

        public override void SetCarEngine()
        {
            Car.Engine = "160 h.p.";
        }

        public override void SetCarName()
        {
            Car.Name = "Ford Probe";
        }

        public override void SetCarTransmission()
        {
            Car.Transmission = "4 Auto";
        }

        public override void SetCarTyres()
        {
            Car.Tyres = 14;
        }
    }

    class UazPatriotBuilder : ConcreteBuilder
    {
        public override void SetCarBodyType()
        {
            Car.BodyType = "Universal";
        }

        public override void SetCarEngine()
        {
            Car.Engine = "120 h.p.";
        }

        public override void SetCarName()
        {
            Car.Name = "Uaz Patriot";
        }

        public override void SetCarTransmission()
        {
            Car.Transmission = "4 Manual";
        }

        public override void SetCarTyres()
        {
            Car.Tyres = 16;
        }
    }

    class HyndaiGetzBuilder : ConcreteBuilder
    {
        public override void SetCarBodyType()
        {
            Car.BodyType = "Hatchback";
        }

        public override void SetCarEngine()
        {
            Car.Engine = "110 h.p.";
        }

        public override void SetCarName()
        {
            Car.Name = "Hyndai Getz";
        }

        public override void SetCarTransmission()
        {
            Car.Transmission = "4 auto";
        }

        public override void SetCarTyres()
        {
            Car.Tyres = 17;
        }
    }
}
