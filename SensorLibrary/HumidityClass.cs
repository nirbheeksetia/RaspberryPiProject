using System.Device.Gpio;
using System.Threading;
using System;


namespace SensorLibrary
{
    public class HumidityClass
    {
        private int ledPin;
        private int time;
        public HumidityClass(int ledpin,int timeint) 
        {
            this.ledPin = ledpin;
            this.time = timeint;
        }
        public int ReadData() {
            GpioController test = new GpioController();
            using GpioController controller = new();
            controller.OpenPin(ledPin);
            var returnVal = -1;
            while (true)
            {
                var val = controller.Read(ledPin);
                //Console.WriteLine(val.ToString());
                //Console.WriteLine(((int)val).ToString());
                if (val == 0)
                {
                    Console.WriteLine("High");
                    returnVal = 1;
                }
                else if (val == 1)
                {
                    Console.WriteLine("Low");
                    returnVal = 0;
                }
                else
                {
                    Console.WriteLine("Unvalid");
                }
                Thread.Sleep(time);
                return returnVal;
            }
        }
    }
}
