using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DaoProductos
    {
        AccesoDatos ds = new AccesoDatos();

        // ========== EXISTENCIA ==========

        public bool ExisteProductoxNombre(Producto prod)
        {
            string consulta = "SELECT * FROM Productos WHERE Nombre_Pr = '" + prod.getNombre_Pr() + "'";
            return ds.existe(consulta);
        }

        public bool ExisteProductoxId(Producto prod)
        {
            string consulta = "SELECT * FROM Productos WHERE Id_Producto_Pr = " + prod.getId_Producto_Pr();
            return ds.existe(consulta);
        }

        // ========== ALTA ==========

        public int agregarProducto(Producto prod)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosProductoAgregar(ref comando, prod);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarProducto");
        }

        private void ArmarParametrosProductoAgregar(ref SqlCommand comando, Producto prod)
        {
            SqlParameter param = new SqlParameter();
            param = comando.Parameters.Add("@Nombre_Pr", SqlDbType.NVarChar);
            param.Value = prod.getNombre_Pr();
            param = comando.Parameters.Add("@Id_Categoria_Pr", SqlDbType.Int);
            param.Value = prod.getId_Categoria_Pr();
            param = comando.Parameters.Add("@Precio_Pr", SqlDbType.Decimal);
            param.Value = prod.getPrecio_Pr();
            param = comando.Parameters.Add("@Activo_Pr", SqlDbType.Bit);
            param.Value = prod.getActivo_Pr();
        }

        // ========== MODIFICACIÓN ==========

        public int modificarProducto(Producto prod)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosProductoModificar(ref comando, prod);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spModificarProducto");
        }

        private void ArmarParametrosProductoModificar(ref SqlCommand comando, Producto prod)
        {
            SqlParameter param = new SqlParameter();
            param = comando.Parameters.Add("@Id_Producto_Pr", SqlDbType.Int);
            param.Value = prod.getId_Producto_Pr();
            param = comando.Parameters.Add("@Nombre_Pr", SqlDbType.NVarChar);
            param.Value = prod.getNombre_Pr();
            param = comando.Parameters.Add("@Id_Categoria_Pr", SqlDbType.Int);
            param.Value = prod.getId_Categoria_Pr();
            param = comando.Parameters.Add("@Precio_Pr", SqlDbType.Decimal);
            param.Value = prod.getPrecio_Pr();
            param = comando.Parameters.Add("@Activo_Pr", SqlDbType.Bit);
            param.Value = prod.getActivo_Pr();
        }

        // ========== BAJA (LÓGICA) ==========

        public int eliminarProducto(Producto prod)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosProductoEliminar(ref comando, prod);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spEliminarProducto");
        }

        private void ArmarParametrosProductoEliminar(ref SqlCommand comando, Producto prod)
        {
            SqlParameter param = new SqlParameter();
            param = comando.Parameters.Add("@Id_Producto_Pr", SqlDbType.Int);
            param.Value = prod.getId_Producto_Pr();
        }

        // ========== CONSULTAS ==========
        // Ahora hacemos JOIN con Categorias para mostrar el nombre, aunque
        // guardemos el Id — así la grilla sigue mostrando "Pizzas" en vez de un número

        public DataTable getTablaProductos()
        {
            return ds.ObtenerTabla("Productos",
                "SELECT p.Id_Producto_Pr AS Id, p.Nombre_Pr AS Nombre, " +
                "p.Id_Categoria_Pr AS IdCategoria, c.Nombre_C AS Categoria, " +
                "p.Precio_Pr AS Precio, CAST(p.Activo_Pr AS INT) AS Activo " +
                "FROM Productos p INNER JOIN Categorias c ON p.Id_Categoria_Pr = c.Id_Categoria_C " +
                "WHERE p.Activo_Pr = 1");
        }

        public DataTable getTablaProductosTodos()
        {
            return ds.ObtenerTabla("Productos",
                "SELECT p.Id_Producto_Pr AS Id, p.Nombre_Pr AS Nombre, " +
                "p.Id_Categoria_Pr AS IdCategoria, c.Nombre_C AS Categoria, " +
                "p.Precio_Pr AS Precio, CAST(p.Activo_Pr AS INT) AS Activo " +
                "FROM Productos p INNER JOIN Categorias c ON p.Id_Categoria_Pr = c.Id_Categoria_C");
        }

        public DataTable getTablaProductosxCategoria(int idCategoria)
        {
            return ds.ObtenerTabla("Productos",
                "SELECT p.Id_Producto_Pr AS Id, p.Nombre_Pr AS Nombre, " +
                "p.Id_Categoria_Pr AS IdCategoria, c.Nombre_C AS Categoria, " +
                "p.Precio_Pr AS Precio, CAST(p.Activo_Pr AS INT) AS Activo " +
                "FROM Productos p INNER JOIN Categorias c ON p.Id_Categoria_Pr = c.Id_Categoria_C " +
                "WHERE p.Activo_Pr = 1 AND p.Id_Categoria_Pr = " + idCategoria);
        }

        public bool activarProducto(int idProducto)
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Parameters.AddWithValue("@Id_Producto_Pr", idProducto);
                int filas = ds.EjecutarProcedimientoAlmacenado(comando, "spActivarProducto");
                return filas > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}