using System;
using System.Data;
using System.Windows.Forms;
using Entidades;
using Negocio;

namespace Vistas.Usuarios.administrador.Control_Diario
{
    public partial class formularioControlDiario : Form
    {
        private Usuario usuarioActual;
        private NegocioVenta negVenta = new NegocioVenta();

        public formularioControlDiario(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
            lbl_Usuario.Text = "Usuario: " + usuario.getNombreUsuario_U();
        }

        private void formularioControlDiario_Load(object sender, EventArgs e)
        {
            ConfigurarGrilla();
            btn_Hoy_Click(sender, e); // arranca mostrando el día de hoy
        }

        private void ConfigurarGrilla()
        {
            dgv_Ventas.TabStop = false;
            dgv_Ventas.AutoGenerateColumns = false;
            dgv_Ventas.Columns.Clear();

            dgv_Ventas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colId",
                HeaderText = "Id",
                DataPropertyName = "Id",
                Visible = false
            });

            dgv_Ventas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colFecha",
                HeaderText = "Hora",
                DataPropertyName = "Fecha",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "HH:mm" }
            });

            dgv_Ventas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colVendedor",
                HeaderText = "Vendedor",
                DataPropertyName = "Vendedor",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgv_Ventas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTotal",
                HeaderText = "Total",
                DataPropertyName = "Total",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C0" }
            });
        }

        private void CargarDatos(DateTime desde, DateTime hasta, string etiquetaPeriodo)
        {
            dgv_Ventas.SelectionChanged -= dgv_Ventas_SelectionChanged;

            lbl_Fecha.Text = etiquetaPeriodo;

            DataTable tabla = negVenta.getTablaVentasPorRango(desde, hasta);

            dgv_Ventas.DataSource = null;
            dgv_Ventas.DataSource = tabla;
            dgv_Ventas.ClearSelection();
            dgv_Ventas.CurrentCell = null;

            lbl_ValorVentas.Text = tabla.Rows.Count.ToString();

            decimal total = 0;
            foreach (DataRow fila in tabla.Rows)
            {
                total += Convert.ToDecimal(fila["Total"]);
            }
            lbl_ValorTotal.Text = "$" + total.ToString("N0");

            lbl_ValorProducto.Text = negVenta.getProductoMasVendidoPorRango(desde, hasta);

            dgv_Ventas.SelectionChanged += dgv_Ventas_SelectionChanged;
        }

        private void btn_Hoy_Click(object sender, EventArgs e)
        {
            DateTime hoy = DateTime.Now.Date;
            CargarDatos(hoy, hoy, "Hoy: " + hoy.ToString("dd/MM/yyyy"));
        }

        private void btn_EsteMes_Click(object sender, EventArgs e)
        {
            DateTime hoy = DateTime.Now.Date;
            DateTime primerDiaDelMes = new DateTime(hoy.Year, hoy.Month, 1);
            CargarDatos(primerDiaDelMes, hoy, "Este mes: " + primerDiaDelMes.ToString("MM/yyyy"));
        }

        private void btn_Todo_Click(object sender, EventArgs e)
        {
            DateTime desdeElPrincipio = new DateTime(2000, 1, 1); // fecha bien vieja, para traer todo el historial
            DateTime hoy = DateTime.Now.Date;
            CargarDatos(desdeElPrincipio, hoy, "Historial completo");
        }

        private void btn_ControlDiario_Click(object sender, EventArgs e)
        {
            // Ya estamos en Control Diario, no hace falta nada acá
        }

        private void btn_Volver_Click(object sender, EventArgs e)
        {
            formularioPrincipal principal = new formularioPrincipal(usuarioActual);
            principal.Show();
            this.Close();
        }

        private void dgv_Ventas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_Ventas.CurrentRow == null) return;

            int idVenta = Convert.ToInt32(dgv_Ventas.CurrentRow.Cells["colId"].Value);
            MostrarDetalleVenta(idVenta);
        }
        private void MostrarDetalleVenta(int idVenta)
        {
            DataTable detalle = negVenta.getDetalleVentaxId(idVenta);

            if (detalle.Rows.Count == 0)
            {
                MessageBox.Show("No se encontró el detalle de esta venta.");
                return;
            }

            string texto = "===== DETALLE DE VENTA N° " + idVenta + " =====\n\n";
            decimal total = 0;

            foreach (DataRow fila in detalle.Rows)
            {
                string producto = fila["Producto"].ToString();
                int cantidad = Convert.ToInt32(fila["Cantidad"]);
                decimal subtotal = Convert.ToDecimal(fila["Subtotal"]);

                texto += cantidad + "x " + producto.PadRight(20) + " $" + subtotal.ToString("N0") + "\n";
                total += subtotal;
            }

            texto += "\n------------------------\n";
            texto += "TOTAL: $" + total.ToString("N0");

            MessageBox.Show(texto, "Detalle de venta");
        }
    }
}