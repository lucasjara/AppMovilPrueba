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
            
            var image = new Image { Source = "imagen_defecto.jpg", Margin = new Thickness(10, 10, 10, 10) };
            pickPhoto.Clicked += async (sender, args) =>
            {
                try
                {
                    if (!CrossMedia.Current.IsPickPhotoSupported)
                    {
                        await DisplayAlert("Foto No soportada", "No cuenta con permisos para acceder a las fotos", "OK");
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
				}
            };
        }
    }
}