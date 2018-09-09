using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace AppMovilPrueba.Data
{
    public class MostrarTabs : TabbedPage
    {
        public MostrarTabs()
        {
            Children.Add(new BuscadorImagenes { Title = "Mostrar Imagen", Icon = "foto.png" });
            Children.Add(new MostrarMapa { Title = "Mostrar Mapa", Icon = "mapa.png" });
        }
    }
}