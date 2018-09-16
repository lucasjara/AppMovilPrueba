using AppMovilPrueba.Data.Usuarios.Tabs.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;

using Xamarin.Forms;

namespace AppMovilPrueba.Data.Usuarios.Tabs
{
    public class ListadoFavoritos : ContentPage
    {
        public ObservableCollection<LocalViewModel> local { get; set; }
        public ListadoFavoritos()
        {
            local = new ObservableCollection<LocalViewModel>();
            ListView lstView = new ListView();
            lstView.RowHeight = 60;
            string id = 1;
            var respuesta = JArray.Parse(ObtenerListadoLocalesFavoritos(id));
            if (respuesta[0].ToString() == "S")
            {
                lstView.ItemTemplate = new DataTemplate(typeof(FormatoCelda));

                local.Add(new LocalViewModel { Nombre = "LOCAL DE PRUEBAS TEMUCO", Descripcion = "LOCAL DE PRUEBAS SISTEMA", Imagen = "img_defecto_local.png" });
            }
            else
            {
                lstView.ItemTemplate = new DataTemplate(typeof(SinFormato));
                local.Add(new LocalViewModel { Nombre = respuesta[1].ToString() });
            }

            lstView.ItemsSource = local;
            Content = lstView;
        }

        public class FormatoCelda : ViewCell
        {
            public FormatoCelda()
            {
                //instantiate each of our views
                var imagen = new Image();
                var nombre = new Label();
                var descripcion = new Label();
                var verticaLayout = new StackLayout();
                var horizontalLayout = new StackLayout() { };

                nombre.SetBinding(Label.TextProperty, new Binding("Nombre"));
                descripcion.SetBinding(Label.TextProperty, new Binding("Descripcion"));
                imagen.SetBinding(Image.SourceProperty, new Binding("Imagen"));

                imagen.HorizontalOptions = LayoutOptions.Start;
                horizontalLayout.Orientation = StackOrientation.Horizontal;
                horizontalLayout.HorizontalOptions = LayoutOptions.Fill;
                nombre.FontSize = 20;
                descripcion.FontSize = 15;

                verticaLayout.Children.Add(nombre);
                verticaLayout.Children.Add(descripcion);
                horizontalLayout.Children.Add(imagen);
                horizontalLayout.Children.Add(verticaLayout);

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
                nombre.FontSize = 15;
                verticaLayout.Children.Add(nombre);

                View = horizontalLayout;
            }
        }
        // Obtenemos los datos de los locales favoritos
        string ObtenerListadoLocalesFavoritos(string id)
        {
            string respuestaString = "";
            try
            {
                WebClient cliente = new WebClient();
                Uri uri = new Uri("http://www.infest.cl/api/usuarios/obtener_listado_locales_favoritos/");
                NameValueCollection parametros = new NameValueCollection
                    {
                        { "id", id },
                    };
                byte[] respuestaByte = cliente.UploadValues(uri, "POST", parametros);
                respuestaString = Encoding.UTF8.GetString(respuestaByte);
            }
            catch (Exception ex)
            {
                respuestaString = "[\"N\",\"Error al Enviar la petición.\"]";
            }
            return respuestaString;
        }
    }
}