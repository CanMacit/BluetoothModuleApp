using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BluetoothController
{
    using Plugin.BluetoothClassic.Abstractions;
    using Xamarin.Forms;

    public partial class App : Application
    {
        public static IBluetoothManagedConnection CurrentBluetoothConnection { get; internal set; }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new PairedDevices());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}