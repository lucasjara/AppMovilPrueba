using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace AppMovilPrueba.Data
{
    public class MostrarInterfaz : ContentPage
    {
        class PruebaTemplate : Grid
        {
            public PruebaTemplate()
            {
                RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.05, GridUnitType.Star) });
                RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.6, GridUnitType.Star) });
                RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.05, GridUnitType.Star) });
                ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.05, GridUnitType.Star) });
                ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.95, GridUnitType.Star) });

                var topBoxView = new BoxView { Color = Color.Orange };
                Children.Add(topBoxView, 0, 0);
                Grid.SetColumnSpan(topBoxView, 2);

                var topLabel = new Label
                {
                    TextColor = Color.White,
                    VerticalOptions = LayoutOptions.Center
                };
                topLabel.SetBinding(Label.TextProperty, new TemplateBinding("Parent.HeaderText"));
                Children.Add(topLabel, 1, 0);

                var contentPresenter = new ContentPresenter();
                Children.Add(contentPresenter, 0, 1);
                Grid.SetColumnSpan(contentPresenter, 2);


                var bottomLabel = new Label
                {
                    TextColor = Color.White,
                    VerticalOptions = LayoutOptions.Center
                };
                bottomLabel.SetBinding(Label.TextProperty, new TemplateBinding("Parent.FooterText"));
                Children.Add(bottomLabel, 1, 2);
            }
        }
        ControlTemplate pruebatemplate = new ControlTemplate(typeof(PruebaTemplate));
        public static readonly BindableProperty HeaderTextProperty = BindableProperty.Create("HeaderText", typeof(string), typeof(MostrarInterfaz), "FORMATO APP PRUEBA");

        public string HeaderText
        {
            get { return (string)GetValue(HeaderTextProperty); }
        }

        public MostrarInterfaz()
        {
            Button BtnUsuario = new Button
            {
                Image = "formato_usuario.png",
            };
            Button BtnRepartidor = new Button
            {
                Text = "Repartidor",
            };
            Button BtnAdministrativo = new Button
            {
                Text = "Administrativo",
                Margin = new Thickness()
            };
            var contentView = new ContentView
            {
                Content = new StackLayout
                {
                    //VerticalOptions = LayoutOptions.CenterAndExpand,
                    Children = {
                        BtnUsuario,
                        BtnRepartidor,
                        BtnAdministrativo
                    }
                },
                ControlTemplate = pruebatemplate
            };
            Content = contentView;
        }
    }
}