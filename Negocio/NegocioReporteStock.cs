using System;
using System.Data;
using Datos;

namespace Negocio
{
    public class NegocioReporteStock
    {
        DaoReporteStock dao = new DaoReporteStock();

        // idInsumo = 0 significa todos los insumos
        public DataTable getResumenPorDia(DateTime desde, DateTime hasta, int idInsumo)
        {
            return dao.getResumenPorDia(desde, hasta, idInsumo);
        }

        public DataTable getDetalleMovimientos(DateTime desde, DateTime hasta, int idInsumo)
        {
            return dao.getDetalleMovimientos(desde, hasta, idInsumo);
        }
    }
}