using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proyecto_Prestamos.Entidades
{
    public class PrestamosMesesDetalle
    {
        [Key]
        public int PrestamoMesDetalleId { get; set; }
        public int PrestamoMesId { get; set; }
        public int ClienteId { get; set; }
        public int NumeroCuota { get; set; }
        public string Nombres { get; set; }
        public string Cedula { get; set; }
        public DateTime FechaPago { get; set; }
        public string DescripcionPago { get; set; }
        public decimal Abono { get; set; }
        public decimal Redito { get; set; }
        public decimal Mora { get; set; }
        public decimal BalanceRestante { get; set; }

        public PrestamosMesesDetalle()
        {
            PrestamoMesDetalleId = 0;
            PrestamoMesId = 0;
            ClienteId = 0;
            NumeroCuota = 0;
            Nombres = string.Empty;
            Cedula = string.Empty;
            FechaPago = DateTime.Now;
            DescripcionPago = string.Empty;
            Abono = 0;
            Redito = 0;
            Mora = 0;
            BalanceRestante = 0;
        }

        public PrestamosMesesDetalle(int prestamoMesDetalleId, int prestamoMesId, int clienteId, int numeroCuota, string nombres, string cedula, DateTime fechaPago, string descripcionPago, decimal abono, decimal redito, decimal mora, decimal balanceRestante)
        {
            PrestamoMesDetalleId = prestamoMesDetalleId;
            PrestamoMesId = prestamoMesId;
            ClienteId = clienteId;
            NumeroCuota = numeroCuota;
            Nombres = nombres;
            Cedula = cedula;
            FechaPago = fechaPago;
            DescripcionPago = descripcionPago;
            Abono = abono;
            Redito = redito;
            Mora = mora;
            BalanceRestante = balanceRestante;
        }
    }
}
