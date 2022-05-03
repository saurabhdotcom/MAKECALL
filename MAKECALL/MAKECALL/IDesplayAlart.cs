using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MAKECALL
{
    public interface IDesplayAlart
    {
        Task ShowAsync(string appname,string message);
    }

    public class MessageService : IDesplayAlart
    {
        public async Task ShowAsync(string appname,string message)
        {
            await App.Current.MainPage.DisplayAlert(appname, message, "Ok");
        }
    }
}
