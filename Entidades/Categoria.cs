using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal class Categoria
    {
        private int Id_Categoria_C;
        private string Nombre_C;
        private int? Id_CategoriaPadre_C; // puede ser null (categoría de nivel superior)
        private bool Activo_C;

        public Categoria() { }

        public int getId_Categoria_C() { return Id_Categoria_C; }
        public void setId_Categoria_C(int id) { Id_Categoria_C = id; }

        public string getNombre_C() { return Nombre_C; }
        public void setNombre_C(string nombre) { Nombre_C = nombre; }

        public int? getId_CategoriaPadre_C() { return Id_CategoriaPadre_C; }
        public void setId_CategoriaPadre_C(int? id) { Id_CategoriaPadre_C = id; }

        public bool getActivo_C() { return Activo_C; }
        public void setActivo_C(bool activo) { Activo_C = activo; }
    }
}
