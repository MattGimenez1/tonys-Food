using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace Datos
{
    public class DaoMovimientosStock
    {
        AccesoDatos ds = new AccesoDatos();

        // ========== INGRESO (compra / reposición) ==========

        public int ingresarStock(int idInsumo, int cantidad, int idUsuario, string detalle)
        {
            SqlCommand comando = new SqlCommand();
            SqlParameter param = new SqlParameter();
            param = comando.Parameters.Add("@Id_Insumo_Ins", SqlDbType.Int);
            param.Value = idInsumo;
            param = comando.Parameters.Add("@Cantidad", SqlDbType.Int);
            param.Value = cantidad;
            param = comando.Parameters.Add("@Id_Usuario_M", SqlDbType.Int);
            param.Value = idUsuario;
            param = comando.Parameters.Add("@Detalle_M", SqlDbType.NVarChar);
            param.Value = string.IsNullOrWhiteSpace(detalle) ? (object)DBNull.Value : detalle;
            return ds.EjecutarProcedimientoAlmacenado(comando, "spIngresarStock");
        }

        // ========== AJUSTE (conteo físico) ==========
        // Iguala el stock del sistema a lo que el dueño contó y guarda la diferencia

        public int ajustarStock(int idInsumo, int stockReal, int idUsuario, string detalle)
        {
            SqlCommand comando = new SqlCommand();
            SqlParameter param = new SqlParameter();
            param = comando.Parameters.Add("@Id_Insumo_Ins", SqlDbType.Int);
            param.Value = idInsumo;
            param = comando.Parameters.Add("@StockReal", SqlDbType.Int);
            param.Value = stockReal;
            param = comando.Parameters.Add("@Id_Usuario_M", SqlDbType.Int);
            param.Value = idUsuario;
            param = comando.Parameters.Add("@Detalle_M", SqlDbType.NVarChar);
            param.Value = string.IsNullOrWhiteSpace(detalle) ? (object)DBNull.Value : detalle;
            return ds.EjecutarProcedimientoAlmacenado(comando, "spAjustarStock");
        }

        // ========== DESCUENTO POR VENTA ==========
        // Lo va a llamar el cobro (paso 4). Puede dejar el stock en negativo, a propósito.

        public int descontarInsumo(int idInsumo, int cantidad, int idVenta, int idUsuario)
        {
            SqlCommand comando = new SqlCommand();
            SqlParameter param = new SqlParameter();
            param = comando.Parameters.Add("@Id_Insumo_Ins", SqlDbType.Int);
            param.Value = idInsumo;
            param = comando.Parameters.Add("@Cantidad", SqlDbType.Int);
            param.Value = cantidad;
            param = comando.Parameters.Add("@Id_Venta_M", SqlDbType.Int);
            param.Value = idVenta;
            param = comando.Parameters.Add("@Id_Usuario_M", SqlDbType.Int);
            param.Value = idUsuario;
            return ds.EjecutarProcedimientoAlmacenado(comando, "spDescontarInsumo");
        }

        // ========== CONSULTAS ==========

        private string consultaBaseMovimientos()
        {
            return
                "SELECT m.Id_Movimiento_M AS Id, m.Fecha_M AS Fecha, i.Nombre_Ins AS Insumo, " +
                "u.NombreUsuario_U AS Usuario, m.Tipo_M AS Tipo, m.Cantidad_M AS Cantidad, " +
                "m.Detalle_M AS Detalle, m.Id_Venta_M AS Venta " +
                "FROM MovimientosStock m " +
                "INNER JOIN Insumos i ON m.Id_Insumo_M = i.Id_Insumo_Ins " +
                "INNER JOIN Usuarios u ON m.Id_Usuario_M = u.Id_Usuario_U ";
        }

        // Los últimos 200 movimientos de todos los insumos
        public DataTable getTablaMovimientos()
        {
            string consulta = consultaBaseMovimientos().Replace("SELECT ", "SELECT TOP 200 ") +
                              "ORDER BY m.Fecha_M DESC, m.Id_Movimiento_M DESC";
            return ds.ObtenerTabla("Movimientos", consulta);
        }

        // Filtrado por insumo (0 = todos) y por rango de fechas (el día "hasta" se incluye completo)
        public DataTable getTablaMovimientosFiltrado(int idInsumo, DateTime desde, DateTime hasta)
        {
            string consulta = consultaBaseMovimientos() +
                "WHERE m.Fecha_M >= '" + desde.Date.ToString("yyyyMMdd", CultureInfo.InvariantCulture) + "' " +
                "AND m.Fecha_M < '" + hasta.Date.AddDays(1).ToString("yyyyMMdd", CultureInfo.InvariantCulture) + "' ";

            if (idInsumo > 0)
                consulta += "AND m.Id_Insumo_M = " + idInsumo + " ";

            consulta += "ORDER BY m.Fecha_M DESC, m.Id_Movimiento_M DESC";
            return ds.ObtenerTabla("Movimientos", consulta);
        }
    }
}