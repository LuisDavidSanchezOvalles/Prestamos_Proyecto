using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Proyecto_Prestamos.Entidades
{
    public class PrestamosMeses
    {
        [Key]
        public int PrestamoMesId { get; set; }
        public int ClienteId { get; set; }
        public string Nombres { get; set; }
        public string Cedula { get; set; }
        public string Descripcion { get; set; }
        public decimal Prestamo { get; set; }
        public decimal Interes { get; set; }
        public int Tiempo { get; set; }
        public DateTime FechaInicio { get; set; }
        public decimal CapitalRestante { get; set; }
        public decimal ReditoPagar { get; set; }
        public decimal DeudaRedito { get; set; }
        public decimal Ganancia { get; set; }
        public int Retrazo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int UsuarioIdCreacion { get; set; }
        public bool Accesibilidad { get; set; }

        [ForeignKey("PrestamoMesId")]
        public List<PrestamosMesesDetalle> PrestamoMesDetalle { get; set; }

        public PrestamosMeses()
        {
            PrestamoMesId = 0;
            ClienteId = 0;
            Nombres = string.Empty;
            Cedula = string.Empty;
            Descripcion = string.Empty;
            Prestamo = 0;
            Interes = 0;
            Tiempo = 0;
            FechaInicio = DateTime.Now;
            CapitalRestante = 0;
            ReditoPagar = 0;
            DeudaRedito = 0;
            Ganancia = 0;
            Retrazo = 0;
            FechaCreacion = DateTime.Now;
            FechaModificacion = DateTime.Now;
            UsuarioIdCreacion = 0;
            Accesibilidad = true;
            PrestamoMesDetalle = new List<PrestamosMesesDetalle>();
        }
    }
}
