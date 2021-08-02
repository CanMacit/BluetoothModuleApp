using BluetoothController.ViewModel;
using Plugin.BluetoothClassic.Abstractions;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace BluetoothController
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SendData : ContentPage
    {
        public SendData()
        {
            InitializeComponent();

            DigitViewModel model = (DigitViewModel)BindingContext;
           

            if (App.CurrentBluetoothConnection != null)
            {
                App.CurrentBluetoothConnection.OnStateChanged += CurrentBluetoothConnection_OnStateChanged;
                App.CurrentBluetoothConnection.OnRecived += CurrentBluetoothConnection_OnRecived;
                App.CurrentBluetoothConnection.OnError += CurrentBluetoothConnection_OnError;
            }



            btnClampOpen.Pressed += delegate
             {
                 try
                 {
                     App.CurrentBluetoothConnection.Transmit(new Memory<byte>(new byte[1] { 49 }));
                 }
                 catch (Exception outPutEX)
                 {

                 }
             };

            btnClampOpen.Released += delegate
             {
                 try
                 {
                     App.CurrentBluetoothConnection.Transmit(new Memory<byte>(new byte[1] { 48 }));
                 }
                 catch (Exception outPutEX)
                 {

                 }
             };



            btnClampClose.Pressed += delegate
            {
                try
                {
                    App.CurrentBluetoothConnection.Transmit(new Memory<byte>(new byte[1] { 50 }));
                }
                catch (Exception outPutEX)
                {

                }
            };

            btnClampClose.Released += delegate
            {
                try
                {
                    App.CurrentBluetoothConnection.Transmit(new Memory<byte>(new byte[1] { 48 }));
                }
                catch (Exception outPutEX)
                {

                }
            };













            btnClampJointUp.Pressed += delegate
            {
                try
                {
                    App.CurrentBluetoothConnection.Transmit(new Memory<byte>(new byte[1] { 51 }));
                }
                catch (Exception outPutEX)
                {

                }
            };

            btnClampJointUp.Released += delegate
            {
                try
                {
                    App.CurrentBluetoothConnection.Transmit(new Memory<byte>(new byte[1] { 48 }));
                }
                catch (Exception outPutEX)
                {

                }
            };



            btnClampJointDown.Pressed += delegate
            {
                try
                {
                    App.CurrentBluetoothConnection.Transmit(new Memory<byte>(new byte[1] { 52 }));
                }
                catch (Exception outPutEX)
                {

                }
            };

            btnClampJointDown.Released += delegate
            {
                try
                {
                    App.CurrentBluetoothConnection.Transmit(new Memory<byte>(new byte[1] { 48 }));
                }
                catch (Exception outPutEX)
                {

                }
            };











            btnElbowJointUp.Pressed += delegate
            {
                try
                {
                    App.CurrentBluetoothConnection.Transmit(new Memory<byte>(new byte[1] { 53 }));
                }
                catch (Exception outPutEX)
                {

                }
            };

            btnElbowJointUp.Released += delegate
            {
                try
                {
                    App.CurrentBluetoothConnection.Transmit(new Memory<byte>(new byte[1] { 48 }));
                }
                catch (Exception outPutEX)
                {

                }
            };



            btnElbowJointDown.Pressed += delegate
            {
                try
                {
                    App.CurrentBluetoothConnection.Transmit(new Memory<byte>(new byte[1] { 54 }));
                }
                catch (Exception outPutEX)
                {

                }
            };

            btnElbowJointDown.Released += delegate
            {
                try
                {
                    App.CurrentBluetoothConnection.Transmit(new Memory<byte>(new byte[1] { 48 }));
                }
                catch (Exception outPutEX)
                {

                }
            };












            btnCraneJointLeft.Pressed += delegate
            {
                try
                {
                    App.CurrentBluetoothConnection.Transmit(new Memory<byte>(new byte[1] { 55 }));
                }
                catch (Exception outPutEX)
                {

                }
            };

            btnCraneJointLeft.Released += delegate
            {
                try
                {
                    App.CurrentBluetoothConnection.Transmit(new Memory<byte>(new byte[1] { 48 }));
                }
                catch (Exception outPutEX)
                {

                }
            };



            btnCraneJointRight.Pressed += delegate
            {
                try
                {
                    App.CurrentBluetoothConnection.Transmit(new Memory<byte>(new byte[1] { 56 }));
                }
                catch (Exception outPutEX)
                {

                }
            };

            btnCraneJointRight.Released += delegate
            {
                try
                {
                    App.CurrentBluetoothConnection.Transmit(new Memory<byte>(new byte[1] { 48 }));
                }
                catch (Exception outPutEX)
                {

                }
            };




        }

        ~SendData()
        {
            if (App.CurrentBluetoothConnection != null)
            {
                App.CurrentBluetoothConnection.OnStateChanged -= CurrentBluetoothConnection_OnStateChanged;
                App.CurrentBluetoothConnection.OnRecived -= CurrentBluetoothConnection_OnRecived;
                App.CurrentBluetoothConnection.OnError -= CurrentBluetoothConnection_OnError;
            }
        }

        private void CurrentBluetoothConnection_OnStateChanged(object sender, StateChangedEventArgs stateChangedEventArgs)
        {
            var model = (DigitViewModel)BindingContext;
            if (model != null)
            {
                model.ConnectionState = stateChangedEventArgs.ConnectionState;
            }
        }

        private void CurrentBluetoothConnection_OnRecived(object sender, Plugin.BluetoothClassic.Abstractions.RecivedEventArgs recivedEventArgs)
        {
            DigitViewModel model = (DigitViewModel)BindingContext;

            if (model != null)
            {
                model.SetReciving();

                for (int index = 0; index < recivedEventArgs.Buffer.Length; index++)
                {
                    byte value = recivedEventArgs.Buffer.ToArray()[index];
                    model.Digit = value;
                }

                model.SetRecived();
            }
        }

       

        private void CurrentBluetoothConnection_OnError(object sender, System.Threading.ThreadExceptionEventArgs errorEventArgs)
        {
            if (errorEventArgs.Exception is BluetoothDataTransferUnitException)
            {
                
            }
        }

      
    }
}