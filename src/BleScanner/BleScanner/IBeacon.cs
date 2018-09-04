using System;
using System.Collections.Generic;
using System.Text;

namespace Plugin.BleScanner
{
    public interface IBeacon
    {
        
        Guid Uuid { get; }

        int Major { get; }

        int Minor { get; }

        int TxPower { get; }
    }
}
