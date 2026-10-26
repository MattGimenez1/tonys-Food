using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Entidades;
using Negocio;
using System.Drawing.Printing;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Text;

namespace Vistas.Usuarios.vendedor
{
    public partial class formularioVendedor : Form
    {
        private Usuario usuarioActual;
        private NegocioProductos negProductos = new NegocioProductos();
        private NegocioCategoria negCategoria = new NegocioCategoria();
        private NegocioVenta negVenta = new NegocioVenta();
        private string textoAImprimir;
        private long idUltimoPagoVisto = 0;
        private Timer timerPolling;
        private int idUltimaVentaGenerada = 0;
        private bool impresionHabilitada = true;

        private int? idCategoriaComidas = null;

        private class ItemPedido
        {
            public int IdProducto;
            public string Nombre;
            public decimal Precio;
            public int Cantidad;
            public int? IdTamano;
            public List<ExtraElegido> Extras = new List<ExtraElegido>();
            public decimal Subtotal => Precio * Cantidad;
        }

        private Dictionary<int, ItemPedido> carrito =
            new Dictionary<int, ItemPedido>();

        public formularioVendedor(Usuario usuario)
        {
            InitializeComponent();

            usuarioActual = usuario;

            lbl_Usuario.Text =
                "Usuario: " + usuario.getNombreUsuario_U();

            lbl_Fecha.Text =
                DateTime.Now.ToString("dd/MM/yyyy");

            cb_FormaPago.SelectedIndex = 0;
        }

        private void formularioVendedor_Load(object sender, EventArgs e)
        {
            MostrarCategoriasPadre();
            RenderCarrito();
            IniciarPollingMercadoPago();
        }

        // ========== NAVEGACIÓN DE CATEGORÍAS ==========

        private void MostrarCategoriasPadre()
        {
            flp_Categorias.Controls.Clear();

            DataTable tabla =
                negCategoria.getCategoriasPadre();

            foreach (DataRow fila in tabla.Rows)
            {
                int id =
                    Convert.ToInt32(fila["Id"]);

                string nombre =
                    fila["Nombre"].ToString();

                if (nombre == "Comidas")
                    idCategoriaComidas = id;

                Button btn =
                    CrearBotonCategoria(nombre);

                btn.Tag = id;

                btn.Click +=
                    BtnCategoriaPadre_Click;

                flp_Categorias.Controls.Add(btn);
            }
        }

        private void BtnCategoriaPadre_Click(
            object sender,
            EventArgs e)
        {
            int id =
                (int)((Button)sender).Tag;

            string nombre =
                ((Button)sender).Text;

            if (nombre == "Comidas")
                MostrarSubcategorias(id);
            else
                MostrarProductos(id, nombre);
        }

        private void MostrarSubcategorias(
            int idComidas)
        {
            flp_Categorias.Controls.Clear();

            Button btnVolver =
                CrearBotonCategoria("◀ Categorías");

            btnVolver.Click +=
                (s, e) => MostrarCategoriasPadre();

            flp_Categorias.Controls.Add(btnVolver);

            DataTable tabla =
                negCategoria.getSubcategorias(idComidas);

            foreach (DataRow fila in tabla.Rows)
            {
                int id =
                    Convert.ToInt32(fila["Id"]);

                string nombre =
                    fila["Nombre"].ToString();

                Button btn =
                    CrearBotonCategoria(nombre);

                btn.Tag = id;

                btn.Click +=
                    (s, e) =>
                        MostrarProductos(
                            id,
                            nombre,
                            esSubcategoria: true);

                flp_Categorias.Controls.Add(btn);
            }
        }

        private Button CrearBotonCategoria(
            string texto)
        {
            Button btn = new Button();

            btn.Text = texto;
            btn.BackColor = Color.DimGray;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Popup;
            btn.Font = new Font("Segoe UI", 12F);

            btn.Width =
                flp_Categorias.ClientSize.Width - 5;

            btn.Height = 50;
            btn.Margin = new Padding(3);

            return btn;
        }

        // ========== PRODUCTOS ==========

