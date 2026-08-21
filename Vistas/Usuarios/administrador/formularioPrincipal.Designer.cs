namespace Vistas.Usuarios.administrador
{
    partial class formularioPrincipal
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
            this.btn_CerrarSession = new System.Windows.Forms.Button();
            this.lbl_Usuario = new System.Windows.Forms.Label();
            this.pnl_Botones = new System.Windows.Forms.Panel();
            this.btn_Vendedores = new System.Windows.Forms.Button();
            this.btn_ControlDiario = new System.Windows.Forms.Button();
            this.btn_Menus = new System.Windows.Forms.Button();
            this.btn_NuevaVenta = new System.Windows.Forms.Button();
            this.pnl_Principal = new System.Windows.Forms.Panel();
            this.lbl_Fecha = new System.Windows.Forms.Label();
            this.pnl_Arriba.SuspendLayout();
            this.pnl_Botones.SuspendLayout();
            this.pnl_Principal.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_Arriba
            // 
            this.pnl_Arriba.BackColor = System.Drawing.Color.White;
            this.pnl_Arriba.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_Arriba.Controls.Add(this.btn_CerrarSession);
            this.pnl_Arriba.Controls.Add(this.lbl_Usuario);
            this.pnl_Arriba.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Arriba.Location = new System.Drawing.Point(0, 0);
            this.pnl_Arriba.Name = "pnl_Arriba";
            this.pnl_Arriba.Size = new System.Drawing.Size(1300, 100);
            this.pnl_Arriba.TabIndex = 2;
            // 
            // btn_CerrarSession
            // 
            this.btn_CerrarSession.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_CerrarSession.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CerrarSession.Location = new System.Drawing.Point(1135, 22);
            this.btn_CerrarSession.Name = "btn_CerrarSession";
            this.btn_CerrarSession.Size = new System.Drawing.Size(153, 31);
            this.btn_CerrarSession.TabIndex = 1;
            this.btn_CerrarSession.Text = "Cerrar Sesion";
            this.btn_CerrarSession.UseVisualStyleBackColor = true;
            this.btn_CerrarSession.Click += new System.EventHandler(this.btn_CerrarSession_Click);
            // 
            // lbl_Usuario
            // 
            this.lbl_Usuario.AutoSize = true;
            this.lbl_Usuario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Usuario.Location = new System.Drawing.Point(12, 35);
            this.lbl_Usuario.Name = "lbl_Usuario";
            this.lbl_Usuario.Size = new System.Drawing.Size(75, 23);
            this.lbl_Usuario.TabIndex = 0;
            this.lbl_Usuario.Text = "Usuario:";
            // 
            // pnl_Botones
            // 
            this.pnl_Botones.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnl_Botones.BackColor = System.Drawing.Color.White;
            this.pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_Botones.Controls.Add(this.btn_Vendedores);
            this.pnl_Botones.Controls.Add(this.btn_ControlDiario);
            this.pnl_Botones.Controls.Add(this.btn_Menus);
            this.pnl_Botones.Controls.Add(this.btn_NuevaVenta);
            this.pnl_Botones.Location = new System.Drawing.Point(458, 49);
            this.pnl_Botones.Name = "pnl_Botones";
            this.pnl_Botones.Size = new System.Drawing.Size(463, 568);
            this.pnl_Botones.TabIndex = 1;
            // 
            // btn_Vendedores
            // 
            this.btn_Vendedores.BackColor = System.Drawing.Color.DimGray;
            this.btn_Vendedores.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Vendedores.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Vendedores.ForeColor = System.Drawing.Color.White;
            this.btn_Vendedores.Location = new System.Drawing.Point(-1, 80);
            this.btn_Vendedores.Name = "btn_Vendedores";
            this.btn_Vendedores.Size = new System.Drawing.Size(463, 59);
            this.btn_Vendedores.TabIndex = 3;
            this.btn_Vendedores.Text = "Vendedores";
            this.btn_Vendedores.UseVisualStyleBackColor = false;
            this.btn_Vendedores.Click += new System.EventHandler(this.btn_Vendedores_Click);
            // 
            // btn_ControlDiario
            // 
            this.btn_ControlDiario.BackColor = System.Drawing.Color.DimGray;
            this.btn_ControlDiario.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_ControlDiario.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ControlDiario.ForeColor = System.Drawing.Color.White;
            this.btn_ControlDiario.Location = new System.Drawing.Point(-1, 145);
            this.btn_ControlDiario.Name = "btn_ControlDiario";
            this.btn_ControlDiario.Size = new System.Drawing.Size(463, 58);
            this.btn_ControlDiario.TabIndex = 2;
            this.btn_ControlDiario.Text = "Control Diario";
            this.btn_ControlDiario.UseVisualStyleBackColor = false;
            this.btn_ControlDiario.Click += new System.EventHandler(this.btn_ControlDiario_Click);
            // 
            // btn_Menus
            // 
            this.btn_Menus.BackColor = System.Drawing.Color.DimGray;
            this.btn_Menus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Menus.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Menus.ForeColor = System.Drawing.Color.White;
            this.btn_Menus.Location = new System.Drawing.Point(-1, 15);
            this.btn_Menus.Name = "btn_Menus";
            this.btn_Menus.Size = new System.Drawing.Size(463, 59);
            this.btn_Menus.TabIndex = 1;
            this.btn_Menus.Text = "Menus";
            this.btn_Menus.UseVisualStyleBackColor = false;
            this.btn_Menus.Click += new System.EventHandler(this.btn_Menus_Click);
            // 
            // btn_NuevaVenta
            // 
            this.btn_NuevaVenta.BackColor = System.Drawing.Color.DimGray;
            this.btn_NuevaVenta.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_NuevaVenta.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_NuevaVenta.ForeColor = System.Drawing.Color.White;
            this.btn_NuevaVenta.Location = new System.Drawing.Point(-1, 209);
            this.btn_NuevaVenta.Name = "btn_NuevaVenta";
            this.btn_NuevaVenta.Size = new System.Drawing.Size(463, 59);
            this.btn_NuevaVenta.TabIndex = 0;
            this.btn_NuevaVenta.Text = "Nueva venta";
            this.btn_NuevaVenta.UseVisualStyleBackColor = false;
            this.btn_NuevaVenta.Click += new System.EventHandler(this.btn_NuevaVenta_Click);
            // 
            // pnl_Principal
            // 
            this.pnl_Principal.BackColor = System.Drawing.Color.White;
            this.pnl_Principal.Controls.Add(this.lbl_Fecha);
            this.pnl_Principal.Controls.Add(this.pnl_Botones);
            this.pnl_Principal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Principal.Location = new System.Drawing.Point(0, 100);
            this.pnl_Principal.Name = "pnl_Principal";
            this.pnl_Principal.Size = new System.Drawing.Size(1300, 701);
            this.pnl_Principal.TabIndex = 0;
            // 
            // lbl_Fecha
            // 
            this.lbl_Fecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Fecha.AutoSize = true;
            this.lbl_Fecha.Location = new System.Drawing.Point(1217, 685);
            this.lbl_Fecha.Name = "lbl_Fecha";
            this.lbl_Fecha.Size = new System.Drawing.Size(45, 16);
            this.lbl_Fecha.TabIndex = 0;
            this.lbl_Fecha.Text = "Fecha";
            // 
            // formularioPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 801);
            this.Controls.Add(this.pnl_Principal);
            this.Controls.Add(this.pnl_Arriba);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formularioPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuPrincipal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.formularioPrincipal_Load);
            this.pnl_Arriba.ResumeLayout(false);
            this.pnl_Arriba.PerformLayout();
            this.pnl_Botones.ResumeLayout(false);
            this.pnl_Principal.ResumeLayout(false);
            this.pnl_Principal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_Arriba;
        private System.Windows.Forms.Panel pnl_Botones;
        private System.Windows.Forms.Button btn_ControlDiario;
        private System.Windows.Forms.Button btn_Menus;
        private System.Windows.Forms.Button btn_NuevaVenta;
        private System.Windows.Forms.Panel pnl_Principal;
        private System.Windows.Forms.Label lbl_Usuario;
        private System.Windows.Forms.Button btn_CerrarSession;
        private System.Windows.Forms.Button btn_Vendedores;
        private System.Windows.Forms.Label lbl_Fecha;
    }
}