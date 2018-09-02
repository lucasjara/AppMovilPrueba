using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace AppMovilPrueba.Data
{
    public class PPrincipal : ContentPage
    {
        public PPrincipal()
        {
            Padding = new Thickness(0, 20, 0, 0);
            //var image = new Image { Source = "file.jpg", Margin = new Thickness(10, 10, 10, 10) };
            Button cmdModuloImagen = new Button
            {
                Text = "Modulo Imagen",
                Margin = new Thickness()
            };
            cmdModuloImagen.Clicked += async (sender, e) =>
            {
                await Navigation.PushModalAsync(new BuscadorImagenes());
            };
            Content = new StackLayout
            {
                Children = {
                    //image,
                    cmdModuloImagen
					//new Label { Text = "Bienvenido a la pagina Principal!" }
				}
            };
        }
    }
}