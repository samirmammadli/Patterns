using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{

    interface IComputerReport
    {
        void GetHardwareInfo();
    }

    class VideoCardInfo : IComputerReport
    {
        public void GetHardwareInfo()
        {
            Console.WriteLine("Graphic Card: GeForce GTX 1080");
        }
    }

    class ProcessorInfo : IComputerReport
    {
        public void GetHardwareInfo()
        {
            Console.WriteLine("Processor: Intel i7 7700HQ");
        }
    }

    class HardDiskInfo : IComputerReport
    {
        public void GetHardwareInfo()
        {
            Console.WriteLine("Internal memory: Seagate 2TB");
        }
    }

    class RamInfo : IComputerReport
    {
        public void GetHardwareInfo()
        {
            Console.WriteLine("RAM: 16GB Kingston");
        }
    }


    class PcReporter
    {
        public IComputerReport Hardware { get; set; }

        public void GetHardwareInfo()
        {
            Hardware.GetHardwareInfo();
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            var reporter = new PcReporter();
            reporter.Hardware = new HardDiskInfo();
            reporter.GetHardwareInfo();
            reporter.Hardware = new ProcessorInfo();
            reporter.GetHardwareInfo();
            reporter.Hardware = new VideoCardInfo();
            reporter.GetHardwareInfo();
            reporter.Hardware = new RamInfo();
            reporter.GetHardwareInfo();
        }
    }
}
