using System;
using System.Collections.Generic;
using System.Text;

namespace Plugin.BleScanner
{
    public class ScanResult : IScanResult
    {
      

        public Guid Uuid { get; }

        public int Rssi { get; }

        public IDevice Device { get; }

        public IBeacon Beacon { get; }

        public ScanResult(Guid uuid, int rssi, IDevice device, IBeacon beacon)
        {
            Uuid = uuid;
            Rssi = rssi;
            Device = device;
            Beacon = beacon;
        }
    }
}
