using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace AppMovilPrueba.Data.Usuarios.Pedido
{
    class PedidoTemplate : Grid
    {
        public PedidoTemplate()
        {
            RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.05, GridUnitType.Star) });
            RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.6, GridUnitType.Star) });
            RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.05, GridUnitType.Star) });
            ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.05, GridUnitType.Star) });
            ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.95, GridUnitType.Star) });

            var topBoxView = new BoxView { Color = Color.FromHex("#FF8800") };
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
}