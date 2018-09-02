using Android.Bluetooth;
using Android.Bluetooth.LE;
using Android.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plugin.BleScanner
{
    public class LollipopScanCallback : ScanCallback
    {
        readonly Action<BluetoothDevice, int, ScanRecord> _callback;


        public LollipopScanCallback(Action<BluetoothDevice, int, ScanRecord> callback)
           => _callback = callback;

     

        public override void OnScanResult([GeneratedEnum] ScanCallbackType callbackType, Android.Bluetooth.LE.ScanResult result)
            => _callback(result.Device, result.Rssi, result.ScanRecord);
    }
}