        private void MostrarProductos(
            int idCategoria,
            string nombreCategoria,
            bool esSubcategoria = false)
        {
            flp_Productos.Controls.Clear();

            DataTable tabla =
                negProductos.getTablaxCategoria(
                    idCategoria);

            foreach (DataRow fila in tabla.Rows)
            {
                int id =
                    Convert.ToInt32(fila["Id"]);

                string nombre =
                    fila["Nombre"].ToString();

                decimal precio =
                    Convert.ToDecimal(fila["Precio"]);

                Button btnProducto =
                    new Button();

                btnProducto.Text =
                    nombre +
                    "\n$" +
                    precio.ToString("N0");

                btnProducto.Size =
                    new Size(180, 60);

                btnProducto.Margin =
                    new Padding(5);

                btnProducto.Tag =
                    new ItemPedido
                    {
                        IdProducto = id,
                        Nombre = nombre,
                        Precio = precio,
                        Cantidad = 1
                    };

                btnProducto.Click +=
                    BtnProducto_Click;

                flp_Productos.Controls.Add(
                    btnProducto);
            }
        }

        // ========== CARRITO ==========

        private void BtnProducto_Click(
            object sender,
            EventArgs e)
        {
            ItemPedido itemClickeado =
                (ItemPedido)((Button)sender).Tag;

            frmPersonalizarProducto ventana =
                new frmPersonalizarProducto(
                    itemClickeado.IdProducto,
                    itemClickeado.Nombre,
                    itemClickeado.Precio);

            ventana.ShowDialog();

            if (!ventana.Confirmado)
                return;

            string claveUnica =
                itemClickeado.IdProducto +
                "_" +
                ventana.ResumenPersonalizacion;

            if (carrito.ContainsKey(
                claveUnica.GetHashCode()))
            {
                carrito[
                    claveUnica.GetHashCode()
                ].Cantidad +=
                    ventana.Cantidad;
            }
            else
            {
                carrito[
                    claveUnica.GetHashCode()
                ] = new ItemPedido
                {
                    IdProducto =
                        itemClickeado.IdProducto,

                    Nombre =
                        itemClickeado.Nombre +
                        (
                            string.IsNullOrEmpty(
                                ventana.ResumenPersonalizacion)
                            ? ""
                            : " (" +
                              ventana.ResumenPersonalizacion +
                              ")"
                        ),

                    Precio =
                        ventana.PrecioFinal,

                    Cantidad =
                        ventana.Cantidad,

                    IdTamano =
                        ventana.IdTamanoElegido,

                    Extras =
                        ventana.ExtrasElegidos
                };
            }

            RenderCarrito();
        }

        private void RenderCarrito()
        {
            flp_Carrito.Controls.Clear();

            if (carrito.Count == 0)
            {
                Label lbl =
                    new Label();

                lbl.Text =
                    "Sin productos todavía.";

                lbl.ForeColor =
                    Color.Gray;

                lbl.AutoSize = true;

                flp_Carrito.Controls.Add(lbl);
            }
            else
            {
                int anchoDisponible =
                    flp_Carrito.ClientSize.Width - 30;

                foreach (var par in carrito)
                {
                    int clave = par.Key;

                    ItemPedido item =
                        par.Value;

                    Label lblItem =
                        new Label();

                    lblItem.Text =
                        item.Cantidad +
                        "x " +
                        item.Nombre +
                        " - $" +
                        item.Subtotal.ToString("N0");

                    lblItem.AutoSize = true;

                    lblItem.MaximumSize =
                        new Size(
                            anchoDisponible,
                            0);

                    lblItem.Location =
                        new Point(0, 2);

                    Panel fila =
                        new Panel();

                    fila.Width =
                        flp_Carrito.ClientSize.Width - 10;

                    fila.Margin =
                        new Padding(2);

                    Button btnQuitar =
                        new Button();

                    btnQuitar.Text = "✕";

                    btnQuitar.Size =
                        new Size(22, 22);

                    btnQuitar.Location =
                        new Point(
                            fila.Width - 22,
                            0);

                    btnQuitar.Tag =
                        clave;

                    btnQuitar.Click +=
                        (s, e) =>
                        {
                            int claveAQuitar =
                                (int)((Button)s).Tag;

                            carrito.Remove(
                                claveAQuitar);

                            RenderCarrito();
                        };

                    fila.Controls.Add(lblItem);
                    fila.Controls.Add(btnQuitar);

                    fila.Height =
                        Math.Max(
                            lblItem.Height,
                            22) + 4;

                    flp_Carrito.Controls.Add(fila);
                }
            }

            decimal total =
                carrito.Values.Sum(
                    x => x.Subtotal);

            lbl_Precio.Text =
                "$" +
                total.ToString("N0");
        }

