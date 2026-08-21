using System;
using System.Data;
using System.Windows.Forms;
using Negocio;

namespace Vistas
{
    public partial class frmOpcionesProducto : Form
    {
        private int idProducto;
        private NegocioOpciones negOpciones = new NegocioOpciones();

        private int idTamanoSeleccionado = 0;
        private int idExtraSeleccionado = 0;
        private int idIngredienteSeleccionado = 0;

        public frmOpcionesProducto(int idProducto, string nombreProducto)
        {
            InitializeComponent();
            this.idProducto = idProducto;
            lbl_NombreProducto.Text = "Opciones de: " + nombreProducto;

            lst_Tamanos.SelectedIndexChanged += lst_Tamanos_SelectedIndexChanged;
            lst_Extras.SelectedIndexChanged += lst_Extras_SelectedIndexChanged;
            lst_Ingredientes.SelectedIndexChanged += lst_Ingredientes_SelectedIndexChanged;

            RefrescarTamanos();
            RefrescarExtras();
            RefrescarIngredientes();
        }

        // ========== TAMAÑOS ==========

        private void RefrescarTamanos()
        {
            lst_Tamanos.SelectedIndexChanged -= lst_Tamanos_SelectedIndexChanged;
            lst_Tamanos.Items.Clear();
            DataTable tabla = negOpciones.getTamanos(idProducto);
            foreach (DataRow fila in tabla.Rows)
            {
                int id = Convert.ToInt32(fila["Id"]);
                string nombre = fila["Nombre"].ToString();
                decimal precio = Convert.ToDecimal(fila["Precio"]);
                lst_Tamanos.Items.Add(new ItemLista { Id = id, Nombre = nombre, Precio = precio, Texto = nombre + " — $" + precio.ToString("N0") });
            }
            lst_Tamanos.SelectedIndexChanged += lst_Tamanos_SelectedIndexChanged;
        }

