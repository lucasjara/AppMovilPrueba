using AppMovilPrueba.Data.Usuarios.Pedido;
using AppMovilPrueba.Data.Usuarios.Pedido.Tabs;
using AppMovilPrueba.Data.Usuarios.Tabs.Model;
using AppMovilPrueba.Usuarios;
using ImageCircle.Forms.Plugin.Abstractions;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppMovilPrueba.Data.Usuarios.Tabs
{
    public class ListadoOfertas : ContentPage
    {
        public double valor;
        public ObservableCollection<ProductoViewModel> producto { get; set; }
        public String error { get; set; }
        public string respuestaString { get; set; }
        public ListadoOfertas()
        {
            var stack = new StackLayout { Spacing = 0 };
            producto = new ObservableCollection<ProductoViewModel>();
            ListView lstView = new ListView();

            // ID que debemos obtener de la app
            string id = "1";
            Button cmdProductosZona = new Button
            {
                Text = "Obtener Productos Disponibles"
            };
            cmdProductosZona.Clicked += async (sender, e) =>
            {
                var constante = "";
                try
                {
                    var location = await Geolocation.GetLastKnownLocationAsync();
                    var latitude = location.Latitude;
                    var longitud = location.Longitude;
                    var respuesta = JArray.Parse(ObtenerListadoProductosDisponibles(id, latitude, longitud));
                    if (respuesta[0].ToString() == "S")
                    {
                        lstView.RowHeight = 60;
                        lstView.ItemTemplate = new DataTemplate(typeof(FormatoCelda));
                        JArray jsonString = JArray.Parse(respuesta[1].ToString());
                        foreach (JObject item in jsonString)
                        {
                            producto.Add(new ProductoViewModel
                            {
                                Id = item.GetValue("ID_PRODUCTO").ToString(),
                                Nombre = item.GetValue("PRODUCTO").ToString(),
                                Descripcion = item.GetValue("DESCRIPCION").ToString(),
                                Precio = dar_formato(item.GetValue("PRECIO").ToString()),
                                Imagen = "img_defecto_local.png",
                                Local = item.GetValue("LOCAL").ToString(),
                                ImagenProducto = "sin_foto.png",
                            });
                        }
                        lstView.ItemsSource = producto;
                        lstView.ItemTapped += OnTapAsync;
                    }
                    else
                    {
                        lstView.RowHeight = 30;
                        lstView.ItemTemplate = new DataTemplate(typeof(SinFormato));
                        producto.Add(new ProductoViewModel { Nombre = respuesta[1].ToString() });
                        lstView.ItemsSource = producto;
                    }
                    stack.Children.Remove(cmdProductosZona);
                    stack.Children.Add(lstView);
                }
                catch (Exception ex)
                {
                    Label lblerror = new Label
                    {
                        Text = constante.ToString(),
                        HorizontalTextAlignment = TextAlignment.Center
                    };
                    stack.Children.Add(lblerror);
                }
            };
            stack.Children.Add(cmdProductosZona);
            Content = stack;

        }
        async void OnTapAsync(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null) return;

            Task.Delay(500);
            // Deseleccionar Item
            if (sender is ListView lv) lv.SelectedItem = null;

            var foo = e.Item as ProductoViewModel;
            var ped = new PedidoViewModel();
            await Navigation.PushModalAsync(new PaginaMaestra("1",foo,ped));
        }
        public class FormatoCelda : ViewCell
        {
            public FormatoCelda()
            {
                // Instancias de Imagenes
                var imagenproducto = new Image
                {
                    WidthRequest = 300,
                    Aspect = Aspect.AspectFill
                };
                var imagen = new CircleImage
                {
                    BorderColor = Color.Black,
                    BorderThickness = 2,
                    HeightRequest = 60,
                    WidthRequest = 60,
                    Aspect = Aspect.AspectFit,
                    VerticalOptions = LayoutOptions.Start,
                    Margin = 2
                };
                // Instancias de Textos
                var nombre = new Label();
                var descripcion = new Label();
                var precio = new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center };
                var local = new Label ();

                var verticaLayout = new StackLayout();
                var horizontalLayout = new StackLayout();

                nombre.SetBinding(Label.TextProperty, new Binding("Nombre"));
                local.SetBinding(Label.TextProperty, new Binding("Local"));
                precio.SetBinding(Label.TextProperty, new Binding("Precio"));

                imagen.SetBinding(Image.SourceProperty, new Binding("Imagen"));

                horizontalLayout.Orientation = StackOrientation.Horizontal;
                horizontalLayout.HorizontalOptions = LayoutOptions.Fill;

                nombre.FontSize = 20;
                local.FontSize = 20;
                precio.FontSize = 25;

                verticaLayout.Children.Add(nombre);
                verticaLayout.Children.Add(local);

                horizontalLayout.Children.Add(imagen);
                horizontalLayout.Children.Add(verticaLayout);
                horizontalLayout.Children.Add(precio);

                View = horizontalLayout;
            }
        }

        public class SinFormato : ViewCell
        {
            public SinFormato()
            {
                //instantiate each of our views
                var nombre = new Label();
                var verticaLayout = new StackLayout();
                var horizontalLayout = new StackLayout() { };
                nombre.SetBinding(Label.TextProperty, new Binding("Nombre"));
                nombre.FontSize = 20;
                nombre.HorizontalOptions = LayoutOptions.Center;
                verticaLayout.Children.Add(nombre);
                horizontalLayout.Children.Add(verticaLayout);
                View = horizontalLayout;
            }
        }
        // Obtenemos los datos de los locales favoritos

        private string ObtenerListadoProductosDisponibles(string id, double latitud, double longitud)
        {
            string respuestaString = "";
            try
            {
                WebClient cliente = new WebClient();
                Uri uri = new Uri("https://www.infest.cl/servicios/api/usuarios/obtener_oferta_productos");
                NameValueCollection parametros = new NameValueCollection
                    {
                        { "id", id },
                        { "latitud",latitud.ToString()},
                        { "longitud",longitud.ToString()}
                    };
                byte[] respuestaByte = cliente.UploadValues(uri, "POST", parametros);
                respuestaString = Encoding.UTF8.GetString(respuestaByte);
            }
            catch (Exception)
            {
                respuestaString = "[\"N\",\"Error al Enviar la petición.\"]";
            }
            return respuestaString;
        }
        private string dar_formato(string numero)
        {
            int numVal = Int32.Parse(numero);
            return numVal.ToString("C");
        }
    }
}