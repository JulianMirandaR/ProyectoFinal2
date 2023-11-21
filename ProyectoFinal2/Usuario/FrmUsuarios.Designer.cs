namespace ProyectoFinal2
{
    partial class FrmUsuarios
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
            this.btnIngresarNuevo = new System.Windows.Forms.ToolStripLabel();
            this.btnModificarUsuario = new System.Windows.Forms.ToolStripLabel();
            this.btnEliminarUsuario = new System.Windows.Forms.ToolStripLabel();
            this.panelUsuarios = new System.Windows.Forms.Panel();
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
            this.btnIngresarNuevo,
            this.btnModificarUsuario,
            this.btnEliminarUsuario});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(190, 757);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnIngresarNuevo
            // 
            this.btnIngresarNuevo.AutoSize = false;
            this.btnIngresarNuevo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnIngresarNuevo.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresarNuevo.Name = "btnIngresarNuevo";
            this.btnIngresarNuevo.Padding = new System.Windows.Forms.Padding(0, 88, 0, 0);
            this.btnIngresarNuevo.Size = new System.Drawing.Size(190, 180);
            this.btnIngresarNuevo.Text = "Ingresar Nuevo";
            this.btnIngresarNuevo.Click += new System.EventHandler(this.btnIngresarNuevo_Click);
            // 
            // btnModificarUsuario
            // 
            this.btnModificarUsuario.AutoSize = false;
            this.btnModificarUsuario.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnModificarUsuario.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarUsuario.Name = "btnModificarUsuario";
            this.btnModificarUsuario.Padding = new System.Windows.Forms.Padding(0, 88, 0, 0);
            this.btnModificarUsuario.Size = new System.Drawing.Size(190, 180);
            this.btnModificarUsuario.Text = "Modificar Usuario";
            this.btnModificarUsuario.Click += new System.EventHandler(this.btnModificarUsuario_Click);
            // 
            // btnEliminarUsuario
            // 
            this.btnEliminarUsuario.AutoSize = false;
            this.btnEliminarUsuario.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarUsuario.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnEliminarUsuario.Name = "btnEliminarUsuario";
            this.btnEliminarUsuario.Padding = new System.Windows.Forms.Padding(0, 88, 0, 0);
            this.btnEliminarUsuario.Size = new System.Drawing.Size(190, 180);
            this.btnEliminarUsuario.Text = "Eliminar Usuario";
            this.btnEliminarUsuario.Click += new System.EventHandler(this.btnEliminarUsurio_Click);
            // 
            // panelUsuarios
            // 
            this.panelUsuarios.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panelUsuarios.Location = new System.Drawing.Point(186, 0);
            this.panelUsuarios.Margin = new System.Windows.Forms.Padding(4);
            this.panelUsuarios.Name = "panelUsuarios";
            this.panelUsuarios.Size = new System.Drawing.Size(1354, 757);
            this.panelUsuarios.TabIndex = 2;
            // 
            // FrmUsuarios
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1540, 757);
            this.Controls.Add(this.panelUsuarios);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmUsuarios";
            this.Text = "FrmUsuarios";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel btnIngresarNuevo;
        private System.Windows.Forms.ToolStripLabel btnModificarUsuario;
        private System.Windows.Forms.ToolStripLabel btnEliminarUsuario;
        private System.Windows.Forms.Panel panelUsuarios;
    }
}