using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Negocio;

namespace Vistas
{
    public partial class frmPersonalizarProducto : Form
    {
        private int idProducto;
        private string nombreProducto;
        private decimal precioBase;
        private NegocioOpciones negOpciones = new NegocioOpciones();

        // Lo que va a leer quien abrió esta ventana, después de cerrarla
        public bool Confirmado { get; private set; } = false;
        public decimal PrecioFinal { get; private set; } = 0;
        public string ResumenPersonalizacion { get; private set; } = "";
        public int Cantidad { get; private set; } = 1;

        // Controles dinámicos que armamos en tiempo de ejecución
        private RadioButton[] radiosTamano;
        private decimal[] preciosTamano;
        private string[] nombresTamano;

        private List<(string Nombre, decimal Precio, NumericUpDown Cantidad)> extras =
            new List<(string, decimal, NumericUpDown)>();

        private List<(string Nombre, CheckBox Check)> ingredientes =
            new List<(string, CheckBox)>();

        private TextBox txt_Aclaraciones;

        public frmPersonalizarProducto(int idProducto, string nombreProducto, decimal precioBase)
        {
            InitializeComponent();
            this.idProducto = idProducto;
            this.nombreProducto = nombreProducto;
            this.precioBase = precioBase;

            lbl_NombreProducto.Text = nombreProducto;
            nud_Cantidad.ValueChanged += (s, e) => ActualizarSubtotal();
            ArmarContenido();
            ActualizarSubtotal();
        }

        private void ArmarContenido()
        {
            int y = 10;

            // ===== TAMAÑOS =====
            DataTable tablaTamanos = negOpciones.getTamanos(idProducto);
            if (tablaTamanos.Rows.Count > 0)
            {
                Label lblTitulo = new Label { Text = "Tamaño", Font = new Font("Segoe UI", 10F, FontStyle.Bold), Location = new Point(10, y), AutoSize = true };
                pnl_Contenido.Controls.Add(lblTitulo);
                y += 26;

                radiosTamano = new RadioButton[tablaTamanos.Rows.Count];
                preciosTamano = new decimal[tablaTamanos.Rows.Count];
                nombresTamano = new string[tablaTamanos.Rows.Count];

                for (int i = 0; i < tablaTamanos.Rows.Count; i++)
                {
                    string nombre = tablaTamanos.Rows[i]["Nombre"].ToString();
                    decimal precio = Convert.ToDecimal(tablaTamanos.Rows[i]["Precio"]);

                    nombresTamano[i] = nombre;
                    preciosTamano[i] = precio;

                    RadioButton rb = new RadioButton
                    {
                        Text = nombre + " — $" + precio.ToString("N0"),
                        Location = new Point(20, y),
                        AutoSize = true,
                        Checked = (i == 0) // el primero viene tildado por defecto
                    };
                    rb.CheckedChanged += (s, e) => ActualizarSubtotal();
                    radiosTamano[i] = rb;
                    pnl_Contenido.Controls.Add(rb);
                    y += 26;
                }
                y += 10;
            }

            // ===== EXTRAS =====
            DataTable tablaExtras = negOpciones.getExtras(idProducto);
            if (tablaExtras.Rows.Count > 0)
            {
                Label lblTitulo = new Label { Text = "Extras", Font = new Font("Segoe UI", 10F, FontStyle.Bold), Location = new Point(10, y), AutoSize = true };
                pnl_Contenido.Controls.Add(lblTitulo);
                y += 26;

                foreach (DataRow fila in tablaExtras.Rows)
                {
                    string nombre = fila["Nombre"].ToString();
                    decimal precio = Convert.ToDecimal(fila["Precio"]);

                    Label lbl = new Label
                    {
                        Text = nombre + " (+$" + precio.ToString("N0") + " c/u)",
                        Location = new Point(20, y + 3),
                        AutoSize = false,
                        Width = 260,
                        Height = 20,
                        AutoEllipsis = true // si no entra, corta con "..." en vez de solaparse
                    };
                    NumericUpDown numeric = new NumericUpDown { Minimum = 0, Maximum = 20, Value = 0, Location = new Point(290, y), Width = 60 };
                    numeric.ValueChanged += (s, e) => ActualizarSubtotal();

                    pnl_Contenido.Controls.Add(lbl);
                    pnl_Contenido.Controls.Add(numeric);
                    extras.Add((nombre, precio, numeric));
                    y += 30;
                }
                y += 10;
            }

            // ===== INGREDIENTES PARA QUITAR =====
            DataTable tablaIngredientes = negOpciones.getIngredientesQuitables(idProducto);
            if (tablaIngredientes.Rows.Count > 0)
            {
                Label lblTitulo = new Label { Text = "Quitar ingredientes", Font = new Font("Segoe UI", 10F, FontStyle.Bold), Location = new Point(10, y), AutoSize = true };
                pnl_Contenido.Controls.Add(lblTitulo);
                y += 26;

                foreach (DataRow fila in tablaIngredientes.Rows)
                {
                    string nombre = fila["Nombre"].ToString();
                    CheckBox chk = new CheckBox { Text = "Sin " + nombre, Location = new Point(20, y), AutoSize = true };
                    pnl_Contenido.Controls.Add(chk);
                    ingredientes.Add((nombre, chk));
                    y += 26;
                }
                y += 10;
            }

            // ===== ACLARACIONES =====
            Label lblAclaraciones = new Label { Text = "Aclaraciones", Font = new Font("Segoe UI", 10F, FontStyle.Bold), Location = new Point(10, y), AutoSize = true };
            pnl_Contenido.Controls.Add(lblAclaraciones);
            y += 26;

            txt_Aclaraciones = new TextBox { Multiline = true, Location = new Point(10, y), Size = new Size(300, 60) };
            pnl_Contenido.Controls.Add(txt_Aclaraciones);
        }

