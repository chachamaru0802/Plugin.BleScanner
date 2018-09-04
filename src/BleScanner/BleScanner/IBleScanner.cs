using System;
using System.Collections.Generic;
using System.Text;

namespace Plugin.BleScanner
{
    public interface IBleScanner
    {
        IObservable<IScanResult> Scan();

        void StopScan();

        void OpenSetting();
    }
}
