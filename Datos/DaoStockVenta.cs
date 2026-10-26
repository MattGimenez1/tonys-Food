using System.Collections.Generic;
using System.Data;
using Entidades;

namespace Datos
{
    public class DaoStockVenta
    {
        AccesoDatos ds = new AccesoDatos();

        // Trae los vínculos que aplican a una línea de venta:
        // los del producto, más los del tamaño elegido, más los de los extras elegidos.
        // IdExtra viene con valor solo en los vínculos de extras (para poder multiplicar por la cantidad pedida).
        public DataTable getVinculosDeLinea(int idProducto, int? idTamano, List<ExtraElegido> extras)
        {
            string sql =
                "SELECT Id_Insumo_VI AS IdInsumo, Cantidad_VI AS Cantidad, Id_Extra_VI AS IdExtra " +
                "FROM VinculosInsumo " +
                "WHERE Id_Producto_VI = " + idProducto;

            if (idTamano.HasValue)
                sql += " OR Id_Tamano_VI = " + idTamano.Value;

            if (extras != null && extras.Count > 0)
            {
                List<string> ids = new List<string>();
                foreach (ExtraElegido ex in extras)
                    ids.Add(ex.getId_Extra().ToString());

                sql += " OR Id_Extra_VI IN (" + string.Join(",", ids) + ")";
            }

            return ds.ObtenerTabla("VinculosLinea", sql);
        }
    }
}