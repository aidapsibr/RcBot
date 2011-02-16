/*
Copyright 2010 GHI Electronics LLC
Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at
http://www.apache.org/licenses/LICENSE-2.0
Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License. 
*/

using System;
using System.Threading;
using GHIElectronics.NETMF.Hardware;
using GHIElectronics.NETMF.FEZ;

namespace GHIElectronics.NETMF.FEZ
{
    public static partial class Components
    {
        public class Servo : IDisposable
        {
            PWM pwm;

            public Servo(FEZ_Pin.PWM pin)
            {
                pwm = new PWM((PWM.Pin)pin);
            }

            public void Dispose()
            {
                pwm.Dispose();
            }

            //Range of power 0 being off 30 being maximum power
            public void Power(int hertz=1000, byte DutyLoad = 30)
            {
                pwm.Set(hertz, DutyLoad);
            }
        }
    }
}