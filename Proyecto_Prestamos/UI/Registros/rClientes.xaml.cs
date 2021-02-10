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

namespace Proyecto_Prestamos.UI.Registros
{
    /// <summary>
    /// Interaction logic for rClientes.xaml
    /// </summary>
    public partial class rClientes : Window
    {
        Clientes cliente = new Clientes();
        int UsuarioId = 0;
        string UsuarioNombre = string.Empty;
        public rClientes(int usuarioId, string usuarioNombre)
        {
            InitializeComponent();
            UsuarioId = usuarioId;
            UsuarioNombre = usuarioNombre;
            UsuarioLabel.Content = UsuarioNombre;
            CreacionLabel.ContentStringFormat = "dd/MM/yyyy";
            ModificacionLabel.ContentStringFormat = "dd/MM/yyyy";
            FechaDatePicker.SelectedDate = DateTime.Now;
            this.DataContext = cliente;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Clientes respuesta = ClientesBLL.Buscar(cliente.ClienteId);

            if (respuesta.ClienteId == 0)
            {
                limpiar();
                MessageBox.Show("Cliente no encontrado");
            }
            else
            {
                cliente = respuesta;
                UsuarioLabel.Content = obtenerNombreUsuario(cliente.ClienteId);
                reCargar();
            }
        }

        private void ConsultarClientesButton_Click(object sender, RoutedEventArgs e)
        {
            //cClientes cClientes = new cClientes();
            //cClientes.Show();
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            Clientes respuesta = ClientesBLL.Buscar(cliente.ClienteId);
            bool guardo;

            if (cliente.ClienteId == 0)
                cliente.UsuarioId = UsuarioId;

            cliente.FechaModificacion = DateTime.Now;

            if(cliente.ClienteId == 0)
            {
                if (cliente.Retrazos == 0)
                    cliente.Estado = "Excelente";
                else if (cliente.Retrazos == 1)
                    cliente.Estado = "Bueno";
                else if (cliente.Retrazos == 2)
                    cliente.Estado = "Regular";
                else if (cliente.Retrazos > 2)
                    cliente.Estado = "Malo";

                guardo = ClientesBLL.Insertar(cliente);
            }
            else
            {
                if(ClientesBLL.Existe(cliente.ClienteId)==true)
                {
                    if (respuesta.ClienteId == 0)
                    {
                        limpiar();
                        MessageBox.Show("Cliente no encontrado para guardar en ese Id colocado");
                        return;
                    }
                    else
                    {
                        cliente.FechaModificacion = DateTime.Now;

                        if (cliente.Retrazos == 0)
                            cliente.Estado = "Excelente";
                        else if (cliente.Retrazos == 1)
                            cliente.Estado = "Bueno";
                        else if (cliente.Retrazos == 2)
                            cliente.Estado = "Regular";
                        else if (cliente.Retrazos > 2)
                            cliente.Estado = "Malo";

                        guardo = ClientesBLL.Modificar(cliente);
                    }
                }
                else
                {
                    MessageBox.Show("No se Pude Modificar un Cliente que no Existe");
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
            Clientes AnteriorCliente = ClientesBLL.Buscar(cliente.ClienteId);
            if (AnteriorCliente.ClienteId == 0)
            {
                MessageBox.Show("No se Puede Eliminar un cliente que no existe");
                return;
            }

            if (ClientesBLL.Eliminar(cliente.ClienteId))
            {
                limpiar();
                MessageBox.Show("Eliminado Correctamente");
            }
            else
                MessageBox.Show("No se Puede Eliminar un Cliente que no existe");
        }

        private void limpiar()
        {
            cliente = new Clientes();

            UsuarioLabel.Content = UsuarioNombre;

            reCargar();
        }

        private void reCargar()
        {
            this.DataContext = null;
            this.DataContext = cliente;
        }

        //private bool ExisteEnLaBaseDeDatos()
        //{
        //    Clientes AnteriorCliente = ClientesBLL.Buscar(cliente.ClienteId);

        //    return (AnteriorCliente != null);
        //}

        private string obtenerNombreUsuario(int id)
        {
            Usuarios usuarios = UsuariosBLL.Buscar(id);

            return usuarios.NombreUsuario;
        }
    }
}
