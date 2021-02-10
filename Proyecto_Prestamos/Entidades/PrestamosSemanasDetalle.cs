using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proyecto_Prestamos.Entidades
{
    public class PrestamosSemanasDetalle
    {
        [Key]
        public int PrestamoSemDetalleId { get; set; }
        public int PrestamoSemId { get; set; }
        public int ClienteId { get; set; }
        public int NumeroCuota { get; set; }
        public string Nombres { get; set; }
        public string Cedula { get; set; }
        public DateTime FechaPago { get; set; }
        public string DescripcionPago { get; set; }
        public decimal Pago { get; set; }
        public decimal Mora { get; set; }
        public decimal BalanceRestante { get; set; }

        public PrestamosSemanasDetalle()
        {
            PrestamoSemDetalleId = 0;
            PrestamoSemId = 0;
            ClienteId = 0;
            NumeroCuota = 0;
            Nombres = string.Empty;
            Cedula = string.Empty;
            FechaPago = DateTime.Now;
            DescripcionPago = string.Empty;
            Pago = 0;
            Mora = 0;
            BalanceRestante = 0;
        }
    }
}
