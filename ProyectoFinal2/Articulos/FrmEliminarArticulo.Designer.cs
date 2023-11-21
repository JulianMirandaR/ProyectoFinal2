namespace ProyectoFinal2
{
    partial class FrmEliminarArticulo
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cmbArticuloAEliminar = new System.Windows.Forms.ComboBox();
            this.btnCargar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblPrecioVenta = new System.Windows.Forms.Label();
            this.lblPrecioCompra = new System.Windows.Forms.Label();
            this.lblPresentacion = new System.Windows.Forms.Label();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.lblIdArticulo = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.cmbArticuloAEliminar);
            this.panel1.Controls.Add(this.btnCargar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(27, 26);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1320, 377);
            this.panel1.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(227, 42);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(821, 199);
            this.dataGridView1.TabIndex = 7;
            // 
            // cmbArticuloAEliminar
            // 
            this.cmbArticuloAEliminar.FormattingEnabled = true;
            this.cmbArticuloAEliminar.Location = new System.Drawing.Point(358, 264);
            this.cmbArticuloAEliminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbArticuloAEliminar.Name = "cmbArticuloAEliminar";
            this.cmbArticuloAEliminar.Size = new System.Drawing.Size(793, 24);
            this.cmbArticuloAEliminar.TabIndex = 4;
            // 
            // btnCargar
            // 
            this.btnCargar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCargar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargar.Location = new System.Drawing.Point(986, 316);
            this.btnCargar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(165, 34);
            this.btnCargar.TabIndex = 3;
            this.btnCargar.Text = "Seleccionar Empleado";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(142, 265);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Articulo a Eliminar:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblStock);
            this.panel2.Controls.Add(this.lblPrecioVenta);
            this.panel2.Controls.Add(this.lblPrecioCompra);
            this.panel2.Controls.Add(this.lblPresentacion);
            this.panel2.Controls.Add(this.lblDetalle);
            this.panel2.Controls.Add(this.lblIdArticulo);
            this.panel2.Controls.Add(this.btnAceptar);
            this.panel2.Controls.Add(this.btnCancelar);
            this.panel2.Location = new System.Drawing.Point(27, 424);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1320, 305);
            this.panel2.TabIndex = 6;
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStock.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblStock.Location = new System.Drawing.Point(831, 167);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(74, 25);
            this.lblStock.TabIndex = 7;
            this.lblStock.Text = "Stock:";
            // 
            // lblPrecioVenta
            // 
            this.lblPrecioVenta.AutoSize = true;
            this.lblPrecioVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioVenta.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblPrecioVenta.Location = new System.Drawing.Point(831, 105);
            this.lblPrecioVenta.Name = "lblPrecioVenta";
            this.lblPrecioVenta.Size = new System.Drawing.Size(149, 25);
            this.lblPrecioVenta.TabIndex = 6;
            this.lblPrecioVenta.Text = "Precio Venta: ";
            // 
            // lblPrecioCompra
            // 
            this.lblPrecioCompra.AutoSize = true;
            this.lblPrecioCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioCompra.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblPrecioCompra.Location = new System.Drawing.Point(831, 48);
            this.lblPrecioCompra.Name = "lblPrecioCompra";
            this.lblPrecioCompra.Size = new System.Drawing.Size(168, 25);
            this.lblPrecioCompra.TabIndex = 5;
            this.lblPrecioCompra.Text = "Precio Compra: ";
            // 
            // lblPresentacion
            // 
            this.lblPresentacion.AutoSize = true;
            this.lblPresentacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPresentacion.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblPresentacion.Location = new System.Drawing.Point(313, 167);
            this.lblPresentacion.Name = "lblPresentacion";
            this.lblPresentacion.Size = new System.Drawing.Size(151, 25);
            this.lblPresentacion.TabIndex = 4;
            this.lblPresentacion.Text = "Presentacion: ";
            // 
            // lblDetalle
            // 
            this.lblDetalle.AutoSize = true;
            this.lblDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblDetalle.Location = new System.Drawing.Point(313, 105);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(92, 25);
            this.lblDetalle.TabIndex = 3;
            this.lblDetalle.Text = "Detalle: ";
            // 
            // lblIdArticulo
            // 
            this.lblIdArticulo.AutoSize = true;
            this.lblIdArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdArticulo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblIdArticulo.Location = new System.Drawing.Point(313, 48);
            this.lblIdArticulo.Name = "lblIdArticulo";
            this.lblIdArticulo.Size = new System.Drawing.Size(157, 25);
            this.lblIdArticulo.TabIndex = 2;
            this.lblIdArticulo.Text = "Id del Articulo: ";
            // 
            // btnAceptar
            // 
            this.btnAceptar.FlatAppearance.BorderSize = 2;
            this.btnAceptar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(907, 232);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(141, 42);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(307, 232);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(141, 42);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // FrmEliminarArticulo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1375, 757);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmEliminarArticulo";
            this.Text = "FrmEliminarArticulo";
            this.Load += new System.EventHandler(this.FrmEliminarArticulo_Load_1);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbArticuloAEliminar;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblPrecioVenta;
        private System.Windows.Forms.Label lblPrecioCompra;
        private System.Windows.Forms.Label lblPresentacion;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.Label lblIdArticulo;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}