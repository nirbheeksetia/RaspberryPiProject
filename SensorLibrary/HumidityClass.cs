using System.Device.Gpio;
using System.Threading;
using System;


namespace SensorLibrary
{
    public class HumidityClass
    {
        private int ledPin = 4;
        private int time = 600000;
        public HumidityClass(int ledpin,int timeint) 
        {
            this.ledPin = ledpin;
            this.time = timeint;
        }
        public void ReadData() {
            GpioController test = new GpioController();
            using GpioController controller = new();
            controller.OpenPin(ledPin);
            while (true)
            {
                var val = controller.Read(ledPin);
                Console.WriteLine(val.ToString());
                Thread.Sleep(time);
            }
        }
    }
}
