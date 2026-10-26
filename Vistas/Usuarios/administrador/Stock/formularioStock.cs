using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Entidades;
using Negocio;

namespace Vistas.Usuarios.administrador.Stock
{
    public partial class formularioStock : Form
    {
        private Usuario usuarioActual;
        private NegocioInsumos negInsumos = new NegocioInsumos();
        private NegocioMovimientosStock negMovimientos = new NegocioMovimientosStock();
        private NegocioProductos negProductos = new NegocioProductos();
        private NegocioOpciones negOpciones = new NegocioOpciones();
        private NegocioVinculos negVinculos = new NegocioVinculos();
        private NegocioReporteStock negReporte = new NegocioReporteStock();

        private int idInsumoSeleccionado = 0; // 0 = estamos cargando uno nuevo
        private bool cargando = false;          // mientras se llena la grilla de insumos
        private bool cargandoVinculos = false;  // mientras se llenan los combos / grilla de vínculos
        private bool grillaVinculosConfigurada = false;
        private bool grillaConteoConfigurada = false;
        private bool grillaMovimientosConfigurada = false;

        public formularioStock(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
            lbl_Usuario.Text = "Usuario: " + usuario.getNombreUsuario_U();
            lbl_Fecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void formularioStock_Load(object sender, EventArgs e)
        {
            Ejecutar(() =>
            {
                ConfigurarGrilla();
                CargarInsumos();
            });
        }

        // =====================================================
        //  SECCIÓN INSUMOS
        // =====================================================

        private void ConfigurarGrilla()
        {
            // Que los encabezados y las filas se ajusten solos al tamaño de la letra
            dgv_Insumos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_Insumos.DefaultCellStyle.Padding = new Padding(2, 4, 2, 4);
            dgv_Insumos.ColumnHeadersDefaultCellStyle.Padding = new Padding(2, 4, 2, 4);
            dgv_Insumos.SelectionChanged += dgv_Insumos_SelectionChanged;
        }

        private void CargarInsumos()
        {
            DataTable tabla = chk_VerInactivos.Checked ? negInsumos.getTablaTodos() : negInsumos.getTabla();

            // Columna calculada: OK / Bajo / Negativo / Inactivo
            tabla.Columns.Add("Estado", typeof(string));
            foreach (DataRow fila in tabla.Rows)
            {
                int stock = Convert.ToInt32(fila["Stock"]);
                int minimo = Convert.ToInt32(fila["StockMinimo"]);
                bool activo = Convert.ToInt32(fila["Activo"]) == 1;

                if (!activo) fila["Estado"] = "Inactivo";
                else if (stock < 0) fila["Estado"] = "Negativo";
                else if (stock <= minimo) fila["Estado"] = "Bajo";
                else fila["Estado"] = "OK";
            }

            cargando = true;
            try
            {
                dgv_Insumos.DataSource = tabla;
                dgv_Insumos.Columns["Id"].Visible = false;
                dgv_Insumos.Columns["Activo"].Visible = false;
                dgv_Insumos.Columns["StockMinimo"].HeaderText = "Mínimo";
                dgv_Insumos.Columns["Nombre"].FillWeight = 200;

                // Rojo = negativo, amarillo = en el mínimo o por debajo, gris = dado de baja
                foreach (DataGridViewRow fila in dgv_Insumos.Rows)
                {
                    string estado = fila.Cells["Estado"].Value.ToString();
                    if (estado == "Negativo") fila.DefaultCellStyle.BackColor = Color.FromArgb(255, 205, 205);
                    else if (estado == "Bajo") fila.DefaultCellStyle.BackColor = Color.FromArgb(255, 236, 179);
                    else if (estado == "Inactivo") fila.DefaultCellStyle.ForeColor = Color.Gray;
                }

                dgv_Insumos.ClearSelection();
                dgv_Insumos.CurrentCell = null;
            }
            finally
            {
                cargando = false;
            }

            LimpiarFormulario();
        }

        private void SeleccionarFila(int idInsumo)
        {
            foreach (DataGridViewRow fila in dgv_Insumos.Rows)
            {
                if (Convert.ToInt32(fila.Cells["Id"].Value) == idInsumo)
                {
                    dgv_Insumos.CurrentCell = fila.Cells["Nombre"];
                    fila.Selected = true;
                    return;
                }
            }
        }

        private void dgv_Insumos_SelectionChanged(object sender, EventArgs e)
        {
            if (cargando || dgv_Insumos.SelectedRows.Count == 0) return;

            DataGridViewRow fila = dgv_Insumos.SelectedRows[0];
            idInsumoSeleccionado = Convert.ToInt32(fila.Cells["Id"].Value);
            bool activo = Convert.ToInt32(fila.Cells["Activo"].Value) == 1;
            int stock = Convert.ToInt32(fila.Cells["Stock"].Value);
            int minimo = Convert.ToInt32(fila.Cells["StockMinimo"].Value);

            txt_Nombre.Text = fila.Cells["Nombre"].Value.ToString();
            nud_StockMinimo.Value = Math.Max(0, minimo);
            nud_StockInicial.Value = 0;
            nud_StockInicial.Enabled = false; // el stock solo cambia con ingresos, ajustes y ventas

            lbl_TituloInsumo.Text = "Editar insumo";
            lbl_InfoStock.Text = "Stock actual: " + stock;
            ActualizarEstadoBotones(true, activo);
        }

        private void LimpiarFormulario()
        {
            idInsumoSeleccionado = 0;
            txt_Nombre.Text = "";
            nud_StockInicial.Enabled = true;
            nud_StockInicial.Value = 0;
            nud_StockMinimo.Value = 5;
            nud_CantidadIngreso.Value = 1;
            txt_DetalleIngreso.Text = "";
            lbl_TituloInsumo.Text = "Nuevo insumo";
            lbl_InfoStock.Text = "";
            ActualizarEstadoBotones(false, false);
        }

        // Baja, Alta e Ingresar solo se habilitan cuando corresponde
        private void ActualizarEstadoBotones(bool haySeleccion, bool activo)
        {
            btn_DarDeBajaInsumo.Enabled = haySeleccion && activo;
            btn_DarDeAltaInsumo.Enabled = haySeleccion && !activo;
            btn_IngresarStock.Enabled = haySeleccion && activo;
        }

        private void chk_VerInactivos_CheckedChanged(object sender, EventArgs e)
        {
            Ejecutar(() => CargarInsumos());
        }

        private void btn_NuevoInsumo_Click(object sender, EventArgs e)
        {
            dgv_Insumos.ClearSelection();
            dgv_Insumos.CurrentCell = null;
            LimpiarFormulario();
            txt_Nombre.Focus();
        }

        // Si no hay nada seleccionado agrega; si hay un insumo seleccionado lo modifica
        private void btn_GuardarInsumo_Click(object sender, EventArgs e)
        {
            Ejecutar(() =>
            {
                string nombre = txt_Nombre.Text.Trim();
                if (nombre == "")
                {
                    MessageBox.Show("Escribí el nombre del insumo.");
                    txt_Nombre.Focus();
                    return;
                }

                if (idInsumoSeleccionado == 0)
                {
                    bool ok = negInsumos.agregarInsumo(nombre, (int)nud_StockInicial.Value,
                        (int)nud_StockMinimo.Value, usuarioActual.getId_Usuario_U());

                    if (ok) CargarInsumos();
                    else MessageBox.Show("No se pudo agregar. ¿Ya existe un insumo con ese nombre?");
                }
                else
                {
                    int id = idInsumoSeleccionado;
                    bool ok = negInsumos.modificarInsumo(id, nombre, (int)nud_StockMinimo.Value);

                    if (ok)
                    {
                        CargarInsumos();
                        SeleccionarFila(id);
                    }
                    else MessageBox.Show("No se pudo modificar. ¿Ya existe otro insumo con ese nombre?");
                }
            });
        }

        private void btn_DarDeBajaInsumo_Click(object sender, EventArgs e)
        {
            Ejecutar(() =>
            {
                if (idInsumoSeleccionado == 0)
                {
                    MessageBox.Show("Seleccioná primero un insumo de la lista.");
                    return;
                }

                if (MessageBox.Show("¿Dar de baja este insumo? No se borra, queda inactivo.", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                if (negInsumos.eliminarInsumo(idInsumoSeleccionado)) CargarInsumos();
                else MessageBox.Show("No se pudo dar de baja.");
            });
        }

        private void btn_DarDeAltaInsumo_Click(object sender, EventArgs e)
        {
            Ejecutar(() =>
            {
                if (idInsumoSeleccionado == 0)
                {
                    MessageBox.Show("Seleccioná primero un insumo de la lista.");
                    return;
                }

                int id = idInsumoSeleccionado;
                if (negInsumos.activarInsumo(id))
                {
                    CargarInsumos();
                    SeleccionarFila(id);
                }
                else MessageBox.Show("No se pudo dar de alta.");
            });
        }

        private void btn_IngresarStock_Click(object sender, EventArgs e)
        {
            Ejecutar(() =>
            {
                if (idInsumoSeleccionado == 0)
                {
                    MessageBox.Show("Seleccioná primero el insumo al que le entra stock.");
                    return;
                }

                int id = idInsumoSeleccionado;
                bool ok = negMovimientos.ingresarStock(id, (int)nud_CantidadIngreso.Value,
                    usuarioActual.getId_Usuario_U(), txt_DetalleIngreso.Text.Trim());

                if (ok)
                {
                    CargarInsumos();
                    SeleccionarFila(id);
                }
                else MessageBox.Show("No se pudo ingresar el stock.");
            });
        }

        // =====================================================
        //  SECCIÓN VÍNCULOS
        // =====================================================

        private void ConfigurarGrillaVinculos()
        {
            dgv_Vinculos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_Vinculos.DefaultCellStyle.Padding = new Padding(2, 4, 2, 4);
            dgv_Vinculos.ColumnHeadersDefaultCellStyle.Padding = new Padding(2, 4, 2, 4);
            grillaVinculosConfigurada = true;
        }

        // Llena los combos (se vuelve a llamar cada vez que se entra a la sección,
        // por si se agregaron insumos o productos mientras tanto) y mantiene lo que estaba elegido
        private void CargarCombosVinculos()
        {
            cargandoVinculos = true;
            try
            {
                int idFiltro = ValorSeleccionado(cmb_FiltroProducto);
                int idProducto = ValorSeleccionado(cmb_VProducto);
                int idInsumo = ValorSeleccionado(cmb_VInsumo);

                DataTable productos = negProductos.getTabla();
                DataTable insumos = negInsumos.getTabla();

                CargarCombo(cmb_FiltroProducto, ArmarLista(productos, "Todos los productos"), idFiltro);
                CargarCombo(cmb_VProducto, ArmarLista(productos, null), idProducto);
                CargarCombo(cmb_VInsumo, ArmarLista(insumos, null), idInsumo);

                if (cmb_VTipo.SelectedIndex < 0) cmb_VTipo.SelectedIndex = 0;
                CargarOpciones();
            }
            finally
            {
                cargandoVinculos = false;
            }
        }

        // Arma una lista simple (Id, Nombre) y, si se pide, una primera fila con Id = 0
        private DataTable ArmarLista(DataTable origen, string textoPrimeraFila)
        {
            DataTable lista = new DataTable();
            lista.Columns.Add("Id", typeof(int));
            lista.Columns.Add("Nombre", typeof(string));

            if (textoPrimeraFila != null) lista.Rows.Add(0, textoPrimeraFila);

            foreach (DataRow fila in origen.Rows)
                lista.Rows.Add(Convert.ToInt32(fila["Id"]), fila["Nombre"].ToString());

            return lista;
        }

        private void CargarCombo(ComboBox combo, DataTable lista, int idPrevio)
        {
            combo.DataSource = null;
            combo.DisplayMember = "Nombre";
            combo.ValueMember = "Id";
            combo.DataSource = lista;

            if (lista.Rows.Count == 0)
            {
                combo.SelectedIndex = -1;
                return;
            }

            combo.SelectedValue = idPrevio;
            if (combo.SelectedIndex < 0) combo.SelectedIndex = 0;
        }

        // Devuelve el Id elegido en un combo (0 si no hay nada elegido)
        private int ValorSeleccionado(ComboBox combo)
        {
            if (combo.SelectedIndex < 0) return 0;
            object valor = combo.SelectedValue;
            if (valor == null || valor is DataRowView) return 0;
            return Convert.ToInt32(valor);
        }

        // Llena el combo "Opción" con los tamaños o extras del producto elegido
        private void CargarOpciones()
        {
            int tipo = cmb_VTipo.SelectedIndex; // 0 = Producto, 1 = Tamaño, 2 = Extra
            int idProducto = ValorSeleccionado(cmb_VProducto);

            if (tipo == 1) lbl_VOpcion.Text = "Tamaño";
            else if (tipo == 2) lbl_VOpcion.Text = "Extra";
            else lbl_VOpcion.Text = "Tamaño o extra (solo si corresponde)";

            if (tipo <= 0 || idProducto == 0)
            {
                cmb_VOpcion.DataSource = null;
                cmb_VOpcion.Enabled = false;
                return;
            }

            DataTable opciones = (tipo == 1) ? negOpciones.getTamanos(idProducto) : negOpciones.getExtras(idProducto);

            cmb_VOpcion.DisplayMember = "Nombre";
            cmb_VOpcion.ValueMember = "Id";
            cmb_VOpcion.DataSource = opciones;
            cmb_VOpcion.Enabled = opciones.Rows.Count > 0;
            cmb_VOpcion.SelectedIndex = opciones.Rows.Count > 0 ? 0 : -1;
        }

        private void CargarVinculos()
        {
            int idProducto = ValorSeleccionado(cmb_FiltroProducto);
            DataTable tabla = (idProducto == 0) ? negVinculos.getTabla() : negVinculos.getTablaxProducto(idProducto);

            dgv_Vinculos.DataSource = tabla;
            dgv_Vinculos.Columns["Id"].Visible = false;
            dgv_Vinculos.Columns["IdInsumo"].Visible = false;
            dgv_Vinculos.Columns["IdProducto"].Visible = false;
            dgv_Vinculos.Columns["Opcion"].HeaderText = "Opción";
            dgv_Vinculos.ClearSelection();
            dgv_Vinculos.CurrentCell = null;
        }

        private void cmb_FiltroProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoVinculos) return;
            Ejecutar(() => CargarVinculos());
        }

        private void cmb_VTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoVinculos) return;
            Ejecutar(() => CargarOpciones());
        }

