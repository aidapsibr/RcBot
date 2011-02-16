/*
Copyright 2010 GHI Electronics LLC
Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at
http://www.apache.org/licenses/LICENSE-2.0
Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License. 
*/

using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using GHIElectronics.NETMF.Hardware;

namespace Rooster
{


    public static partial class Components
    {

        public class DriveState
        {
            public enum Forward : byte
            {
                One = (byte)90
            }

            public enum Reverse : byte
            {
                One = (byte)120
            }

            public const byte Stop = 105;
        }

        public class ESC : GHIElectronics.NETMF.FEZ.Components.ServoMotor
        {
            public ESC(GHIElectronics.NETMF.FEZ.FEZ_Pin.Digital pin)
                : base(pin)
            {
                this.SetPosition((byte)DriveState.Stop);
            }

            public void Drive()
            {
                this.SetPosition((byte)DriveState.Forward.One);
            }

            public void Reverse()
            {
                this.SetPosition((byte)DriveState.Reverse.One);
            }

            public void Stop()
            {
                this.SetPosition((byte)DriveState.Stop);
            }
        }
    }
}