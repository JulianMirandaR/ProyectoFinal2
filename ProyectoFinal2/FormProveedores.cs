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
    public partial class FormProveedores : Form
    {
        private Form ventanaActual;// mantiene registrado la ventana actual
        private ToolStripItem botonActivo;
        public FormProveedores()
        {
            InitializeComponent();
        }

        private void AbrirVentana(Form otroFormulario, ToolStripItem botonPresionado)
        {
            if (ventanaActual != null)
            {
                ventanaActual.Close(); //Cierra la ventana anterior si existe.
                botonActivo.BackColor = DefaultBackColor;
            }

            otroFormulario.TopLevel = false;
            panelProveedores.Controls.Add(otroFormulario);
            otroFormulario.Show();
            ventanaActual = otroFormulario; //Establece la ventana actual como la que se acaba de abrir.
            botonActivo = botonPresionado;  // Establece el botón activo.
            botonActivo.BackColor = SystemColors.MenuHighlight;
        }

        private void btnListaProveedores_Click(object sender, EventArgs e)
        {
            FormListaProveedores otroFormulario = new FormListaProveedores();
            AbrirVentana(otroFormulario, btnListaProveedores);
        }

        private void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            FormAgregarProveedor otroFormulario = new FormAgregarProveedor();
            AbrirVentana(otroFormulario, btnAgregarProveedor);
        }

        private void btnModificarProveedor_Click(object sender, EventArgs e)
        {
            FormModificarProveedor otroFormulario = new FormModificarProveedor();
            AbrirVentana(otroFormulario, btnModificarProveedor);
        }

        private void btnEliminarProveedor_Click(object sender, EventArgs e)
        {
            FormEliminarProveedor otroFormulario = new FormEliminarProveedor();
            AbrirVentana(otroFormulario, btnEliminarProveedor);
        }
    }
}
