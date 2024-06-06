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
        private AuthService authServ = new AuthService();

        private Usuario usu = new Usuario("admin@mail", "admin");
        public Usuario Usu
        {
            get { return usu; }
            set { SetProperty(ref usu, value); }
        }
        internal async void Aceptar(TextBlock feedbackLogin)
        {
            try
            {
                ApiResponse ar = await authServ.LogIn(Usu);
                //Trace.WriteLine("LoginVM.Aceptar(): ============");
                if (ar.Status == 201)
                {
                    Properties.Settings.Default.Token = ar.Message;

                    GuardaMiPerfil(await authServ.GetMyUser(Properties.Settings.Default.Token, Usu.email));

                    WeakReferenceMessenger.Default.Send(new ConfirmaTokenMessage(true));
                }
                else
                {
                    var fadeAnimation = new DoubleAnimation();
                    fadeAnimation.To = 55;
                    fadeAnimation.Duration = System.Windows.Duration.Automatic;
                    feedbackLogin.Text = "Nombre o contraseña equivocados";
                    feedbackLogin.BeginAnimation(TextBlock.OpacityProperty, fadeAnimation);
                    feedbackLogin.BeginAnimation(TextBlock.OpacityProperty, fadeAnimation);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

                var fadeAnimation = new DoubleAnimation();
                fadeAnimation.Duration = System.Windows.Duration.Automatic;
                fadeAnimation.To = 55;

                var fadeAnimationM = new DoubleAnimation();
                fadeAnimationM.Duration = System.Windows.Duration.Automatic;
                fadeAnimationM.To = 0;

                feedbackLogin.Text = "Api desconectada";
                feedbackLogin.BeginAnimation(TextBlock.OpacityProperty, fadeAnimationM);
            }
        }
        private void GuardaMiPerfil(Empleado? em)
        {
            if (em != null)
            {
                Properties.Settings.Default.MiId = em.Id;
                Properties.Settings.Default.MiNombre = em.Nombre;
                Properties.Settings.Default.MiApellido = em.Apellidos;
                Properties.Settings.Default.MiEmail = em.Email;
                Properties.Settings.Default.MiTelefono = em.Telefono;
                Properties.Settings.Default.MiCentro = em.CentroTrabajo;
                Properties.Settings.Default.MiRol = em.Rol;
            };
        }
    }
}
