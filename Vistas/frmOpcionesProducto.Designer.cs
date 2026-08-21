namespace Vistas
{
    partial class frmOpcionesProducto
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
            this.lbl_NombreProducto = new System.Windows.Forms.Label();
            this.lbl_Tamanos = new System.Windows.Forms.Label();
            this.lst_Tamanos = new System.Windows.Forms.ListBox();
            this.lbl_Nombre = new System.Windows.Forms.Label();
            this.txt_NombreTamano = new System.Windows.Forms.TextBox();
            this.lbl_Precio = new System.Windows.Forms.Label();
            this.txt_PrecioTamano = new System.Windows.Forms.TextBox();
            this.btn_AgregarTamano = new System.Windows.Forms.Button();
            this.btn_QuitarTamano = new System.Windows.Forms.Button();
            this.lbl_Extras = new System.Windows.Forms.Label();
            this.lst_Extras = new System.Windows.Forms.ListBox();
            this.lbl_NombreExtra = new System.Windows.Forms.Label();
            this.txt_NombreExtra = new System.Windows.Forms.TextBox();
            this.lbl_PrecioAdicional = new System.Windows.Forms.Label();
            this.txt_PrecioExtra = new System.Windows.Forms.TextBox();
            this.btn_AgregarExtra = new System.Windows.Forms.Button();
            this.btn_QuitarExtra = new System.Windows.Forms.Button();
            this.lbl_Ingredientes = new System.Windows.Forms.Label();
            this.lst_Ingredientes = new System.Windows.Forms.ListBox();
            this.txt_NombreIngrediente = new System.Windows.Forms.TextBox();
            this.lbl_NombreIngrediente = new System.Windows.Forms.Label();
            this.btn_AgregarIngrediente = new System.Windows.Forms.Button();
            this.btn_QuitarIngrediente = new System.Windows.Forms.Button();
            this.btn_Cerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_NombreProducto
            // 
            this.lbl_NombreProducto.AutoSize = true;
            this.lbl_NombreProducto.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NombreProducto.Location = new System.Drawing.Point(15, 10);
            this.lbl_NombreProducto.Name = "lbl_NombreProducto";
            this.lbl_NombreProducto.Size = new System.Drawing.Size(0, 32);
            this.lbl_NombreProducto.TabIndex = 0;
            // 
            // lbl_Tamanos
            // 
            this.lbl_Tamanos.AutoSize = true;
            this.lbl_Tamanos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Tamanos.Location = new System.Drawing.Point(15, 45);
            this.lbl_Tamanos.Name = "lbl_Tamanos";
            this.lbl_Tamanos.Size = new System.Drawing.Size(80, 23);
            this.lbl_Tamanos.TabIndex = 1;
            this.lbl_Tamanos.Text = "Tamanos";
            // 
            // lst_Tamanos
            // 
            this.lst_Tamanos.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst_Tamanos.FormattingEnabled = true;
            this.lst_Tamanos.ItemHeight = 17;
            this.lst_Tamanos.Location = new System.Drawing.Point(12, 71);
            this.lst_Tamanos.Name = "lst_Tamanos";
            this.lst_Tamanos.Size = new System.Drawing.Size(460, 72);
            this.lst_Tamanos.TabIndex = 2;
            // 
            // lbl_Nombre
            // 
            this.lbl_Nombre.AutoSize = true;
            this.lbl_Nombre.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Nombre.Location = new System.Drawing.Point(15, 150);
            this.lbl_Nombre.Name = "lbl_Nombre";
            this.lbl_Nombre.Size = new System.Drawing.Size(57, 17);
            this.lbl_Nombre.TabIndex = 3;
            this.lbl_Nombre.Text = "Nombre";
            // 
            // txt_NombreTamano
            // 
            this.txt_NombreTamano.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_NombreTamano.Location = new System.Drawing.Point(15, 170);
            this.txt_NombreTamano.Name = "txt_NombreTamano";
            this.txt_NombreTamano.Size = new System.Drawing.Size(150, 25);
            this.txt_NombreTamano.TabIndex = 4;
            // 
            // lbl_Precio
            // 
            this.lbl_Precio.AutoSize = true;
            this.lbl_Precio.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Precio.Location = new System.Drawing.Point(180, 150);
            this.lbl_Precio.Name = "lbl_Precio";
            this.lbl_Precio.Size = new System.Drawing.Size(44, 17);
            this.lbl_Precio.TabIndex = 5;
            this.lbl_Precio.Text = "Precio";
            // 
            // txt_PrecioTamano
            // 
            this.txt_PrecioTamano.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PrecioTamano.Location = new System.Drawing.Point(180, 170);
            this.txt_PrecioTamano.Name = "txt_PrecioTamano";
            this.txt_PrecioTamano.Size = new System.Drawing.Size(100, 25);
            this.txt_PrecioTamano.TabIndex = 6;
            // 
            // btn_AgregarTamano
            // 
            this.btn_AgregarTamano.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AgregarTamano.Location = new System.Drawing.Point(290, 168);
            this.btn_AgregarTamano.Name = "btn_AgregarTamano";
            this.btn_AgregarTamano.Size = new System.Drawing.Size(90, 27);
            this.btn_AgregarTamano.TabIndex = 7;
            this.btn_AgregarTamano.Text = "Agregar";
            this.btn_AgregarTamano.UseVisualStyleBackColor = true;
            this.btn_AgregarTamano.Click += new System.EventHandler(this.btn_AgregarTamano_Click);
            // 
            // btn_QuitarTamano
            // 
            this.btn_QuitarTamano.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_QuitarTamano.Location = new System.Drawing.Point(385, 168);
            this.btn_QuitarTamano.Name = "btn_QuitarTamano";
            this.btn_QuitarTamano.Size = new System.Drawing.Size(90, 27);
            this.btn_QuitarTamano.TabIndex = 8;
            this.btn_QuitarTamano.Text = "Quitar";
            this.btn_QuitarTamano.UseVisualStyleBackColor = true;
            this.btn_QuitarTamano.Click += new System.EventHandler(this.btn_QuitarTamano_Click);
            // 
            // lbl_Extras
            // 
            this.lbl_Extras.AutoSize = true;
            this.lbl_Extras.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Extras.Location = new System.Drawing.Point(15, 210);
            this.lbl_Extras.Name = "lbl_Extras";
            this.lbl_Extras.Size = new System.Drawing.Size(58, 23);
            this.lbl_Extras.TabIndex = 9;
            this.lbl_Extras.Text = "Extras";
            // 
            // lst_Extras
            // 
            this.lst_Extras.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst_Extras.FormattingEnabled = true;
            this.lst_Extras.ItemHeight = 17;
            this.lst_Extras.Location = new System.Drawing.Point(15, 236);
            this.lst_Extras.Name = "lst_Extras";
            this.lst_Extras.Size = new System.Drawing.Size(460, 72);
            this.lst_Extras.TabIndex = 10;
            // 
            // lbl_NombreExtra
            // 
            this.lbl_NombreExtra.AutoSize = true;
            this.lbl_NombreExtra.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NombreExtra.Location = new System.Drawing.Point(15, 315);
            this.lbl_NombreExtra.Name = "lbl_NombreExtra";
            this.lbl_NombreExtra.Size = new System.Drawing.Size(57, 17);
            this.lbl_NombreExtra.TabIndex = 11;
            this.lbl_NombreExtra.Text = "Nombre";
            // 
            // txt_NombreExtra
            // 
            this.txt_NombreExtra.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_NombreExtra.Location = new System.Drawing.Point(15, 335);
            this.txt_NombreExtra.Name = "txt_NombreExtra";
            this.txt_NombreExtra.Size = new System.Drawing.Size(150, 25);
            this.txt_NombreExtra.TabIndex = 12;
            // 
            // lbl_PrecioAdicional
            // 
            this.lbl_PrecioAdicional.AutoSize = true;
            this.lbl_PrecioAdicional.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PrecioAdicional.Location = new System.Drawing.Point(180, 315);
            this.lbl_PrecioAdicional.Name = "lbl_PrecioAdicional";
            this.lbl_PrecioAdicional.Size = new System.Drawing.Size(101, 17);
            this.lbl_PrecioAdicional.TabIndex = 13;
            this.lbl_PrecioAdicional.Text = "Precio Adicional";
            // 
            // txt_PrecioExtra
            // 
            this.txt_PrecioExtra.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PrecioExtra.Location = new System.Drawing.Point(180, 335);
            this.txt_PrecioExtra.Name = "txt_PrecioExtra";
            this.txt_PrecioExtra.Size = new System.Drawing.Size(100, 25);
            this.txt_PrecioExtra.TabIndex = 14;
            // 
            // btn_AgregarExtra
            // 
            this.btn_AgregarExtra.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AgregarExtra.Location = new System.Drawing.Point(290, 333);
            this.btn_AgregarExtra.Name = "btn_AgregarExtra";
            this.btn_AgregarExtra.Size = new System.Drawing.Size(90, 27);
            this.btn_AgregarExtra.TabIndex = 15;
            this.btn_AgregarExtra.Text = "Agregar";
            this.btn_AgregarExtra.UseVisualStyleBackColor = true;
            this.btn_AgregarExtra.Click += new System.EventHandler(this.btn_AgregarExtra_Click);
            // 
            // btn_QuitarExtra
            // 
            this.btn_QuitarExtra.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_QuitarExtra.Location = new System.Drawing.Point(385, 333);
            this.btn_QuitarExtra.Name = "btn_QuitarExtra";
            this.btn_QuitarExtra.Size = new System.Drawing.Size(90, 27);
            this.btn_QuitarExtra.TabIndex = 16;
            this.btn_QuitarExtra.Text = "Quitar";
            this.btn_QuitarExtra.UseVisualStyleBackColor = true;
            this.btn_QuitarExtra.Click += new System.EventHandler(this.btn_QuitarExtra_Click);
            // 
            // lbl_Ingredientes
            // 
            this.lbl_Ingredientes.AutoSize = true;
            this.lbl_Ingredientes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Ingredientes.Location = new System.Drawing.Point(15, 375);
            this.lbl_Ingredientes.Name = "lbl_Ingredientes";
            this.lbl_Ingredientes.Size = new System.Drawing.Size(273, 23);
            this.lbl_Ingredientes.TabIndex = 17;
            this.lbl_Ingredientes.Text = "Ingredientes que se pueden quitar";
            // 
            // lst_Ingredientes
            // 
            this.lst_Ingredientes.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst_Ingredientes.FormattingEnabled = true;
            this.lst_Ingredientes.ItemHeight = 17;
            this.lst_Ingredientes.Location = new System.Drawing.Point(12, 401);
            this.lst_Ingredientes.Name = "lst_Ingredientes";
            this.lst_Ingredientes.Size = new System.Drawing.Size(460, 72);
            this.lst_Ingredientes.TabIndex = 18;
            // 
            // txt_NombreIngrediente
            // 
            this.txt_NombreIngrediente.Location = new System.Drawing.Point(15, 500);
            this.txt_NombreIngrediente.Name = "txt_NombreIngrediente";
            this.txt_NombreIngrediente.Size = new System.Drawing.Size(250, 22);
            this.txt_NombreIngrediente.TabIndex = 19;
            // 
            // lbl_NombreIngrediente
            // 
            this.lbl_NombreIngrediente.AutoSize = true;
            this.lbl_NombreIngrediente.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NombreIngrediente.Location = new System.Drawing.Point(15, 480);
            this.lbl_NombreIngrediente.Name = "lbl_NombreIngrediente";
            this.lbl_NombreIngrediente.Size = new System.Drawing.Size(149, 17);
            this.lbl_NombreIngrediente.TabIndex = 20;
            this.lbl_NombreIngrediente.Text = "Nombre del ingrediente";
            // 
            // btn_AgregarIngrediente
            // 
            this.btn_AgregarIngrediente.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AgregarIngrediente.Location = new System.Drawing.Point(290, 498);
            this.btn_AgregarIngrediente.Name = "btn_AgregarIngrediente";
            this.btn_AgregarIngrediente.Size = new System.Drawing.Size(90, 27);
            this.btn_AgregarIngrediente.TabIndex = 21;
            this.btn_AgregarIngrediente.Text = "Agregar ";
            this.btn_AgregarIngrediente.UseVisualStyleBackColor = true;
            this.btn_AgregarIngrediente.Click += new System.EventHandler(this.btn_AgregarIngrediente_Click);
            // 
            // btn_QuitarIngrediente
            // 
            this.btn_QuitarIngrediente.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_QuitarIngrediente.Location = new System.Drawing.Point(385, 498);
            this.btn_QuitarIngrediente.Name = "btn_QuitarIngrediente";
            this.btn_QuitarIngrediente.Size = new System.Drawing.Size(90, 27);
            this.btn_QuitarIngrediente.TabIndex = 22;
            this.btn_QuitarIngrediente.Text = "Quitar";
            this.btn_QuitarIngrediente.UseVisualStyleBackColor = true;
            this.btn_QuitarIngrediente.Click += new System.EventHandler(this.btn_QuitarIngrediente_Click);
            // 
            // btn_Cerrar
            // 
            this.btn_Cerrar.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cerrar.Location = new System.Drawing.Point(19, 606);
            this.btn_Cerrar.Name = "btn_Cerrar";
            this.btn_Cerrar.Size = new System.Drawing.Size(460, 35);
            this.btn_Cerrar.TabIndex = 23;
            this.btn_Cerrar.Text = "Cerrar";
            this.btn_Cerrar.UseVisualStyleBackColor = true;
            this.btn_Cerrar.Click += new System.EventHandler(this.btn_Cerrar_Click);
            // 
            // frmOpcionesProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 653);
            this.Controls.Add(this.btn_Cerrar);
            this.Controls.Add(this.btn_QuitarIngrediente);
            this.Controls.Add(this.btn_AgregarIngrediente);
            this.Controls.Add(this.lbl_NombreIngrediente);
            this.Controls.Add(this.txt_NombreIngrediente);
            this.Controls.Add(this.lst_Ingredientes);
            this.Controls.Add(this.lbl_Ingredientes);
            this.Controls.Add(this.btn_QuitarExtra);
            this.Controls.Add(this.btn_AgregarExtra);
            this.Controls.Add(this.txt_PrecioExtra);
            this.Controls.Add(this.lbl_PrecioAdicional);
            this.Controls.Add(this.txt_NombreExtra);
            this.Controls.Add(this.lbl_NombreExtra);
            this.Controls.Add(this.lst_Extras);
            this.Controls.Add(this.lbl_Extras);
            this.Controls.Add(this.btn_QuitarTamano);
            this.Controls.Add(this.btn_AgregarTamano);
            this.Controls.Add(this.txt_PrecioTamano);
            this.Controls.Add(this.lbl_Precio);
            this.Controls.Add(this.txt_NombreTamano);
            this.Controls.Add(this.lbl_Nombre);
            this.Controls.Add(this.lst_Tamanos);
            this.Controls.Add(this.lbl_Tamanos);
            this.Controls.Add(this.lbl_NombreProducto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmOpcionesProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Opciones de Producto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_NombreProducto;
        private System.Windows.Forms.Label lbl_Tamanos;
        private System.Windows.Forms.ListBox lst_Tamanos;
        private System.Windows.Forms.Label lbl_Nombre;
        private System.Windows.Forms.TextBox txt_NombreTamano;
        private System.Windows.Forms.Label lbl_Precio;
        private System.Windows.Forms.TextBox txt_PrecioTamano;
        private System.Windows.Forms.Button btn_AgregarTamano;
        private System.Windows.Forms.Button btn_QuitarTamano;
        private System.Windows.Forms.Label lbl_Extras;
        private System.Windows.Forms.ListBox lst_Extras;
        private System.Windows.Forms.Label lbl_NombreExtra;
        private System.Windows.Forms.TextBox txt_NombreExtra;
        private System.Windows.Forms.Label lbl_PrecioAdicional;
        private System.Windows.Forms.TextBox txt_PrecioExtra;
        private System.Windows.Forms.Button btn_AgregarExtra;
        private System.Windows.Forms.Button btn_QuitarExtra;
        private System.Windows.Forms.Label lbl_Ingredientes;
        private System.Windows.Forms.ListBox lst_Ingredientes;
        private System.Windows.Forms.TextBox txt_NombreIngrediente;
        private System.Windows.Forms.Label lbl_NombreIngrediente;
        private System.Windows.Forms.Button btn_AgregarIngrediente;
        private System.Windows.Forms.Button btn_QuitarIngrediente;
        private System.Windows.Forms.Button btn_Cerrar;
    }
}