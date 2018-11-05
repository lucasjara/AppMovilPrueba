using AppMovilPrueba.Data;
using AppMovilPrueba.Data.Usuarios;
using AppMovilPrueba.Data.Usuarios.Pedido;
using AppMovilPrueba.Data.Usuarios.Pedido.Tabs;
using AppMovilPrueba.Data.Usuarios.Tabs.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace AppMovilPrueba.Usuarios
{
    public class PaginaMaestra : MasterDetailPage
    {
        MasterPage masterPage;

        public PaginaMaestra(String origen, ProductoViewModel foo,PedidoViewModel ped)
        {
            masterPage = new MasterPage();
            Master = masterPage;
            if (origen == "")
            {
                Detail = new NavigationPage(new TabsUser());
            }
            else if (origen == "1")
            {
                Detail = new NavigationPage(new VistaPrevia(foo));
            }
            else if (origen == "2")
            {
                Detail = new NavigationPage(new Pedido(ped));
            }
            masterPage.ListView.ItemSelected += OnItemSelected;
        }
        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                masterPage.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}