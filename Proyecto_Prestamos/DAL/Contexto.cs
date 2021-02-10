using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Proyecto_Prestamos.BLL;
using Proyecto_Prestamos.Entidades;

namespace Proyecto_Prestamos.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<PrestamosMeses> PrestamosMeses { get; set; }
        public DbSet<PrestamosSemanas> PrestamosSemanas { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Data\Prestamos.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>().HasData(new Usuarios { UsuarioId = 1, Fecha = DateTime.Now, Nombres = "Administrador", NombreUsuario = "admin", Clave = UsuariosBLL.Encriptar("admin"), Email = "Admin@outlook.com", CodigoRecuperacion = "12345678", FechaCreacion = DateTime.Now, FechaModificacion = DateTime.Now, UsuarioIdCreacion = 1, Accesibilidad = true });
        }
    }
}