        private void lst_Tamanos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lst_Tamanos.SelectedItem == null) return;
            ItemLista item = (ItemLista)lst_Tamanos.SelectedItem;
            idTamanoSeleccionado = item.Id;
            txt_NombreTamano.Text = item.Nombre;
            txt_PrecioTamano.Text = item.Precio.ToString();
        }

        private void btn_AgregarTamano_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_NombreTamano.Text))
            {
                MessageBox.Show("Ingresá un nombre para el tamaño.");
                return;
            }
            if (!decimal.TryParse(txt_PrecioTamano.Text, out decimal precio))
            {
                MessageBox.Show("El precio ingresado no es válido.");
                return;
            }

            if (idTamanoSeleccionado != 0)
                negOpciones.modificarTamano(idTamanoSeleccionado, txt_NombreTamano.Text, precio);
            else
                negOpciones.agregarTamano(idProducto, txt_NombreTamano.Text, precio);

            LimpiarTamano();
            RefrescarTamanos();
        }

        private void btn_QuitarTamano_Click(object sender, EventArgs e)
        {
            if (lst_Tamanos.SelectedItem == null)
            {
                MessageBox.Show("Seleccioná un tamaño de la lista.");
                return;
            }
            ItemLista item = (ItemLista)lst_Tamanos.SelectedItem;
            negOpciones.eliminarTamano(item.Id);
            LimpiarTamano();
            RefrescarTamanos();
        }

        private void LimpiarTamano()
        {
            idTamanoSeleccionado = 0;
            txt_NombreTamano.Text = "";
            txt_PrecioTamano.Text = "";
        }

        // ========== EXTRAS ==========

        private void RefrescarExtras()
        {
            lst_Extras.SelectedIndexChanged -= lst_Extras_SelectedIndexChanged;
            lst_Extras.Items.Clear();
            DataTable tabla = negOpciones.getExtras(idProducto);
            foreach (DataRow fila in tabla.Rows)
            {
                int id = Convert.ToInt32(fila["Id"]);
                string nombre = fila["Nombre"].ToString();
                decimal precio = Convert.ToDecimal(fila["Precio"]);
                lst_Extras.Items.Add(new ItemLista { Id = id, Nombre = nombre, Precio = precio, Texto = nombre + " — +$" + precio.ToString("N0") });
            }
            lst_Extras.SelectedIndexChanged += lst_Extras_SelectedIndexChanged;
        }

        private void lst_Extras_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lst_Extras.SelectedItem == null) return;
            ItemLista item = (ItemLista)lst_Extras.SelectedItem;
            idExtraSeleccionado = item.Id;
            txt_NombreExtra.Text = item.Nombre;
            txt_PrecioExtra.Text = item.Precio.ToString();
        }

        private void btn_AgregarExtra_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_NombreExtra.Text))
            {
                MessageBox.Show("Ingresá un nombre para el extra.");
                return;
            }
            if (!decimal.TryParse(txt_PrecioExtra.Text, out decimal precio))
            {
                MessageBox.Show("El precio ingresado no es válido.");
                return;
            }

            if (idExtraSeleccionado != 0)
                negOpciones.modificarExtra(idExtraSeleccionado, txt_NombreExtra.Text, precio);
            else
                negOpciones.agregarExtra(idProducto, txt_NombreExtra.Text, precio);

            LimpiarExtra();
            RefrescarExtras();
        }

        private void btn_QuitarExtra_Click(object sender, EventArgs e)
        {
            if (lst_Extras.SelectedItem == null)
            {
                MessageBox.Show("Seleccioná un extra de la lista.");
                return;
            }
            ItemLista item = (ItemLista)lst_Extras.SelectedItem;
            negOpciones.eliminarExtra(item.Id);
            LimpiarExtra();
            RefrescarExtras();
        }

        private void LimpiarExtra()
        {
            idExtraSeleccionado = 0;
            txt_NombreExtra.Text = "";
            txt_PrecioExtra.Text = "";
        }

        // ========== INGREDIENTES QUITABLES ==========

        private void RefrescarIngredientes()
        {
            lst_Ingredientes.SelectedIndexChanged -= lst_Ingredientes_SelectedIndexChanged;
            lst_Ingredientes.Items.Clear();
            DataTable tabla = negOpciones.getIngredientesQuitables(idProducto);
            foreach (DataRow fila in tabla.Rows)
            {
                int id = Convert.ToInt32(fila["Id"]);
                string nombre = fila["Nombre"].ToString();
                lst_Ingredientes.Items.Add(new ItemLista { Id = id, Nombre = nombre, Texto = nombre });
            }
            lst_Ingredientes.SelectedIndexChanged += lst_Ingredientes_SelectedIndexChanged;
        }

        private void lst_Ingredientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lst_Ingredientes.SelectedItem == null) return;
            ItemLista item = (ItemLista)lst_Ingredientes.SelectedItem;
            idIngredienteSeleccionado = item.Id;
            txt_NombreIngrediente.Text = item.Nombre;
        }

        private void btn_AgregarIngrediente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_NombreIngrediente.Text))
            {
                MessageBox.Show("Ingresá un nombre para el ingrediente.");
                return;
            }

            if (idIngredienteSeleccionado != 0)
                negOpciones.modificarIngrediente(idIngredienteSeleccionado, txt_NombreIngrediente.Text);
            else
                negOpciones.agregarIngrediente(idProducto, txt_NombreIngrediente.Text);

            LimpiarIngrediente();
            RefrescarIngredientes();
        }

        private void btn_QuitarIngrediente_Click(object sender, EventArgs e)
        {
            if (lst_Ingredientes.SelectedItem == null)
            {
                MessageBox.Show("Seleccioná un ingrediente de la lista.");
                return;
            }
            ItemLista item = (ItemLista)lst_Ingredientes.SelectedItem;
            negOpciones.eliminarIngrediente(item.Id);
            LimpiarIngrediente();
            RefrescarIngredientes();
        }

        private void LimpiarIngrediente()
        {
            idIngredienteSeleccionado = 0;
            txt_NombreIngrediente.Text = "";
        }

        // ========== CERRAR ==========

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Clase auxiliar: guarda el Id, el nombre y el precio por separado (antes solo tenía Id+Texto)
        private class ItemLista
        {
            public int Id;
            public string Nombre;
            public decimal Precio;
            public string Texto;
            public override string ToString() => Texto;
        }
    }
}