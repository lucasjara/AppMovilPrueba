using AppMovilPrueba.Data;
using AppMovilPrueba.Data.Usuarios.Pedido.Tabs;
using AppMovilPrueba.Data.Usuarios.Tabs.Model;
using AppMovilPrueba.Usuarios;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AppMovilPrueba
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var foo = new ProductoViewModel();
            var ped = new PedidoViewModel();
            MainPage = new PaginaMaestra("",foo,ped);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
