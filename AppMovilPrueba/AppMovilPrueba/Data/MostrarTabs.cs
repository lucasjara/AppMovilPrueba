using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace AppMovilPrueba.Data
{
    public class MostrarTabs : ContentPage
    {
        public MostrarTabs()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Ventana Prueba Tabs!" }
                }
            };
        }
    }
}