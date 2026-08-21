using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DaoCategoria
    {
        AccesoDatos ds = new AccesoDatos();

        // Las 4 categorías de nivel superior (Comidas, Bebidas, Guarniciones, Postres)
        public DataTable getCategoriasPadre()
        {
            return ds.ObtenerTabla("CategoriasPadre",
                "SELECT Id_Categoria_C AS Id, Nombre_C AS Nombre " +
                "FROM Categorias WHERE Id_CategoriaPadre_C IS NULL AND Activo_C = 1 " +
                "ORDER BY Nombre_C");
        }

        // Las subcategorías de una categoría padre (ej: las 9 de "Comidas")
        public DataTable getSubcategorias(int idPadre)
        {
            return ds.ObtenerTabla("Subcategorias",
                "SELECT Id_Categoria_C AS Id, Nombre_C AS Nombre " +
                "FROM Categorias WHERE Id_CategoriaPadre_C = " + idPadre + " AND Activo_C = 1 " +
                "ORDER BY Nombre_C");
        }

        // Todas las categorías donde SÍ se puede colgar un producto directamente
        // (o sea, las que NO tienen hijos: Bebidas, Guarniciones, Postres,
        // y las 9 subcategorías de Comidas — "Comidas" en sí queda afuera)
        public DataTable getCategoriasSeleccionables()
        {
            return ds.ObtenerTabla("CategoriasSeleccionables",
                "SELECT Id_Categoria_C AS Id, Nombre_C AS Nombre " +
                "FROM Categorias " +
                "WHERE Activo_C = 1 " +
                "AND Id_Categoria_C NOT IN (SELECT DISTINCT Id_CategoriaPadre_C FROM Categorias WHERE Id_CategoriaPadre_C IS NOT NULL) " +
                "ORDER BY Nombre_C");
        }
    }
}