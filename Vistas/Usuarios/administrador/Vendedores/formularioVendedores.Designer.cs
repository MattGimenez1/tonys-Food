namespace Vistas.Usuarios.administrador.Vendedores
{
    partial class formularioVendedores
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
            this.btn_volver = new System.Windows.Forms.Button();
            this.lbl_Usuario = new System.Windows.Forms.Label();
            this.pnl_Izquierdo = new System.Windows.Forms.Panel();
            this.btn_Vendedores = new System.Windows.Forms.Button();
            this.pnl_Principal = new System.Windows.Forms.Panel();
            this.dgv_Vendedor = new System.Windows.Forms.DataGridView();
            this.pnl_Derecha = new System.Windows.Forms.Panel();
            this.lbl_Fecha = new System.Windows.Forms.Label();
            this.btn_DarDeAlta = new System.Windows.Forms.Button();
            this.btn_DarDeBajaVendedor = new System.Windows.Forms.Button();
            this.btn_NuevoVendedor = new System.Windows.Forms.Button();
            this.btn_GuardarVendedor = new System.Windows.Forms.Button();
            this.txt_Dni = new System.Windows.Forms.TextBox();
            this.lbl_Dni = new System.Windows.Forms.Label();
            this.txt_Usuario = new System.Windows.Forms.TextBox();
            this.lbl_UsuarioVendedor = new System.Windows.Forms.Label();
            this.txt_Apellido = new System.Windows.Forms.TextBox();
            this.lbl_Apellido = new System.Windows.Forms.Label();
            this.txt_Nombre = new System.Windows.Forms.TextBox();
            this.lbl_Nombre = new System.Windows.Forms.Label();
            this.lbl_NuevoVendedor = new System.Windows.Forms.Label();
            this.lbl_TocarFila = new System.Windows.Forms.Label();
            this.pnl_Arriba.SuspendLayout();
            this.pnl_Izquierdo.SuspendLayout();
            this.pnl_Principal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Vendedor)).BeginInit();
            this.pnl_Derecha.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_Arriba
            // 
            this.pnl_Arriba.BackColor = System.Drawing.Color.White;
            this.pnl_Arriba.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_Arriba.Controls.Add(this.btn_volver);
            this.pnl_Arriba.Controls.Add(this.lbl_Usuario);
            this.pnl_Arriba.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Arriba.Location = new System.Drawing.Point(0, 0);
            this.pnl_Arriba.Name = "pnl_Arriba";
            this.pnl_Arriba.Size = new System.Drawing.Size(1920, 100);
            this.pnl_Arriba.TabIndex = 2;
            this.pnl_Arriba.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_Arriba_Paint);
            // 
            // btn_volver
            // 
            this.btn_volver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_volver.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_volver.Location = new System.Drawing.Point(1770, 11);
            this.btn_volver.Name = "btn_volver";
            this.btn_volver.Size = new System.Drawing.Size(132, 31);
            this.btn_volver.TabIndex = 1;
            this.btn_volver.Text = "Volver";
            this.btn_volver.UseVisualStyleBackColor = true;
            this.btn_volver.Click += new System.EventHandler(this.btn_volver_Click);
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
            this.lbl_Usuario.Click += new System.EventHandler(this.lbl_Usuario_Click);
            // 
            // pnl_Izquierdo
            // 
            this.pnl_Izquierdo.BackColor = System.Drawing.Color.White;
            this.pnl_Izquierdo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_Izquierdo.Controls.Add(this.btn_Vendedores);
            this.pnl_Izquierdo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_Izquierdo.Location = new System.Drawing.Point(0, 100);
            this.pnl_Izquierdo.Name = "pnl_Izquierdo";
            this.pnl_Izquierdo.Size = new System.Drawing.Size(314, 980);
            this.pnl_Izquierdo.TabIndex = 1;
            this.pnl_Izquierdo.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_Izquierdo_Paint);
            // 
            // btn_Vendedores
            // 
            this.btn_Vendedores.BackColor = System.Drawing.Color.DimGray;
            this.btn_Vendedores.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Vendedores.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Vendedores.ForeColor = System.Drawing.Color.White;
            this.btn_Vendedores.Location = new System.Drawing.Point(0, 3);
            this.btn_Vendedores.Name = "btn_Vendedores";
            this.btn_Vendedores.Size = new System.Drawing.Size(313, 41);
            this.btn_Vendedores.TabIndex = 3;
            this.btn_Vendedores.Text = "Vendedores";
            this.btn_Vendedores.UseVisualStyleBackColor = false;
            this.btn_Vendedores.Click += new System.EventHandler(this.btn_Vendedores_Click_1);
            // 
            // pnl_Principal
            // 
            this.pnl_Principal.BackColor = System.Drawing.Color.White;
            this.pnl_Principal.Controls.Add(this.dgv_Vendedor);
            this.pnl_Principal.Controls.Add(this.pnl_Derecha);
            this.pnl_Principal.Controls.Add(this.lbl_TocarFila);
            this.pnl_Principal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Principal.Location = new System.Drawing.Point(314, 100);
            this.pnl_Principal.Name = "pnl_Principal";
            this.pnl_Principal.Size = new System.Drawing.Size(1606, 980);
            this.pnl_Principal.TabIndex = 0;
            this.pnl_Principal.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_Principal_Paint);
            // 
            // dgv_Vendedor
            // 
            this.dgv_Vendedor.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Vendedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Vendedor.Location = new System.Drawing.Point(21, 30);
            this.dgv_Vendedor.Name = "dgv_Vendedor";
            this.dgv_Vendedor.RowHeadersWidth = 51;
            this.dgv_Vendedor.RowTemplate.Height = 24;
            this.dgv_Vendedor.Size = new System.Drawing.Size(1278, 938);
            this.dgv_Vendedor.TabIndex = 2;
            this.dgv_Vendedor.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Vendedor_CellContentClick);
            // 
            // pnl_Derecha
            // 
            this.pnl_Derecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_Derecha.Controls.Add(this.lbl_Fecha);
            this.pnl_Derecha.Controls.Add(this.btn_DarDeAlta);
            this.pnl_Derecha.Controls.Add(this.btn_DarDeBajaVendedor);
            this.pnl_Derecha.Controls.Add(this.btn_NuevoVendedor);
            this.pnl_Derecha.Controls.Add(this.btn_GuardarVendedor);
            this.pnl_Derecha.Controls.Add(this.txt_Dni);
            this.pnl_Derecha.Controls.Add(this.lbl_Dni);
            this.pnl_Derecha.Controls.Add(this.txt_Usuario);
            this.pnl_Derecha.Controls.Add(this.lbl_UsuarioVendedor);
            this.pnl_Derecha.Controls.Add(this.txt_Apellido);
            this.pnl_Derecha.Controls.Add(this.lbl_Apellido);
            this.pnl_Derecha.Controls.Add(this.txt_Nombre);
            this.pnl_Derecha.Controls.Add(this.lbl_Nombre);
            this.pnl_Derecha.Controls.Add(this.lbl_NuevoVendedor);
            this.pnl_Derecha.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl_Derecha.Location = new System.Drawing.Point(1318, 0);
            this.pnl_Derecha.Name = "pnl_Derecha";
            this.pnl_Derecha.Size = new System.Drawing.Size(288, 980);
            this.pnl_Derecha.TabIndex = 1;
            this.pnl_Derecha.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_Derecha_Paint);
            // 
            // lbl_Fecha
            // 
            this.lbl_Fecha.AutoSize = true;
            this.lbl_Fecha.Location = new System.Drawing.Point(176, 963);
            this.lbl_Fecha.Name = "lbl_Fecha";
            this.lbl_Fecha.Size = new System.Drawing.Size(45, 16);
            this.lbl_Fecha.TabIndex = 4;
            this.lbl_Fecha.Text = "Fecha";
            this.lbl_Fecha.Click += new System.EventHandler(this.lbl_Fecha_Click);
            // 
            // btn_DarDeAlta
            // 
            this.btn_DarDeAlta.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DarDeAlta.Location = new System.Drawing.Point(15, 539);
            this.btn_DarDeAlta.Name = "btn_DarDeAlta";
            this.btn_DarDeAlta.Size = new System.Drawing.Size(255, 46);
            this.btn_DarDeAlta.TabIndex = 20;
            this.btn_DarDeAlta.Text = "Dar de Alta";
            this.btn_DarDeAlta.UseVisualStyleBackColor = true;
            this.btn_DarDeAlta.Click += new System.EventHandler(this.btn_DarDeAlta_Click);
            // 
            // btn_DarDeBajaVendedor
            // 
            this.btn_DarDeBajaVendedor.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DarDeBajaVendedor.Location = new System.Drawing.Point(15, 487);
            this.btn_DarDeBajaVendedor.Name = "btn_DarDeBajaVendedor";
            this.btn_DarDeBajaVendedor.Size = new System.Drawing.Size(256, 46);
            this.btn_DarDeBajaVendedor.TabIndex = 19;
            this.btn_DarDeBajaVendedor.Text = "Dar de Baja";
            this.btn_DarDeBajaVendedor.UseVisualStyleBackColor = true;
            this.btn_DarDeBajaVendedor.Click += new System.EventHandler(this.btn_DarDeBajaVendedor_Click);
            // 
            // btn_NuevoVendedor
            // 
            this.btn_NuevoVendedor.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_NuevoVendedor.Location = new System.Drawing.Point(16, 383);
            this.btn_NuevoVendedor.Name = "btn_NuevoVendedor";
            this.btn_NuevoVendedor.Size = new System.Drawing.Size(255, 46);
            this.btn_NuevoVendedor.TabIndex = 18;
            this.btn_NuevoVendedor.Text = "Nuevo";
            this.btn_NuevoVendedor.UseVisualStyleBackColor = true;
            this.btn_NuevoVendedor.Click += new System.EventHandler(this.btn_NuevoVendedor_Click);
            // 
            // btn_GuardarVendedor
            // 
            this.btn_GuardarVendedor.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GuardarVendedor.Location = new System.Drawing.Point(15, 435);
            this.btn_GuardarVendedor.Name = "btn_GuardarVendedor";
            this.btn_GuardarVendedor.Size = new System.Drawing.Size(256, 46);
            this.btn_GuardarVendedor.TabIndex = 10;
            this.btn_GuardarVendedor.Text = "Guardar";
            this.btn_GuardarVendedor.UseVisualStyleBackColor = true;
            this.btn_GuardarVendedor.Click += new System.EventHandler(this.btn_GuardarVendedor_Click);
            // 
            // txt_Dni
            // 
            this.txt_Dni.BackColor = System.Drawing.Color.DarkGray;
            this.txt_Dni.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Dni.Location = new System.Drawing.Point(15, 301);
            this.txt_Dni.MaxLength = 8;
            this.txt_Dni.Name = "txt_Dni";
            this.txt_Dni.Size = new System.Drawing.Size(256, 32);
            this.txt_Dni.TabIndex = 16;
            this.txt_Dni.TextChanged += new System.EventHandler(this.txt_Dni_TextChanged);
            // 
            // lbl_Dni
            // 
            this.lbl_Dni.AutoSize = true;
            this.lbl_Dni.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Dni.Location = new System.Drawing.Point(12, 281);
            this.lbl_Dni.Name = "lbl_Dni";
            this.lbl_Dni.Size = new System.Drawing.Size(30, 17);
            this.lbl_Dni.TabIndex = 15;
            this.lbl_Dni.Text = "DNI";
            this.lbl_Dni.Click += new System.EventHandler(this.lbl_Dni_Click);
            // 
            // txt_Usuario
            // 
            this.txt_Usuario.BackColor = System.Drawing.Color.DarkGray;
            this.txt_Usuario.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Usuario.Location = new System.Drawing.Point(15, 229);
            this.txt_Usuario.MaxLength = 50;
            this.txt_Usuario.Name = "txt_Usuario";
            this.txt_Usuario.Size = new System.Drawing.Size(256, 32);
            this.txt_Usuario.TabIndex = 14;
            this.txt_Usuario.TextChanged += new System.EventHandler(this.txt_Usuario_TextChanged);
            // 
            // lbl_UsuarioVendedor
            // 
            this.lbl_UsuarioVendedor.AutoSize = true;
            this.lbl_UsuarioVendedor.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_UsuarioVendedor.Location = new System.Drawing.Point(12, 209);
            this.lbl_UsuarioVendedor.Name = "lbl_UsuarioVendedor";
            this.lbl_UsuarioVendedor.Size = new System.Drawing.Size(53, 17);
            this.lbl_UsuarioVendedor.TabIndex = 13;
            this.lbl_UsuarioVendedor.Text = "Usuario";
            this.lbl_UsuarioVendedor.Click += new System.EventHandler(this.lbl_UsuarioVendedor_Click);
            // 
            // txt_Apellido
            // 
            this.txt_Apellido.BackColor = System.Drawing.Color.DarkGray;
            this.txt_Apellido.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Apellido.Location = new System.Drawing.Point(15, 156);
            this.txt_Apellido.MaxLength = 50;
            this.txt_Apellido.Name = "txt_Apellido";
            this.txt_Apellido.Size = new System.Drawing.Size(256, 32);
            this.txt_Apellido.TabIndex = 12;
            this.txt_Apellido.TextChanged += new System.EventHandler(this.txt_Apellido_TextChanged);
            // 
            // lbl_Apellido
            // 
            this.lbl_Apellido.AutoSize = true;
            this.lbl_Apellido.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Apellido.Location = new System.Drawing.Point(12, 136);
            this.lbl_Apellido.Name = "lbl_Apellido";
            this.lbl_Apellido.Size = new System.Drawing.Size(56, 17);
            this.lbl_Apellido.TabIndex = 11;
            this.lbl_Apellido.Text = "Apellido";
            this.lbl_Apellido.Click += new System.EventHandler(this.lbl_Apellido_Click);
            // 
            // txt_Nombre
            // 
            this.txt_Nombre.BackColor = System.Drawing.Color.DarkGray;
            this.txt_Nombre.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Nombre.Location = new System.Drawing.Point(15, 81);
            this.txt_Nombre.MaxLength = 50;
            this.txt_Nombre.Name = "txt_Nombre";
            this.txt_Nombre.Size = new System.Drawing.Size(256, 32);
            this.txt_Nombre.TabIndex = 10;
            this.txt_Nombre.TextChanged += new System.EventHandler(this.txt_Nombre_TextChanged);
            // 
            // lbl_Nombre
            // 
            this.lbl_Nombre.AutoSize = true;
            this.lbl_Nombre.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Nombre.Location = new System.Drawing.Point(12, 61);
            this.lbl_Nombre.Name = "lbl_Nombre";
            this.lbl_Nombre.Size = new System.Drawing.Size(57, 17);
            this.lbl_Nombre.TabIndex = 10;
            this.lbl_Nombre.Text = "Nombre";
            this.lbl_Nombre.Click += new System.EventHandler(this.lbl_Nombre_Click);
            // 
            // lbl_NuevoVendedor
            // 
            this.lbl_NuevoVendedor.AutoSize = true;
            this.lbl_NuevoVendedor.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NuevoVendedor.Location = new System.Drawing.Point(30, 7);
            this.lbl_NuevoVendedor.Name = "lbl_NuevoVendedor";
            this.lbl_NuevoVendedor.Size = new System.Drawing.Size(232, 37);
            this.lbl_NuevoVendedor.TabIndex = 2;
            this.lbl_NuevoVendedor.Text = "Nuevo Vendedor";
            this.lbl_NuevoVendedor.Click += new System.EventHandler(this.lbl_NuevoVendedor_Click);
            // 
            // lbl_TocarFila
            // 
            this.lbl_TocarFila.AutoSize = true;
            this.lbl_TocarFila.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TocarFila.Location = new System.Drawing.Point(16, 4);
            this.lbl_TocarFila.Name = "lbl_TocarFila";
            this.lbl_TocarFila.Size = new System.Drawing.Size(230, 25);
            this.lbl_TocarFila.TabIndex = 0;
            this.lbl_TocarFila.Text = "Toca una fila para editarla";
            this.lbl_TocarFila.Click += new System.EventHandler(this.lbl_TocarFila_Click);
            // 
            // formularioVendedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.pnl_Principal);
            this.Controls.Add(this.pnl_Izquierdo);
            this.Controls.Add(this.pnl_Arriba);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formularioVendedores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuPrincipal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.formularioVendedores_Load);
            this.pnl_Arriba.ResumeLayout(false);
            this.pnl_Arriba.PerformLayout();
            this.pnl_Izquierdo.ResumeLayout(false);
            this.pnl_Principal.ResumeLayout(false);
            this.pnl_Principal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Vendedor)).EndInit();
            this.pnl_Derecha.ResumeLayout(false);
            this.pnl_Derecha.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_Arriba;
        private System.Windows.Forms.Panel pnl_Izquierdo;
        private System.Windows.Forms.Panel pnl_Principal;
        private System.Windows.Forms.Label lbl_Usuario;
        private System.Windows.Forms.Button btn_volver;
        private System.Windows.Forms.Button btn_Vendedores;
        private System.Windows.Forms.Label lbl_TocarFila;
        private System.Windows.Forms.Panel pnl_Derecha;
        private System.Windows.Forms.Label lbl_NuevoVendedor;
        private System.Windows.Forms.Label lbl_Nombre;
        private System.Windows.Forms.TextBox txt_Apellido;
        private System.Windows.Forms.Label lbl_Apellido;
        private System.Windows.Forms.TextBox txt_Nombre;
        private System.Windows.Forms.TextBox txt_Dni;
        private System.Windows.Forms.Label lbl_Dni;
        private System.Windows.Forms.TextBox txt_Usuario;
        private System.Windows.Forms.Label lbl_UsuarioVendedor;
        private System.Windows.Forms.Button btn_DarDeBajaVendedor;
        private System.Windows.Forms.Button btn_NuevoVendedor;
        private System.Windows.Forms.Button btn_GuardarVendedor;
        private System.Windows.Forms.DataGridView dgv_Vendedor;
        private System.Windows.Forms.Button btn_DarDeAlta;
        private System.Windows.Forms.Label lbl_Fecha;
    }
}