        private void btn_VaciarPedido_Click(
            object sender,
            EventArgs e)
        {
            carrito.Clear();
            RenderCarrito();
        }

        // ========== TEXTOS PARA IMPRIMIR ==========

        private string AjustarTexto(string texto, int ancho = 32)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return "";

            StringBuilder resultado = new StringBuilder();

            while (texto.Length > ancho)
            {
                int posicionCorte = texto.LastIndexOf(' ', ancho);

                if (posicionCorte <= 0)
                    posicionCorte = ancho;

                resultado.AppendLine(texto.Substring(0, posicionCorte).Trim());
                texto = texto.Substring(posicionCorte).Trim();
            }

            if (texto.Length > 0)
                resultado.AppendLine(texto);

            return resultado.ToString();
        }


        private string GenerarTextoComanda(int idVenta)
        {
            string texto = "";

            texto += "===== COCINA =====\n";
            texto += "Ticket N°: " + idVenta + "\n";
            texto += DateTime.Now.ToString("dd/MM/yyyy HH:mm") + "\n";
            texto += "------------------------\n";

            foreach (ItemPedido item in carrito.Values)
            {
                string nombreProducto = item.Nombre;
                string aclaracion = "";

                int idxParentesis = nombreProducto.IndexOf(" (");

                if (idxParentesis >= 0)
                {
                    aclaracion = nombreProducto.Substring(idxParentesis + 2).TrimEnd(')');
                    nombreProducto = nombreProducto.Substring(0, idxParentesis);
                }

                // Producto
                texto += AjustarTexto(
                    item.Cantidad + "x " + nombreProducto,
                    32
                );

                // Aclaración / adicionales
                if (!string.IsNullOrEmpty(aclaracion))
                {
                    texto += AjustarTexto(
                        "   >> " + aclaracion,
                        32
                    );
                }
            }

            texto += "------------------------\n";

            return texto;
        }


        private string GenerarTextoTicketCliente(int idVenta, string formaPago, decimal total)
        {
            string texto = "";

            texto += "===== TONY'S FOOD =====\n";
            texto += "Ticket N°: " + idVenta + "\n";
            texto += DateTime.Now.ToString("dd/MM/yyyy HH:mm") + "\n";

            // Usuario
            texto += AjustarTexto(
                "Atendió: " + usuarioActual.getNombreUsuario_U(),
                32
            );

            texto += "------------------------\n";

            foreach (ItemPedido item in carrito.Values)
            {
                string nombreProducto = item.Nombre;
                string aclaracion = "";

                int idxParentesis = nombreProducto.IndexOf(" (");

                if (idxParentesis >= 0)
                {
                    aclaracion = nombreProducto.Substring(idxParentesis + 2).TrimEnd(')');
                    nombreProducto = nombreProducto.Substring(0, idxParentesis);
                }

                // Producto + precio
                string lineaProducto =
                    item.Cantidad + "x " +
                    nombreProducto.PadRight(15) +
                    " $" +
                    item.Subtotal.ToString("N0");

                texto += AjustarTexto(
                    lineaProducto,
                    32
                );

                // Aclaración / adicionales
                if (!string.IsNullOrEmpty(aclaracion))
                {
                    texto += AjustarTexto(
                        "   >> " + aclaracion,
                        32
                    );
                }
            }

            texto += "------------------------\n";

            texto += AjustarTexto(
                "TOTAL: $" + total.ToString("N0"),
                32
            );

            texto += AjustarTexto(
                "Forma de pago: " + formaPago,
                32
            );

            texto += "========================\n";

            // Texto corto para evitar que se corte
            texto += "No válido como factura\n";

            texto += "¡Gracias por su compra!\n";

            return texto;
        }

        // ========== TEXTOS PARA REIMPRIMIR ==========

        private string GenerarTextoComandaDesdeDetalle(
            int idVenta,
            DataTable detalle,
            DateTime fecha)
        {
            string texto = "";

            texto +=
                "===== COCINA (REIMPRESIÓN) =====\n";

            texto +=
                "Ticket N°: " +
                idVenta +
                "\n";

            texto +=
                fecha.ToString(
                    "dd/MM/yyyy HH:mm") +
                "\n";

            texto +=
                "------------------------\n";

            foreach (DataRow fila
                     in detalle.Rows)
            {
                texto +=
                    fila["Cantidad"] +
                    "x " +
                    fila["Producto"] +
                    "\n";
            }

            texto +=
                "------------------------\n";

            // Margen final para cocina
            texto += "\n\n";

            return texto;
        }

