using Android.Bluetooth;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plugin.BleScanner
{
   public class AdapterContext
    {
        readonly BluetoothManager _manager;

        public AdapterContext(BluetoothManager manager)
        {
            _manager = manager;
        }
    }
}
