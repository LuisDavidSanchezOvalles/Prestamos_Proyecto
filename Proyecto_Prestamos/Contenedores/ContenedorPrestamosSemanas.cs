using System;
using System.Collections.Generic;
using System.Text;
using Proyecto_Prestamos.Entidades;

namespace Proyecto_Prestamos.Contenedores
{
    public class ContenedorPrestamosSemanas
    {
        public PrestamosSemanas prestamosSemanas { get; set; }
        public PrestamosSemanasDetalle prestamosSemanasDetalle { get; set; }
        public List<ListaPrestamosSemanas> listaPrestamosSemanas { get; set; }

        public ContenedorPrestamosSemanas()
        {
            prestamosSemanas = new PrestamosSemanas();
            prestamosSemanasDetalle = new PrestamosSemanasDetalle();
            listaPrestamosSemanas = new List<ListaPrestamosSemanas>();
        }
    }
}
