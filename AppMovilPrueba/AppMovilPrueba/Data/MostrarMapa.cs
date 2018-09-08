using System;
using Xamarin.Essentials;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace AppMovilPrueba.Data
{
    public class MostrarMapa : ContentPage
    {
        public MostrarMapa()
        {
            var stack = new StackLayout { Spacing = 0 };
            Button cmdObtener = new Button
            {
                Text = "Obtener Ubicacion Actual"
            };
            var map = new Map();
            cmdObtener.Clicked += async (sender, e) =>
            {
                var location = await Geolocation.GetLastKnownLocationAsync();
                var latitud = location.Latitude;
                var longitud = location.Longitude;
                var altitud = location.Altitude;
                map = new Map(
                    MapSpan.FromCenterAndRadius(
                    new Position(latitud, longitud), Distance.FromMiles(0.1)))
                {
                    IsShowingUser = true,
                    HeightRequest = 100,
                    WidthRequest = 960,
                    VerticalOptions = LayoutOptions.FillAndExpand
                };
                stack.Children.Add(map);
            };
            stack.Children.Add(cmdObtener);
            Content = stack;
            /*
            Content = new StackLayout
            {
                Children = {
                    cmdObtener
                }
            };
            */
        }
    }
}