using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;
using Emgu.CV;
using ProyectoFinal;
using ValidarLibrary;
using ZXing;

namespace ProyectoFinal2
{
    public partial class FrmAgregarArticulo : Form
    {
        public FrmAgregarArticulo()
        {
            InitializeComponent();
        }

        private Mat Frame;
        private VideoCapture Camara;
        private BarcodeReader Reader;

        private void LimpiarPantalla()
        {
            txtIdArticulo.Clear();
            txtDetalle.Clear();
            txtPresentacion.Clear();
            txtPrecioCompra.Clear();
            txtPrecioVenta.Clear();
            txtStock.Clear();
        }
        //Lo siguiente es para validar datos

        private void txtDetalle_Validating_1(object sender, CancelEventArgs e)
        {
            if (!Validator.IsAlphaNumeric(txtDetalle.Text))
            {
                txtDetalle.Focus();
                errorProvider1.SetError(txtDetalle, "El detalle ingresado es incorrecto");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtDetalle, string.Empty);
                e.Cancel = false;
            }
        }

        private void txtPresentacion_Validating_1(object sender, CancelEventArgs e)
        {
            if (!Validator.IsAlphaNumeric(txtPresentacion.Text))
            {
                txtPresentacion.Focus();
                errorProvider1.SetError(txtPresentacion, "La presentación ingresada es incorrecta");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtPresentacion, string.Empty);
                e.Cancel = false;
            }
        }

        private void txtPrecioCompra_Validating_1(object sender, CancelEventArgs e)
        {
            if (!Validator.IsMoneda(txtPrecioCompra.Text))
            {
                txtPrecioCompra.Focus();
                errorProvider1.SetError(txtPrecioCompra, "El precio de compra es incorrecto");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtPrecioCompra, string.Empty);
                e.Cancel = false;
            }
        }

        private void txtPrecioVenta_Validating_1(object sender, CancelEventArgs e)
        {
            if (!Validator.IsMoneda(txtPrecioVenta.Text))
            {
                txtPrecioVenta.Focus();
                errorProvider1.SetError(txtPrecioVenta, "El precio de venta es incorrecto");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtPrecioVenta, string.Empty);
                e.Cancel = false;
            }
        }

        private void txtStock_Validating(object sender, CancelEventArgs e)
        {
            if (!Validator.Isnumeric(txtStock.Text))
            {
                txtStock.Focus();
                errorProvider1.SetError(txtStock, "El stock ingresado no es correcto");
            }
            else
            {
                errorProvider1.SetError(txtStock, string.Empty);
            }
        }

        private void cmbProveedor_Validating(object sender, CancelEventArgs e)
        {
            if (!Validator.IsAlphabetic(cmbProveedor.Text))
            {
                cmbProveedor.Focus();
                errorProvider1.SetError(cmbProveedor, "El proveedor no es correcto");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(cmbProveedor, string.Empty);
                e.Cancel = false;
            }
        }


        public bool FormularioValidado()
        {
            bool resultado = true;
            if (!Validator.Isnumeric(txtIdArticulo.Text)) resultado = false;
            if (!Validator.IsAlphaNumeric(txtDetalle.Text)) resultado = false;
            if (!Validator.IsAlphaNumeric(txtPresentacion.Text)) resultado = false;
            if (!Validator.IsMoneda(txtPrecioCompra.Text)) resultado = false;
            if (!Validator.IsMoneda(txtPrecioVenta.Text)) resultado = false;
            if (!Validator.Isnumeric(txtStock.Text)) resultado = false;
            if (!Validator.IsAlphabetic(cmbProveedor.Text)) resultado = false;
            return resultado;
        }


        private void btnGuardar_Click(object sender, EventArgs e)//Se guarda el articulo
        {
            if (FormularioValidado())
            {
                var articulo = new Articulo(long.Parse(txtIdArticulo.Text),txtDetalle.Text, txtPresentacion.Text, decimal.Parse(txtPrecioCompra.Text), decimal.Parse(txtPrecioVenta.Text), int.Parse(txtStock.Text), cmbProveedor.Text);
                var resultado = ArticuloController.AgregarArticulo(articulo);
                if (resultado!=null)
                {
                    MessageBox.Show("Se ha ingresado todos los datos del artículo correctamente");
                    LimpiarPantalla();
                }
                else
                {
                    MessageBox.Show("No se han obtenido datos");
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar todos los datos del artículo correctamente");
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtIdArticulo_Validating(object sender, CancelEventArgs e)
        {
            if (!Validator.Isnumeric(txtIdArticulo.Text))
            {
                txtIdArticulo.Focus();
                errorProvider1.SetError(txtIdArticulo, "El Id del articulo ingresado no es correcto");
            }
            else
            {
                errorProvider1.SetError(txtIdArticulo, string.Empty);
            }
        }

        private void rdbEncender_CheckedChanged(object sender, EventArgs e)
        {
            Camara.Start();
            if (!timer1.Enabled) timer1.Enabled = true;
            if (!timer2.Enabled) timer2.Enabled = true;
            timer1.Start();
            timer2.Start();
        }

        private void FrmAgregarArticulo_Load(object sender, EventArgs e)
        {
            Frame = new Mat();
            Camara = new VideoCapture();
            Reader = new BarcodeReader();
            timer1.Interval = 40;
            timer2.Interval = 250;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            txtIdArticulo.Text = string.Empty;
            rdbApagar.Checked = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Camara.IsOpened)
            {
                Camara.Read(Frame);
                pictureBox1.Image = Frame.ToBitmap();
            }
        }

        private string DetalleArticulo(string _codigoBarra)
        {
            string detalle = string.Empty;
            if (!string.IsNullOrEmpty(_codigoBarra))
            { 

                detalle = _codigoBarra;
            }
            return detalle;
        }
        private void rdbApagar_CheckedChanged(object sender, EventArgs e)//Apagar camara
        {
            timer1.Stop();
            timer2.Stop();
            timer1.Enabled = false;
            timer2.Enabled = false;
            Camara.Stop();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Result resultado;
            if (pictureBox1.Image != null)
            {
                resultado = Reader.Decode((Bitmap)pictureBox1.Image);
                if (resultado != null)
                {
                    txtIdArticulo.Text = DetalleArticulo(resultado.Text);// Cambio la llamada a DetalleArticulo para obtener el código de barras
                }
            }
        }
    }
}


