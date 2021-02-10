using Microsoft.EntityFrameworkCore;
using Proyecto_Prestamos.DAL;
using Proyecto_Prestamos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Proyecto_Prestamos.BLL
{
    public class UsuariosBLL
    {
        public static bool Guardar(Usuarios usuario)
        {
            if (!Existe(usuario.UsuarioId))
                return Insertar(usuario);
            else
                return Modificar(usuario);
        }

        public static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto contexto = new Contexto();

            try
            {
                encontrado = contexto.Usuarios.Any(u => u.UsuarioId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        public static bool Insertar(Usuarios usuario)
        {
            if (usuario.UsuarioId != 0)
                return false;

            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                usuario.Clave = Encriptar(usuario.Clave);
                usuario.CodigoRecuperacion = Encriptar(usuario.CodigoRecuperacion);

                if (contexto.Usuarios.Add(usuario) != null)
                    paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Usuarios usuario)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                usuario.Clave = Encriptar(usuario.Clave);
                usuario.CodigoRecuperacion = Encriptar(usuario.CodigoRecuperacion);

                contexto.Entry(usuario).State = EntityState.Modified;
                paso = (contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static string Encriptar(string cadenaEncriptada)
        {
            if (!string.IsNullOrEmpty(cadenaEncriptada))
            {
                string resultado = string.Empty;
                byte[] encryted = Encoding.Unicode.GetBytes(cadenaEncriptada);
                resultado = Convert.ToBase64String(encryted);

                return resultado;
            }
            return string.Empty;
        }

        public static string DesEncriptar(string cadenaDesencriptada)
        {
            if (!string.IsNullOrEmpty(cadenaDesencriptada))
            {
                string resultado = string.Empty;
                byte[] decryted = Convert.FromBase64String(cadenaDesencriptada);
                resultado = System.Text.Encoding.Unicode.GetString(decryted);

                return resultado;
            }
            return string.Empty;
        }

        public static Usuarios Buscar(int id)
        {
            Usuarios usuario = new Usuarios();
            Contexto contexto = new Contexto();

            try
            {
                var encontrado = contexto.Usuarios.Find(id);

                if(encontrado == null)
                    return new Usuarios();
                if (encontrado.Accesibilidad == false)
                    return new Usuarios();
                else
                    encontrado.Clave = DesEncriptar(encontrado.Clave);
                    encontrado.CodigoRecuperacion = DesEncriptar(encontrado.CodigoRecuperacion);
                    usuario = encontrado;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return usuario;
        }

        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool eliminado = false;
            try
            {
                var usuario = contexto.Usuarios.Where(u => u.UsuarioId == id).FirstOrDefault();

                if (usuario != null)
                {
                    usuario.Accesibilidad = false;
                    contexto.Usuarios.Update(usuario);
                    //contexto.Clientes.Remove(Clientes);
                    eliminado = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return eliminado;
        }

        public static List<Usuarios> GetList()
        {
            Contexto contexto = new Contexto();
            List<Usuarios> Lista;
            try
            {
                Lista = contexto.Usuarios.Where(u => u.Accesibilidad == true).ToList();
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

        public static List<Usuarios> GetListCompleta(Expression<Func<Usuarios, bool>> usuario)
        {
            List<Usuarios> Lista = new List<Usuarios>();
            Contexto db = new Contexto();
            try
            {
                Lista = db.Usuarios.Where(usuario).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return Lista;
        }

        public static bool ExisteUsuario(string usuario, string clave)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                clave = Encriptar(clave);

                if (contexto.Usuarios.Where(u => u.NombreUsuario == usuario && u.Clave == clave).SingleOrDefault() != null)
                    paso = true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static string ObtenerUsuarioId(string usuario, string clave)
        {
            Contexto contexto = new Contexto();
            string id;

            try
            {
                clave = Encriptar(clave);

                id = contexto.Usuarios.Where(u => u.NombreUsuario == usuario && u.Clave == clave).FirstOrDefault().UsuarioId.ToString();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return id;
        }
    }
}
