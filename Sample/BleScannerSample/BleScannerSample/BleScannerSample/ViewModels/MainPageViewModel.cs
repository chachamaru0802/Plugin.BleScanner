using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BleScannerSample.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public DelegateCommand BleScanCommand => new DelegateCommand(async () => await BleScan());

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
        }

        Task BleScan()
        {
            //Plugin.BleScanner.CrossBleScanner.Current.OpenSetting();

            var result = Plugin.BleScanner.CrossBleScanner.Current.Scan().Buffer(TimeSpan.FromSeconds(1)).Subscribe(r =>
            {
                r.ToList().ForEach(x => Debug.WriteLine($"DeviceName:{x.Device.Name}     Rssi:{x.Rssi}   Address:{x.Device.Address}    Beacon:{x.Beacon.Uuid} "));
               
            });
                


            return Task.CompletedTask;
        }
    }
}