        // Al elegir un producto para cargar un vínculo, la grilla muestra lo que ya descuenta ese producto
        private void cmb_VProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoVinculos) return;
            Ejecutar(() =>
            {
                CargarOpciones();
                SincronizarFiltro(ValorSeleccionado(cmb_VProducto));
                CargarVinculos();
            });
        }

        private void SincronizarFiltro(int idProducto)
        {
            if (idProducto == 0) return;

            cargandoVinculos = true;
            try
            {
                cmb_FiltroProducto.SelectedValue = idProducto;
            }
            finally
            {
                cargandoVinculos = false;
            }
        }

        private void btn_AgregarVinculo_Click(object sender, EventArgs e)
        {
            Ejecutar(() =>
            {
                int idProducto = ValorSeleccionado(cmb_VProducto);
                int idInsumo = ValorSeleccionado(cmb_VInsumo);
                int tipo = cmb_VTipo.SelectedIndex; // 0 = Producto, 1 = Tamaño, 2 = Extra

                if (idProducto == 0)
                {
                    MessageBox.Show("Elegí un producto.");
                    return;
                }

                if (idInsumo == 0)
                {
                    MessageBox.Show("Elegí un insumo. Si no hay ninguno, cargalo primero en la sección Insumos.");
                    return;
                }

                int? origenProducto = null;
                int? origenTamano = null;
                int? origenExtra = null;

                if (tipo <= 0)
                {
                    origenProducto = idProducto;
                }
                else
                {
                    int idOpcion = ValorSeleccionado(cmb_VOpcion);
                    if (idOpcion == 0)
                    {
                        MessageBox.Show("Ese producto no tiene " + (tipo == 1 ? "tamaños" : "extras") + " cargados.");
                        return;
                    }

                    if (tipo == 1) origenTamano = idOpcion;
                    else origenExtra = idOpcion;
                }

                bool ok = negVinculos.agregarVinculo(idInsumo, origenProducto, origenTamano, origenExtra, (int)nud_VCantidad.Value);

                if (ok)
                {
                    nud_VCantidad.Value = 1;
                    SincronizarFiltro(idProducto);
                    CargarVinculos();
                }
                else MessageBox.Show("No se pudo agregar. ¿Ese insumo ya está vinculado a lo mismo?");
            });
        }

        private void btn_QuitarVinculo_Click(object sender, EventArgs e)
        {
            Ejecutar(() =>
            {
                if (dgv_Vinculos.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccioná primero un vínculo de la lista.");
                    return;
                }

                int idVinculo = Convert.ToInt32(dgv_Vinculos.SelectedRows[0].Cells["Id"].Value);

                if (MessageBox.Show("¿Quitar este vínculo?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                if (negVinculos.eliminarVinculo(idVinculo)) CargarVinculos();
                else MessageBox.Show("No se pudo quitar el vínculo.");
            });
        }

        // =====================================================
        //  SECCIÓN CONTEO FÍSICO
        // =====================================================

        private void ConfigurarGrillaConteo()
        {
            dgv_Conteo.Columns.Clear();
            dgv_Conteo.Columns.Add("Id", "Id");
            dgv_Conteo.Columns.Add("Insumo", "Insumo");
            dgv_Conteo.Columns.Add("Sistema", "Sistema");
            dgv_Conteo.Columns.Add("Contado", "Contado");
            dgv_Conteo.Columns.Add("Diferencia", "Diferencia");

            dgv_Conteo.Columns["Id"].Visible = false;
            dgv_Conteo.Columns["Insumo"].FillWeight = 200;

            // Solo "Contado" se puede escribir; el resto es de solo lectura
            dgv_Conteo.Columns["Insumo"].ReadOnly = true;
            dgv_Conteo.Columns["Sistema"].ReadOnly = true;
            dgv_Conteo.Columns["Diferencia"].ReadOnly = true;
            dgv_Conteo.Columns["Contado"].DefaultCellStyle.BackColor = Color.DarkGray;
            dgv_Conteo.Columns["Contado"].DefaultCellStyle.ForeColor = Color.Black;

            foreach (DataGridViewColumn columna in dgv_Conteo.Columns)
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;

            dgv_Conteo.EditMode = DataGridViewEditMode.EditOnEnter;
            dgv_Conteo.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_Conteo.DefaultCellStyle.Padding = new Padding(2, 4, 2, 4);
            dgv_Conteo.ColumnHeadersDefaultCellStyle.Padding = new Padding(2, 4, 2, 4);
            dgv_Conteo.CellEndEdit += dgv_Conteo_CellEndEdit;

            grillaConteoConfigurada = true;
        }

        // Trae los insumos activos con el stock que calcula el sistema y deja "Contado" vacío
        private void CargarConteo()
        {
            DataTable tabla = negInsumos.getTabla();

            dgv_Conteo.Rows.Clear();
            foreach (DataRow fila in tabla.Rows)
            {
                dgv_Conteo.Rows.Add(
                    Convert.ToInt32(fila["Id"]),
                    fila["Nombre"].ToString(),
                    Convert.ToInt32(fila["Stock"]),
                    "",
                    "—");
            }

            txt_DetalleConteo.Text = "";
            ActualizarResumenConteo();
        }

        // Devuelve lo contado en una fila (null si está vacío o no es un número válido)
        private int? LeerContado(DataGridViewRow fila)
        {
            string texto = Convert.ToString(fila.Cells["Contado"].Value ?? "").Trim();
            if (texto == "") return null;

            int numero;
            if (int.TryParse(texto, out numero) && numero >= 0) return numero;
            return null;
        }

        private void dgv_Conteo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgv_Conteo.Columns[e.ColumnIndex].Name != "Contado") return;

            DataGridViewRow fila = dgv_Conteo.Rows[e.RowIndex];
            string texto = Convert.ToString(fila.Cells["Contado"].Value ?? "").Trim();

            int numero;
            if (texto != "" && !(int.TryParse(texto, out numero) && numero >= 0))
            {
                fila.Cells["Contado"].Value = "";
                MessageBox.Show("Escribí un número entero, 0 o más.");
            }
            else
            {
                fila.Cells["Contado"].Value = texto;
            }

            ActualizarResumenConteo();
        }

        // Calcula la diferencia de cada fila (Contado - Sistema), la pinta y arma el resumen del costado
        private void ActualizarResumenConteo()
        {
            int conDiferencia = 0;
            int faltan = 0;
            int sobran = 0;

            foreach (DataGridViewRow fila in dgv_Conteo.Rows)
            {
                DataGridViewCell celdaDif = fila.Cells["Diferencia"];
                int? contado = LeerContado(fila);
                int sistema = Convert.ToInt32(fila.Cells["Sistema"].Value);

                if (contado == null)
                {
                    celdaDif.Value = "—";
                    celdaDif.Style.BackColor = Color.Empty;
                    continue;
                }

                int dif = contado.Value - sistema;

                if (dif == 0)
                {
                    celdaDif.Value = "0";
                    celdaDif.Style.BackColor = Color.Empty;
                }
                else if (dif < 0)
                {
                    celdaDif.Value = dif.ToString();
                    celdaDif.Style.BackColor = Color.FromArgb(255, 205, 205); // falta
                    faltan += -dif;
                    conDiferencia++;
                }
                else
                {
                    celdaDif.Value = "+" + dif;
                    celdaDif.Style.BackColor = Color.FromArgb(205, 240, 205); // sobra
                    sobran += dif;
                    conDiferencia++;
                }
            }

            if (conDiferencia == 0)
                lbl_ResumenConteo.Text = "Sin diferencias cargadas";
            else
                lbl_ResumenConteo.Text = conDiferencia + (conDiferencia == 1 ? " insumo con diferencia." : " insumos con diferencia.")
                    + "\nFaltan: " + faltan + "\nSobran: " + sobran;
        }

        private void btn_AplicarConteo_Click(object sender, EventArgs e)
        {
            Ejecutar(() =>
            {
                dgv_Conteo.EndEdit();

                // Solo se ajustan los insumos donde se cargó un número distinto al del sistema
                List<DataGridViewRow> cambios = new List<DataGridViewRow>();
                foreach (DataGridViewRow fila in dgv_Conteo.Rows)
                {
                    int? contado = LeerContado(fila);
                    if (contado != null && contado.Value != Convert.ToInt32(fila.Cells["Sistema"].Value))
                        cambios.Add(fila);
                }

                if (cambios.Count == 0)
                {
                    MessageBox.Show("No hay diferencias para aplicar. Escribí lo que contaste en la columna Contado.");
                    return;
                }

                string pregunta = "Se va a corregir el stock de " + cambios.Count +
                    (cambios.Count == 1 ? " insumo" : " insumos") + " con lo que contaste. ¿Aplicar los ajustes?";

                if (MessageBox.Show(pregunta, "Confirmar conteo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                string detalle = txt_DetalleConteo.Text.Trim();
                if (detalle == "") detalle = "Conteo físico";

                int aplicados = 0;
                int fallidos = 0;

                foreach (DataGridViewRow fila in cambios)
                {
                    int idInsumo = Convert.ToInt32(fila.Cells["Id"].Value);
                    int contado = LeerContado(fila).Value;

                    if (negMovimientos.ajustarStock(idInsumo, contado, usuarioActual.getId_Usuario_U(), detalle))
                        aplicados++;
                    else
                        fallidos++;
                }

                if (fallidos == 0)
                    MessageBox.Show("Ajustes aplicados: " + aplicados + ".");
                else
                    MessageBox.Show("Ajustes aplicados: " + aplicados + ". No se pudieron aplicar: " + fallidos + ".");

                CargarConteo();
            });
        }

        // Vuelve a traer el stock del sistema y vacía lo que se había escrito
        private void btn_LimpiarConteo_Click(object sender, EventArgs e)
        {
            Ejecutar(() => CargarConteo());
        }

        // =====================================================
        //  SECCIÓN MOVIMIENTOS
        // =====================================================

        private void ConfigurarGrillaMovimientos()
        {
            dgv_Movimientos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_Movimientos.DefaultCellStyle.Padding = new Padding(2, 4, 2, 4);
            dgv_Movimientos.ColumnHeadersDefaultCellStyle.Padding = new Padding(2, 4, 2, 4);

            // Por defecto: los últimos 7 días
            dtp_MovDesde.Value = DateTime.Today.AddDays(-6);
            dtp_MovHasta.Value = DateTime.Today;

            grillaMovimientosConfigurada = true;
        }

        // Llena el combo de insumos (incluye los dados de baja, porque tienen historial)
        private void CargarComboMovimientos()
        {
            int idPrevio = ValorSeleccionado(cmb_MovInsumo);
            CargarCombo(cmb_MovInsumo, ArmarLista(negInsumos.getTablaTodos(), "Todos los insumos"), idPrevio);
        }

        private void MostrarMovimientos()
        {
            DateTime desde = dtp_MovDesde.Value.Date;
            DateTime hasta = dtp_MovHasta.Value.Date;

            if (desde > hasta)
            {
                MessageBox.Show("La fecha Desde no puede ser posterior a la fecha Hasta.");
                return;
            }

            int idInsumo = ValorSeleccionado(cmb_MovInsumo);
            DataTable resumen = negReporte.getResumenPorDia(desde, hasta, idInsumo);
            bool verResumen = rdo_MovResumen.Checked;

            if (verResumen)
            {
                dgv_Movimientos.DataSource = resumen;
                dgv_Movimientos.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgv_Movimientos.Columns["Ingresos"].HeaderText = "Ingresó";
                dgv_Movimientos.Columns["Ventas"].HeaderText = "Vendido";
                dgv_Movimientos.Columns["Ajustes"].HeaderText = "Ajuste (conteo)";
                FormatearColumnaNumerica("Ingresos");
                FormatearColumnaNumerica("Ventas");
                FormatearColumnaNumerica("Ajustes");
            }
            else
            {
                DataTable detalle = negReporte.getDetalleMovimientos(desde, hasta, idInsumo);
                dgv_Movimientos.DataSource = detalle;
                dgv_Movimientos.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                dgv_Movimientos.Columns["Detalle"].FillWeight = 200;
                FormatearColumnaNumerica("Cantidad");
            }

            ColorearAjustes(verResumen);
            ArmarTotalesMovimientos(resumen, desde, hasta);
            dgv_Movimientos.ClearSelection();
        }

        // Muestra los números con signo (+5, -3, 0) y alineados a la derecha
        private void FormatearColumnaNumerica(string columna)
        {
            dgv_Movimientos.Columns[columna].DefaultCellStyle.Format = "+0;-0;0";
            dgv_Movimientos.Columns[columna].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        // Rojo si faltó, verde si sobró (solo en los ajustes del conteo)
        private void ColorearAjustes(bool verResumen)
        {
            string columna = verResumen ? "Ajustes" : "Cantidad";

            foreach (DataGridViewRow fila in dgv_Movimientos.Rows)
            {
                if (!verResumen && Convert.ToString(fila.Cells["Tipo"].Value) != "Ajuste") continue;

                int valor = Convert.ToInt32(fila.Cells[columna].Value);
                if (valor < 0) fila.Cells[columna].Style.BackColor = Color.FromArgb(255, 205, 205);
                else if (valor > 0) fila.Cells[columna].Style.BackColor = Color.FromArgb(205, 240, 205);
            }
        }

        // Resumen del costado: faltantes y sobrantes por insumo (no se mezclan insumos distintos en un solo número)
        private void ArmarTotalesMovimientos(DataTable resumen, DateTime desde, DateTime hasta)
        {
            Dictionary<string, int> faltantes = new Dictionary<string, int>();
            Dictionary<string, int> sobrantes = new Dictionary<string, int>();

            foreach (DataRow fila in resumen.Rows)
            {
                string insumo = fila["Insumo"].ToString();
                int ajuste = Convert.ToInt32(fila["Ajustes"]);

                if (ajuste < 0)
                    faltantes[insumo] = (faltantes.ContainsKey(insumo) ? faltantes[insumo] : 0) - ajuste;
                else if (ajuste > 0)
                    sobrantes[insumo] = (sobrantes.ContainsKey(insumo) ? sobrantes[insumo] : 0) + ajuste;
            }

            string texto = "Del " + desde.ToString("dd/MM") + " al " + hasta.ToString("dd/MM") + "\n\n";

            if (faltantes.Count == 0 && sobrantes.Count == 0)
            {
                texto += "Sin diferencias en los conteos de este período.";
            }
            else
            {
                if (faltantes.Count > 0)
                {
                    texto += "Faltaron:\n";
                    foreach (KeyValuePair<string, int> par in faltantes)
                        texto += "  " + par.Key + ": " + par.Value + "\n";
                    texto += "\n";
                }

                if (sobrantes.Count > 0)
                {
                    texto += "Sobraron:\n";
                    foreach (KeyValuePair<string, int> par in sobrantes)
                        texto += "  " + par.Key + ": " + par.Value + "\n";
                }
            }

            lbl_TotalesMov.Text = texto;
        }

        private void btn_MovBuscar_Click(object sender, EventArgs e)
        {
            Ejecutar(() => MostrarMovimientos());
        }

        private void rdo_MovVista_CheckedChanged(object sender, EventArgs e)
        {
            // Este evento salta en los dos botones; solo actuamos en el que quedó marcado
            if (!((RadioButton)sender).Checked) return;
            Ejecutar(() => MostrarMovimientos());
        }

        private void btn_MovHoy_Click(object sender, EventArgs e)
        {
            dtp_MovDesde.Value = DateTime.Today;
            dtp_MovHasta.Value = DateTime.Today;
            Ejecutar(() => MostrarMovimientos());
        }

        private void btn_MovUltimos7_Click(object sender, EventArgs e)
        {
            dtp_MovDesde.Value = DateTime.Today.AddDays(-6);
            dtp_MovHasta.Value = DateTime.Today;
            Ejecutar(() => MostrarMovimientos());
        }

        private void btn_MovMes_Click(object sender, EventArgs e)
        {
            DateTime hoy = DateTime.Today;
            dtp_MovDesde.Value = new DateTime(hoy.Year, hoy.Month, 1);
            dtp_MovHasta.Value = hoy;
            Ejecutar(() => MostrarMovimientos());
        }

        // =====================================================
        //  MENÚ LATERAL
        // =====================================================

        // Muestra una sola sección a la vez
        private void MostrarPanel(Panel panel)
        {
            pnl_Principal.Visible = (panel == pnl_Principal);
            pnl_Vinculos.Visible = (panel == pnl_Vinculos);
            pnl_Conteo.Visible = (panel == pnl_Conteo);
            pnl_Movimientos.Visible = (panel == pnl_Movimientos);
        }

        private void ResaltarMenu(Button activo)
        {
            Button[] botones = { btn_MenuInsumos, btn_MenuVinculos, btn_MenuConteo, btn_MenuMovimientos };
            foreach (Button b in botones)
            {
                b.BackColor = Color.Gainsboro;
                b.ForeColor = Color.DimGray;
            }
            activo.BackColor = Color.DimGray;
            activo.ForeColor = Color.White;
        }

        private void btn_MenuInsumos_Click(object sender, EventArgs e)
        {
            MostrarPanel(pnl_Principal);
            ResaltarMenu(btn_MenuInsumos);
        }

        private void btn_MenuVinculos_Click(object sender, EventArgs e)
        {
            MostrarPanel(pnl_Vinculos);
            ResaltarMenu(btn_MenuVinculos);

            Ejecutar(() =>
            {
                if (!grillaVinculosConfigurada) ConfigurarGrillaVinculos();
                CargarCombosVinculos();
                CargarVinculos();
            });
        }

        private void btn_MenuConteo_Click(object sender, EventArgs e)
        {
            MostrarPanel(pnl_Conteo);
            ResaltarMenu(btn_MenuConteo);

            Ejecutar(() =>
            {
                if (!grillaConteoConfigurada) ConfigurarGrillaConteo();
                CargarConteo();
            });
        }

        private void btn_MenuMovimientos_Click(object sender, EventArgs e)
        {
            MostrarPanel(pnl_Movimientos);
            ResaltarMenu(btn_MenuMovimientos);

            Ejecutar(() =>
            {
                if (!grillaMovimientosConfigurada) ConfigurarGrillaMovimientos();
                CargarComboMovimientos();
                MostrarMovimientos();
            });
        }

        // =====================================================
        //  VOLVER Y UTILIDADES
        // =====================================================

        private void btn_volver_Click(object sender, EventArgs e)
        {
            formularioPrincipal principal = new formularioPrincipal(usuarioActual);
            principal.Show();
            this.Close();
        }

        // Si algo falla (por ejemplo la base no responde) se muestra el error en vez de cerrar la app
        private void Ejecutar(Action accion)
        {
            try
            {
                accion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}