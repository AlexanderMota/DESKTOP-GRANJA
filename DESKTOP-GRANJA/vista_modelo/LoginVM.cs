using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using DESKTOP_GRANJA.apiREST;
using DESKTOP_GRANJA.mensajeria;
using DESKTOP_GRANJA.modelos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace DESKTOP_GRANJA.vista_modelo
{
    internal class LoginVM : ObservableObject
    {
        private string nombre = "";
        public string Nombre
        {
            get { return this.nombre; }
            set { SetProperty(ref this.nombre, value); }
        }
        private string password = "";
        public string Password
        {
            get { return this.password; }
            set { SetProperty(ref this.password, value); }
        }
        internal async void Aceptar(TextBlock feedbackLogin)
        {
            try
            {
                ApiResponse ar = await new DBApi().Post("auth/signin", new Usuario(Nombre, Password));
                if (ar.Status == 201)
                {
                    Properties.Settings.Default.Token = ar.Message;
                    Trace.WriteLine(Properties.Settings.Default.Token);

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
