
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MAKECALL
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void BtnCall_Clicked(object sender, EventArgs e)
        {
          await  Navigation.PushAsync(new PhoneCallSystem());
        }

        private async void BtnBrowser_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BrowserSystem());

        }

        private async void BtnBarcodeReading_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BarCodeReadingSystem());
        }

        private async void BtnTakePicture_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TakePictureSystem());
        }
    }
}
