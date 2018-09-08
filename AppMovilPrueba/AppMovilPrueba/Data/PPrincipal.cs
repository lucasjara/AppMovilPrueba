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
            Padding = new Thickness(5, 5, 5, 5);
            //var image = new Image { Source = "file.jpg", Margin = new Thickness(10, 10, 10, 10) };
            Button cmdModuloImagen = new Button
            {
                Text = "Modulo Imagen",
                Margin = new Thickness()
            };
            Button cmdModuloMapa = new Button
            {
                Text = "Modulo Mapa",
                Margin = new Thickness()
            };
            cmdModuloImagen.Clicked += async (sender, e) =>
            {
                await Navigation.PushModalAsync(new BuscadorImagenes());
            };
            cmdModuloMapa.Clicked += async (sender, e) =>
            {
                
                await Navigation.PushModalAsync(new MostrarMapa());
            };
            Content = new StackLayout
            {
                Children = {
                    //image,
                    cmdModuloImagen,
                    cmdModuloMapa
					//new Label { Text = "Bienvenido a la pagina Principal!" }
				}
            };
        }
    }
}