using AppMovilPrueba.Data;
using AppMovilPrueba.Data.Usuarios;
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

        public PaginaMaestra(String origen)
        {
            masterPage = new MasterPage();
            Master = masterPage;
            Detail = new NavigationPage(new TabsUser());
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