        private string GenerarTextoTicketClienteDesdeDetalle(
            int idVenta,
            DataTable detalle,
            string formaPago,
            decimal total,
            DateTime fecha)
        {
            string texto = "";

            texto +=
                "===== TONY'S FOOD (REIMPRESIÓN) =====\n";

            texto +=
                "Ticket N°: " +
                idVenta +
                "\n";

            texto +=
                fecha.ToString(
                    "dd/MM/yyyy HH:mm") +
                "\n";

            texto +=
                "------------------------\n";

            foreach (DataRow fila
                     in detalle.Rows)
            {
                string nombre =
                    fila["Producto"].ToString();

                int cantidad =
                    Convert.ToInt32(
                        fila["Cantidad"]);

                decimal subtotal =
                    Convert.ToDecimal(
                        fila["Subtotal"]);

                texto +=
                    cantidad +
                    "x " +
                    nombre.PadRight(15) +
                    " $" +
                    subtotal.ToString("N0") +
                    "\n";
            }

            texto +=
                "------------------------\n";

            texto +=
                "TOTAL: $" +
                total.ToString("N0") +
                "\n";

            texto +=
                "Forma de pago: " +
                formaPago +
                "\n";

            texto +=
                "========================\n";

            texto +=
                "no válido como factura\n";

            texto +=
                "¡Gracias por su compra! (REIMPRESIÓN)\n";

            return texto;
        }

        // ========== IMPRESIÓN ==========

