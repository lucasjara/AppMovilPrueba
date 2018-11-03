using AppMovilPrueba.Data.Usuarios.Tabs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace AppMovilPrueba.Data.Usuarios
{
	public class TabsUser : TabbedPage
    {
		public TabsUser ()
		{
            var c = Color.FromHex("#3C454F");
            this.BarBackgroundColor = c;
            Children.Add(new ListadoOfertas() { Title = "Ofertas de Hoy"});
            Children.Add(new ListadoFavoritos { Title = "Locales Favoritos"});
            Children.Add(new MostrarMapa { Title = "Busca más"});
        }
	}
}