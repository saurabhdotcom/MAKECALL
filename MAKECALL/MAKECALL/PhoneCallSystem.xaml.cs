using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MAKECALL
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PhoneCallSystem : ContentPage
    {
        public PhoneCallSystem()
        {
            InitializeComponent();
        }

        private void makeCall_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IMakeCall>().Docall(entryNumber.Text.ToString());
        }
    }
}