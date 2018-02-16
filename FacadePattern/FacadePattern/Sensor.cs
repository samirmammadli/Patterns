using System;


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
}