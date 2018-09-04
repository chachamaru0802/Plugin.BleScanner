using Android.Bluetooth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plugin.BleScanner
{
    public partial class Device
    {
        public static Device GetDeviceInfo(BluetoothDevice native)
        {
            var address = native.Address;
            var deviceId = ParseDeviceId(address);
            return new Device(deviceId, native.Name, address);
        }

        static Guid ParseDeviceId(string address)
        {
            var deviceGuid = new byte[16];
            var macWithoutColons = address.Replace(":", "");
            var macBytes = Enumerable.Range(0, macWithoutColons.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(macWithoutColons.Substring(x, 2), 16))
                .ToArray();
            macBytes.CopyTo(deviceGuid, 10);
            return new Guid(deviceGuid);
        }
    }
}
