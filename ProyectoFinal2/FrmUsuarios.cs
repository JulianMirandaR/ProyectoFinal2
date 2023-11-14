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
    public partial class FrmUsuarios : Form
    {
        public FrmUsuarios()
        {
            InitializeComponent();
        }
        private Form ventanaActual;// mantiene registrado la ventana actual
        private ToolStripItem botonActivo;

        private void AbrirVentana(Form otroFormulario, ToolStripItem botonPresionado)
        {
            if (ventanaActual != null)
            {
                ventanaActual.Close(); //Cierra la ventana anterior si existe.
                botonActivo.BackColor = DefaultBackColor;
            }

            otroFormulario.TopLevel = false;
            panelUsuarios.Controls.Add(otroFormulario);
            otroFormulario.Show();
            ventanaActual = otroFormulario; //Establece la ventana actual como la que se acaba de abrir.
            botonActivo = botonPresionado;  // Establece el botón activo.
            botonActivo.BackColor = SystemColors.MenuHighlight;
        }

        private void btnIngresarNuevo_Click(object sender, EventArgs e)
        {
            FrmAgregarUsuario otroFormulario = new FrmAgregarUsuario();
            AbrirVentana(otroFormulario, btnIngresarNuevo);
        }

        private void btnModificarUsuario_Click(object sender, EventArgs e)
        {
            FrmModificarUsuario otroFormulario = new FrmModificarUsuario();
            AbrirVentana(otroFormulario, btnModificarUsuario);
        }

        private void btnEliminarUsurio_Click(object sender, EventArgs e)
        {
            FrmEliminarUsuario otroFormulario = new FrmEliminarUsuario();
            AbrirVentana(otroFormulario, btnEliminarUsuario);
        }
    }
}
