using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MAKECALL.ViewModel;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MAKECALL.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupDetail : PopupPage
    {
        public PopupDetail()
        {
            InitializeComponent();
            BindingContext = new PopupDetailViewModel(Navigation);
        }
        public PopupDetail(Employee objEmp)
        {
            InitializeComponent();
            BindingContext = new PopupDetailViewModel(Navigation, objEmp);
        }
    }
}