namespace ProyectoFinal2
{
    partial class FormProveedores
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
            this.btnListaProveedores = new System.Windows.Forms.ToolStripLabel();
            this.btnAgregarProveedor = new System.Windows.Forms.ToolStripLabel();
            this.btnModificarProveedor = new System.Windows.Forms.ToolStripLabel();
            this.btnEliminarProveedor = new System.Windows.Forms.ToolStripLabel();
            this.panelProveedores = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnListaProveedores,
            this.btnAgregarProveedor,
            this.btnModificarProveedor,
            this.btnEliminarProveedor});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(190, 757);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnListaProveedores
            // 
            this.btnListaProveedores.AutoSize = false;
            this.btnListaProveedores.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnListaProveedores.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnListaProveedores.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListaProveedores.Name = "btnListaProveedores";
            this.btnListaProveedores.Padding = new System.Windows.Forms.Padding(0, 88, 0, 0);
            this.btnListaProveedores.Size = new System.Drawing.Size(190, 168);
            this.btnListaProveedores.Text = "Lista de Proveedores";
            this.btnListaProveedores.Click += new System.EventHandler(this.btnListaProveedores_Click);
            // 
            // btnAgregarProveedor
            // 
            this.btnAgregarProveedor.AutoSize = false;
            this.btnAgregarProveedor.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnAgregarProveedor.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarProveedor.Name = "btnAgregarProveedor";
            this.btnAgregarProveedor.Padding = new System.Windows.Forms.Padding(0, 88, 0, 0);
            this.btnAgregarProveedor.Size = new System.Drawing.Size(190, 168);
            this.btnAgregarProveedor.Text = "Agregar Proveedor";
            this.btnAgregarProveedor.Click += new System.EventHandler(this.btnAgregarProveedor_Click);
            // 
            // btnModificarProveedor
            // 
            this.btnModificarProveedor.AutoSize = false;
            this.btnModificarProveedor.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarProveedor.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnModificarProveedor.Name = "btnModificarProveedor";
            this.btnModificarProveedor.Padding = new System.Windows.Forms.Padding(0, 88, 0, 0);
            this.btnModificarProveedor.Size = new System.Drawing.Size(190, 168);
            this.btnModificarProveedor.Text = "Modificar Proveedor ";
            this.btnModificarProveedor.Click += new System.EventHandler(this.btnModificarProveedor_Click);
            // 
            // btnEliminarProveedor
            // 
            this.btnEliminarProveedor.AutoSize = false;
            this.btnEliminarProveedor.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarProveedor.Name = "btnEliminarProveedor";
            this.btnEliminarProveedor.Padding = new System.Windows.Forms.Padding(0, 88, 0, 0);
            this.btnEliminarProveedor.Size = new System.Drawing.Size(190, 168);
            this.btnEliminarProveedor.Text = "Eliminar Proveedor";
            this.btnEliminarProveedor.Click += new System.EventHandler(this.btnEliminarProveedor_Click);
            // 
            // panelProveedores
            // 
            this.panelProveedores.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panelProveedores.Location = new System.Drawing.Point(186, 0);
            this.panelProveedores.Margin = new System.Windows.Forms.Padding(4);
            this.panelProveedores.Name = "panelProveedores";
            this.panelProveedores.Size = new System.Drawing.Size(1341, 757);
            this.panelProveedores.TabIndex = 2;
            // 
            // FormProveedores
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1530, 757);
            this.Controls.Add(this.panelProveedores);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormProveedores";
            this.Text = "FrmProveedores";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel btnListaProveedores;
        private System.Windows.Forms.ToolStripLabel btnAgregarProveedor;
        private System.Windows.Forms.ToolStripLabel btnModificarProveedor;
        private System.Windows.Forms.ToolStripLabel btnEliminarProveedor;
        private System.Windows.Forms.Panel panelProveedores;
    }
}