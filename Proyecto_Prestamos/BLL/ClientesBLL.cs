using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Proyecto_Prestamos.DAL;
using Proyecto_Prestamos.Entidades;

namespace Proyecto_Prestamos.BLL
{
    public class ClientesBLL
    {
        public static bool Insertar(Clientes cliente)
        {
            Contexto contexto = new Contexto();
            bool guardar = false;

            try
            {
                contexto.Clientes.Add(cliente);
                guardar = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return guardar;
        }

        public static bool Modificar(Clientes cliente)
        {
            Contexto contexto = new Contexto();
            bool modificar = false;

            try
            {
                contexto.Clientes.Update(cliente);
                modificar = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return modificar; 
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool existe;

            try
            {
                existe = contexto.Clientes.Any(c => c.ClienteId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return existe;
        }

        public bool Guardar(Clientes cliente)
        {
            if (Existe(cliente.ClienteId))
                return Modificar(cliente);
            else
                return Insertar(cliente);
        }

        public static Clientes Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Clientes cliente = new Clientes();

            try
            {
                var encontrado = contexto.Clientes.Find(id);

                if (encontrado == null)
                    return new Clientes();
                if (encontrado.Accesibilidad == false)
                    return new Clientes();
                else
                    cliente = encontrado;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return cliente;
        }

        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool eliminado = false;

            try
            {
                var cliente = contexto.Clientes.Where(c => c.ClienteId == id).FirstOrDefault();

                if (cliente != null)
                {
                    cliente.Accesibilidad = false;
                    contexto.Clientes.Update(cliente);
                    //contexto.Clientes.Remove(cliente);
                    eliminado = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return eliminado;
        }

        public static List<Clientes> GetList()
        {
            Contexto contexto = new Contexto();
            List<Clientes> Lista;
            try
            {
                Lista = contexto.Clientes.Where(c => c.Accesibilidad == true).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
        }

        public static List<Clientes> GetListCompleta(Expression<Func<Clientes, bool>> cliente)
        {
            List<Clientes> Lista = new List<Clientes>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Clientes.Where(cliente).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
        }
    }
}
