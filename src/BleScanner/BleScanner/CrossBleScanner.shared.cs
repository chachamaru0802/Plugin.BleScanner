﻿using System;

namespace Plugin.BleScanner
{
    /// <summary>
    /// Cross BleScanner
    /// </summary>
    public static class CrossBleScanner
    {
        static Lazy<IBleScanner> implementation = new Lazy<IBleScanner>(() => CreateBleScanner(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

        /// <summary>
        /// Gets if the plugin is supported on the current platform.
        /// </summary>
        public static bool IsSupported => implementation.Value == null ? false : true;

        /// <summary>
        /// Current plugin implementation to use
        /// </summary>
        public static IBleScanner Current
        {
            get
            {
                IBleScanner ret = implementation.Value;
                if (ret == null)
                {
                    throw NotImplementedInReferenceAssembly();
                }
                return ret;
            }
        }

        static IBleScanner CreateBleScanner()
        {
#if NETSTANDARD1_0 || NETSTANDARD2_0
            return null;
#else
#pragma warning disable IDE0022 // Use expression body for methods
            return new BleScannerImplementation();
#pragma warning restore IDE0022 // Use expression body for methods
#endif
        }

        internal static Exception NotImplementedInReferenceAssembly() =>
            new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");

    }
}
