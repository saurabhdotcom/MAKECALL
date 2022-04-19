using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace MAKECALL
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BarCodeReadingSystem : ContentPage
    {
        public BarCodeReadingSystem()
        {
            InitializeComponent();
        }

        private async void BtnScan_Clicked(object sender, EventArgs e)
        {
            var scannerPage = new ZXingScannerPage();
            await Navigation.PushAsync(scannerPage);
            scannerPage.OnScanResult += (result) =>
            {
                Device.BeginInvokeOnMainThread(async () => {
                await Navigation.PopAsync();
                    lblBarcode.Text = result.Text;
                });
            };
        }
    }
}