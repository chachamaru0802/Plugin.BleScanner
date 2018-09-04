using System;
using System.Collections.Generic;
using System.Text;

namespace Plugin.BleScanner
{
    public partial class Device : IDevice
    {
     
        public Guid Id { get; }

        public string Name { get; }

        public string Address { get; }

        public Device(Guid id, string name, string address)
        {
            Id = id;
            Name = name;
            Address = address;
        }

    }
}
