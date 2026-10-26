using Datos;
using Entidades;
using System;
using System.Data;

namespace Negocio
{
    public class NegocioMovimientosStock
    {
        // Compra / reposición: siempre suma, la cantidad tiene que ser mayor a 0
        public bool ingresarStock(int idInsumo, int cantidad, int idUsuario, string detalle)
        {
            int cantFilas = 0;

            if (cantidad <= 0) return false;

            if (existeInsumo(idInsumo))
            {
                DaoMovimientosStock dao = new DaoMovimientosStock();
                cantFilas = dao.ingresarStock(idInsumo, cantidad, idUsuario, detalle);
            }

            return cantFilas >= 1;
        }

        // Conteo físico: el dueño dice cuánto hay REALMENTE y el sistema se iguala
        public bool ajustarStock(int idInsumo, int stockReal, int idUsuario, string detalle)
        {
            int cantFilas = 0;

            if (stockReal < 0) return false;

            if (existeInsumo(idInsumo))
            {
                DaoMovimientosStock dao = new DaoMovimientosStock();
                cantFilas = dao.ajustarStock(idInsumo, stockReal, idUsuario, detalle);
            }

            return cantFilas >= 1;
        }

        // Lo usa el cobro (paso 4). Puede dejar el stock en negativo, a propósito
        public bool descontarInsumo(int idInsumo, int cantidad, int idVenta, int idUsuario)
        {
            int cantFilas = 0;

            if (cantidad <= 0) return false;

            DaoMovimientosStock dao = new DaoMovimientosStock();
            cantFilas = dao.descontarInsumo(idInsumo, cantidad, idVenta, idUsuario);

            return cantFilas >= 1;
        }

        public DataTable getTabla()
        {
            DaoMovimientosStock dao = new DaoMovimientosStock();
            return dao.getTablaMovimientos();
        }

        // idInsumo = 0 para ver todos los insumos
        public DataTable getTablaFiltrado(int idInsumo, DateTime desde, DateTime hasta)
        {
            if (desde.Date > hasta.Date)
            {
                DateTime aux = desde;
                desde = hasta;
                hasta = aux;
            }

            DaoMovimientosStock dao = new DaoMovimientosStock();
            return dao.getTablaMovimientosFiltrado(idInsumo, desde, hasta);
        }

        private bool existeInsumo(int idInsumo)
        {
            DaoInsumos daoIns = new DaoInsumos();
            Insumo ins = new Insumo();
            ins.setId_Insumo_Ins(idInsumo);
            return daoIns.ExisteInsumoxId(ins);
        }
    }
}