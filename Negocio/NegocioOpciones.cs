using System.Data;
using Datos;

namespace Negocio
{
    public class NegocioOpciones
    {
        DaoOpciones dao = new DaoOpciones();

        public DataTable getIngredientesQuitables(int idProducto) => dao.getIngredientesQuitables(idProducto);
        public DataTable getExtras(int idProducto) => dao.getExtras(idProducto);
        public DataTable getTamanos(int idProducto) => dao.getTamanos(idProducto);

        public bool agregarTamano(int idProducto, string nombre, decimal precio) => dao.agregarTamano(idProducto, nombre, precio);
        public bool agregarExtra(int idProducto, string nombre, decimal precioAdicional) => dao.agregarExtra(idProducto, nombre, precioAdicional);
        public bool agregarIngrediente(int idProducto, string nombre) => dao.agregarIngrediente(idProducto, nombre);

        public bool eliminarTamano(int idTamano) => dao.eliminarTamano(idTamano);
        public bool eliminarExtra(int idExtra) => dao.eliminarExtra(idExtra);
        public bool eliminarIngrediente(int idIngrediente) => dao.eliminarIngrediente(idIngrediente);
        public bool modificarTamano(int idTamano, string nombre, decimal precio) => dao.modificarTamano(idTamano, nombre, precio);
        public bool modificarExtra(int idExtra, string nombre, decimal precioAdicional) => dao.modificarExtra(idExtra, nombre, precioAdicional);
        public bool modificarIngrediente(int idIngrediente, string nombre) => dao.modificarIngrediente(idIngrediente, nombre);
    }
}