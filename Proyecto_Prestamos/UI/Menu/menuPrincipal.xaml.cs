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
using Proyecto_Prestamos.UI.Registros;

namespace Proyecto_Prestamos.UI.Menu
{
    /// <summary>
    /// Interaction logic for menuPrincipal.xaml
    /// </summary>
    public partial class menuPrincipal : Window
    {
        int UsuarioId = 0;
        string UsuarioNombre = string.Empty;
        public menuPrincipal(int usuarioId, string usuarioNombre)
        {
            InitializeComponent();
            UsuarioId = usuarioId;
            UsuarioNombre = usuarioNombre;
            UsuarioTextBlock.Text = "Usuario: " + usuarioNombre;
        }

        //Registros
        private void RegistrarClienteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rClientes rClientes = new rClientes(UsuarioId, UsuarioNombre);
            rClientes.Show();
        }

        private void RegistrarUsuarioMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rUsuarios rUsuarios = new rUsuarios(UsuarioId, UsuarioNombre);
            rUsuarios.Show();
        }
    }
}
