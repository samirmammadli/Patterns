using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FacadePattern
{
    class Sensor
    {
        private Random rnd = new Random();
        private int _succRate;
        public int SuccessRate
        {
            get { return _succRate; }
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentException("Success rate must be between 0 and 100!");
                _succRate = value;
            }
        }
        public Sensor(int successrate)
        {
            SuccessRate = successrate;
        }

        public bool Check() { return SuccessRate >= rnd.Next(0, 101); }
    }

    abstract class Device
    {
        protected Sensor sensor;
        public Device(int successRate)
        {
            sensor = new Sensor(successRate);
        }
        public void CheckTemperature()
        {
            if (sensor.Check())
                Console.WriteLine(this +  " temperature check: Temperature is normal.");
            else
                throw new ArgumentException(this + " Temperature is too High of Low!");
        }
    }

    class GraphicCard : Device
    { 
        public GraphicCard(int successRate) : base(successRate) { }
        public void Run()
        {
            Console.WriteLine("Graphic Card running...");
        }
        public void CheckVoltage()
        {
            if (sensor.Check())
                Console.WriteLine("Graphic Card voltage check: Voltage is normal.");
            else
                throw new ArgumentException("Graphic Card voltage is incorrect!");
        }
        public override string ToString()
        {
            return "Graphic Card";
        }
    }

    class RAM : Device
    {
        public RAM(int successRate) : base(successRate) { }
        public override string ToString()
        {
            return "RAM";
        }
    }

    class HardDrive 
    {

    }

    class ROM 
    {

    }

    class PowerSupply
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
            var card = new GraphicCard(100);
            card.CheckTemperature();

            var ram = new RAM(100);
            ram.CheckTemperature();
        }
    }
}
