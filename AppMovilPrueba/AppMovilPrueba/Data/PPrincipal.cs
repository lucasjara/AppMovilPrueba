using AppMovilPrueba.Data.Usuarios.Pedido.Tabs;
using AppMovilPrueba.Data.Usuarios.Tabs.Model;
using AppMovilPrueba.Usuarios;
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
                Text = "Seleccionar Imagen",
                Margin = new Thickness()
            };
            Button cmdModuloMapa = new Button
            {
                Text = "Ver Ubicacion",
                Margin = new Thickness()
            };
            Button cmdModuloInterfaz = new Button
            {
                Text = "Selecionar Perfil",
                Margin = new Thickness()
            };
            Button cmdModuloTabs = new Button
            {
                Text = "Selecionar Pestañas",
                Margin = new Thickness()
            };
            Button cmdModuloUsuario = new Button
            {
                Text = "Selecionar Usuario",
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
            cmdModuloInterfaz.Clicked += async (sender, e) =>
            {
                await Navigation.PushModalAsync(new MostrarInterfaz());
            };
            cmdModuloTabs.Clicked += async (sender, e) =>
            {
                await Navigation.PushModalAsync(new MostrarTabs());
            };
            cmdModuloUsuario.Clicked += async (sender, e) =>
            {
                string origen = "asd";
                var foo = new ProductoViewModel();
                var ped = new PedidoViewModel();
                await Navigation.PushModalAsync(new PaginaMaestra(origen,foo,ped));
            };
            Content = new StackLayout
            {
                Children = {
                    //image,
                    cmdModuloImagen,
                    cmdModuloMapa,
                    cmdModuloInterfaz,
                    cmdModuloTabs,
                    cmdModuloUsuario
					//new Label { Text = "Bienvenido a la pagina Principal!" }
				}
            };
        }
    }
}