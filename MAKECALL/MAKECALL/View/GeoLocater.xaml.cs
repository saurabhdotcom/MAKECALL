using MAKECALL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MAKECALL.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GeoLocater : ContentPage
    {
        public GeoLocater()
        {
            InitializeComponent();
            BindingContext = new GeoLocaterViewmodel(Navigation);
        }
    }
}