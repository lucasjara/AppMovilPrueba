﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;

using Xamarin.Forms;

namespace AppMovilPrueba.Data
{
    public class Login : ContentPage
    {
        public Login()
        {
            // Declaración de Elementos
            Padding = new Thickness(0, 20, 0, 0);
            var image = new Image { Source = "img.jpg", Margin = new Thickness(10, 10, 10, 10) };
            Label labelerror = new Label();
            Label lblBienvenida = new Label
            {
                Text = "Bienvenido a AppMovilPrueba Master",
                HorizontalTextAlignment = TextAlignment.Center
            };
            Entry ent_username = new Entry { Placeholder = "Ingrese su Usuario " };
            Entry ent_userpass = new Entry { IsPassword = true, Placeholder = "Ingrese su contraseña" };
            Button cmdIniciarSesion = new Button
            {
                Text = "Iniciar Sesión"
            };
            Button debug = new Button
            {
                Text = "Ir a la siguiente Página"
            };
            ent_username.Focus();
            // Eventos
            ent_username.Completed += (object sender,EventArgs e) =>
            {
                ent_userpass.Focus();
            };
            cmdIniciarSesion.Clicked += async (sender, e) =>
            {
                string username = ent_username.Text;
                string passuser = ent_userpass.Text;

                var respuesta = JArray.Parse(validarAcceso(username, passuser));
                if (respuesta[0].ToString() == "S")
                {
                    await Navigation.PushModalAsync(new PPrincipal());
                }
                else
                {
                    await DisplayAlert("LOGIN", respuesta[1].ToString(), "OK");
                }
            };
            ent_userpass.Completed += (object sender, EventArgs e) =>
            {
                cmdIniciarSesion.Focus();
            };
            Content = new StackLayout
            {
                Children = {
                    lblBienvenida,
                    image,
                     ent_username,
                     ent_userpass,
                     cmdIniciarSesion,
                     labelerror
                }
            };
            // Metodos
            string validarAcceso(string username, string passuser)
            {
                labelerror.Text = "";
                string respuestaString = "";
                try
                {
                    WebClient cliente = new WebClient();
                    Uri uri = new Uri("http://www.infest.cl/api/usuarios/validar_usuario/");
                    NameValueCollection parametros = new NameValueCollection
                    {
                        { "usuario", username },
                        { "password", passuser }
                    };
                    byte[] respuestaByte = cliente.UploadValues(uri, "POST", parametros);
                    respuestaString = Encoding.UTF8.GetString(respuestaByte);
                }
                catch (Exception ex)
                {
                    respuestaString = "[\"N\",\"Error al Enviar la petición.\"]";
                    labelerror.Text = ex.Message;
                }
                return respuestaString;
            }
        }
    }
}