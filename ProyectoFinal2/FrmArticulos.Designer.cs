namespace ProyectoFinal2
{
    partial class FrmArticulos
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnListaArticulos = new System.Windows.Forms.ToolStripLabel();
            this.btnAgregarArticulo = new System.Windows.Forms.ToolStripLabel();
            this.btnModificarArticulo = new System.Windows.Forms.ToolStripLabel();
            this.btnEliminarArticulo = new System.Windows.Forms.ToolStripLabel();
            this.panelArticulo = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnListaArticulos,
            this.btnAgregarArticulo,
            this.btnModificarArticulo,
            this.btnEliminarArticulo});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(191, 757);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnListaArticulos
            // 
            this.btnListaArticulos.AutoSize = false;
            this.btnListaArticulos.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnListaArticulos.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListaArticulos.Name = "btnListaArticulos";
            this.btnListaArticulos.Padding = new System.Windows.Forms.Padding(0, 88, 0, 0);
            this.btnListaArticulos.Size = new System.Drawing.Size(160, 170);
            this.btnListaArticulos.Text = "Lista de Articulos ";
            this.btnListaArticulos.Click += new System.EventHandler(this.btnListaArticulos_Click);
            // 
            // btnAgregarArticulo
            // 
            this.btnAgregarArticulo.AutoSize = false;
            this.btnAgregarArticulo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnAgregarArticulo.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarArticulo.Name = "btnAgregarArticulo";
            this.btnAgregarArticulo.Padding = new System.Windows.Forms.Padding(0, 88, 0, 0);
            this.btnAgregarArticulo.Size = new System.Drawing.Size(190, 170);
            this.btnAgregarArticulo.Text = "Agregar Articulo";
            this.btnAgregarArticulo.Click += new System.EventHandler(this.btnAgregarArticulo_Click);
            // 
            // btnModificarArticulo
            // 
            this.btnModificarArticulo.AutoSize = false;
            this.btnModificarArticulo.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarArticulo.Name = "btnModificarArticulo";
            this.btnModificarArticulo.Padding = new System.Windows.Forms.Padding(0, 88, 0, 0);
            this.btnModificarArticulo.Size = new System.Drawing.Size(190, 170);
            this.btnModificarArticulo.Text = "Modificar Articulo ";
            this.btnModificarArticulo.Click += new System.EventHandler(this.btnModificarArticulo_Click);
            // 
            // btnEliminarArticulo
            // 
            this.btnEliminarArticulo.AutoSize = false;
            this.btnEliminarArticulo.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarArticulo.Name = "btnEliminarArticulo";
            this.btnEliminarArticulo.Padding = new System.Windows.Forms.Padding(0, 88, 0, 0);
            this.btnEliminarArticulo.Size = new System.Drawing.Size(190, 170);
            this.btnEliminarArticulo.Text = "Eliminar Articulo";
            this.btnEliminarArticulo.Click += new System.EventHandler(this.btnEliminarArticulo_Click);
            // 
            // panelArticulo
            // 
            this.panelArticulo.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panelArticulo.Location = new System.Drawing.Point(185, 0);
            this.panelArticulo.Margin = new System.Windows.Forms.Padding(4);
            this.panelArticulo.Name = "panelArticulo";
            this.panelArticulo.Size = new System.Drawing.Size(1342, 757);
            this.panelArticulo.TabIndex = 1;
            // 
            // FrmArticulos
            // 
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1526, 757);
            this.Controls.Add(this.panelArticulo);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmArticulos";
            this.Text = "ArticuloForm";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripLabel btnListaArticulos;
        private System.Windows.Forms.ToolStripLabel btnAgregarArticulo;
        private System.Windows.Forms.ToolStripLabel btnModificarArticulo;
        private System.Windows.Forms.ToolStripLabel btnEliminarArticulo;
        private System.Windows.Forms.Panel panelArticulo;
        public System.Windows.Forms.ToolStrip toolStrip1;
    }
}