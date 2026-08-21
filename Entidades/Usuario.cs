using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        private int Id_Usuario_U;
        private string NombreUsuario_U;
        private string Contrasena_U;
        private bool Activo_U;

        public Usuario() { }

        public int getId_Usuario_U() { return Id_Usuario_U; }
        public void setId_Usuario_U(int id) { Id_Usuario_U = id; }

        public string getNombreUsuario_U() { return NombreUsuario_U; }
        public void setNombreUsuario_U(string nombre) { NombreUsuario_U = nombre; }

        public string getContrasena_U() { return Contrasena_U; }
        public void setContrasena_U(string contrasena) { Contrasena_U = contrasena; }

        public bool getActivo_U() { return Activo_U; }
        public void setActivo_U(bool activo) { Activo_U = activo; }
    }
}
