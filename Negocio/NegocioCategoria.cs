using System.Data;
using Datos;

namespace Negocio
{
    public class NegocioCategoria
    {
        DaoCategoria dao = new DaoCategoria();

        public DataTable getCategoriasPadre()
        {
            return dao.getCategoriasPadre();
        }

        public DataTable getSubcategorias(int idPadre)
        {
            return dao.getSubcategorias(idPadre);
        }

        public DataTable getCategoriasSeleccionables()
        {
            return dao.getCategoriasSeleccionables();
        }
    }
}