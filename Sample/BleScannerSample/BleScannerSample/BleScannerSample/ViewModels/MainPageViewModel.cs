using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var result = Plugin.BleScanner.CrossBleScanner.Current.Scan();


            return Task.CompletedTask;
        }
    }
}
