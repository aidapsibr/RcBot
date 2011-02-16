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
        public class Piezo : IDisposable
        {
            PWM pwm;

            public Piezo(FEZ_Pin.PWM pin)
            {
                pwm = new PWM((PWM.Pin)pin);
            }

            public void Dispose()
            {
                pwm.Dispose();
            }

            public void Play(int freq_Hz, int duration_mSec)
            {
                pwm.Set(freq_Hz, 50);
                Thread.Sleep(duration_mSec);
                pwm.Set(freq_Hz, 0);
            }

            public void Play(int[] freqs, int[] durations_mSec)
            {
                if (freqs.Length != durations_mSec.Length)
                    throw new ArgumentException("Arrays must be of the same length.");

                for (int i = 0; i < freqs.Length; i++)
                {
                    Play(freqs[i], durations_mSec[0]);
                }
            }
        }
    }
}