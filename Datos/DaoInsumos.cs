using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DaoInsumos
    {
        AccesoDatos ds = new AccesoDatos();

        // ========== EXISTENCIA ==========

        public bool ExisteInsumoxNombre(Insumo ins)
        {
            string consulta = "SELECT * FROM Insumos WHERE Nombre_Ins = '" + ins.getNombre_Ins().Replace("'", "''") + "'";
            return ds.existe(consulta);
        }

        public bool ExisteInsumoxId(Insumo ins)
        {
            string consulta = "SELECT * FROM Insumos WHERE Id_Insumo_Ins = " + ins.getId_Insumo_Ins();
            return ds.existe(consulta);
        }

        // ========== ALTA ==========
        // El stock inicial viaja en el propio Insumo (getStock_Ins).
        // El procedimiento también guarda el movimiento 'Alta' en el historial,
        // por eso necesita el usuario que lo está cargando.

        public int agregarInsumo(Insumo ins, int idUsuario)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosInsumoAgregar(ref comando, ins, idUsuario);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarInsumo");
        }

        private void ArmarParametrosInsumoAgregar(ref SqlCommand comando, Insumo ins, int idUsuario)
        {
            SqlParameter param = new SqlParameter();
            param = comando.Parameters.Add("@Nombre_Ins", SqlDbType.NVarChar);
            param.Value = ins.getNombre_Ins();
            param = comando.Parameters.Add("@StockInicial", SqlDbType.Int);
            param.Value = ins.getStock_Ins();
            param = comando.Parameters.Add("@StockMinimo_Ins", SqlDbType.Int);
            param.Value = ins.getStockMinimo_Ins();
            param = comando.Parameters.Add("@Id_Usuario_M", SqlDbType.Int);
            param.Value = idUsuario;
        }

        // ========== MODIFICACIÓN ==========
        // Cambia nombre y stock mínimo. El stock NO se toca acá:
        // solo cambia con ingresos, ajustes y ventas.

        public int modificarInsumo(Insumo ins)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosInsumoModificar(ref comando, ins);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spModificarInsumo");
        }

        private void ArmarParametrosInsumoModificar(ref SqlCommand comando, Insumo ins)
        {
            SqlParameter param = new SqlParameter();
            param = comando.Parameters.Add("@Id_Insumo_Ins", SqlDbType.Int);
            param.Value = ins.getId_Insumo_Ins();
            param = comando.Parameters.Add("@Nombre_Ins", SqlDbType.NVarChar);
            param.Value = ins.getNombre_Ins();
            param = comando.Parameters.Add("@StockMinimo_Ins", SqlDbType.Int);
            param.Value = ins.getStockMinimo_Ins();
        }

        // ========== BAJA (LÓGICA) ==========

        public int eliminarInsumo(Insumo ins)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosInsumoEliminar(ref comando, ins);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spEliminarInsumo");
        }

        private void ArmarParametrosInsumoEliminar(ref SqlCommand comando, Insumo ins)
        {
            SqlParameter param = new SqlParameter();
            param = comando.Parameters.Add("@Id_Insumo_Ins", SqlDbType.Int);
            param.Value = ins.getId_Insumo_Ins();
        }

        public bool activarInsumo(int idInsumo)
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Parameters.AddWithValue("@Id_Insumo_Ins", idInsumo);
                int filas = ds.EjecutarProcedimientoAlmacenado(comando, "spActivarInsumo");
                return filas > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // ========== CONSULTAS ==========

        public DataTable getTablaInsumos()
        {
            return ds.ObtenerTabla("Insumos",
                "SELECT Id_Insumo_Ins AS Id, Nombre_Ins AS Nombre, " +
                "Stock_Ins AS Stock, StockMinimo_Ins AS StockMinimo, " +
                "CAST(Activo_Ins AS INT) AS Activo " +
                "FROM Insumos WHERE Activo_Ins = 1 ORDER BY Nombre_Ins");
        }

        public DataTable getTablaInsumosTodos()
        {
            return ds.ObtenerTabla("Insumos",
                "SELECT Id_Insumo_Ins AS Id, Nombre_Ins AS Nombre, " +
                "Stock_Ins AS Stock, StockMinimo_Ins AS StockMinimo, " +
                "CAST(Activo_Ins AS INT) AS Activo " +
                "FROM Insumos ORDER BY Nombre_Ins");
        }
    }
}