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
using UtilsLibrary;
using static System.Net.Mime.MediaTypeNames;

namespace ProyectoFinal2
{
    public partial class FrmModificarArticulo : Form
    {

        private List<string> proveedor = new List<string>() { };
        public FrmModificarArticulo()
        {
            InitializeComponent();
        }

        private void FrmModificarArticulo_Load(object sender, EventArgs e)
        {
            CargarDatosArticulos();
        }

        private void CargarDatosArticulos()
        {
            // Utiliza tu controlador de Artículo para obtener la lista de artículos
            // y mostrarla en el dataGridView1
            var resultado = ArticuloController.GetArticulos();

            if (resultado.IsValid)
            {
                dataGridView1.DataSource = resultado.Articulos;
            }
            else
            {
                MessageBox.Show($"Error al cargar los datos: {resultado.Error}");
            }
        }


        private void btnSeleccionar_Click_1(object sender, EventArgs e)
        {
            
            if (dataGridView1.SelectedRows.Count > 0)// obtiene el artículo seleccionado en el dataGridView1
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                long articuloId = Convert.ToInt64(selectedRow.Cells["Articuloid"].Value);

                
                var resultado = ArticuloController.GetArticulo(articuloId);// utiliza tu controlador de Artículo para obtener el artículo seleccionado

                if (resultado.IsValid)
                {
                    var articulo = resultado.Articulos[0];

                    // llena los controles del formulario con los datos del artículo
                    txtIdArticulo.Text = articulo.Articuloid.ToString();
                    txtDetalle.Text = articulo.Detalle;
                    txtPresentacion.Text = articulo.Presentacion;
                    txtPrecioCompra.Text = articulo.Precio_compra.ToString();
                    txtPrecioVenta.Text = articulo.Precio_venta.ToString();
                    txtStock.Text = articulo.Stock.ToString();

   
                    var proveedoresResultado = ProveedorController.GetProveedores(); // utiliza tu controlador de Proveedor para obtener la lista de proveedores

                    if (proveedoresResultado.IsValid)
                    {
                        cmbProveedor.DataSource = proveedoresResultado.Proveedores;
                        cmbProveedor.DisplayMember = "Nombre";
                        cmbProveedor.ValueMember = "ProveedorID";

                        // selecciona el proveedor correspondiente al artículo
                        cmbProveedor.SelectedValue = articulo.Proveedor;
                    }
                    else
                    {
                        MessageBox.Show($"Error al cargar los proveedores: {proveedoresResultado.Error}");
                    }
                }
                else
                {
                    MessageBox.Show($"Error al obtener el artículo: {resultado.Error}");
                }
            }
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            
            long articuloId = Convert.ToInt64(txtIdArticulo.Text);//
            string detalle = txtDetalle.Text;//
            string presentacion = txtPresentacion.Text;//
            decimal precioCompra = Convert.ToDecimal(txtPrecioCompra.Text);//// obtener los datos del formulario
            decimal precioVenta = Convert.ToDecimal(txtPrecioVenta.Text);//
            int stock = Convert.ToInt32(txtStock.Text);//
            string proveedorId = cmbProveedor.Text;//

            
            Articulo articulo = new Articulo(articuloId, detalle, presentacion, precioCompra, precioVenta, stock, proveedorId);//crea un nuevo objeto Articulo con los datos actualizados

            
            var resultado = ArticuloController.ModificarArticulo(articulo);// utiliza tu controlador de Artículo para modificar el artículo en la base de datos

            if (resultado.IsValid)
            {
                MessageBox.Show("Artículo modificado correctamente");
                CargarDatosArticulos(); // vuelve a cargar la lista de artículos
            }
            else
            {
                MessageBox.Show($"Error al modificar el artículo: {resultado.Error}");
            }
        }


    }
}