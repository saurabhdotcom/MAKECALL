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

[assembly:Dependency(typeof(Message_Android))]
namespace MAKECALL.Droid
{
    public class Message_Android : IMessage
    {
        public void Longtime(string message)
        {
            Toast.MakeText(Android.App.Application.Context,message,ToastLength.Long).Show();
        }

        public void ShortTime(string message)
        {
            Toast.MakeText(Android.App.Application.Context, message, ToastLength.Short).Show();
        }
    }
}