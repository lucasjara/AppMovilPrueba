using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppMovilPrueba.Data
{
    public class BuscadorImagenes : ContentPage
    {
        public BuscadorImagenes()
        {
            
            
            Label lbl_error = new Label();
            Button pickPhoto = new Button
            {
                Text = "Buscar Imagen",
                Margin = new Thickness()
            };
            
            var image = new Image { Source = "file.jpg", Margin = new Thickness(10, 10, 10, 10) };
            pickPhoto.Clicked += async (sender, args) =>
            {
                try
                {
                    if (!CrossMedia.Current.IsPickPhotoSupported)
                    {
                        //DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                        await DisplayAlert("FOTO", "Foto no soportada", "OK");
                        return;
                    }
                        var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                    {
                        PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                    });


                    if (file == null)
                        return;

                    image.Source = ImageSource.FromStream(() =>
                    {
                        var stream = file.GetStream();
                        file.Dispose();
                        return stream;
                    });
                    image.HeightRequest = 500;
                }
                catch (Exception ex) {
                    lbl_error.Text = ex.Message;
                }
            };
            
            Content = new StackLayout
            {
                Children = {
                    pickPhoto,
                    image,
                    lbl_error
					//new Label { Text = "Welcome to Xamarin.Forms!" }
				}
            };
        }
        private async Task Init()
        {
            await RequestLocationPermission();
        }
        private async Task RequestLocationPermission()
        {
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
                    {
                        await DisplayAlert("Need location", "Gunna need that location", "OK");
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Location });
                    status = results[Permission.Location];
                }

                if (status == PermissionStatus.Granted)
                {
                }
                else if (status != PermissionStatus.Unknown)
                {
                    await DisplayAlert("Location Denied", "Can not continue, try again.", "OK");
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}