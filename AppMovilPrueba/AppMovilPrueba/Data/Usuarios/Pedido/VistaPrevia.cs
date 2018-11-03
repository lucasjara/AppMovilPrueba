using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace AppMovilPrueba.Data.Usuarios.Pedido
{
    public class VistaPrevia : ContentPage
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
        ControlTemplate pruebatemplate = new ControlTemplate(typeof(PruebaTemplate));
        public static readonly BindableProperty HeaderTextProperty = BindableProperty.Create("HeaderText", typeof(string), typeof(MostrarInterfaz), " Vista Previa Pedido Delysoft");

        public string HeaderText
        {
            get { return (string)GetValue(HeaderTextProperty); }
        }

        // Declaracion Elementos Publicos
        Switch switcher = new Switch { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.CenterAndExpand };
        Switch switcher_dos = new Switch { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.CenterAndExpand };

        Label lbl_valor_Total = new Label { FontSize = 20 };
        Label lbl_cantidad_total = new Label { Text = "1" };

        public VistaPrevia(Tabs.Model.ProductoViewModel foo)
        {
            // Elementos Titulo y Imagen
            var stack_uno = new StackLayout { VerticalOptions = LayoutOptions.Center };

            Label lbl_delyvery = new Label { Text = foo.Local + " - " + foo.Nombre, HorizontalTextAlignment = TextAlignment.Center, FontSize = 13, Margin = new Thickness(5) };
            Image imagen = new Image { Source = "sushi.jpg", Margin = new Thickness(10, 0, 10, 10) };
            stack_uno.Children.Add(lbl_delyvery);
            stack_uno.Children.Add(imagen);
            // Elementos Detalle Cantidad - Precio - Total
            var stack_dos = new StackLayout { VerticalOptions = LayoutOptions.End };

            Label lbl_Cantidad = new Label { Text = "Cantidad:", FontSize = 10 };
            Label lbl_Precio = new Label { Text = "Precio Unitario:", FontSize = 10 };
            Label lbl_valor_Precio = new Label { Text = foo.Precio, FontSize = 20 };
            Label lbl_Total = new Label { Text = "Total:", FontSize = 10 };
            lbl_valor_Total.Text = foo.Precio;

            stack_dos.Children.Add(lbl_Cantidad);
            stack_dos.Children.Add(lbl_cantidad_total);
            stack_dos.Children.Add(lbl_Precio);
            stack_dos.Children.Add(lbl_valor_Precio);
            stack_dos.Children.Add(lbl_Total);
            stack_dos.Children.Add(lbl_valor_Total);
            // Elementos Tipo de Pago
            Label lbl_efectivo = new Label { Text = "Efectivo Justo", FontSize = 15, VerticalTextAlignment = TextAlignment.Center };
            Label lbl_sobre = new Label { Text = "SobreEfectivo", FontSize = 15, VerticalTextAlignment = TextAlignment.Center };
            Label lbl_efectivo_detalle = new Label { Text = "(Entregara el monto exacto que aparece en el total)", FontSize = 8, VerticalTextAlignment = TextAlignment.Center };
            Label lbl_sobre_detalle = new Label { Text = "(Entregara un monto superior al que aparece en el Total)", FontSize = 8, VerticalTextAlignment = TextAlignment.Center };
            Entry ent_monto = new Entry { Placeholder = "Ingrese el Monto con el que pagara", Keyboard = Keyboard.Numeric };

            var stack_tres = new StackLayout();
            var stack_tres_uno = new StackLayout { Orientation = StackOrientation.Horizontal };
            var stack_tres_dos = new StackLayout { Orientation = StackOrientation.Horizontal };

            stack_tres_uno.Children.Add(switcher);
            stack_tres_uno.Children.Add(lbl_efectivo);
            stack_tres_uno.Children.Add(lbl_efectivo_detalle);

            stack_tres_dos.Children.Add(switcher_dos);
            stack_tres_dos.Children.Add(lbl_sobre);
            stack_tres_dos.Children.Add(lbl_sobre_detalle);

            switcher.Toggled += switcher_Toggled;
            switcher_dos.Toggled += switcher_Toggled_dos;
            switcher.IsToggled = true;

            stack_tres.Children.Add(stack_tres_uno);
            stack_tres.Children.Add(stack_tres_dos);
            stack_tres.Children.Add(ent_monto);
            // Elementos Final Siguiente / Cancelar
            var stack_cuatro = new StackLayout { Margin = new Thickness(5) };
            Button cmdSiguiente = new Button { Text = "Siguiente", BackgroundColor = Color.FromHex("#FF8800"), TextColor = Color.FromHex("#FFFFFF") };
            Button cmdCancelar = new Button { Text = "Cancelar", BackgroundColor = Color.FromHex("#47525E"), TextColor = Color.FromHex("#FFFFFF") };
            // Eventos Siguiente / Cancelar
            cmdSiguiente.Clicked += async (sender, e) =>
            {
                Boolean flag = false;
                if (switcher.IsToggled) { flag = true; }
                else if (switcher_dos.IsToggled)
                {
                    if (ent_monto.Text != null && Int32.Parse(ent_monto.Text) >= 1)
                    {
                        flag = true;
                    }
                    else
                    {
                        await DisplayAlert("Alerta", "Monto no Valido al Elegir SobreEfectivo", "OK");
                    }
                }
                if (flag) { await DisplayAlert("Alerta", "OK podemos Seguir", "OK"); }// await Navigation.PushModalAsync(new PPrincipal());k
            };
            cmdCancelar.Clicked += async (sender, e) =>
            {
                base.OnBackButtonPressed();
            };
            stack_cuatro.Children.Add(cmdSiguiente);
            stack_cuatro.Children.Add(cmdCancelar);
            //Definicion de Grilla 
            var grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(3, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(3, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            // Agregar Stack uno y dos en Grilla
            grid.Children.Add(stack_uno, 0, 0);
            grid.Children.Add(stack_dos, 1, 0);
            // Agregar Elementos a stack General
            var stack_general = new StackLayout();
            var stack_general_total = new StackLayout { Margin = new Thickness(10, 20, 10, 0), BackgroundColor = Color.White };
            stack_general_total.Children.Add(grid);
            stack_general_total.Children.Add(stack_tres);

            stack_general.Children.Add(stack_general_total);
            stack_general.Children.Add(stack_cuatro);
            var contentView = new ContentView
            {
                Content = stack_general,
                ControlTemplate = pruebatemplate,
                BackgroundColor = Color.FromHex("#E9E9E9")
            };
            Content = contentView;
        }

        void switcher_Toggled(object sender, ToggledEventArgs e)
        {
            if (switcher.IsToggled)
            {
                switcher_dos.IsToggled = false;
            }
        }
        void switcher_Toggled_dos(object sender, ToggledEventArgs e)
        {
            if (switcher_dos.IsToggled)
            {
                switcher.IsToggled = false;
            }
        }
    }
}
