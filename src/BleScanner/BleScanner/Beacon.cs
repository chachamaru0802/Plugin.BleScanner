using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plugin.BleScanner
{
    public class Beacon : IBeacon
    {


        public Guid Uuid { get; private set; }

        public int Major { get; private set; }

        public int Minor { get; private set; }

        public int TxPower { get; private set; }

        public static Beacon ParseBeacon(byte[] scanRecord)
        {
            if (scanRecord == null)
            {
                return null;
            }

            var result = new Beacon();
            var index = 0;

            while (index < scanRecord.Length)
            {
                var len = scanRecord[index++];
                if (len == 0)
                {
                    return null;
                }

                var type = scanRecord[index];
                if (type == 0)
                {
                    return null;
                }




                var data = new byte[len];
                Array.Copy(scanRecord, index + 1, data, 0, len);

                switch ((AdvertisementRecordType)type)
                {
                    case AdvertisementRecordType.ManufacturerSpecificData:

                        if (data.Length != 26)
                        {
                            break;
                        }
                        //var dataType = data[1];
                        //if (dataType !=0xFF)
                        //{
                        //    break;
                        //}


                        var uuidData = new byte[16];
                        Array.Copy(data, 4, uuidData, 0, 16);
                        var uuidValue = BitConverter.ToString(uuidData).Replace("-", "");
                        result.Uuid = new Guid(uuidValue);

                        break;


                }
                index += len;
            }

            return result;
        }
    }
}
