using Entidades;
using Negocio;
using System;
using System.Data;
using System.Windows.Forms;

namespace Vistas.Usuarios.administrador.Menus
{
    public partial class formularioMenus : Form
    {
        private Usuario usuarioActual;
        private NegocioProductos negProductos = new NegocioProductos();
        private NegocioCategoria negCategoria = new NegocioCategoria();
        private int idProductoSeleccionado = 0;
        private bool productoActivoActual = true;

        public formularioMenus(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
            lbl_Usuario.Text = "Usuario: " + usuario.getNombreUsuario_U();
            lbl_Fecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void formularioMenus_Load(object sender, EventArgs e)
        {
            CargarComboCategorias();
            ConfigurarGrilla();
            RefrescarGrilla();
            LimpiarFormulario();
        }

        private void CargarComboCategorias()
        {
            DataTable tabla = negCategoria.getCategoriasSeleccionables();
            cmb_Categoria.DataSource = tabla;
            cmb_Categoria.DisplayMember = "Nombre";
            cmb_Categoria.ValueMember = "Id";
            cmb_Categoria.SelectedIndex = -1; // arranca sin nada elegido
        }

        private void ConfigurarGrilla()
        {
            dgv_Productos.TabStop = false;
            dgv_Productos.AutoGenerateColumns = false;
            dgv_Productos.Columns.Clear();
            dgv_Productos.AllowUserToAddRows = false;
            dgv_Productos.ReadOnly = true;
            dgv_Productos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Productos.MultiSelect = false;

            dgv_Productos.Columns.Add(new DataGridViewTextBoxColumn { Name = "colId", HeaderText = "Id", DataPropertyName = "Id", Visible = false });
            dgv_Productos.Columns.Add(new DataGridViewTextBoxColumn { Name = "colIdCategoria", HeaderText = "IdCategoria", DataPropertyName = "IdCategoria", Visible = false });
            dgv_Productos.Columns.Add(new DataGridViewTextBoxColumn { Name = "colNombre", HeaderText = "Producto", DataPropertyName = "Nombre", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgv_Productos.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCategoria", HeaderText = "Categoría", DataPropertyName = "Categoria", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgv_Productos.Columns.Add(new DataGridViewTextBoxColumn { Name = "colPrecio", HeaderText = "Precio", DataPropertyName = "Precio", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, DefaultCellStyle = new DataGridViewCellStyle { Format = "C0" } });
            dgv_Productos.Columns.Add(new DataGridViewCheckBoxColumn { Name = "colActivo", HeaderText = "Activo", DataPropertyName = "Activo", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });

            dgv_Productos.SelectionChanged += dgv_Productos_SelectionChanged;
        }

        private void RefrescarGrilla()
        {
            dgv_Productos.SelectionChanged -= dgv_Productos_SelectionChanged;
            DataTable tabla = negProductos.getTablaTodos();
            dgv_Productos.DataSource = null;
            dgv_Productos.DataSource = tabla;
            dgv_Productos.ClearSelection();
            dgv_Productos.CurrentCell = null;
            dgv_Productos.SelectionChanged += dgv_Productos_SelectionChanged;
        }

        private void dgv_Productos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_Productos.CurrentRow == null) return;
            DataGridViewRow fila = dgv_Productos.CurrentRow;

            idProductoSeleccionado = Convert.ToInt32(fila.Cells["colId"].Value);
            txt_Nombre.Text = fila.Cells["colNombre"].Value.ToString();
            cmb_Categoria.SelectedValue = Convert.ToInt32(fila.Cells["colIdCategoria"].Value);
            txt_Precio.Text = fila.Cells["colPrecio"].Value.ToString();
            productoActivoActual = Convert.ToBoolean(fila.Cells["colActivo"].Value);
        }

        private void btn_Nuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            idProductoSeleccionado = 0;
            productoActivoActual = true;
            txt_Nombre.Text = "";
            cmb_Categoria.SelectedIndex = -1;
            txt_Precio.Text = "";
            dgv_Productos.ClearSelection();
            dgv_Productos.CurrentCell = null;
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Nombre.Text)) { MessageBox.Show("Ingresá un nombre para el producto."); return; }
            if (cmb_Categoria.SelectedValue == null) { MessageBox.Show("Seleccioná una categoría."); return; }
            decimal precio = 0;
            if (!string.IsNullOrWhiteSpace(txt_Precio.Text) && !decimal.TryParse(txt_Precio.Text, out precio))
            {
                MessageBox.Show("El precio ingresado no es válido.");
                return;
            }

            int idCategoria = Convert.ToInt32(cmb_Categoria.SelectedValue);
            bool resultado;

            if (idProductoSeleccionado == 0)
            {
                resultado = negProductos.agregarProducto(txt_Nombre.Text, idCategoria, precio);
                MessageBox.Show(resultado ? "Producto agregado correctamente." : "Ya existe un producto con ese nombre.");
            }
            else
            {
                resultado = negProductos.modificarProducto(idProductoSeleccionado, txt_Nombre.Text, idCategoria, precio, productoActivoActual);
                MessageBox.Show(resultado ? "Producto actualizado correctamente." : "No se pudo actualizar el producto.");
            }

            RefrescarGrilla();
            LimpiarFormulario();
        }

        private void btn_Menus_Click(object sender, EventArgs e)
        {
            // Ya estamos en Menús, no hace falta nada acá
        }

        private void btn_Volver_Click(object sender, EventArgs e)
        {
            formularioPrincipal principal = new formularioPrincipal(usuarioActual);
            principal.Show();
            this.Close();
        }

        private void btn_DarDeBaja_Click(object sender, EventArgs e)
        {
            if (idProductoSeleccionado == 0) { MessageBox.Show("Seleccioná primero un producto de la lista."); return; }
            DialogResult confirmacion = MessageBox.Show("¿Seguro que querés dar de baja a este producto?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmacion == DialogResult.Yes)
            {
                negProductos.eliminarProducto(idProductoSeleccionado);
                RefrescarGrilla();
                LimpiarFormulario();
            }
        }

        private void btn_DarDeAlta_Click(object sender, EventArgs e)
        {
            if (idProductoSeleccionado == 0) { MessageBox.Show("Seleccioná primero un producto de la lista."); return; }
            bool activado = negProductos.activarProducto(idProductoSeleccionado);
            MessageBox.Show(activado ? "Producto dado de alta correctamente." : "Ocurrió un error.");
            RefrescarGrilla();
            LimpiarFormulario();
        }

        private void btn_Opciones_Click(object sender, EventArgs e)
        {
            if (idProductoSeleccionado == 0)
            {
                MessageBox.Show("Seleccioná primero un producto de la lista.");
                return;
            }

            frmOpcionesProducto ventana = new frmOpcionesProducto(idProductoSeleccionado, txt_Nombre.Text);
            ventana.ShowDialog();
        }
    }
}