using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Vendedor
    {
        private int Id_Usuario_Ve;
        private string Nombre_Ve;
        private string Apellido_Ve;
        private string Dni_Ve;

        public Vendedor() { }

        public int getId_Usuario_Ve() { return Id_Usuario_Ve; }
        public void setId_Usuario_Ve(int id) { Id_Usuario_Ve = id; }

        public string getNombre_Ve() { return Nombre_Ve; }
        public void setNombre_Ve(string nombre) { Nombre_Ve = nombre; }

        public string getApellido_Ve() { return Apellido_Ve; }
        public void setApellido_Ve(string apellido) { Apellido_Ve = apellido; }

        public string getDni_Ve() { return Dni_Ve; }
        public void setDni_Ve(string dni) { Dni_Ve = dni; }
    }
}