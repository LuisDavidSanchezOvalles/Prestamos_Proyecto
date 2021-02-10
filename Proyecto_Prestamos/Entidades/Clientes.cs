using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proyecto_Prestamos.Entidades
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombres { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int UsuarioId { get; set; }
        public decimal Balance { get; set; }
        public decimal Ganancia { get; set; }
        public string Estado { get; set; }//esto determinara el estado de Excelente: Retrazo = 0, regular = 2, malo =3
        public int Retrazos { get; set; } //Cantidad de retrazos acumulados
        public bool Accesibilidad { get; set; }

        public Clientes()
        {
            ClienteId = 0;
            Fecha = DateTime.Now;
            Nombres = string.Empty;
            Cedula = string.Empty;
            Telefono = string.Empty;
            Direccion = string.Empty;
            FechaCreacion = DateTime.Now;
            FechaModificacion = DateTime.Now;
            UsuarioId = 0;
            Balance = 0;
            Ganancia = 0;
            Estado = string.Empty;
            Retrazos = 0;
            Accesibilidad = true;
        }
    }
}
