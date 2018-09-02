using Android.App;
using Android.Bluetooth;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Text;

namespace Plugin.BleScanner
{
    /// <summary>
    /// Interface for $safeprojectgroupname$
    /// </summary>
    public class BleScannerImplementation : IBleScanner
    {

        readonly BluetoothManager _manager;

        public BleScannerImplementation()
        {
            _manager = (BluetoothManager)Application.Context.GetSystemService(Application.BluetoothService);
        }

        public IObservable<IScanResult> Scan()
        {
            return Observable.Create<ScanResult>(ob =>
            {
                var callback = new LollipopScanCallback((native, rssi, sr) =>
                {
                    var scanResult = ToScanResult(native, rssi);
                    ob.OnNext(scanResult);
                });

                _manager.Adapter.BluetoothLeScanner.StartScan(null,new Android.Bluetooth.LE.ScanSettings.Builder().SetScanMode(Android.Bluetooth.LE.ScanMode.Balanced).Build(), callback);

                return () => _manager.Adapter.BluetoothLeScanner?.StopScan(callback);
            });

            
        }

        public void StopScan()
        {
            
        }

        protected ScanResult ToScanResult(BluetoothDevice native, int rssi)
        {
            //var dev = this.Devices.GetDevice(native);
            //var result = new ScanResult(dev, rssi, ad);

            var result = new ScanResult();
            return result;
        }

    }
}
