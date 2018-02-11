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
}
