using System;
using System.Drawing;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace Vistas
{
    public partial class frmToastPago : Form
    {
        public frmToastPago(string mensajeVisual, string mensajeHablado)
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.BackColor = Color.FromArgb(40, 40, 40);
            this.Size = new Size(320, 80);
            this.TopMost = true;

            Rectangle areaPantalla = Screen.PrimaryScreen.WorkingArea;
            this.Location = new Point(areaPantalla.Width - this.Width - 20, areaPantalla.Height - this.Height - 20);

            Label lbl = new Label();
            lbl.Text = mensajeVisual;
            lbl.ForeColor = Color.White;
            lbl.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Dock = DockStyle.Fill;
            this.Controls.Add(lbl);

            SpeechSynthesizer sintetizador = new SpeechSynthesizer();
            sintetizador.SpeakAsync(mensajeHablado); // no bloquea la pantalla mientras habla

            Timer temporizador = new Timer();
            temporizador.Interval = 4000;
            temporizador.Tick += (s, e) => { temporizador.Stop(); this.Close(); };
            temporizador.Start();
        }

        public static void Mostrar(decimal monto, string nombrePagador = null)
        {
            string mensajeVisual = "💰 Pago recibido: $" + monto.ToString("N0");
            string mensajeHablado = "Se ha recibido un pago de " + monto.ToString("N0") + " pesos";

            frmToastPago toast = new frmToastPago(mensajeVisual, mensajeHablado);
            toast.Show();
        }
    }
}