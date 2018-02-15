using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FacadePattern
{
    class Sensor
    {
        static private Random rnd = new Random();
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
                Console.WriteLine($"{this} temperature check: Temperature is normal.");
            else
                throw new ArgumentException($"{this} Temperature is too High of Low!");
        }
        public void CheckVoltage()
        {
            if (sensor.Check())
                Console.WriteLine($"{this} voltage check: Voltage is normal.");
            else
                throw new ArgumentException($"{this} voltage is incorrect!");
        }
        public void Run()
        {
            Console.WriteLine($"{this} running...");
        }

        public void Stop()
        {
            Console.WriteLine($"{this} stopped.");
        }
    }

    class GraphicCard : Device
    {
        public GraphicCard(int successRate) : base(successRate) { }
        public override string ToString()
        {
            return "Graphic Card";
        }
        public void CheckMonitorConnection()
        {
            if (sensor.Check())
                Console.WriteLine($"{this}: Monitor connected.");
            else
                throw new ArgumentException($"{this}: Monitor not found!");
        }
    }

    class RAM : Device
    {
        public RAM(int successRate) : base(successRate) { }
        public override string ToString()
        {
            return "RAM";
        }

        public void MemoryCheck()
        {
            if (sensor.Check())
                Console.WriteLine($"{this}: Memory check OK.");
            else
                throw new ArgumentException($"{this}: Memory damaged!");
        }
        public void ClearMemory()
        {
            Console.WriteLine($"{this}: Memory Cleared.");
        }
    }

    class HardDrive : Device
    {
        public HardDrive(int successRate) : base(successRate) { }
        public override string ToString()
        {
            return "Hard Drive";
        }
        public void CheckBootLoader()
        {
            if (sensor.Check())
                Console.WriteLine($"{this}: BootLoader OK.");
            else
                throw new ArgumentException($"{this}: Failed start system, BootLoader damaged!");
        }
    }

    class ROM : Device
    {
        public ROM(int successRate) : base(successRate) { }
        public override string ToString()
        {
            return "ROM";
        }
        
    }

    class PowerSupply : Device
    {
        public bool OnOff { get; set; }
        public PowerSupply(int successRate) : base(successRate) { }
        public override string ToString()
        {
            return "Power Supply";
        }
        public void PowerGraphicCard()
        {
            if (OnOff)
                Console.WriteLine("Power Supply: Graphic Card Powered.");
            else
                Console.WriteLine("Power Supply: Graphic Card power stopped.");
        }

        public void PowerRom()
        {
            if (OnOff)
                Console.WriteLine("Power Supply: ROM Powered.");
            else
                Console.WriteLine("Power Supply: ROM power stopped.");
        }

        public void PowerHDD()
        {
            if (OnOff)
                Console.WriteLine("Power Supply: HDD Powered.");
            else
                Console.WriteLine("Power Supply: HDD power stopped.");
        }

        public void PowerRAM()
        {
            if (OnOff)
                Console.WriteLine("Power Supply: RAM Powered.");
            else
                Console.WriteLine("Power Supply: RAM power stopped.");
        }
    }

    class Computer
    {
        public int SuccessRate;
        private bool IsTurnedOn { get; set; }
        private PowerSupply PowerSup { get; set; }
        private GraphicCard Card { get; set; }
        private RAM Ram { get; set; }
        private ROM Rom { get; set; }
        private HardDrive HDD { get; set; }
        public Computer(int successRate)
        {
            IsTurnedOn = false;
            SuccessRate = successRate;
            PowerSup = new PowerSupply(successRate);
            Card = new GraphicCard(successRate);
            Ram = new RAM(successRate);
            Rom = new ROM(successRate);
            HDD = new HardDrive(successRate);
            
        }

        public void PowerOn()
        {
            if (IsTurnedOn)
                throw new ArgumentException("Computer is alrady running!");
            PowerSup.OnOff = true;
            PowerSup.Run();
            CheckAllDevicesVoltage();
            PowerSup.CheckTemperature();
            Card.CheckTemperature();
            PowerSup.PowerGraphicCard();
            Card.Run();
            Card.CheckMonitorConnection();
            Ram.CheckTemperature();
            PowerSup.PowerRAM();
            Ram.Run();
            Ram.MemoryCheck();
            PowerSup.PowerRom();
            Rom.Run();
            PowerSup.PowerHDD();
            HDD.Run();
            HDD.CheckBootLoader();
            CheckAllDevicesTempirature();
            Console.WriteLine("\n[+]SUCCESS[+]  COMPUTER STARTS");
            IsTurnedOn = true;
        }

        public void PowerOff()
        {
            if (!IsTurnedOn)
                throw new ArgumentException("Computer is alrady turned off!");
            PowerSup.OnOff = false;
            HDD.Stop();
            Ram.ClearMemory();
            Card.Stop();
            Rom.Stop();
            PowerSup.PowerGraphicCard();
            PowerSup.PowerRAM();
            PowerSup.PowerRom();
            PowerSup.PowerHDD();
            CheckAllDevicesVoltage();
            PowerSup.Stop();
            Console.WriteLine("\n[+]SUCCESS[+]  COMPUTER OFF");
        }

        private void CheckAllDevicesVoltage()
        {
            try
            {
                PowerSup.CheckVoltage();
                Card.CheckVoltage();
                Ram.CheckVoltage();
                Rom.CheckVoltage();
                HDD.CheckVoltage();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void CheckAllDevicesTempirature()
        {
            try
            {
                PowerSup.CheckTemperature();
                Card.CheckTemperature();
                Ram.CheckTemperature();
                Rom.CheckTemperature();
                HDD.CheckTemperature();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var comp = new Computer(98);
            try
            {
                comp.PowerOn();
            }
            catch (Exception e)
            {

                Console.WriteLine("\n[-]ERROR[-]: "+e.Message); ;
            }
            Console.WriteLine("\n");

            try
            {
                comp.PowerOff();
            }
            catch (Exception e)
            {

                Console.WriteLine("\n[-]ERROR[-]: " + e.Message);
            }

        }
    }
}