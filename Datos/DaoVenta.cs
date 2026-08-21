using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DaoVenta
    {
        AccesoDatos ds = new AccesoDatos();

        public int agregarVenta(Venta ven)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosVentaAgregar(ref comando, ven);
            return ds.EjecutarProcedimientoEscalar(comando, "spAgregarVenta");
        }

        private void ArmarParametrosVentaAgregar(ref SqlCommand comando, Venta ven)
        {
            SqlParameter param = new SqlParameter();
            param = comando.Parameters.Add("@Total_V", SqlDbType.Decimal);
            param.Value = ven.getTotal_V();
            param = comando.Parameters.Add("@Id_Usuario_V", SqlDbType.Int);
            param.Value = ven.getId_Usuario_V();
            param = comando.Parameters.Add("@FormaPago_V", SqlDbType.NVarChar); 
            param.Value = ven.getFormaPago_V(); 
        }

        public int agregarDetalleVenta(DetalleVenta det)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosDetalleAgregar(ref comando, det);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarDetalleVenta");
        }

        private void ArmarParametrosDetalleAgregar(ref SqlCommand comando, DetalleVenta det)
        {
            SqlParameter param = new SqlParameter();
            param = comando.Parameters.Add("@Id_Venta_D", SqlDbType.Int);
            param.Value = det.getId_Venta_D();
            param = comando.Parameters.Add("@Id_Producto_D", SqlDbType.Int);
            param.Value = det.getId_Producto_D();
            param = comando.Parameters.Add("@Cantidad_D", SqlDbType.Int);
            param.Value = det.getCantidad_D();
            param = comando.Parameters.Add("@PrecioUnitario_D", SqlDbType.Decimal);
            param.Value = det.getPrecioUnitario_D();
            param = comando.Parameters.Add("@Subtotal_D", SqlDbType.Decimal);
            param.Value = det.getSubtotal_D();
        }

        public DataTable getTablaVentasDelDia()
        {
            return ds.ObtenerTabla("Ventas",
                "SELECT v.Id_Venta_V AS Id, v.Fecha_V AS Fecha, v.Total_V AS Total, " +
                "ISNULL(ve.Nombre_Ve + ' ' + ve.Apellido_Ve, 'Admin') AS Vendedor " +
                "FROM Ventas v " +
                "LEFT JOIN Vendedores ve ON v.Id_Usuario_V = ve.Id_Usuario_Ve " +
                "WHERE CAST(v.Fecha_V AS DATE) = CAST(GETDATE() AS DATE) " +
                "ORDER BY v.Fecha_V DESC");
        }

        public DataTable getDetalleVentaxId(int idVenta)
        {
            return ds.ObtenerTabla("DetalleVentas",
                "SELECT d.Id_Detalle_D AS Id, p.Nombre_Pr AS Producto, " +
                "d.Cantidad_D AS Cantidad, d.PrecioUnitario_D AS PrecioUnitario, d.Subtotal_D AS Subtotal " +
                "FROM DetalleVentas d " +
                "INNER JOIN Productos p ON d.Id_Producto_D = p.Id_Producto_Pr " +
                "WHERE d.Id_Venta_D = " + idVenta);
        }
        public DataTable getProductoMasVendidoDelDia()
        {
            return ds.ObtenerTabla("ProductoTop",
                "SELECT TOP 1 p.Nombre_Pr AS Producto, SUM(d.Cantidad_D) AS CantidadVendida " +
                "FROM DetalleVentas d " +
                "INNER JOIN Productos p ON d.Id_Producto_D = p.Id_Producto_Pr " +
                "INNER JOIN Ventas v ON d.Id_Venta_D = v.Id_Venta_V " +
                "WHERE CAST(v.Fecha_V AS DATE) = CAST(GETDATE() AS DATE) " +
                "GROUP BY p.Nombre_Pr " +
                "ORDER BY SUM(d.Cantidad_D) DESC");
        }
        public DataTable getTablaVentasPorRango(DateTime desde, DateTime hasta)
        {
            string sqlDesde = desde.ToString("yyyy-MM-dd");
            string sqlHasta = hasta.ToString("yyyy-MM-dd");

            return ds.ObtenerTabla("VentasRango",
                "SELECT v.Id_Venta_V AS Id, v.Fecha_V AS Fecha, v.Total_V AS Total, " +
                "ISNULL(ve.Nombre_Ve + ' ' + ve.Apellido_Ve, 'Admin') AS Vendedor " +
                "FROM Ventas v " +
                "LEFT JOIN Vendedores ve ON v.Id_Usuario_V = ve.Id_Usuario_Ve " +
                "WHERE CAST(v.Fecha_V AS DATE) BETWEEN '" + sqlDesde + "' AND '" + sqlHasta + "' " +
                "ORDER BY v.Fecha_V DESC");
        }

        public DataTable getProductoMasVendidoPorRango(DateTime desde, DateTime hasta)
        {
            string sqlDesde = desde.ToString("yyyy-MM-dd");
            string sqlHasta = hasta.ToString("yyyy-MM-dd");

            return ds.ObtenerTabla("ProductoTopRango",
                "SELECT TOP 1 p.Nombre_Pr AS Producto, SUM(d.Cantidad_D) AS CantidadVendida " +
                "FROM DetalleVentas d " +
                "INNER JOIN Productos p ON d.Id_Producto_D = p.Id_Producto_Pr " +
                "INNER JOIN Ventas v ON d.Id_Venta_D = v.Id_Venta_V " +
                "WHERE CAST(v.Fecha_V AS DATE) BETWEEN '" + sqlDesde + "' AND '" + sqlHasta + "' " +
                "GROUP BY p.Nombre_Pr " +
                "ORDER BY SUM(d.Cantidad_D) DESC");
        }
        public DataTable getVentaPorId(int idVenta)
        {
            return ds.ObtenerTabla("Venta",
                "SELECT Id_Venta_V AS Id, Fecha_V AS Fecha, Total_V AS Total, FormaPago_V AS FormaPago " +
                "FROM Ventas WHERE Id_Venta_V = " + idVenta);
        }
    }
}