using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Connectivity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MAKECALL
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BrowserSystem : ContentPage
    {
        public BrowserSystem()
        {
            InitializeComponent();
        }

        private void browser_Navigating(object sender, WebNavigatingEventArgs e)
        {
            progress.IsRunning = true;
            progress.IsVisible = true;
        }

        public bool Checkconnectivity()
        {
            if (CrossConnectivity.Current.IsConnected == true)
            {
                // DisplayAlert("Message","Internet Connected","OK");
                return true;
            }
            else
            {
                DisplayAlert("Message", "Internet Not Connected", "OK");
                return false;
            }
        }
        private void browser_Navigated(object sender, WebNavigatedEventArgs e)
        {
            progress.IsRunning = false;
            progress.IsVisible = false;
        }

        private void btnBrowse_Clicked(object sender, EventArgs e)
        {
            if (Checkconnectivity())
            {
                string url = "http:\\" + entryUrl.Text;
                browser.Source = url;
            }
        }
    }
}