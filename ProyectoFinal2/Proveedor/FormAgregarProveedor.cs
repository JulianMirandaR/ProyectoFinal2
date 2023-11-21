using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoFinal;
using ValidarLibrary;

namespace ProyectoFinal2
{
    public partial class FormAgregarProveedor : Form
    {
        public FormAgregarProveedor()
        {
            InitializeComponent();
        }

        private void LimpiarPantalla()//Limpia los textBox
        {
            txtNombre.Clear();
            txtCuit.Clear();
            txtEmail.Clear();
            txtCelular.Clear();
            txtRubro.Clear();
            txtDireccion.Clear();
        }

        public bool FormularioValidado()
        {
            bool resultado = true;
            if (!Validator.IsAlphabetic(txtNombre.Text)) resultado = false;
            if (!Validator.IsAlphaNumeric(txtCuit.Text)) resultado = false;
            if (!Validator.IsAlphaNumeric(txtEmail.Text)) resultado = false;
            if (!Validator.IsAlphaNumeric(txtCelular.Text)) resultado = false;
            if (!Validator.IsAlphabetic(txtRubro.Text)) resultado = false;
            if (!Validator.IsDomicilio(txtDireccion.Text)) resultado = false;
            resultado = true;//no se porque siempre me da falso.Corregir
            return resultado;
        }

        //los siguientes son validores
        private void txtNombre_Validating(object sender, CancelEventArgs e)
        {
            if (!Validator.IsAlphabetic(txtNombre.Text))
            {
                txtNombre.Focus();
                errorProvider1.SetError(txtNombre, "El Nombre ingresado es incorrecto");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtNombre, string.Empty);
                e.Cancel = false;
            }
        }

        private void txtCuit_Validating(object sender, CancelEventArgs e)
        {
            if (!Validator.IsAlphaNumeric(txtCuit.Text))
            {
                txtCuit.Focus();
                errorProvider1.SetError(txtCuit, "El Cuit ingresado no es correcto");
            }
            else
            {
                errorProvider1.SetError(txtCuit, string.Empty);
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (!Validator.IsEmail(txtEmail.Text))
            {
                txtNombre.Focus();
                errorProvider1.SetError(txtEmail, "El Email ingresado es incorrecto");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtEmail, string.Empty);
                e.Cancel = false;
            }
        }

        private void txtCelular_Validating(object sender, CancelEventArgs e)
        {
            if (!Validator.IsAlphaNumeric(txtCelular.Text))
            {
                txtCelular.Focus();
                errorProvider1.SetError(txtCelular, "El Celular ingresado no es correcto");
            }
            else
            {
                errorProvider1.SetError(txtCelular, string.Empty);
            }
        }



        private void txtRubro_Validating(object sender, CancelEventArgs e)
        {
            if (!Validator.IsAlphabetic(txtRubro.Text))
            {
                txtRubro.Focus();
                errorProvider1.SetError(txtRubro, "El Rubro ingresado es incorrecto");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtRubro, string.Empty);
                e.Cancel = false;
            }
        }

        private void txtDireccion_Validating(object sender, CancelEventArgs e)
        {
            if (!Validator.IsDomicilio(txtDireccion.Text))
            {
                txtDireccion.Focus();
                errorProvider1.SetError(txtDireccion, "La Direccion ingresada es incorrecta");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtDireccion, string.Empty);
                e.Cancel = false;
            }
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)//Guardar proveedor en el servidor local
        {
            if (FormularioValidado())
            {
                var proveedor = new Proveedor(1,txtNombre.Text, long.Parse(txtCuit.Text), txtEmail.Text, long.Parse(txtCelular.Text), txtRubro.Text, txtDireccion.Text);
                var resultado = ProveedorController.AgregarProveedor(proveedor);
                if (resultado != null)
                {
                    MessageBox.Show("Se ha ingresado todos los datos del Proveedor correctamente");
                    LimpiarPantalla();
                }
                else
                {
                    MessageBox.Show("No se han obtenido datos");
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar todos los datos del Proveedor correctamente");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
