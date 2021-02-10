using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_Prestamos.Entidades
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombres { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public string Email { get; set; }
        public string CodigoRecuperacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int UsuarioIdCreacion { get; set; }
        public bool Accesibilidad { get; set; }

        public Usuarios()
        {
            UsuarioId = 0;
            Fecha = DateTime.Now;
            Nombres = string.Empty;
            NombreUsuario = string.Empty;
            Clave = string.Empty;
            Email = string.Empty;
            CodigoRecuperacion = string.Empty;
            FechaCreacion = DateTime.Now;
            FechaModificacion = DateTime.Now;
            UsuarioIdCreacion = 0;
            Accesibilidad = true;
        }

        public Usuarios(int usuarioId, DateTime fecha, string nombres, string nombreUsuario, string clave, string email, string codigoRecuperacion, DateTime fechaCreacion, DateTime fechaModificacion, int usuarioIdCreacion, bool accesibilidad)
        {
            UsuarioId = usuarioId;
            Fecha = fecha;
            Nombres = nombres;
            NombreUsuario = nombreUsuario;
            Clave = clave;
            Email = email;
            CodigoRecuperacion = codigoRecuperacion;
            FechaCreacion = fechaCreacion;
            FechaModificacion = fechaModificacion;
            UsuarioIdCreacion = usuarioIdCreacion;
            Accesibilidad = accesibilidad;
        }
    }
}
