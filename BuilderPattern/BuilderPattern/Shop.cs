using System;

namespace BuilderPattern
{
    class Shop
    {
        public ConcreteBuilder CarBuilder { get; set; }

        public void ConstructCar()
        {
            if (CarBuilder == null) return;
            CarBuilder.CreatNewCar();
            CarBuilder.SetCarName();
            CarBuilder.SetCarBodyType();
            CarBuilder.SetCarEngine();
            CarBuilder.SetCarTransmission();
            CarBuilder.SetCarTyres();
        }
        public Car GetCar
        {
            get { return CarBuilder.GetCar() ?? throw new NullReferenceException(); }
        }
    }
}
