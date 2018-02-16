using System;


namespace FacadePattern
{
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
}