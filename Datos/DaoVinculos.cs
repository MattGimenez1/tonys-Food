using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DaoVinculos
    {
        AccesoDatos ds = new AccesoDatos();

        // ========== EXISTENCIA ==========

        public bool ExisteVinculoxId(VinculoInsumo vin)
        {
            string consulta = "SELECT * FROM VinculosInsumo WHERE Id_Vinculo_VI = " + vin.getId_Vinculo_VI();
            return ds.existe(consulta);
        }

        // Para no cargar dos veces el mismo insumo sobre el mismo producto / tamaño / extra
        public bool ExisteVinculoDuplicado(VinculoInsumo vin)
        {
            string consulta = "SELECT * FROM VinculosInsumo WHERE Id_Insumo_VI = " + vin.getId_Insumo_VI();

            if (vin.getId_Producto_VI().HasValue)
                consulta += " AND Id_Producto_VI = " + vin.getId_Producto_VI().Value;
            else if (vin.getId_Tamano_VI().HasValue)
                consulta += " AND Id_Tamano_VI = " + vin.getId_Tamano_VI().Value;
            else if (vin.getId_Extra_VI().HasValue)
                consulta += " AND Id_Extra_VI = " + vin.getId_Extra_VI().Value;
            else
                return false;

            return ds.existe(consulta);
        }

        // ========== ALTA ==========

        public int agregarVinculo(VinculoInsumo vin)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosVinculoAgregar(ref comando, vin);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarVinculo");
        }

        private void ArmarParametrosVinculoAgregar(ref SqlCommand comando, VinculoInsumo vin)
        {
            SqlParameter param = new SqlParameter();
            param = comando.Parameters.Add("@Id_Insumo_VI", SqlDbType.Int);
            param.Value = vin.getId_Insumo_VI();
            param = comando.Parameters.Add("@Id_Producto_VI", SqlDbType.Int);
            param.Value = (object)vin.getId_Producto_VI() ?? DBNull.Value;
            param = comando.Parameters.Add("@Id_Tamano_VI", SqlDbType.Int);
            param.Value = (object)vin.getId_Tamano_VI() ?? DBNull.Value;
            param = comando.Parameters.Add("@Id_Extra_VI", SqlDbType.Int);
            param.Value = (object)vin.getId_Extra_VI() ?? DBNull.Value;
            param = comando.Parameters.Add("@Cantidad_VI", SqlDbType.Int);
            param.Value = vin.getCantidad_VI();
        }

        // ========== MODIFICACIÓN ==========
        // Solo se puede cambiar el insumo y la cantidad.
        // Si se equivocó de producto / tamaño / extra, se elimina el vínculo y se crea otro.

        public int modificarVinculo(VinculoInsumo vin)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosVinculoModificar(ref comando, vin);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spModificarVinculo");
        }

        private void ArmarParametrosVinculoModificar(ref SqlCommand comando, VinculoInsumo vin)
        {
            SqlParameter param = new SqlParameter();
            param = comando.Parameters.Add("@Id_Vinculo_VI", SqlDbType.Int);
            param.Value = vin.getId_Vinculo_VI();
            param = comando.Parameters.Add("@Id_Insumo_VI", SqlDbType.Int);
            param.Value = vin.getId_Insumo_VI();
            param = comando.Parameters.Add("@Cantidad_VI", SqlDbType.Int);
            param.Value = vin.getCantidad_VI();
        }

        // ========== BAJA (FÍSICA: es configuración, no historial) ==========

        public int eliminarVinculo(VinculoInsumo vin)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosVinculoEliminar(ref comando, vin);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spEliminarVinculo");
        }

        private void ArmarParametrosVinculoEliminar(ref SqlCommand comando, VinculoInsumo vin)
        {
            SqlParameter param = new SqlParameter();
            param = comando.Parameters.Add("@Id_Vinculo_VI", SqlDbType.Int);
            param.Value = vin.getId_Vinculo_VI();
        }

        // ========== CONSULTAS ==========
        // Cada fila trae:
        //   Producto = el producto al que pertenece (aunque el vínculo sea de un tamaño o un extra)
        //   Tipo     = Producto / Tamaño / Extra
        //   Opcion   = nombre del tamaño o del extra (vacío si el vínculo es del producto)
        //   Insumo   = lo que se descuenta
        //   Cantidad = cuánto se descuenta

        private string consultaBaseVinculos()
        {
            return
                "SELECT v.Id_Vinculo_VI AS Id, v.Id_Insumo_VI AS IdInsumo, i.Nombre_Ins AS Insumo, " +
                "COALESCE(v.Id_Producto_VI, t.Id_Producto_T, e.Id_Producto_E) AS IdProducto, " +
                "COALESCE(p.Nombre_Pr, pt.Nombre_Pr, pe.Nombre_Pr) AS Producto, " +
                "CASE WHEN v.Id_Producto_VI IS NOT NULL THEN 'Producto' " +
                "     WHEN v.Id_Tamano_VI IS NOT NULL THEN 'Tamaño' " +
                "     ELSE 'Extra' END AS Tipo, " +
                "COALESCE(t.Nombre_T, e.Nombre_E, '') AS Opcion, " +
                "v.Cantidad_VI AS Cantidad " +
                "FROM VinculosInsumo v " +
                "INNER JOIN Insumos i ON v.Id_Insumo_VI = i.Id_Insumo_Ins " +
                "LEFT JOIN Productos p ON v.Id_Producto_VI = p.Id_Producto_Pr " +
                "LEFT JOIN TamanosProducto t ON v.Id_Tamano_VI = t.Id_Tamano_T " +
                "LEFT JOIN Productos pt ON t.Id_Producto_T = pt.Id_Producto_Pr " +
                "LEFT JOIN ExtrasProducto e ON v.Id_Extra_VI = e.Id_Extra_E " +
                "LEFT JOIN Productos pe ON e.Id_Producto_E = pe.Id_Producto_Pr ";
        }

        public DataTable getTablaVinculos()
        {
            return ds.ObtenerTabla("Vinculos",
                consultaBaseVinculos() + "ORDER BY Producto, Tipo, Opcion, Insumo");
        }

        // Todo lo que descuenta un producto: lo suyo, el de sus tamaños y el de sus extras
        public DataTable getTablaVinculosxProducto(int idProducto)
        {
            return ds.ObtenerTabla("Vinculos",
                consultaBaseVinculos() +
                "WHERE COALESCE(v.Id_Producto_VI, t.Id_Producto_T, e.Id_Producto_E) = " + idProducto +
                " ORDER BY Tipo, Opcion, Insumo");
        }

        public DataTable getTablaVinculosxInsumo(int idInsumo)
        {
            return ds.ObtenerTabla("Vinculos",
                consultaBaseVinculos() + "WHERE v.Id_Insumo_VI = " + idInsumo +
                " ORDER BY Producto, Tipo, Opcion");
        }
    }
}