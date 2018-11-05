using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace AppMovilPrueba.Data.Usuarios.Pedido
{
    public class Pedido : ContentPage
    {
        ControlTemplate pruebatemplate = new ControlTemplate(typeof(PedidoTemplate));
        public static readonly BindableProperty HeaderTextProperty = BindableProperty.Create("HeaderText", typeof(string), typeof(MostrarInterfaz), "Pedido Delysoft");

        public string HeaderText
        {
            get { return (string)GetValue(HeaderTextProperty); }
        }

        public Pedido(Tabs.PedidoViewModel ped)
        {
            // Elementos Titulo y Imagen
            var stack_uno = new StackLayout { VerticalOptions = LayoutOptions.Center };

            Label lbl_delyvery = new Label {
                Text = ped.Local + " - " + ped.NombreProducto,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 13,
                Margin = new Thickness(5)
            };
            Image imagen = new Image { Source = "sushi.jpg", Margin = new Thickness(10, 0, 10, 5) };
            Label lbl_observacion = new Label
            {
                Text = "Direccion: " + ped.Observacion,
                FontSize = 15,
                Margin = new Thickness(5, 0, 0, 0),
                HorizontalOptions = LayoutOptions.Center
            };
            stack_uno.Children.Add(lbl_delyvery);
            stack_uno.Children.Add(imagen);
            stack_uno.Children.Add(lbl_observacion);
            // Elementos Detalle Cantidad - Precio - Total
            var stack_dos = new StackLayout { VerticalOptions = LayoutOptions.End };

            Label lbl_Cantidad = new Label { Text = "Cantidad:", FontSize = 10 };
            Label lbl_Precio = new Label { Text = "Precio Unitario:", FontSize = 10 };
            Label lbl_Total = new Label { Text = "Total:", FontSize = 10 };
            Label lbl_Tipo = new Label { Text = "Tipo de Pago:", FontSize = 10 };
            Label lbl_Estado = new Label { Text = "Estado:", FontSize = 10 };

            Label lbl_cantidad_total = new Label { Text = ped.Cantidad, FontSize = 20 };
            Label lbl_valor_Precio = new Label { Text = formatoPeso(ped.Precio), FontSize = 20 };
            Label lbl_valor_Total = new Label { Text = formatoPeso(ped.Total), FontSize = 20 };
            Label lbl_tipo_txt = new Label { Text = ped.TipoPago, FontSize = 20 };
            Label lbl_estado_txt = new Label { Text = ped.EstadoPedido, FontSize = 20, Margin = new Thickness(0, 0, 0, 17) };

            stack_dos.Children.Add(lbl_Cantidad);
            stack_dos.Children.Add(lbl_cantidad_total);
            stack_dos.Children.Add(lbl_Precio);
            stack_dos.Children.Add(lbl_valor_Precio);
            stack_dos.Children.Add(lbl_Total);
            stack_dos.Children.Add(lbl_valor_Total);
            stack_dos.Children.Add(lbl_Tipo);
            stack_dos.Children.Add(lbl_tipo_txt);
            stack_dos.Children.Add(lbl_Estado);
            stack_dos.Children.Add(lbl_estado_txt);
            // Definición Grilla
            var grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(4, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(3, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            // Agregar Stack uno y dos en Grilla
            grid.Children.Add(stack_uno, 0, 0);
            grid.Children.Add(stack_dos, 1, 0);
            // Stack General
            var stack_general = new StackLayout();
            var stack_general_total = new StackLayout { Margin = new Thickness(10, 20, 10, 0), BackgroundColor = Color.White };
            stack_general_total.Children.Add(grid);
            stack_general.Children.Add(stack_general_total);
            // Contenido Vista
            var contentView = new ContentView
            {
                Content = stack_general,
                //ControlTemplate = pruebatemplate,
                BackgroundColor = Color.FromHex("#E9E9E9")
            };
            Content = contentView;
        }
        private string formatoPeso(string valor)
        {
            int numero = Int32.Parse(valor);
            return numero.ToString("C");
        }
    }
}