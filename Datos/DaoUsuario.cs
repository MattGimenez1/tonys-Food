using Entidades;
using System.Data;

namespace Datos
{
    public class DaoUsuario
    {
        AccesoDatos ds = new AccesoDatos();

        public bool ValidarUsuario(Usuario usu)
        {
            string consulta = "SELECT * FROM Usuarios WHERE NombreUsuario_U = '" + usu.getNombreUsuario_U() +
                               "' AND Contrasena_U = '" + usu.getContrasena_U() + "' AND Activo_U = 1";
            return ds.existe(consulta);
        }

        public bool EsAdministrador(int idUsuario)
        {
            string consulta = "SELECT * FROM Administrador WHERE Id_Usuario_A = " + idUsuario;
            return ds.existe(consulta);
        }

        public bool EsVendedor(int idUsuario)
        {
            string consulta = "SELECT * FROM Vendedores WHERE Id_Usuario_Ve = " + idUsuario;
            return ds.existe(consulta);
        }

        public DataTable getUsuarioPorNombre(Usuario usu)
        {
            return ds.ObtenerTabla("Usuarios",
                "SELECT Id_Usuario_U AS Id, NombreUsuario_U AS NombreUsuario, Activo_U AS Activo " +
                "FROM Usuarios WHERE NombreUsuario_U = '" + usu.getNombreUsuario_U() + "'");
        }
    }
}