using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;

namespace Negocio
{
    public class NegocioVenta
    {
        public int registrarVentaCompleta(decimal total, int idUsuario, string formaPago, List<DetalleVenta> detalles)
        {
            DaoVenta dao = new DaoVenta();

            Venta ven = new Venta();
            ven.setTotal_V(total);
            ven.setId_Usuario_V(idUsuario);
            ven.setFormaPago_V(formaPago);

            int idVentaGenerada = dao.agregarVenta(ven);

            if (idVentaGenerada <= 0)
                return 0;

            foreach (DetalleVenta det in detalles)
            {
                det.setId_Venta_D(idVentaGenerada);
                dao.agregarDetalleVenta(det);
            }

            // Descuento automático de insumos (nunca hace fallar la venta)
            new NegocioStockVenta().descontarVenta(idVentaGenerada, idUsuario, detalles);

            return idVentaGenerada;
        }

        public DataTable getTablaVentasDelDia()
        {
            DaoVenta dao = new DaoVenta();
            return dao.getTablaVentasDelDia();
        }

        public DataTable getDetalleVentaxId(int idVenta)
        {
            DaoVenta dao = new DaoVenta();
            return dao.getDetalleVentaxId(idVenta);
        }

        public string getProductoMasVendidoDelDia()
        {
            DaoVenta dao = new DaoVenta();
            DataTable tabla = dao.getProductoMasVendidoDelDia();

            if (tabla.Rows.Count == 0)
                return "-";

            return tabla.Rows[0]["Producto"].ToString();
        }
        public DataTable getTablaVentasPorRango(DateTime desde, DateTime hasta)
        {
            DaoVenta dao = new DaoVenta();
            return dao.getTablaVentasPorRango(desde, hasta);
        }

        public string getProductoMasVendidoPorRango(DateTime desde, DateTime hasta)
        {
            DaoVenta dao = new DaoVenta();
            DataTable tabla = dao.getProductoMasVendidoPorRango(desde, hasta);
            return tabla.Rows.Count == 0 ? "-" : tabla.Rows[0]["Producto"].ToString();
        }
        public DataTable getVentaPorId(int idVenta)
        {
            DaoVenta dao = new DaoVenta();
            return dao.getVentaPorId(idVenta);
        }
    }
}