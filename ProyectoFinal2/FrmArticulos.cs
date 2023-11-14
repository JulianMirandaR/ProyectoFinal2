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
    public partial class FrmArticulos : Form
    {
        private Form ventanaActual;// mantiene registrado la ventana actual
        private ToolStripItem botonActivo;
        public FrmArticulos()
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
            panelArticulo.Controls.Add(otroFormulario);
            otroFormulario.Show();
            ventanaActual = otroFormulario; //Establece la ventana actual como la que se acaba de abrir.
            botonActivo = botonPresionado;  // Establece el botón activo.
            botonActivo.BackColor = SystemColors.MenuHighlight;
        }

        private void btnModificarArticulo_Click(object sender, EventArgs e)
        {
            FrmModificarArticulo otroFormulario = new FrmModificarArticulo();
            AbrirVentana(otroFormulario, btnModificarArticulo);
        }

        private void btnListaArticulos_Click(object sender, EventArgs e)
        {
            FrmListaArticulos otroFormulario = new FrmListaArticulos();
            AbrirVentana(otroFormulario, btnListaArticulos);
        }

        private void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            FrmAgregarArticulo otroFormulario = new FrmAgregarArticulo();
            AbrirVentana(otroFormulario, btnAgregarArticulo);
        }

        private void btnEliminarArticulo_Click(object sender, EventArgs e)
        {
            FrmEliminarArticulo otroFormulario = new FrmEliminarArticulo();
            AbrirVentana(otroFormulario, btnEliminarArticulo);
        }
    }
}
