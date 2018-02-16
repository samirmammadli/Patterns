using System;


namespace FacadePattern
{
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
}