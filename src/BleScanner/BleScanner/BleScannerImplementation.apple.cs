using System;
using System.Collections.Generic;
using System.Text;

namespace Plugin.BleScanner
{
    /// <summary>
    /// Interface for $safeprojectgroupname$
    /// </summary>
    public class BleScannerImplementation : IBleScanner
    {
        

        public IObservable<IScanResult> Scan()
        {
            return null;
        }

        public void StopScan()
        {
        }
    }
}
