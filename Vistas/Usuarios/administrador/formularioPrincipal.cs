using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Vistas.Usuarios.administrador.Control_Diario;
using Vistas.Usuarios.administrador.Menus;
using Vistas.Usuarios.administrador.Nueva_Venta;
using Vistas.Usuarios.administrador.Vendedores;

namespace Vistas.Usuarios.administrador
{
    public partial class formularioPrincipal : Form
    {
        private Usuario usuarioActual;

        public formularioPrincipal(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
            lbl_Usuario.Text = "Usuario: " + usuario.getNombreUsuario_U();
            lbl_Fecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void formularioPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void btn_CerrarSession_Click(object sender, EventArgs e)
        {
            login formLogin = new login();
            formLogin.Show();
            this.Close();
        }

        private void btn_Menus_Click(object sender, EventArgs e)
        {
            formularioMenus formMenus = new formularioMenus(usuarioActual);
            formMenus.Show();
            this.Close();
        }

        private void btn_NuevaVenta_Click(object sender, EventArgs e)
        {
            formularioNuevaVenta formNuevaVenta = new formularioNuevaVenta(usuarioActual);
            formNuevaVenta.Show();
            this.Close();
        }

        private void btn_ControlDiario_Click(object sender, EventArgs e)
        {
            formularioControlDiario formControlDiario = new formularioControlDiario(usuarioActual);
            formControlDiario.Show();
            this.Close();
        }

        private void btn_Vendedores_Click(object sender, EventArgs e)
        {
            formularioVendedores formVendedores = new formularioVendedores(usuarioActual);
            formVendedores.Show();
            this.Close();
        }

        
    }
}