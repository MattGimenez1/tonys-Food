namespace Vistas.Usuarios.administrador.Nueva_Venta
{
    partial class formularioNuevaVenta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnl_Arriba = new System.Windows.Forms.Panel();
            this.btn_Volver = new System.Windows.Forms.Button();
            this.lbl_Usuario = new System.Windows.Forms.Label();
            this.pnl_Principal = new System.Windows.Forms.Panel();
            this.flp_Productos = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_NroTicket = new System.Windows.Forms.TextBox();
            this.btn_ReimprimirPorNro = new System.Windows.Forms.Button();
            this.btn_ReimprimirUltima = new System.Windows.Forms.Button();
            this.cb_FormaPago = new System.Windows.Forms.ComboBox();
            this.lbl_FormaDePago = new System.Windows.Forms.Label();
            this.lbl_Fecha = new System.Windows.Forms.Label();
            this.flp_Carrito = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_VaciarPedido = new System.Windows.Forms.Button();
            this.btn_CobrarEImprimir = new System.Windows.Forms.Button();
            this.lbl_Precio = new System.Windows.Forms.Label();
            this.lbl_Total = new System.Windows.Forms.Label();
            this.lbl_PedidoActual = new System.Windows.Forms.Label();
            this.pnl_Izquierdo = new System.Windows.Forms.Panel();
            this.btn_CerrarCaja = new System.Windows.Forms.Button();
            this.flp_Categorias = new System.Windows.Forms.FlowLayoutPanel();
            this.pnl_Arriba.SuspendLayout();
            this.pnl_Principal.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnl_Izquierdo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_Arriba
            // 
            this.pnl_Arriba.BackColor = System.Drawing.Color.White;
            this.pnl_Arriba.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_Arriba.Controls.Add(this.btn_Volver);
            this.pnl_Arriba.Controls.Add(this.lbl_Usuario);
            this.pnl_Arriba.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Arriba.Location = new System.Drawing.Point(0, 0);
            this.pnl_Arriba.Name = "pnl_Arriba";
            this.pnl_Arriba.Size = new System.Drawing.Size(1920, 100);
            this.pnl_Arriba.TabIndex = 2;
            // 
            // btn_Volver
            // 
            this.btn_Volver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Volver.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Volver.Location = new System.Drawing.Point(1775, 11);
            this.btn_Volver.Name = "btn_Volver";
            this.btn_Volver.Size = new System.Drawing.Size(132, 31);
            this.btn_Volver.TabIndex = 1;
            this.btn_Volver.Text = "Volver";
            this.btn_Volver.UseVisualStyleBackColor = true;
            this.btn_Volver.Click += new System.EventHandler(this.btn_Volver_Click);
            // 
            // lbl_Usuario
            // 
            this.lbl_Usuario.AutoSize = true;
            this.lbl_Usuario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Usuario.Location = new System.Drawing.Point(12, 35);
            this.lbl_Usuario.Name = "lbl_Usuario";
            this.lbl_Usuario.Size = new System.Drawing.Size(67, 20);
            this.lbl_Usuario.TabIndex = 0;
            this.lbl_Usuario.Text = "Usuario:";
            // 
            // pnl_Principal
            // 
            this.pnl_Principal.BackColor = System.Drawing.Color.White;
            this.pnl_Principal.Controls.Add(this.flp_Productos);
            this.pnl_Principal.Controls.Add(this.panel1);
            this.pnl_Principal.Controls.Add(this.pnl_Izquierdo);
            this.pnl_Principal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Principal.Location = new System.Drawing.Point(0, 100);
            this.pnl_Principal.Name = "pnl_Principal";
            this.pnl_Principal.Size = new System.Drawing.Size(1920, 980);
            this.pnl_Principal.TabIndex = 0;
            // 
            // flp_Productos
            // 
            this.flp_Productos.AutoScroll = true;
            this.flp_Productos.BackColor = System.Drawing.Color.White;
            this.flp_Productos.Location = new System.Drawing.Point(304, 6);
            this.flp_Productos.Name = "flp_Productos";
            this.flp_Productos.Size = new System.Drawing.Size(1333, 971);
            this.flp_Productos.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txt_NroTicket);
            this.panel1.Controls.Add(this.btn_ReimprimirPorNro);
            this.panel1.Controls.Add(this.btn_ReimprimirUltima);
            this.panel1.Controls.Add(this.cb_FormaPago);
            this.panel1.Controls.Add(this.lbl_FormaDePago);
            this.panel1.Controls.Add(this.lbl_Fecha);
            this.panel1.Controls.Add(this.flp_Carrito);
            this.panel1.Controls.Add(this.btn_VaciarPedido);
            this.panel1.Controls.Add(this.btn_CobrarEImprimir);
            this.panel1.Controls.Add(this.lbl_Precio);
            this.panel1.Controls.Add(this.lbl_Total);
            this.panel1.Controls.Add(this.lbl_PedidoActual);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1643, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(277, 980);
            this.panel1.TabIndex = 3;
            // 
            // txt_NroTicket
            // 
            this.txt_NroTicket.Location = new System.Drawing.Point(8, 652);
            this.txt_NroTicket.Name = "txt_NroTicket";
            this.txt_NroTicket.Size = new System.Drawing.Size(62, 22);
            this.txt_NroTicket.TabIndex = 13;
            // 
            // btn_ReimprimirPorNro
            // 
            this.btn_ReimprimirPorNro.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ReimprimirPorNro.Location = new System.Drawing.Point(8, 609);
            this.btn_ReimprimirPorNro.Name = "btn_ReimprimirPorNro";
            this.btn_ReimprimirPorNro.Size = new System.Drawing.Size(256, 37);
            this.btn_ReimprimirPorNro.TabIndex = 10;
            this.btn_ReimprimirPorNro.Text = "Reimprimir x Nro";
            this.btn_ReimprimirPorNro.UseVisualStyleBackColor = true;
            this.btn_ReimprimirPorNro.Click += new System.EventHandler(this.btn_ReimprimirPorNro_Click);
            // 
            // btn_ReimprimirUltima
            // 
            this.btn_ReimprimirUltima.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ReimprimirUltima.Location = new System.Drawing.Point(8, 566);
            this.btn_ReimprimirUltima.Name = "btn_ReimprimirUltima";
            this.btn_ReimprimirUltima.Size = new System.Drawing.Size(256, 37);
            this.btn_ReimprimirUltima.TabIndex = 9;
            this.btn_ReimprimirUltima.Text = "Reimprimir Ultima";
            this.btn_ReimprimirUltima.UseVisualStyleBackColor = true;
            this.btn_ReimprimirUltima.Click += new System.EventHandler(this.btn_ReimprimirUltima_Click);
            // 
            // cb_FormaPago
            // 
            this.cb_FormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_FormaPago.FormattingEnabled = true;
            this.cb_FormaPago.Items.AddRange(new object[] {
            "Efectivo",
            "Transferencia",
            "QR/Tarjeta"});
            this.cb_FormaPago.Location = new System.Drawing.Point(8, 416);
            this.cb_FormaPago.Name = "cb_FormaPago";
            this.cb_FormaPago.Size = new System.Drawing.Size(256, 24);
            this.cb_FormaPago.TabIndex = 8;
            // 
            // lbl_FormaDePago
            // 
            this.lbl_FormaDePago.AutoSize = true;
            this.lbl_FormaDePago.Location = new System.Drawing.Point(6, 397);
            this.lbl_FormaDePago.Name = "lbl_FormaDePago";
            this.lbl_FormaDePago.Size = new System.Drawing.Size(98, 16);
            this.lbl_FormaDePago.TabIndex = 7;
            this.lbl_FormaDePago.Text = "forma De Pago";
            // 
            // lbl_Fecha
            // 
            this.lbl_Fecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Fecha.AutoSize = true;
            this.lbl_Fecha.Location = new System.Drawing.Point(186, 960);
            this.lbl_Fecha.Name = "lbl_Fecha";
            this.lbl_Fecha.Size = new System.Drawing.Size(45, 16);
            this.lbl_Fecha.TabIndex = 6;
            this.lbl_Fecha.Text = "Fecha";
            // 
            // flp_Carrito
            // 
            this.flp_Carrito.AutoScroll = true;
            this.flp_Carrito.Location = new System.Drawing.Point(9, 50);
            this.flp_Carrito.Name = "flp_Carrito";
            this.flp_Carrito.Size = new System.Drawing.Size(255, 301);
            this.flp_Carrito.TabIndex = 5;
            // 
            // btn_VaciarPedido
            // 
            this.btn_VaciarPedido.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_VaciarPedido.Location = new System.Drawing.Point(7, 523);
            this.btn_VaciarPedido.Name = "btn_VaciarPedido";
            this.btn_VaciarPedido.Size = new System.Drawing.Size(257, 37);
            this.btn_VaciarPedido.TabIndex = 4;
            this.btn_VaciarPedido.Text = "Vaciar Pedido";
            this.btn_VaciarPedido.UseVisualStyleBackColor = true;
            this.btn_VaciarPedido.Click += new System.EventHandler(this.btn_VaciarPedido_Click);
            // 
            // btn_CobrarEImprimir
            // 
            this.btn_CobrarEImprimir.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CobrarEImprimir.Location = new System.Drawing.Point(8, 480);
            this.btn_CobrarEImprimir.Name = "btn_CobrarEImprimir";
            this.btn_CobrarEImprimir.Size = new System.Drawing.Size(256, 37);
            this.btn_CobrarEImprimir.TabIndex = 3;
            this.btn_CobrarEImprimir.Text = "Cobrar e Imprimir";
            this.btn_CobrarEImprimir.UseVisualStyleBackColor = true;
            this.btn_CobrarEImprimir.Click += new System.EventHandler(this.btn_CobrarEImprimir_Click);
            // 
            // lbl_Precio
            // 
            this.lbl_Precio.AutoSize = true;
            this.lbl_Precio.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Precio.Location = new System.Drawing.Point(88, 354);
            this.lbl_Precio.Name = "lbl_Precio";
            this.lbl_Precio.Size = new System.Drawing.Size(42, 32);
            this.lbl_Precio.TabIndex = 2;
            this.lbl_Precio.Text = "$0";
            // 
            // lbl_Total
            // 
            this.lbl_Total.AutoSize = true;
            this.lbl_Total.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Total.Location = new System.Drawing.Point(3, 354);
            this.lbl_Total.Name = "lbl_Total";
            this.lbl_Total.Size = new System.Drawing.Size(70, 32);
            this.lbl_Total.TabIndex = 1;
            this.lbl_Total.Text = "Total";
            // 
            // lbl_PedidoActual
            // 
            this.lbl_PedidoActual.AutoSize = true;
            this.lbl_PedidoActual.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PedidoActual.Location = new System.Drawing.Point(36, 7);
            this.lbl_PedidoActual.Name = "lbl_PedidoActual";
            this.lbl_PedidoActual.Size = new System.Drawing.Size(207, 40);
            this.lbl_PedidoActual.TabIndex = 0;
            this.lbl_PedidoActual.Text = "Pedido Actual";
            // 
            // pnl_Izquierdo
            // 
            this.pnl_Izquierdo.BackColor = System.Drawing.Color.White;
            this.pnl_Izquierdo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_Izquierdo.Controls.Add(this.btn_CerrarCaja);
            this.pnl_Izquierdo.Controls.Add(this.flp_Categorias);
            this.pnl_Izquierdo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_Izquierdo.Location = new System.Drawing.Point(0, 0);
            this.pnl_Izquierdo.Name = "pnl_Izquierdo";
            this.pnl_Izquierdo.Size = new System.Drawing.Size(298, 980);
            this.pnl_Izquierdo.TabIndex = 2;
            // 
            // btn_CerrarCaja
            // 
            this.btn_CerrarCaja.BackColor = System.Drawing.Color.DimGray;
            this.btn_CerrarCaja.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_CerrarCaja.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CerrarCaja.ForeColor = System.Drawing.Color.White;
            this.btn_CerrarCaja.Location = new System.Drawing.Point(-1, 929);
            this.btn_CerrarCaja.Name = "btn_CerrarCaja";
            this.btn_CerrarCaja.Size = new System.Drawing.Size(298, 46);
            this.btn_CerrarCaja.TabIndex = 7;
            this.btn_CerrarCaja.Text = "Cerrar Caja";
            this.btn_CerrarCaja.UseVisualStyleBackColor = false;
            this.btn_CerrarCaja.Click += new System.EventHandler(this.btn_CerrarCaja_Click);
            // 
            // flp_Categorias
            // 
            this.flp_Categorias.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_Categorias.Location = new System.Drawing.Point(0, 0);
            this.flp_Categorias.Name = "flp_Categorias";
            this.flp_Categorias.Size = new System.Drawing.Size(296, 923);
            this.flp_Categorias.TabIndex = 0;
            // 
            // formularioNuevaVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.pnl_Principal);
            this.Controls.Add(this.pnl_Arriba);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formularioNuevaVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nueva Venta";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.formularioNuevaVenta_Load);
            this.pnl_Arriba.ResumeLayout(false);
            this.pnl_Arriba.PerformLayout();
            this.pnl_Principal.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnl_Izquierdo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_Arriba;
        private System.Windows.Forms.Panel pnl_Principal;
        private System.Windows.Forms.Label lbl_Usuario;
        private System.Windows.Forms.Button btn_Volver;
        private System.Windows.Forms.Panel pnl_Izquierdo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_Total;
        private System.Windows.Forms.Label lbl_PedidoActual;
        private System.Windows.Forms.Label lbl_Precio;
        private System.Windows.Forms.Button btn_VaciarPedido;
        private System.Windows.Forms.Button btn_CobrarEImprimir;
        private System.Windows.Forms.FlowLayoutPanel flp_Carrito;
        private System.Windows.Forms.FlowLayoutPanel flp_Productos;
        private System.Windows.Forms.Label lbl_Fecha;
        private System.Windows.Forms.Label lbl_FormaDePago;
        private System.Windows.Forms.ComboBox cb_FormaPago;
        private System.Windows.Forms.FlowLayoutPanel flp_Categorias;
        private System.Windows.Forms.Button btn_ReimprimirPorNro;
        private System.Windows.Forms.Button btn_ReimprimirUltima;
        private System.Windows.Forms.TextBox txt_NroTicket;
        private System.Windows.Forms.Button btn_CerrarCaja;
    }
}