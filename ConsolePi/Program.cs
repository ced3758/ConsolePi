using System;
using System.Threading;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;
using Unosquare.WiringPi;

namespace ConsolePi
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Thread.Sleep(2000);
            Console.WriteLine("Close is possible");

            Pi.Init<BootstrapWiringPi>();

            var pin = Pi.Gpio[P1.Pin19];
            pin.PinMode = GpioPinDriveMode.Input;
            pin.RegisterInterruptCallback(EdgeDetection.RisingEdge, Callback);

            Console.ReadKey();
        }

        private static void Callback()
        {
            Console.WriteLine("toto");
        }
    }
}