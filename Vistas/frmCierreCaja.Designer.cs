namespace Vistas
{
    partial class frmCierreCaja
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
            this.lbl_Tituto = new System.Windows.Forms.Label();
            this.lbl_Efectivo = new System.Windows.Forms.Label();
            this.lbl_Transferencia = new System.Windows.Forms.Label();
            this.lbl_QR = new System.Windows.Forms.Label();
            this.lbl_TotalGeneral = new System.Windows.Forms.Label();
            this.btn_ConfirmarCierre = new System.Windows.Forms.Button();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_Tituto
            // 
            this.lbl_Tituto.AutoSize = true;
            this.lbl_Tituto.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Tituto.Location = new System.Drawing.Point(15, 15);
            this.lbl_Tituto.Name = "lbl_Tituto";
            this.lbl_Tituto.Size = new System.Drawing.Size(195, 37);
            this.lbl_Tituto.TabIndex = 0;
            this.lbl_Tituto.Text = "Cierre de Caja";
            // 
            // lbl_Efectivo
            // 
            this.lbl_Efectivo.AutoSize = true;
            this.lbl_Efectivo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Efectivo.Location = new System.Drawing.Point(15, 60);
            this.lbl_Efectivo.Name = "lbl_Efectivo";
            this.lbl_Efectivo.Size = new System.Drawing.Size(28, 28);
            this.lbl_Efectivo.TabIndex = 1;
            this.lbl_Efectivo.Text = "....";
            // 
            // lbl_Transferencia
            // 
            this.lbl_Transferencia.AutoSize = true;
            this.lbl_Transferencia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Transferencia.Location = new System.Drawing.Point(15, 95);
            this.lbl_Transferencia.Name = "lbl_Transferencia";
            this.lbl_Transferencia.Size = new System.Drawing.Size(28, 28);
            this.lbl_Transferencia.TabIndex = 2;
            this.lbl_Transferencia.Text = "....";
            // 
            // lbl_QR
            // 
            this.lbl_QR.AutoSize = true;
            this.lbl_QR.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_QR.Location = new System.Drawing.Point(15, 130);
            this.lbl_QR.Name = "lbl_QR";
            this.lbl_QR.Size = new System.Drawing.Size(28, 28);
            this.lbl_QR.TabIndex = 3;
            this.lbl_QR.Text = "....";
            // 
            // lbl_TotalGeneral
            // 
            this.lbl_TotalGeneral.AutoSize = true;
            this.lbl_TotalGeneral.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TotalGeneral.Location = new System.Drawing.Point(15, 175);
            this.lbl_TotalGeneral.Name = "lbl_TotalGeneral";
            this.lbl_TotalGeneral.Size = new System.Drawing.Size(42, 32);
            this.lbl_TotalGeneral.TabIndex = 4;
            this.lbl_TotalGeneral.Text = "....";
            // 
            // btn_ConfirmarCierre
            // 
            this.btn_ConfirmarCierre.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ConfirmarCierre.Location = new System.Drawing.Point(15, 230);
            this.btn_ConfirmarCierre.Name = "btn_ConfirmarCierre";
            this.btn_ConfirmarCierre.Size = new System.Drawing.Size(350, 40);
            this.btn_ConfirmarCierre.TabIndex = 5;
            this.btn_ConfirmarCierre.Text = "Confirmar Cierre";
            this.btn_ConfirmarCierre.UseVisualStyleBackColor = true;
            this.btn_ConfirmarCierre.Click += new System.EventHandler(this.btn_ConfirmarCierre_Click);
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancelar.Location = new System.Drawing.Point(15, 280);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(350, 35);
            this.btn_Cancelar.TabIndex = 6;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // frmCierreCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 353);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.btn_ConfirmarCierre);
            this.Controls.Add(this.lbl_TotalGeneral);
            this.Controls.Add(this.lbl_QR);
            this.Controls.Add(this.lbl_Transferencia);
            this.Controls.Add(this.lbl_Efectivo);
            this.Controls.Add(this.lbl_Tituto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmCierreCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cierre de Caja";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Tituto;
        private System.Windows.Forms.Label lbl_Efectivo;
        private System.Windows.Forms.Label lbl_Transferencia;
        private System.Windows.Forms.Label lbl_QR;
        private System.Windows.Forms.Label lbl_TotalGeneral;
        private System.Windows.Forms.Button btn_ConfirmarCierre;
        private System.Windows.Forms.Button btn_Cancelar;
    }
}