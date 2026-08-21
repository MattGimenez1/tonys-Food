using Datos;
using Entidades;
using System.Data;

namespace Negocio
{
    public class NegocioUsuario
    {
        public Usuario login(string nombreUsuario, string contrasena)
        {
            DaoUsuario dao = new DaoUsuario();
            Usuario usu = new Usuario();
            usu.setNombreUsuario_U(nombreUsuario);
            usu.setContrasena_U(contrasena);

            // Primero validamos que el usuario/contraseña sean correctos
            if (dao.ValidarUsuario(usu) == false)
                return null;

            // Si es válido, buscamos sus datos completos (Id, etc.)
            DataTable tabla = dao.getUsuarioPorNombre(usu);

            if (tabla.Rows.Count != 1)
                return null;

            Usuario usuarioCompleto = new Usuario();
            usuarioCompleto.setId_Usuario_U((int)tabla.Rows[0]["Id"]);
            usuarioCompleto.setNombreUsuario_U(tabla.Rows[0]["NombreUsuario"].ToString());
            usuarioCompleto.setActivo_U(true);

            return usuarioCompleto;
        }

        public bool esAdministrador(int idUsuario)
        {
            DaoUsuario dao = new DaoUsuario();
            return dao.EsAdministrador(idUsuario);
        }

        public bool esVendedor(int idUsuario)
        {
            DaoUsuario dao = new DaoUsuario();
            return dao.EsVendedor(idUsuario);
        }
    }
}