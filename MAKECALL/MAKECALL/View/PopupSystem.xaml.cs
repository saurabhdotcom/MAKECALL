using Android.Content.Res;
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
    public partial class PopupSystem : ContentPage
    {
        public PopupSystem()
        {
            InitializeComponent();
            BindingContext = new PopupSystemViewModel(Navigation);
        }
    }
}