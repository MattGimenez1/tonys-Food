using System;
using System.Data;

namespace Datos
{
    public class DaoReporteStock
    {
        AccesoDatos ds = new AccesoDatos();

        private string filtroComun(DateTime desde, DateTime hasta, int idInsumo)
        {
            string sqlDesde = desde.ToString("yyyyMMdd");
            string sqlHasta = hasta.ToString("yyyyMMdd");

            string filtro = "WHERE CAST(m.Fecha_M AS DATE) BETWEEN '" + sqlDesde + "' AND '" + sqlHasta + "' ";

            if (idInsumo > 0)
                filtro += "AND m.Id_Insumo_M = " + idInsumo + " ";

            return filtro;
        }

        // Una fila por día e insumo: cuánto ingresó, cuánto se vendió y cuánto se ajustó (conteo físico)
        public DataTable getResumenPorDia(DateTime desde, DateTime hasta, int idInsumo)
        {
            return ds.ObtenerTabla("ResumenStock",
                "SELECT CAST(m.Fecha_M AS DATE) AS Fecha, i.Nombre_Ins AS Insumo, " +
                "SUM(CASE WHEN m.Tipo_M IN ('Alta', 'Ingreso') THEN m.Cantidad_M ELSE 0 END) AS Ingresos, " +
                "SUM(CASE WHEN m.Tipo_M = 'Venta' THEN m.Cantidad_M ELSE 0 END) AS Ventas, " +
                "SUM(CASE WHEN m.Tipo_M = 'Ajuste' THEN m.Cantidad_M ELSE 0 END) AS Ajustes " +
                "FROM MovimientosStock m " +
                "INNER JOIN Insumos i ON m.Id_Insumo_M = i.Id_Insumo_Ins " +
                filtroComun(desde, hasta, idInsumo) +
                "GROUP BY CAST(m.Fecha_M AS DATE), i.Nombre_Ins " +
                "ORDER BY Fecha DESC, Insumo");
        }

        // Cada movimiento, con hora, usuario y número de ticket (si fue una venta)
        public DataTable getDetalleMovimientos(DateTime desde, DateTime hasta, int idInsumo)
        {
            return ds.ObtenerTabla("DetalleStock",
                "SELECT m.Fecha_M AS Fecha, i.Nombre_Ins AS Insumo, m.Tipo_M AS Tipo, " +
                "m.Cantidad_M AS Cantidad, ISNULL(u.NombreUsuario_U, '') AS Usuario, " +
                "ISNULL(m.Detalle_M, '') AS Detalle, m.Id_Venta_M AS Ticket " +
                "FROM MovimientosStock m " +
                "INNER JOIN Insumos i ON m.Id_Insumo_M = i.Id_Insumo_Ins " +
                "LEFT JOIN Usuarios u ON m.Id_Usuario_M = u.Id_Usuario_U " +
                filtroComun(desde, hasta, idInsumo) +
                "ORDER BY m.Fecha_M DESC, m.Id_Movimiento_M DESC");
        }
    }
}