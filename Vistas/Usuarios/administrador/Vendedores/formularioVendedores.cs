using System;
using System.Data;
using System.Windows.Forms;
using Entidades;
using Negocio;

namespace Vistas.Usuarios.administrador.Vendedores
{
    public partial class formularioVendedores : Form
    {
        private Usuario usuarioActual;
        private NegocioVendedor negVendedor = new NegocioVendedor();
        private int idVendedorSeleccionado = 0; // 0 = estamos cargando uno nuevo

        public formularioVendedores(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
            lbl_Usuario.Text = "Usuario: " + usuario.getNombreUsuario_U();
            lbl_Fecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void formularioVendedores_Load(object sender, EventArgs e)
        {
            ConfigurarGrilla();
            RefrescarGrilla();
            LimpiarFormulario();
        }

        private void ConfigurarGrilla()
        {
            dgv_Vendedor.AutoGenerateColumns = false;
            dgv_Vendedor.Columns.Clear();
            dgv_Vendedor.AllowUserToAddRows = false;
            dgv_Vendedor.ReadOnly = true;
            dgv_Vendedor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Vendedor.MultiSelect = false;

            dgv_Vendedor.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colId",
                HeaderText = "Id",
                DataPropertyName = "Id",
                Visible = false
            });

            dgv_Vendedor.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colNombre",
                HeaderText = "Nombre",
                DataPropertyName = "Nombre",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgv_Vendedor.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colApellido",
                HeaderText = "Apellido",
                DataPropertyName = "Apellido",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgv_Vendedor.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colUsuario",
                HeaderText = "Usuario",
                DataPropertyName = "NombreUsuario",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgv_Vendedor.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDni",
                HeaderText = "DNI",
                DataPropertyName = "Dni",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgv_Vendedor.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "colActivo",
                HeaderText = "Activo",
                DataPropertyName = "Activo",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgv_Vendedor.SelectionChanged += dgv_Vendedor_SelectionChanged;
        }

        private void RefrescarGrilla()
        {
            dgv_Vendedor.SelectionChanged -= dgv_Vendedor_SelectionChanged; // desconecto el evento

            DataTable tabla = negVendedor.getTabla();
            dgv_Vendedor.DataSource = null;
            dgv_Vendedor.DataSource = tabla;
            dgv_Vendedor.ClearSelection();
            dgv_Vendedor.CurrentCell = null;

            dgv_Vendedor.SelectionChanged += dgv_Vendedor_SelectionChanged; // lo reconecto
        }

        private void dgv_Vendedor_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_Vendedor.CurrentRow == null) return;

            DataGridViewRow fila = dgv_Vendedor.CurrentRow;

            idVendedorSeleccionado = Convert.ToInt32(fila.Cells["colId"].Value);
            txt_Nombre.Text = fila.Cells["colNombre"].Value.ToString();
            txt_Apellido.Text = fila.Cells["colApellido"].Value.ToString();
            txt_Usuario.Text = fila.Cells["colUsuario"].Value.ToString();
            txt_Dni.Text = fila.Cells["colDni"].Value.ToString();
            
        }

        private void btn_NuevoVendedor_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            idVendedorSeleccionado = 0;
            txt_Nombre.Text = "";
            txt_Apellido.Text = "";
            txt_Usuario.Text = "";
            txt_Dni.Text = "";
            dgv_Vendedor.ClearSelection();
            dgv_Vendedor.CurrentCell = null;
        }

        private void btn_GuardarVendedor_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Nombre.Text) ||
                string.IsNullOrWhiteSpace(txt_Apellido.Text) ||
                string.IsNullOrWhiteSpace(txt_Usuario.Text) ||
                string.IsNullOrWhiteSpace(txt_Dni.Text))
            {
                MessageBox.Show("Completá todos los campos.");
                return;
            }

            if (idVendedorSeleccionado != 0)
            {
                // Estamos EDITANDO un vendedor ya existente
                bool modificado = negVendedor.modificarVendedor(
                    idVendedorSeleccionado, txt_Usuario.Text, txt_Nombre.Text, txt_Apellido.Text, txt_Dni.Text, true);

                MessageBox.Show(modificado ? "Vendedor modificado correctamente." : "Ocurrió un error al modificar.");
                RefrescarGrilla();
                LimpiarFormulario();
                return;
            }

            // Si llegamos acá, estamos CARGANDO uno nuevo
            int idInactivoEncontrado = negVendedor.buscarUsuarioPorNombre(txt_Usuario.Text);

            if (idInactivoEncontrado == -1)
            {
                MessageBox.Show("Ese nombre de usuario ya está en uso por un vendedor activo. Elegí otro.");
                return;
            }

            if (idInactivoEncontrado > 0)
            {
                DialogResult respuesta = MessageBox.Show(
                    "Ese usuario existe pero está dado de baja. ¿Querés darlo de alta con estos datos?",
                    "Usuario inactivo encontrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta != DialogResult.Yes) return;

                bool reactivado = negVendedor.reactivarVendedor(idInactivoEncontrado, txt_Dni.Text, txt_Nombre.Text, txt_Apellido.Text, txt_Dni.Text);
                MessageBox.Show(reactivado ? "Vendedor reactivado correctamente." : "Ocurrió un error al reactivar.");
            }
            else
            {
                bool resultado = negVendedor.agregarVendedor(txt_Usuario.Text, txt_Dni.Text, txt_Nombre.Text, txt_Apellido.Text, txt_Dni.Text);
                MessageBox.Show(resultado ? "Vendedor agregado correctamente." : "Ocurrió un error al agregar.");
            }

            RefrescarGrilla();
            LimpiarFormulario();
        }

        private void btn_DarDeBajaVendedor_Click(object sender, EventArgs e)
        {
            if (idVendedorSeleccionado == 0)
            {
                MessageBox.Show("Seleccioná primero un vendedor de la lista.");
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                "¿Seguro que querés dar de baja a este vendedor?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                negVendedor.eliminarVendedor(idVendedorSeleccionado);
                RefrescarGrilla();
                LimpiarFormulario();
            }
        }

        private void btn_Vendedores_Click(object sender, EventArgs e)
        {
            // Ya estamos en Vendedores, no hace falta nada acá
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            formularioPrincipal principal = new formularioPrincipal(usuarioActual);
            principal.Show();
            this.Close();
        }

        private void btn_DarDeAlta_Click(object sender, EventArgs e)
        {
            if (idVendedorSeleccionado == 0)
            {
                MessageBox.Show("Seleccioná primero un vendedor de la lista.");
                return;
            }

            bool activado = negVendedor.activarVendedor(idVendedorSeleccionado);
            MessageBox.Show(activado ? "Vendedor dado de alta correctamente." : "Ocurrió un error.");

            RefrescarGrilla();
            LimpiarFormulario();
        }

        private void btn_SimularPago_Click(object sender, EventArgs e)
        {
            frmToastPago.Mostrar(50000, "Matías Gimenez");
        }
    }
    
}