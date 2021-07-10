using System;
using SensorLibrary;
using Microsoft.Azure.Devices.Client;
using System.Text;

namespace HumidityConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            HumidityClass sensor = new HumidityClass(18, 2000);
            while (true)
            {
                var humidityData = sensor.ReadData();
                var connectionString = "[the connection string of your device]";

                using var deviceClient = DeviceClient.CreateFromConnectionString(connectionString);

                //// Set various callback messages: connection status, device twin, a single named method, multiple methods
                //SetVariousCallbackMethods(deviceClient);

                //// open connection explicitly
                deviceClient.OpenAsync().Wait();

                //// Force the retrieval of the devicetwin
                //ForceDeviceTwinRetrieval(deviceClient);

                //// send a single message
                SendSingleMessage(deviceClient,humidityData);

                //// send multiple message in batch in one call
                //SendBatchOfMessages(deviceClient);

                //// Send a file to the Blob storage configured in the IoT Hub
                //SendFileToBlobStorage(deviceClient);

                //// Stall application closing
            }
        }
        private static void SendSingleMessage(DeviceClient deviceClient,int humidity)
        {
            string jsonData = "{ \"humVal\":"+humidity.ToString()+"}";

            var message = new Message(Encoding.ASCII.GetBytes(jsonData));

            message.Properties.Add("messagetype", "normal");

            deviceClient.SendEventAsync(message).Wait();

            Console.WriteLine("A single message is sent");
        }
    }
}
