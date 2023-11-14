using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal2
{
    public partial class InicioAdministrador : Form
    {
        private Form ventanaActual;
        private ToolStripItem menuItemActivo;
        public InicioAdministrador()
        {
            InitializeComponent();
            menuItemActivo = vigilanciaToolStripMenuItem;
        }
        
        
        private void AbrirVentana(Form otroFormulario, ToolStripItem menuItemPresionado)
        {
            if (ventanaActual != null)
            {
                ventanaActual.Close(); //Cierra la ventana anterior si existe.
                menuItemActivo.BackColor = SystemColors.ControlLight;
            }

            otroFormulario.TopLevel = false;
            panelInicio.Controls.Add(otroFormulario);
            otroFormulario.Show();
            ventanaActual = otroFormulario; //Establece la ventana actual como la que se acaba de abrir.
            menuItemActivo = menuItemPresionado; // Establece el elemento de menú activo.
            menuItemActivo.BackColor = SystemColors.ActiveBorder;
        }

        private void vigilanciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
                FrmVigilancia otroFormulario = new FrmVigilancia();
                AbrirVentana(otroFormulario, vigilanciaToolStripMenuItem);
            
        }

        private void transaccionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTransaccion otroFormulario = new FrmTransaccion();
            AbrirVentana(otroFormulario, transaccionToolStripMenuItem);
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVentas otroFormulario = new FrmVentas();
            AbrirVentana(otroFormulario, ventasToolStripMenuItem);
        }

        private void articulosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FrmArticulos otroFormulario = new FrmArticulos();
            AbrirVentana(otroFormulario, articulosToolStripMenuItem);
        }

        private void provedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProveedores otroFormulario = new FormProveedores();
            AbrirVentana(otroFormulario, provedoresToolStripMenuItem);
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsuarios otroFormulario = new FrmUsuarios();
            AbrirVentana(otroFormulario, usuariosToolStripMenuItem);
        }

        private void configurarCuentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ventana = new UserConfig();
            ventana.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose(); 
            var ventana = new FrmLogin();
            ventana.ShowDialog();
        }
    }
}
