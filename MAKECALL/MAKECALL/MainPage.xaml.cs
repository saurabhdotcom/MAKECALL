
using MAKECALL.View;
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
        //saurabh1.0
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

        private async void BtnSqlLite_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SqlLiteSystem());
        }

        private async void BtnPopup_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PopupSystem());
        }
    }
}
