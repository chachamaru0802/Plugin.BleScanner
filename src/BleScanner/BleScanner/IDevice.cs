using System;
using System.Collections.Generic;
using System.Text;

namespace Plugin.BleScanner
{
    public interface IDevice
    {
        Guid Id { get; }

        string Name { get; }

        string Address { get; }


    }
}
