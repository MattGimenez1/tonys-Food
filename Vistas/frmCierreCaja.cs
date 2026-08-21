using System;
using System.Data;
using System.Windows.Forms;
using Entidades;
using Negocio;

namespace Vistas
{
    public partial class frmCierreCaja : Form
    {
        private Usuario usuarioActual;
        private NegocioCierreCaja negCierre = new NegocioCierreCaja();

        private decimal totalEfectivo, totalTransferencia, totalQR, totalGeneral;

        public frmCierreCaja(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
            CargarTotales();
        }

        private void CargarTotales()
        {
            DataTable tabla = negCierre.getTotalesParaCierre();

            if (tabla.Rows.Count == 0)
            {
                MessageBox.Show("No se pudieron calcular los totales.");
                this.Close();
                return;
            }

            totalEfectivo = Convert.ToDecimal(tabla.Rows[0]["TotalEfectivo"]);
            totalTransferencia = Convert.ToDecimal(tabla.Rows[0]["TotalTransferencia"]);
            totalQR = Convert.ToDecimal(tabla.Rows[0]["TotalQR"]);
            totalGeneral = Convert.ToDecimal(tabla.Rows[0]["TotalGeneral"]);

            lbl_Efectivo.Text = "💵 Efectivo: $" + totalEfectivo.ToString("N0");
            lbl_Transferencia.Text = "🏦 Transferencia: $" + totalTransferencia.ToString("N0");
            lbl_QR.Text = "📱 QR/Tarjeta: $" + totalQR.ToString("N0");
            lbl_TotalGeneral.Text = "TOTAL: $" + totalGeneral.ToString("N0");
        }

        private void btn_ConfirmarCierre_Click(object sender, EventArgs e)
        {
            if (totalGeneral == 0)
            {
                DialogResult confirmarVacio = MessageBox.Show(
                    "No hay ventas desde el último cierre. ¿Igual querés registrar el cierre?",
                    "Sin movimientos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmarVacio != DialogResult.Yes) return;
            }

            bool resultado = negCierre.registrarCierre(
                usuarioActual.getId_Usuario_U(), totalEfectivo, totalTransferencia, totalQR, totalGeneral);

            if (resultado)
            {
                MessageBox.Show("Caja cerrada correctamente.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al registrar el cierre.");
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}