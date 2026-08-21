namespace Vistas.Usuarios.administrador.Control_Diario
{
    partial class formularioControlDiario
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
            this.pnl_Izquierdo = new System.Windows.Forms.Panel();
            this.btn_EsteMes = new System.Windows.Forms.Button();
            this.btn_Todo = new System.Windows.Forms.Button();
            this.btn_Hoy = new System.Windows.Forms.Button();
            this.pnl_Principal = new System.Windows.Forms.Panel();
            this.lblb_DetalleVenta = new System.Windows.Forms.Label();
            this.lbl_Fecha = new System.Windows.Forms.Label();
            this.dgv_Ventas = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_ValorProducto = new System.Windows.Forms.Label();
            this.lbl_ProductoMasVendido = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_ValorTotal = new System.Windows.Forms.Label();
            this.lbl_TotalFacturado = new System.Windows.Forms.Label();
            this.pnl_VentasDelDia = new System.Windows.Forms.Panel();
            this.lbl_ValorVentas = new System.Windows.Forms.Label();
            this.lbl_VentasDelDia = new System.Windows.Forms.Label();
            this.pnl_Arriba.SuspendLayout();
            this.pnl_Izquierdo.SuspendLayout();
            this.pnl_Principal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Ventas)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnl_VentasDelDia.SuspendLayout();
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
            // pnl_Izquierdo
            // 
            this.pnl_Izquierdo.BackColor = System.Drawing.Color.White;
            this.pnl_Izquierdo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_Izquierdo.Controls.Add(this.btn_EsteMes);
            this.pnl_Izquierdo.Controls.Add(this.btn_Todo);
            this.pnl_Izquierdo.Controls.Add(this.btn_Hoy);
            this.pnl_Izquierdo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_Izquierdo.Location = new System.Drawing.Point(0, 100);
            this.pnl_Izquierdo.Name = "pnl_Izquierdo";
            this.pnl_Izquierdo.Size = new System.Drawing.Size(295, 980);
            this.pnl_Izquierdo.TabIndex = 1;
            // 
            // btn_EsteMes
            // 
            this.btn_EsteMes.BackColor = System.Drawing.Color.DimGray;
            this.btn_EsteMes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_EsteMes.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_EsteMes.ForeColor = System.Drawing.Color.White;
            this.btn_EsteMes.Location = new System.Drawing.Point(-1, 59);
            this.btn_EsteMes.Name = "btn_EsteMes";
            this.btn_EsteMes.Size = new System.Drawing.Size(295, 48);
            this.btn_EsteMes.TabIndex = 5;
            this.btn_EsteMes.Text = "Este Mes";
            this.btn_EsteMes.UseVisualStyleBackColor = false;
            this.btn_EsteMes.Click += new System.EventHandler(this.btn_EsteMes_Click);
            // 
            // btn_Todo
            // 
            this.btn_Todo.BackColor = System.Drawing.Color.DimGray;
            this.btn_Todo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Todo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Todo.ForeColor = System.Drawing.Color.White;
            this.btn_Todo.Location = new System.Drawing.Point(-1, 5);
            this.btn_Todo.Name = "btn_Todo";
            this.btn_Todo.Size = new System.Drawing.Size(295, 48);
            this.btn_Todo.TabIndex = 4;
            this.btn_Todo.Text = "Todo";
            this.btn_Todo.UseVisualStyleBackColor = false;
            this.btn_Todo.Click += new System.EventHandler(this.btn_Todo_Click);
            // 
            // btn_Hoy
            // 
            this.btn_Hoy.BackColor = System.Drawing.Color.DimGray;
            this.btn_Hoy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Hoy.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Hoy.ForeColor = System.Drawing.Color.White;
            this.btn_Hoy.Location = new System.Drawing.Point(-1, 113);
            this.btn_Hoy.Name = "btn_Hoy";
            this.btn_Hoy.Size = new System.Drawing.Size(295, 48);
            this.btn_Hoy.TabIndex = 2;
            this.btn_Hoy.Text = "Hoy";
            this.btn_Hoy.UseVisualStyleBackColor = false;
            this.btn_Hoy.Click += new System.EventHandler(this.btn_Hoy_Click);
            // 
            // pnl_Principal
            // 
            this.pnl_Principal.BackColor = System.Drawing.Color.White;
            this.pnl_Principal.Controls.Add(this.lblb_DetalleVenta);
            this.pnl_Principal.Controls.Add(this.lbl_Fecha);
            this.pnl_Principal.Controls.Add(this.dgv_Ventas);
            this.pnl_Principal.Controls.Add(this.panel2);
            this.pnl_Principal.Controls.Add(this.panel1);
            this.pnl_Principal.Controls.Add(this.pnl_VentasDelDia);
            this.pnl_Principal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Principal.Location = new System.Drawing.Point(295, 100);
            this.pnl_Principal.Name = "pnl_Principal";
            this.pnl_Principal.Size = new System.Drawing.Size(1625, 980);
            this.pnl_Principal.TabIndex = 0;
            // 
            // lblb_DetalleVenta
            // 
            this.lblb_DetalleVenta.AutoSize = true;
            this.lblb_DetalleVenta.Location = new System.Drawing.Point(77, 202);
            this.lblb_DetalleVenta.Name = "lblb_DetalleVenta";
            this.lblb_DetalleVenta.Size = new System.Drawing.Size(197, 16);
            this.lblb_DetalleVenta.TabIndex = 4;
            this.lblb_DetalleVenta.Text = "Toca una venta para ver detalle";
            // 
            // lbl_Fecha
            // 
            this.lbl_Fecha.AutoSize = true;
            this.lbl_Fecha.Location = new System.Drawing.Point(1525, 964);
            this.lbl_Fecha.Name = "lbl_Fecha";
            this.lbl_Fecha.Size = new System.Drawing.Size(45, 16);
            this.lbl_Fecha.TabIndex = 3;
            this.lbl_Fecha.Text = "Fecha";
            // 
            // dgv_Ventas
            // 
            this.dgv_Ventas.AllowUserToAddRows = false;
            this.dgv_Ventas.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Ventas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Ventas.Location = new System.Drawing.Point(63, 221);
            this.dgv_Ventas.MultiSelect = false;
            this.dgv_Ventas.Name = "dgv_Ventas";
            this.dgv_Ventas.ReadOnly = true;
            this.dgv_Ventas.RowHeadersWidth = 51;
            this.dgv_Ventas.RowTemplate.Height = 24;
            this.dgv_Ventas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Ventas.Size = new System.Drawing.Size(1520, 700);
            this.dgv_Ventas.TabIndex = 2;
            this.dgv_Ventas.SelectionChanged += new System.EventHandler(this.dgv_Ventas_SelectionChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkGray;
            this.panel2.Controls.Add(this.lbl_ValorProducto);
            this.panel2.Controls.Add(this.lbl_ProductoMasVendido);
            this.panel2.Location = new System.Drawing.Point(1220, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(363, 165);
            this.panel2.TabIndex = 1;
            // 
            // lbl_ValorProducto
            // 
            this.lbl_ValorProducto.AutoSize = true;
            this.lbl_ValorProducto.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ValorProducto.Location = new System.Drawing.Point(12, 62);
            this.lbl_ValorProducto.Name = "lbl_ValorProducto";
            this.lbl_ValorProducto.Size = new System.Drawing.Size(26, 30);
            this.lbl_ValorProducto.TabIndex = 3;
            this.lbl_ValorProducto.Text = "0";
            // 
            // lbl_ProductoMasVendido
            // 
            this.lbl_ProductoMasVendido.AutoSize = true;
            this.lbl_ProductoMasVendido.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ProductoMasVendido.Location = new System.Drawing.Point(12, 10);
            this.lbl_ProductoMasVendido.Name = "lbl_ProductoMasVendido";
            this.lbl_ProductoMasVendido.Size = new System.Drawing.Size(217, 25);
            this.lbl_ProductoMasVendido.TabIndex = 2;
            this.lbl_ProductoMasVendido.Text = "Producto Mas Vendido";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Controls.Add(this.lbl_ValorTotal);
            this.panel1.Controls.Add(this.lbl_TotalFacturado);
            this.panel1.Location = new System.Drawing.Point(647, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(360, 165);
            this.panel1.TabIndex = 1;
            // 
            // lbl_ValorTotal
            // 
            this.lbl_ValorTotal.AutoSize = true;
            this.lbl_ValorTotal.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ValorTotal.Location = new System.Drawing.Point(12, 62);
            this.lbl_ValorTotal.Name = "lbl_ValorTotal";
            this.lbl_ValorTotal.Size = new System.Drawing.Size(26, 30);
            this.lbl_ValorTotal.TabIndex = 2;
            this.lbl_ValorTotal.Text = "0";
            // 
            // lbl_TotalFacturado
            // 
            this.lbl_TotalFacturado.AutoSize = true;
            this.lbl_TotalFacturado.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TotalFacturado.Location = new System.Drawing.Point(12, 10);
            this.lbl_TotalFacturado.Name = "lbl_TotalFacturado";
            this.lbl_TotalFacturado.Size = new System.Drawing.Size(149, 25);
            this.lbl_TotalFacturado.TabIndex = 1;
            this.lbl_TotalFacturado.Text = "Total Facturado";
            // 
            // pnl_VentasDelDia
            // 
            this.pnl_VentasDelDia.BackColor = System.Drawing.Color.DarkGray;
            this.pnl_VentasDelDia.Controls.Add(this.lbl_ValorVentas);
            this.pnl_VentasDelDia.Controls.Add(this.lbl_VentasDelDia);
            this.pnl_VentasDelDia.Location = new System.Drawing.Point(63, 33);
            this.pnl_VentasDelDia.Name = "pnl_VentasDelDia";
            this.pnl_VentasDelDia.Size = new System.Drawing.Size(360, 166);
            this.pnl_VentasDelDia.TabIndex = 0;
            // 
            // lbl_ValorVentas
            // 
            this.lbl_ValorVentas.AutoSize = true;
            this.lbl_ValorVentas.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ValorVentas.Location = new System.Drawing.Point(12, 62);
            this.lbl_ValorVentas.Name = "lbl_ValorVentas";
            this.lbl_ValorVentas.Size = new System.Drawing.Size(26, 30);
            this.lbl_ValorVentas.TabIndex = 1;
            this.lbl_ValorVentas.Text = "0";
            // 
            // lbl_VentasDelDia
            // 
            this.lbl_VentasDelDia.AutoSize = true;
            this.lbl_VentasDelDia.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_VentasDelDia.Location = new System.Drawing.Point(12, 10);
            this.lbl_VentasDelDia.Name = "lbl_VentasDelDia";
            this.lbl_VentasDelDia.Size = new System.Drawing.Size(137, 25);
            this.lbl_VentasDelDia.TabIndex = 0;
            this.lbl_VentasDelDia.Text = "Ventas del Dia";
            // 
            // formularioControlDiario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.pnl_Principal);
            this.Controls.Add(this.pnl_Izquierdo);
            this.Controls.Add(this.pnl_Arriba);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formularioControlDiario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuPrincipal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.formularioControlDiario_Load);
            this.pnl_Arriba.ResumeLayout(false);
            this.pnl_Arriba.PerformLayout();
            this.pnl_Izquierdo.ResumeLayout(false);
            this.pnl_Principal.ResumeLayout(false);
            this.pnl_Principal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Ventas)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnl_VentasDelDia.ResumeLayout(false);
            this.pnl_VentasDelDia.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_Arriba;
        private System.Windows.Forms.Panel pnl_Izquierdo;
        private System.Windows.Forms.Button btn_Hoy;
        private System.Windows.Forms.Panel pnl_Principal;
        private System.Windows.Forms.Label lbl_Usuario;
        private System.Windows.Forms.Button btn_Volver;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnl_VentasDelDia;
        private System.Windows.Forms.Label lbl_VentasDelDia;
        private System.Windows.Forms.Label lbl_TotalFacturado;
        private System.Windows.Forms.Label lbl_ProductoMasVendido;
        private System.Windows.Forms.DataGridView dgv_Ventas;
        private System.Windows.Forms.Label lbl_ValorProducto;
        private System.Windows.Forms.Label lbl_ValorTotal;
        private System.Windows.Forms.Label lbl_ValorVentas;
        private System.Windows.Forms.Label lbl_Fecha;
        private System.Windows.Forms.Label lblb_DetalleVenta;
        private System.Windows.Forms.Button btn_EsteMes;
        private System.Windows.Forms.Button btn_Todo;
    }
}