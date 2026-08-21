using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto
    {
        private int Id_Producto_Pr;
        private string Nombre_Pr;
        private int Id_Categoria_Pr;
        private decimal Precio_Pr;
        private bool Activo_Pr;

        public Producto() { }

        public int getId_Producto_Pr() { return Id_Producto_Pr; }
        public void setId_Producto_Pr(int id) { Id_Producto_Pr = id; }

        public string getNombre_Pr() { return Nombre_Pr; }
        public void setNombre_Pr(string nombre) { Nombre_Pr = nombre; }

        public int getId_Categoria_Pr() { return Id_Categoria_Pr; }
        public void setId_Categoria_Pr(int id) { Id_Categoria_Pr = id; }

        public decimal getPrecio_Pr() { return Precio_Pr; }
        public void setPrecio_Pr(decimal precio) { Precio_Pr = precio; }

        public bool getActivo_Pr() { return Activo_Pr; }
        public void setActivo_Pr(bool activo) { Activo_Pr = activo; }
    }
}