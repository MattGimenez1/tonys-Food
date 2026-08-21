using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DaoVendedor
    {
        AccesoDatos ds = new AccesoDatos();

        public bool ExisteVendedorxDni(Vendedor ven)
        {
            string consulta = "SELECT * FROM Vendedores WHERE Dni_Ve = '" + ven.getDni_Ve() + "'";
            return ds.existe(consulta);
        }

        public int agregarVendedor(Vendedor ven, Usuario usu)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosVendedorAgregar(ref comando, ven, usu);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarVendedor");
        }

        private void ArmarParametrosVendedorAgregar(ref SqlCommand comando, Vendedor ven, Usuario usu)
        {
            SqlParameter param = new SqlParameter();
            param = comando.Parameters.Add("@NombreUsuario_U", SqlDbType.NVarChar);
            param.Value = usu.getNombreUsuario_U();
            param = comando.Parameters.Add("@Contrasena_U", SqlDbType.NVarChar);
            param.Value = usu.getContrasena_U();
            param = comando.Parameters.Add("@Nombre_Ve", SqlDbType.NVarChar);
            param.Value = ven.getNombre_Ve();
            param = comando.Parameters.Add("@Apellido_Ve", SqlDbType.NVarChar);
            param.Value = ven.getApellido_Ve();
            param = comando.Parameters.Add("@Dni_Ve", SqlDbType.NVarChar);
            param.Value = ven.getDni_Ve();
        }

        public int eliminarVendedor(Vendedor ven)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosVendedorEliminar(ref comando, ven);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spEliminarVendedor");
        }

        private void ArmarParametrosVendedorEliminar(ref SqlCommand comando, Vendedor ven)
        {
            SqlParameter param = new SqlParameter();
            param = comando.Parameters.Add("@Id_Usuario_Ve", SqlDbType.Int);
            param.Value = ven.getId_Usuario_Ve();
        }

        public DataTable getTablaVendedores()
        {
            return ds.ObtenerTabla("Vendedores",
                "SELECT v.Id_Usuario_Ve AS Id, v.Nombre_Ve AS Nombre, v.Apellido_Ve AS Apellido, " +
                "v.Dni_Ve AS Dni, u.NombreUsuario_U AS NombreUsuario, CAST(u.Activo_U AS INT) AS Activo " +
                "FROM Vendedores v " +
                "INNER JOIN Usuarios u ON v.Id_Usuario_Ve = u.Id_Usuario_U");
        }

        public int buscarUsuarioPorNombre(string nombreUsuario)
        {
            DataTable tabla = ds.ObtenerTabla("Usuario",
                "SELECT Id_Usuario_U AS Id, Activo_U AS Activo FROM Usuarios WHERE NombreUsuario_U = '" + nombreUsuario + "'");

            if (tabla.Rows.Count == 0)
                return 0;

            bool activo = Convert.ToBoolean(tabla.Rows[0]["Activo"]);
            if (activo)
                return -1;

            return Convert.ToInt32(tabla.Rows[0]["Id"]);
        }

        public bool reactivarVendedor(int idUsuario, string contrasena, string nombre, string apellido, string dni)
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Parameters.AddWithValue("@Id_Usuario", idUsuario);
                comando.Parameters.AddWithValue("@Contrasena_U", contrasena);
                comando.Parameters.AddWithValue("@Nombre_Ve", nombre);
                comando.Parameters.AddWithValue("@Apellido_Ve", apellido);
                comando.Parameters.AddWithValue("@Dni_Ve", dni);

                int filas = ds.EjecutarProcedimientoAlmacenado(comando, "spReactivarVendedor");
                return filas > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool modificarVendedor(int idUsuario, string nombreUsuario, string nombre, string apellido, string dni, bool activo)
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Parameters.AddWithValue("@Id_Usuario", idUsuario);
                comando.Parameters.AddWithValue("@NombreUsuario_U", nombreUsuario);
                comando.Parameters.AddWithValue("@Nombre_Ve", nombre);
                comando.Parameters.AddWithValue("@Apellido_Ve", apellido);
                comando.Parameters.AddWithValue("@Dni_Ve", dni);
                comando.Parameters.AddWithValue("@Activo_U", activo);

                int filas = ds.EjecutarProcedimientoAlmacenado(comando, "spModificarVendedor");
                return filas > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool activarVendedor(int idUsuario)
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Parameters.AddWithValue("@Id_Usuario_Ve", idUsuario);
                int filas = ds.EjecutarProcedimientoAlmacenado(comando, "spActivarVendedor");
                return filas > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}