using Datos;
using Entidades;
using System.Data;

namespace Negocio
{
    public class NegocioVendedor
    {
        public bool agregarVendedor(string nombreUsuario, string contrasena, string nombre, string apellido, string dni)
        {
            int cantFilas = 0;

            DaoVendedor dao = new DaoVendedor();
            Vendedor ven = new Vendedor();
            ven.setNombre_Ve(nombre);
            ven.setApellido_Ve(apellido);
            ven.setDni_Ve(dni);

            Usuario usu = new Usuario();
            usu.setNombreUsuario_U(nombreUsuario);
            usu.setContrasena_U(contrasena);

            if (dao.ExisteVendedorxDni(ven) == false)
            {
                cantFilas = dao.agregarVendedor(ven, usu);
            }

            if (cantFilas >= 1)
                return true;
            else
                return false;
        }

        public bool eliminarVendedor(int idUsuario)
        {
            int cantFilas = 0;

            DaoVendedor dao = new DaoVendedor();
            Vendedor ven = new Vendedor();
            ven.setId_Usuario_Ve(idUsuario);

            cantFilas = dao.eliminarVendedor(ven);

            if (cantFilas == 1)
                return true;
            else
                return false;
        }

        public DataTable getTabla()
        {
            DaoVendedor dao = new DaoVendedor();
            return dao.getTablaVendedores();
        }
        public int buscarUsuarioPorNombre(string nombreUsuario)
        {
            DaoVendedor dao = new DaoVendedor();
            return dao.buscarUsuarioPorNombre(nombreUsuario);
        }

        public bool reactivarVendedor(int idUsuario, string contrasena, string nombre, string apellido, string dni)
        {
            DaoVendedor dao = new DaoVendedor();
            return dao.reactivarVendedor(idUsuario, contrasena, nombre, apellido, dni);
        }
        public bool modificarVendedor(int idUsuario, string nombreUsuario, string nombre, string apellido, string dni, bool activo)
        {
            DaoVendedor dao = new DaoVendedor();
            return dao.modificarVendedor(idUsuario, nombreUsuario, nombre, apellido, dni, activo);
        }
        public bool activarVendedor(int idUsuario)
        {
            DaoVendedor dao = new DaoVendedor();
            return dao.activarVendedor(idUsuario);
        }
    }
}