        private void ActualizarSubtotal()
        {
            decimal total = precioBase;

            if (radiosTamano != null)
            {
                for (int i = 0; i < radiosTamano.Length; i++)
                {
                    if (radiosTamano[i].Checked)
                    {
                        total = preciosTamano[i]; // el tamaño reemplaza el precio base
                        break;
                    }
                }
            }

            foreach (var extra in extras)
            {
                total += extra.Precio * extra.Cantidad.Value;
            }

            decimal totalConCantidad = total * nud_Cantidad.Value;
            lbl_Subtotal.Text = "$" + totalConCantidad.ToString("N0");
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            decimal total = precioBase;
            string resumen = "";

            if (radiosTamano != null)
            {
                for (int i = 0; i < radiosTamano.Length; i++)
                {
                    if (radiosTamano[i].Checked)
                    {
                        total = preciosTamano[i];
                        resumen += nombresTamano[i] + ", ";
                        break;
                    }
                }
            }

            foreach (var extra in extras)
            {
                if (extra.Cantidad.Value > 0)
                {
                    total += extra.Precio * extra.Cantidad.Value;
                    resumen += "+" + extra.Cantidad.Value + " " + extra.Nombre + ", ";
                }
            }

            foreach (var ing in ingredientes)
            {
                if (ing.Check.Checked)
                {
                    resumen += "Sin " + ing.Nombre + ", ";
                }
            }

            if (resumen.EndsWith(", "))
                resumen = resumen.Substring(0, resumen.Length - 2);

            if (!string.IsNullOrWhiteSpace(txt_Aclaraciones.Text))
            {
                if (resumen != "") resumen += " — ";
                resumen += "Aclaración: " + txt_Aclaraciones.Text.Trim();
            }

            PrecioFinal = total;
            ResumenPersonalizacion = resumen;
            Cantidad = (int)nud_Cantidad.Value;
            Confirmado = true;
            this.Close();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            Confirmado = false;
            this.Close();
        }
    }
}