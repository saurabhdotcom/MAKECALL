using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MAKECALL.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(MakeCall)) ]
namespace MAKECALL.Droid
{
    public class MakeCall : IMakeCall
    {
        [Obsolete]
        public void Docall(string mobileNumber)
        {
            try
            {
                var Uri = Android.Net.Uri.Parse(string.Format("tel: {0}", mobileNumber));
                var intent = new Intent(Intent.ActionCall, Uri);
                Xamarin.Forms.Forms.Context.StartActivity(intent);
            }
            catch (Exception ex)
            {

              string message = ex.Message;
            }

        }
    }
}