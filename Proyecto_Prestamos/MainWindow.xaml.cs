using Proyecto_Prestamos.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Proyecto_Prestamos.Entidades;
using Proyecto_Prestamos.UI.Menu;
using Proyecto_Prestamos.UI.Recuperacion;

namespace Proyecto_Prestamos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Usuarios usuario = new Usuarios();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = usuario;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UsuarioTextBox.Text) || string.IsNullOrWhiteSpace(ClavePasswordBox.Password))
            {
                MessageBox.Show("Debe llenar los campos");
                return;
            }

            if (UsuariosBLL.ExisteUsuario(UsuarioTextBox.Text, ClavePasswordBox.Password))
            {
                menuPrincipal menuPrincipal = new menuPrincipal(Convert.ToInt32(UsuariosBLL.ObtenerUsuarioId(UsuarioTextBox.Text, ClavePasswordBox.Password)), UsuarioTextBox.Text);
                menuPrincipal.Show();
                this.Close();
            }
            else
                MessageBox.Show("Usuario no existente");
        }

        private void RecuperarButton_Click(object sender, RoutedEventArgs e)
        {
            Recuperacion r = new Recuperacion();
            r.Show();
        }
    }
}
