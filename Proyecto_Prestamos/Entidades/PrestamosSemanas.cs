using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Proyecto_Prestamos.Entidades
{
    public class PrestamosSemanas
    {
        [Key]
        public int PrestamoSemId { get; set; }
        public int ClienteId { get; set; }
        public string Nombres { get; set; }
        public string Cedula { get; set; }
        public string Descripcion { get; set; }
        public decimal Prestamo { get; set; }
        public decimal Interes { get; set; }
        public int Tiempo { get; set; }
        public DateTime FechaInicio { get; set; }
        public decimal Capital { get; set; }
        public decimal Redito { get; set; }
        public decimal PagoSemanal { get; set; }
        public decimal TotalRestante { get; set; }
        public int CuotasRestantes { get; set; }
        public decimal Ganancia { get; set; }
        public int Retrazo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int UsuarioIdCreacion { get; set; }
        public bool Accesibilidad { get; set; }

        [ForeignKey("PrestamoSemId")]
        public List<PrestamosSemanasDetalle> PrestamoSemDetalle { get; set; }

        public PrestamosSemanas()
        {
            PrestamoSemId = 0;
            ClienteId = 0;
            Nombres = string.Empty; ;
            Cedula = string.Empty; ;
            Descripcion = string.Empty;
            Prestamo = 0;
            Interes = 0;
            Tiempo = 0;
            FechaInicio = DateTime.Now;
            Capital = 0;
            Redito = 0;
            PagoSemanal = 0;
            TotalRestante = 0;
            CuotasRestantes = 0;
            Ganancia = 0;
            Retrazo = 0;
            FechaCreacion = DateTime.Now; ;
            FechaModificacion = DateTime.Now;
            UsuarioIdCreacion = 0;
            Accesibilidad = true;
            PrestamoSemDetalle = new List<PrestamosSemanasDetalle>();
        }
    }
}
