using Datos;
using Entidades;
using System.Data;

namespace Negocio
{
    public class NegocioProductos
    {
        public bool agregarProducto(string nombre, int idCategoria, decimal precio)
        {
            int cantFilas = 0;

            DaoProductos dao = new DaoProductos();
            Producto prod = new Producto();
            prod.setNombre_Pr(nombre);
            prod.setId_Categoria_Pr(idCategoria);
            prod.setPrecio_Pr(precio);
            prod.setActivo_Pr(true);

            if (dao.ExisteProductoxNombre(prod) == false)
            {
                cantFilas = dao.agregarProducto(prod);
            }

            return cantFilas >= 1;
        }

        public bool modificarProducto(int idProducto, string nombre, int idCategoria, decimal precio, bool activo)
        {
            int cantFilas = 0;

            DaoProductos dao = new DaoProductos();
            Producto prod = new Producto();
            prod.setId_Producto_Pr(idProducto);
            prod.setNombre_Pr(nombre);
            prod.setId_Categoria_Pr(idCategoria);
            prod.setPrecio_Pr(precio);
            prod.setActivo_Pr(activo);

            if (dao.ExisteProductoxId(prod) == true)
            {
                cantFilas = dao.modificarProducto(prod);
            }

            return cantFilas == 1;
        }

        public bool eliminarProducto(int idProducto)
        {
            int cantFilas = 0;

            DaoProductos dao = new DaoProductos();
            Producto prod = new Producto();
            prod.setId_Producto_Pr(idProducto);

            if (dao.ExisteProductoxId(prod) == true)
            {
                cantFilas = dao.eliminarProducto(prod);
            }

            return cantFilas == 1;
        }

        public DataTable getTabla()
        {
            DaoProductos dao = new DaoProductos();
            return dao.getTablaProductos();
        }

        public DataTable getTablaTodos()
        {
            DaoProductos dao = new DaoProductos();
            return dao.getTablaProductosTodos();
        }

        public DataTable getTablaxCategoria(int idCategoria)
        {
            DaoProductos dao = new DaoProductos();
            return dao.getTablaProductosxCategoria(idCategoria);
        }

        public bool activarProducto(int idProducto)
        {
            DaoProductos dao = new DaoProductos();
            return dao.activarProducto(idProducto);
        }
    }
}