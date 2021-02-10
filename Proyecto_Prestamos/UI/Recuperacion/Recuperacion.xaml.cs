using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Proyecto_Prestamos.Entidades;
using Proyecto_Prestamos.BLL;

namespace Proyecto_Prestamos.UI.Recuperacion
{
    /// <summary>
    /// Interaction logic for Recuperacion.xaml
    /// </summary>
    public partial class Recuperacion : Window
    {
        public Recuperacion()
        {
            InitializeComponent();
            UsuarioTextBlock.Text = "Recuperación";
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            Usuarios usuario = new Usuarios();
            string nombreusuario = UsuarioTextBox.Text;
            string email = EmailTextBox.Text;
            string codigo = CodigoRecuperacionPasswordBox.Password;

            List<Usuarios> usuarioslista = UsuariosBLL.GetList();

            foreach(var item in usuarioslista)
            {
                if (item.NombreUsuario == nombreusuario)
                {
                    usuario = item;
                    break;
                }
                else
                {
                    usuario = null;
                }
            }

            if(usuario != null)
            {
                if(email == usuario.Email && codigo == UsuariosBLL.DesEncriptar(usuario.CodigoRecuperacion))
                {
                    MessageBox.Show("Su contraseña es: "+ UsuariosBLL.DesEncriptar(usuario.Clave));
                }
                else
                {
                    MessageBox.Show("Email o Codigo de recuperación no validos");
                }
            }
            else
            {
                MessageBox.Show("Usuario no Existente");
            }         
        }
    }
}
