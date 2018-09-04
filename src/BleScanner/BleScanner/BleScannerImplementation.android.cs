using Android.App;
using Android.Bluetooth;
using Android.Bluetooth.LE;
using Android.Content;
using Android.OS;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Text;
using ScanMode = Android.Bluetooth.LE.ScanMode;

namespace Plugin.BleScanner
{
    /// <summary>
    /// Interface for $safeprojectgroupname$
    /// </summary>
    public class BleScannerImplementation : IBleScanner
    {

        public static bool AndroidUseNewScanner => Android.OS.Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop;

        readonly BluetoothManager _manager;

        LollipopScanCallback _callback;

        public BleScannerImplementation()
        {
            _manager = (BluetoothManager)Application.Context.GetSystemService(Application.BluetoothService);
        }

        public IObservable<IScanResult> Scan()
        {
            return Observable.Create<ScanResult>(ob =>
            {
                _callback = new LollipopScanCallback((native, rssi, sr) =>
                {
                    var scanResult = ToScanResult(native, rssi, sr);
                    ob.OnNext(scanResult);
                });

                var builder = new ScanSettings.Builder();
                builder.SetScanMode(ScanMode.Balanced);

                var scanFilters = new List<ScanFilter>();


                _manager.Adapter.BluetoothLeScanner.StartScan(
                    scanFilters,
                    builder.Build(),
                    _callback);


                return () => _manager.Adapter.BluetoothLeScanner?.StopScan(_callback);
            })
            .Finally(() =>
            {
            });


        }

        public void StopScan()
        {
            _manager.Adapter.BluetoothLeScanner?.StopScan(_callback);
        }

        protected ScanResult ToScanResult(BluetoothDevice native, int rssi, ScanRecord scanRecord)
        {

            if (scanRecord?.DeviceName == "FSC_BP103")
            {

            }
            
            var beacon = Beacon.ParseBeacon(scanRecord?.GetBytes());
            var device = Device.GetDeviceInfo(native);
            //var dev = this.Devices.GetDevice(native);
            //var result = new ScanResult(dev, rssi, ad);

            var result = new ScanResult(Guid.Empty, rssi, device, beacon);
            return result;
        }

        public void OpenSetting()
        {
            var intent = new Intent(Android.Provider.Settings.ActionBluetoothSettings);
            intent.SetFlags(ActivityFlags.NewTask);
            Application.Context.StartActivity(intent);
        }
    }
}
