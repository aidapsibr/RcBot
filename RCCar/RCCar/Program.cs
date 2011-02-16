using System;
using System.Threading;
using System.Diagnostics;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

using GHIElectronics.NETMF.FEZ;

namespace RCCar
{
    public class Program
    {
        public static void Main()
        {

            /// <summary>
            /// Declare the components
            ///</summary>
            OutputPort led = new OutputPort((Cpu.Pin)FEZ_Pin.Digital.LED, false);
            Rooster.Components.ESC Rooster = new Rooster.Components.ESC(FEZ_Pin.Digital.Di10);
            Components.ServoMotor Futaba = new Components.ServoMotor(FEZ_Pin.Digital.Di9);
            Parallax.Components.Ping ForwardPing = new Parallax.Components.Ping((Cpu.Pin)FEZ_Pin.Digital.Di8);

            int ForwardDistance;
            

            // <summary>
            // Read distance values and write to debug
            //</summary>
            while (true)
            {
                ForwardDistance = ForwardPing.GetDistance(Parallax.Components.Ping.DistanceUnits.Inches);
                Debug.Print(ForwardDistance.ToString() + "in");
            }

            ///// <summary>
            ///// Intelligent driving
            /////</summary>
            //while (true)
            //{
            //    //Get Ping Distance (front of car)
            //    ForwardDistance = ForwardPing.GetDistance(Parallax.Components.Ping.DistanceUnits.Inches);
            //    Debug.Print(ForwardDistance.ToString());

            //    //Drive forward while distance is 2ft or more, drive forward and straight with no led
            //    //When closer than 2ft back up and turn, then repeat
            //    if (ForwardDistance >= 24) 
            //    {
            //        led.Write(false);
            //        Futaba.SetPosition(100);
            //        Rooster.Drive();
            //    }
            //    else //Stop car,turn on led, turn wheels to the left, reverse for one second at lowest speed
            //    {
            //        led.Write(true);
            //        Rooster.Stop(); // this doesnt exactly stop, just cuts motor drive, so it may still ram into things
            //        Futaba.SetPosition(80);
            //        Rooster.Reverse();
            //        Thread.Sleep(1000);
            //    }
            //}


            //Run through movement actions 5 times
            //for (int i = 0; i < 5; i++)
            //{
            //    Thread.Sleep(2000);
            //    Rooster.Drive();
            //    Futaba.SetPosition(90);
            //    Thread.Sleep(2000);
            //    Rooster.Stop();
            //    Futaba.SetPosition(105);
            //    Thread.Sleep(2000);
            //    Rooster.Reverse();
            //    Futaba.SetPosition(120);
            //    Thread.Sleep(2000);
            //    Rooster.Stop();
            //    Futaba.SetPosition(105);

            //}

            


            
        }

    }
}
