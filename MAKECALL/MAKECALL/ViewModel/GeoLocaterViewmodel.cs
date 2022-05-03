
using MAKECALL.Models;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;


namespace MAKECALL.ViewModel
{
    public class GeoLocaterViewmodel : INotifyPropertyChanged
    {
        public INavigation Nevigation { get; set; }
        public GeoLocaterViewmodel(INavigation navigation)
        {
            Nevigation = navigation;
        }
        public LocationModel _loginModel = new LocationModel();

        public event PropertyChangedEventHandler PropertyChanged;

        public LocationModel LocationSetting
        {
            get { return _loginModel; }
            set { _loginModel = value; UpdateProperty("LocationSetting"); }
        }
        public void UpdateProperty(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        [Obsolete]
        public Command GetLocationCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {

                        var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
                        if (status != Plugin.Permissions.Abstractions.PermissionStatus.Granted)
                        {
                            if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
                            {
                                DependencyService.Get<IMessage>().Longtime("Need location Access");
                            }
                            if (status == Plugin.Permissions.Abstractions.PermissionStatus.Granted)
                            {
                                var position = await CrossGeolocator.Current.GetPositionAsync(new TimeSpan(0, 0, 30));
                                LocationSetting = new LocationModel() { Latitude = position.Latitude.ToString(), Longitude = position.Longitude.ToString(), Distence = position.Accuracy.ToString() };

                            }
                            var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
                            status = results[Permission.Location];
                        }
                        else if (status == Plugin.Permissions.Abstractions.PermissionStatus.Granted)
                        {
                            var position = await CrossGeolocator.Current.GetPositionAsync(new TimeSpan(0, 0, 30));
                            LocationSetting = new LocationModel() { Latitude = position.Latitude.ToString(), Longitude = position.Longitude.ToString(), Distence = position.Accuracy.ToString() };

                        }
                        else if (status != Plugin.Permissions.Abstractions.PermissionStatus.Unknown)
                        {
                            DependencyService.Get<IMessage>().Longtime("Location Denied Can not continue, try again.");

                        }
                    }
                    catch (FeatureNotSupportedException fnsEx)
                    {
                        // Handle not supported on device exception
                        await DependencyService.Get<IDesplayAlart>().ShowAsync("Location","device feature not support for fetch location");
                    }
                    catch (FeatureNotEnabledException fneEx)
                    {
                        // Handle not enabled on device exception
                        await DependencyService.Get<IDesplayAlart>().ShowAsync("Location", "device feature not enable for fetch location");
                    }
                    catch (PermissionException pEx)
                    {
                        await DependencyService.Get<IDesplayAlart>().ShowAsync("Location", "permission not provided for fetch location");
                        // Handle permission exception
                    }
                    catch (Exception ex)
                    {
                        // Unable to get location
                        await DependencyService.Get<IDesplayAlart>().ShowAsync("Location", "Opps! Unable to get Location ");
                    }


                });
            }



            //end of class 
        }





    }
}
