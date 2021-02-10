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
    public class PrestamosSemanasBLL
    {
        private static bool Insertar(PrestamosSemanas prestamoSemana)
        {
            Contexto contexto = new Contexto();
            bool guardar = false;

            try
            {
                contexto.PrestamosSemanas.Add(prestamoSemana);
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

        private static bool Modificar(PrestamosSemanas prestamoSemana)
        {
            Contexto contexto = new Contexto();
            bool modificar = false;

            try
            {
                contexto.Database.ExecuteSqlRaw($"Delete FROM PrestamosSemanasDetalle Where PrestamoSemId={prestamoSemana.PrestamoSemId}");
                foreach (var item in prestamoSemana.PrestamoSemDetalle)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }
                contexto.Entry(prestamoSemana).State = EntityState.Modified;
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

        private bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool existe;

            try
            {
                existe = contexto.PrestamosSemanas.Any(p => p.PrestamoSemId == id);
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

        public bool Guardar(PrestamosSemanas PrestamoSemana)
        {
            if (Existe(PrestamoSemana.PrestamoSemId))
                return Modificar(PrestamoSemana);
            else
                return Insertar(PrestamoSemana);
        }

        public PrestamosSemanas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            PrestamosSemanas prestamoSemana = new PrestamosSemanas();

            try
            {
                var encontrado = contexto.PrestamosSemanas.Where(r => r.PrestamoSemId == id).Include(r => r.PrestamoSemDetalle).FirstOrDefault();

                if (encontrado == null)
                    return new PrestamosSemanas();
                if (encontrado.Accesibilidad == false)
                    return new PrestamosSemanas();
                else
                    prestamoSemana = encontrado;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return prestamoSemana;
        }

        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool eliminado = false;

            try
            {
                var prestamoSemana = contexto.PrestamosSemanas.Where(p => p.PrestamoSemId == id)
                    .Include(p => p.PrestamoSemDetalle).FirstOrDefault();

                if (prestamoSemana != null)
                {
                    prestamoSemana.Accesibilidad = false;
                    contexto.PrestamosSemanas.Update(prestamoSemana);
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

        public static List<PrestamosSemanas> GetList()
        {
            Contexto contexto = new Contexto();
            List<PrestamosSemanas> Lista;
            try
            {
                Lista = contexto.PrestamosSemanas.Where(p => p.Accesibilidad == true).Include(p => p.PrestamoSemDetalle).ToList();
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

        public static List<PrestamosSemanas> GetListCompleta(Expression<Func<PrestamosSemanas, bool>> prestamoSemana)
        {
            List<PrestamosSemanas> Lista = new List<PrestamosSemanas>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.PrestamosSemanas.Where(prestamoSemana).Include(p => p.PrestamoSemDetalle).ToList();
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
