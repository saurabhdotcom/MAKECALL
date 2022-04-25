using Plugin.Media;
using Plugin.Media.Abstractions;
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
    public partial class TakePictureSystem : ContentPage
    {
        public TakePictureSystem()
        {
            InitializeComponent();
        }
        
        private async void BtnTakePicture_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if(!CrossMedia.Current.IsTakePhotoSupported&& !CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Picture","Photo Capture not supported!","OK");
                return;
            }
            else
            {
                

                var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions()
                {
                    Directory = "pmsl",
                    Name = $"pmsl_{DateTime.Now.ToString("HH_mm_ss")}.jpg",
                    SaveToAlbum=true,
                    PhotoSize =PhotoSize.Medium

                    
                }); 
                if (file == null)
                {
                    return;
                }
                DependencyService.Get<IMessage>().Longtime("FilePath :"+file.Path.ToString());
                ImgPicture.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    return stream;
                });


            }

        }
    }
}