using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DaoOpciones
    {
        AccesoDatos ds = new AccesoDatos();

        // ========== CONSULTAS ==========

        public DataTable getIngredientesQuitables(int idProducto)
        {
            return ds.ObtenerTabla("Ingredientes",
                "SELECT Id_Ingrediente_I AS Id, Nombre_I AS Nombre " +
                "FROM IngredientesQuitables WHERE Id_Producto_I = " + idProducto);
        }

        public DataTable getExtras(int idProducto)
        {
            return ds.ObtenerTabla("Extras",
                "SELECT Id_Extra_E AS Id, Nombre_E AS Nombre, PrecioAdicional_E AS Precio " +
                "FROM ExtrasProducto WHERE Id_Producto_E = " + idProducto);
        }

        public DataTable getTamanos(int idProducto)
        {
            return ds.ObtenerTabla("Tamanos",
                "SELECT Id_Tamano_T AS Id, Nombre_T AS Nombre, Precio_T AS Precio " +
                "FROM TamanosProducto WHERE Id_Producto_T = " + idProducto);
        }

        // ========== ALTA ==========

        public bool agregarTamano(int idProducto, string nombre, decimal precio)
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Parameters.AddWithValue("@Id_Producto_T", idProducto);
                comando.Parameters.AddWithValue("@Nombre_T", nombre);
                comando.Parameters.AddWithValue("@Precio_T", precio);
                int filas = ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarTamano");
                return filas > 0;
            }
            catch (Exception) { return false; }
        }

        public bool agregarExtra(int idProducto, string nombre, decimal precioAdicional)
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Parameters.AddWithValue("@Id_Producto_E", idProducto);
                comando.Parameters.AddWithValue("@Nombre_E", nombre);
                comando.Parameters.AddWithValue("@PrecioAdicional_E", precioAdicional);
                int filas = ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarExtra");
                return filas > 0;
            }
            catch (Exception) { return false; }
        }

        public bool agregarIngrediente(int idProducto, string nombre)
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Parameters.AddWithValue("@Id_Producto_I", idProducto);
                comando.Parameters.AddWithValue("@Nombre_I", nombre);
                int filas = ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarIngrediente");
                return filas > 0;
            }
            catch (Exception) { return false; }
        }

        // ========== BAJA ==========

        public bool eliminarTamano(int idTamano)
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Parameters.AddWithValue("@Id_Tamano_T", idTamano);
                int filas = ds.EjecutarProcedimientoAlmacenado(comando, "spEliminarTamano");
                return filas > 0;
            }
            catch (Exception) { return false; }
        }

        public bool eliminarExtra(int idExtra)
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Parameters.AddWithValue("@Id_Extra_E", idExtra);
                int filas = ds.EjecutarProcedimientoAlmacenado(comando, "spEliminarExtra");
                return filas > 0;
            }
            catch (Exception) { return false; }
        }

        public bool eliminarIngrediente(int idIngrediente)
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Parameters.AddWithValue("@Id_Ingrediente_I", idIngrediente);
                int filas = ds.EjecutarProcedimientoAlmacenado(comando, "spEliminarIngrediente");
                return filas > 0;
            }
            catch (Exception) { return false; }
        }

        public bool modificarTamano(int idTamano, string nombre, decimal precio)
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Parameters.AddWithValue("@Id_Tamano_T", idTamano);
                comando.Parameters.AddWithValue("@Nombre_T", nombre);
                comando.Parameters.AddWithValue("@Precio_T", precio);
                int filas = ds.EjecutarProcedimientoAlmacenado(comando, "spModificarTamano");
                return filas > 0;
            }
            catch (Exception) { return false; }
        }

        public bool modificarExtra(int idExtra, string nombre, decimal precioAdicional)
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Parameters.AddWithValue("@Id_Extra_E", idExtra);
                comando.Parameters.AddWithValue("@Nombre_E", nombre);
                comando.Parameters.AddWithValue("@PrecioAdicional_E", precioAdicional);
                int filas = ds.EjecutarProcedimientoAlmacenado(comando, "spModificarExtra");
                return filas > 0;
            }
            catch (Exception) { return false; }
        }

        public bool modificarIngrediente(int idIngrediente, string nombre)
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Parameters.AddWithValue("@Id_Ingrediente_I", idIngrediente);
                comando.Parameters.AddWithValue("@Nombre_I", nombre);
                int filas = ds.EjecutarProcedimientoAlmacenado(comando, "spModificarIngrediente");
                return filas > 0;
            }
            catch (Exception) { return false; }
        }


    }
}