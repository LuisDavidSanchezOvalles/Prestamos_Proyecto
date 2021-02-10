using Proyecto_Prestamos.BLL;
using Proyecto_Prestamos.Entidades;
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

namespace Proyecto_Prestamos.UI.Registros
{
    /// <summary>
    /// Interaction logic for rUsuarios.xaml
    /// </summary>
    public partial class rUsuarios : Window
    {
        Usuarios usuario = new Usuarios();
        int UsuarioId = 0;
        string UsuarioNombre = string.Empty;
        public rUsuarios(int usuarioId, string usuarioNombre)
        {
            InitializeComponent();
            UsuarioId = usuarioId;
            UsuarioNombre = usuarioNombre;
            UsuarioLabel.Content = UsuarioNombre;
            CreacionLabel.ContentStringFormat = "dd/MM/yyyy";
            ModificacionLabel.ContentStringFormat = "dd/MM/yyyy";
            this.DataContext = usuario;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Usuarios AnteriorUsuario = UsuariosBLL.Buscar(usuario.UsuarioId);

            if (AnteriorUsuario.UsuarioId == 0)
            {
                limpiar();
                MessageBox.Show("Usuario No existe");
            }
            else
            {
                usuario = AnteriorUsuario;
                UsuarioLabel.Content = obtenerNombreUsuario(usuario.UsuarioIdCreacion);
                reCargar();
            }    
        }

        private void ConsultarUsuariosButton_Click(object sender, RoutedEventArgs e)
        {
            //cUsuarios cUsuarios = new cUsuarios();
            //cUsuarios.Show();
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            Usuarios respuesta = UsuariosBLL.Buscar(usuario.UsuarioId);
            bool guardo = false;

            if (usuario.UsuarioId == 0)
                usuario.UsuarioIdCreacion = UsuarioId;

            if (usuario.UsuarioId == 0)
            {
                guardo = UsuariosBLL.Guardar(usuario);
            }
            else
            {
                if (UsuariosBLL.Existe(usuario.UsuarioId)==true)
                {
                    if (respuesta.UsuarioId == 0)
                    {
                        limpiar();
                        MessageBox.Show("Cliente no encontrado para guardar en ese Id colocado");
                        return;
                    }
                    else
                    {
                        usuario.FechaModificacion = DateTime.Now;
                        guardo = UsuariosBLL.Modificar(usuario);
                    }
                }
                else
                {
                    MessageBox.Show("No se Pude Modificar un usuario que no Existe");
                    return;
                }    
            }

            if (guardo)
            {
                limpiar();
                MessageBox.Show("Guardado");
            }
            else
            {
                MessageBox.Show("No se pudo guardar");
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsuarioId != usuario.UsuarioId)
            {
                Usuarios AnteriorUsuario = UsuariosBLL.Buscar(usuario.UsuarioId);
                if (AnteriorUsuario.UsuarioId == 0)
                {
                    MessageBox.Show("No se Puede Eliminar un usuario que no existe");
                    return;
                }

                if (UsuariosBLL.Eliminar(usuario.UsuarioId))
                {
                    limpiar();
                    MessageBox.Show("Eliminado Correctamente");
                }
                else
                    MessageBox.Show("No se Puede Eliminar un Usuario que no existe");
            }
            else
                MessageBox.Show("No se puede eliminar a un usuario online");
        }

        private void limpiar()
        {
            usuario = new Usuarios();

            UsuarioLabel.Content = UsuarioNombre;

            reCargar();
        }

        private void reCargar()
        {
            this.DataContext = null;
            this.DataContext = usuario;
        }

        //private bool ExisteEnLaBaseDeDatos()
        //{
        //    Usuarios AnteriorUsuario = UsuariosBLL.Buscar(usuario.UsuarioId);

        //    return (AnteriorUsuario != null);
        //}

        private string obtenerNombreUsuario(int id)
        {
            Usuarios usuarios = UsuariosBLL.Buscar(id);

            return usuarios.NombreUsuario;
        }
    }
}
