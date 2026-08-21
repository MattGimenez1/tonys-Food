using Entidades;
using Negocio;
using System;
using System.Windows.Forms;
using Vistas.Usuarios.administrador;
using Vistas.Usuarios.vendedor;

namespace Vistas
{
    public partial class login : Form
    {
        private NegocioUsuario negUsuario = new NegocioUsuario();

        public login()
        {
            InitializeComponent();
            this.Resize += Login_Resize; // se ejecuta cada vez que la ventana cambia de tamaño
            CentrarPanel();
        }

        private void Login_Resize(object sender, EventArgs e)
        {
            CentrarPanel();
        }

        private void CentrarPanel()
        {
            panel1.Left = (this.ClientSize.Width - panel1.Width) / 2;
            panel1.Top = (this.ClientSize.Height - panel1.Height) / 2;
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Ingresar_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txt_Usuario.Text.Trim();
            string contrasena = txt_Contraseña.Text.Trim();

            if (string.IsNullOrEmpty(nombreUsuario) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            Usuario usuarioLogueado = negUsuario.login(nombreUsuario, contrasena);

            if (usuarioLogueado != null)
            {
                if (negUsuario.esAdministrador(usuarioLogueado.getId_Usuario_U()))
                {
                    formularioPrincipal principal = new formularioPrincipal(usuarioLogueado);
                    principal.Show();
                    this.Hide();
                }
                else
                {
                    formularioVendedor venta = new formularioVendedor(usuarioLogueado);
                    venta.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }
        }
    }
}