        private void ImprimirTexto(
            string texto,
            string nombreImpresora = null)
        {
            textoAImprimir = texto;

            PrintDocument documento =
                new PrintDocument();

            if (!string.IsNullOrEmpty(
                nombreImpresora))
            {
                documento.PrinterSettings.PrinterName =
                    nombreImpresora;
            }

            int cantidadLineas =
                texto.Split('\n').Length;

            // 80 mm de ancho.
            // La altura se adapta al contenido.
            int altoPapel =
                (cantidadLineas * 18) + 50;

            documento.DefaultPageSettings.PaperSize =
                new PaperSize(
                    "Ticket 80mm",
                    315,
                    altoPapel);

            documento.DefaultPageSettings.Margins =
                new Margins(
                    0,
                    0,
                    0,
                    0);

            documento.PrintPage +=
                Documento_PrintPage;

            try
            {
                documento.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo imprimir: " +
                    ex.Message);
            }
        }

        private void Documento_PrintPage(
            object sender,
            PrintPageEventArgs e)
        {
            using (Font fuente =
                   new Font(
                       "Consolas",
                       10))
            {
                e.Graphics.DrawString(
                    textoAImprimir,
                    fuente,
                    Brushes.Black,
                    new PointF(5, 5));
            }

            e.HasMorePages = false;
        }

        // ========== COBRAR ==========

        private void btn_CobrarEImprimir_Click(
            object sender,
            EventArgs e)
        {
            if (carrito.Count == 0)
            {
                MessageBox.Show(
                    "El pedido está vacío.");

                return;
            }

            List<DetalleVenta> detalles =
                new List<DetalleVenta>();

            foreach (ItemPedido item
                     in carrito.Values)
            {
                DetalleVenta det =
                    new DetalleVenta();

                det.setId_Producto_D(
                    item.IdProducto);

                det.setCantidad_D(
                    item.Cantidad);

                det.setPrecioUnitario_D(
                    item.Precio);

                det.setSubtotal_D(
                    item.Subtotal);

                det.setId_Tamano_Sel(
                    item.IdTamano);

                det.setExtras_Sel(
                    item.Extras);

                detalles.Add(det);
            }

            decimal total =
                detalles.Sum(
                    d => d.getSubtotal_D());

            string formaPago =
                cb_FormaPago.SelectedItem
                .ToString();

            int idVentaGenerada =
                negVenta.registrarVentaCompleta(
                    total,
                    usuarioActual.getId_Usuario_U(),
                    formaPago,
                    detalles);

            if (idVentaGenerada > 0)
            {
                idUltimaVentaGenerada =
                    idVentaGenerada;

                string textoComanda =
                    GenerarTextoComanda(
                        idVentaGenerada);

                string textoTicket =
                    GenerarTextoTicketCliente(
                        idVentaGenerada,
                        formaPago,
                        total);

                if (impresionHabilitada)
                {
                    ImprimirTexto(
                        textoComanda,
                        "OCOM Cocina");

                    ImprimirTexto(
                        textoTicket,
                        "OCOM Mostrador");
                }

                carrito.Clear();

                RenderCarrito();
            }
            else
            {
                MessageBox.Show(
                    "Ocurrió un error al registrar la venta.");
            }
        }

        // ========== REIMPRIMIR ==========

        private void btn_ReimprimirUltima_Click(
            object sender,
            EventArgs e)
        {
            if (idUltimaVentaGenerada == 0)
            {
                MessageBox.Show(
                    "Todavía no se registró ninguna venta en esta sesión.");

                return;
            }

            ReimprimirVenta(
                idUltimaVentaGenerada);
        }

        private void btn_ReimprimirPorNro_Click(
            object sender,
            EventArgs e)
        {
            if (!int.TryParse(
                txt_NroTicket.Text,
                out int nro))
            {
                MessageBox.Show(
                    "Ingresá un número de ticket válido.");

                return;
            }

            ReimprimirVenta(nro);
        }

        private void ReimprimirVenta(
            int idVenta)
        {
            DataTable cabecera =
                negVenta.getVentaPorId(
                    idVenta);

            if (cabecera.Rows.Count == 0)
            {
                MessageBox.Show(
                    "No se encontró ninguna venta con ese número.");

                return;
            }

            DataTable detalle =
                negVenta.getDetalleVentaxId(
                    idVenta);

            if (detalle.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Esa venta no tiene detalle registrado.");

                return;
            }

            decimal total =
                Convert.ToDecimal(
                    cabecera.Rows[0]["Total"]);

            string formaPago =
                cabecera.Rows[0]["FormaPago"]
                .ToString();

            DateTime fecha =
                Convert.ToDateTime(
                    cabecera.Rows[0]["Fecha"]);

            string textoComanda =
                GenerarTextoComandaDesdeDetalle(
                    idVenta,
                    detalle,
                    fecha);

            string textoTicket =
                GenerarTextoTicketClienteDesdeDetalle(
                    idVenta,
                    detalle,
                    formaPago,
                    total,
                    fecha);

            if (impresionHabilitada)
            {
                ImprimirTexto(
                    textoComanda,
                    "OCOM Cocina");

                ImprimirTexto(
                    textoTicket,
                    "OCOM Mostrador");

                MessageBox.Show(
                    "Ticket N° " +
                    idVenta +
                    " reimpreso correctamente.");
            }
            else
            {
                MessageBox.Show(
                    "La impresión está deshabilitada por ahora.");
            }
        }

        // ========== MENÚS ==========

        private void btn_Menus_Click(
            object sender,
            EventArgs e)
        {
            formularioMenusVendedor pantallaMenu =
                new formularioMenusVendedor(
                    usuarioActual);

            pantallaMenu.Show();

            this.Close();
        }

        private void btn_CerrarSession_Click(
            object sender,
            EventArgs e)
        {
            login formLogin =
                new login();

            formLogin.Show();

            this.Close();
        }

        // ========== MERCADO PAGO ==========

        private void IniciarPollingMercadoPago()
        {
            timerPolling =
                new Timer();

            timerPolling.Interval =
                15000;

            timerPolling.Tick +=
                async (s, e) =>
                    await RevisarPagosNuevos();

            timerPolling.Start();
        }

        private async Task RevisarPagosNuevos()
        {
            try
            {
                JToken pago = await TestMercadoPago.ObtenerUltimoPagoRaw();
                if (pago == null) return;

                long idPago = (long)pago["id"];
                if (idUltimoPagoVisto == 0) { idUltimoPagoVisto = idPago; return; }

                if (idPago != idUltimoPagoVisto)
                {
                    idUltimoPagoVisto = idPago;
                    decimal monto = (decimal)pago["transaction_amount"];
                    frmToastPago.Mostrar(monto);
                }
            }
            catch (Exception)
            {
                // Sin internet u otro problema de conexión: lo ignoramos y seguimos con normalidad,
                // no queremos que esto interrumpa al vendedor en medio de una venta
            }
        }

        // ========== CERRAR CAJA ==========

        private void btn_CerrarCaja_Click(
            object sender,
            EventArgs e)
        {
            frmCierreCaja ventana =
                new frmCierreCaja(
                    usuarioActual);

            ventana.ShowDialog();
        }
    }
}