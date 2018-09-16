using AppMovilPrueba.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace AppMovilPrueba.Usuarios
{
    public class MasterPage : ContentPage
    {
        public ListView ListView { get { return listView; } }
        ListView listView;


        public MasterPage()
        {

            var masterPageItems = new List<MasterPageItem>();
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Inicio",
                IconSource = "menu_100x100.png",
                //TargetType = typeof(MainPageUNAP)
            });

            masterPageItems.Add(new MasterPageItem
            {
                Title = "Notificaciones",
                IconSource = "notificaciones2_100x100.png",
                //TargetType = typeof(PNotificaciones)
            });


            listView = new ListView
            {
                ItemsSource = masterPageItems,
                ItemTemplate = new DataTemplate(() =>
                {
                    var imageCell = new ImageCell();
                    imageCell.SetBinding(TextCell.TextProperty, "Title");
                    imageCell.SetBinding(ImageCell.ImageSourceProperty, "IconSource");
                    return imageCell;
                }),
                VerticalOptions = LayoutOptions.FillAndExpand,
                SeparatorVisibility = SeparatorVisibility.None
            };

            Padding = new Thickness(0, 40, 0, 0);
            Icon = "menu_opciones_24x24.png";
            Title = "Opciones";

            //Botón cerrar sesión
            Button btn_cerrar_sesion = new Button();
            btn_cerrar_sesion.Clicked += Btn_Cerrar_Sesion_Clicked;
            btn_cerrar_sesion.Text = "Cerrar sesión";
            btn_cerrar_sesion.BackgroundColor = Color.Red;
            btn_cerrar_sesion.TextColor = Color.White;

            Content = new StackLayout
            {
                Children =
                {
                    listView,
                    btn_cerrar_sesion
                }
            };
        }
        async void Btn_Cerrar_Sesion_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Cerrar sesión", "Se ha cerrado la sesión", "OK");
            await this.Navigation.PushModalAsync(new Login());
        }
    }
}