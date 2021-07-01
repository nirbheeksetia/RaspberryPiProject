using System;
using SensorLibrary;

namespace TestSensor
{
    class Program
    {
        static void Main(string[] args)
        {
            HumidityClass test = new HumidityClass(4,600000);
            test.ReadData();
        }
    }
}
