using AppMovilPrueba.Data.Usuarios.Pedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace AppMovilPrueba.Data
{
    public class MostrarTabsPedido : TabbedPage
    {
        public MostrarTabsPedido(Usuarios.Tabs.Model.ProductoViewModel foo)
        {
            Children.Add(new VistaPrevia(foo) { Title = "Delysoft"});
        }
    }
}