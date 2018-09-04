using System;
using System.Collections.Generic;
using System.Text;

namespace Plugin.BleScanner
{
    public interface IScanResult
    {
        IDevice Device { get; }

        int Rssi { get; }


        IBeacon Beacon { get; }

    }
}
