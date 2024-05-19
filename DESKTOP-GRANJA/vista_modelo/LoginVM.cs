using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using DESKTOP_GRANJA.apiREST;
using DESKTOP_GRANJA.mensajeria;
using DESKTOP_GRANJA.modelos;
using System;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace DESKTOP_GRANJA.vista_modelo
{
    internal class LoginVM : ObservableObject
    {
        private Usuario usu = new Usuario("admin@mail", "admin");
        public Usuario Usu
        {
            get { return this.usu; }
            set { SetProperty(ref this.usu, value); }
        }
        private AuthService authServ = new AuthService();
        //private string email = "admin@mail";
        /*public string Email
        {
            get { return this.usu.email; }
            set { SetProperty(ref this.email, value); }
        }
        //private string password = "admin";
        public string Password
        {
            get { return this.password; }
            set { SetProperty(ref this.password, value); }
        }*/
        internal async void Aceptar(TextBlock feedbackLogin)
        {
            try
            {
                ApiResponse ar = await this.authServ.LogIn(this.Usu);
                    Trace.WriteLine(ar.Message);
                if (ar.Status == 201)
                {
                    Properties.Settings.Default.Token = ar.Message;

                    WeakReferenceMessenger.Default.Send(new ConfirmaTokenMessage(true));
                }
                else
                {
                    var fadeAnimation = new DoubleAnimation();
                    fadeAnimation.Duration = System.Windows.Duration.Automatic;
                    fadeAnimation.To = 55;

                    //fadeAnimation.AutoReverse = true;

                    feedbackLogin.Text = "Nombre o contraseña equivocados";
                    feedbackLogin.BeginAnimation(TextBlock.OpacityProperty, fadeAnimation);
                    feedbackLogin.BeginAnimation(TextBlock.OpacityProperty, fadeAnimation);
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

                var fadeAnimation = new DoubleAnimation();
                fadeAnimation.Duration = System.Windows.Duration.Automatic;
                fadeAnimation.To = 55;

                var fadeAnimationM = new DoubleAnimation();
                fadeAnimationM.Duration = System.Windows.Duration.Automatic;
                fadeAnimationM.To = 0;
                //fadeAnimation.AutoReverse = true;

                feedbackLogin.Text = "Api desconectada";
                feedbackLogin.BeginAnimation(TextBlock.OpacityProperty, fadeAnimationM);
                //feedbackLogin.BeginAnimation(TextBlock.MarginProperty, fadeAnimation);
            }
        }
    }
}
