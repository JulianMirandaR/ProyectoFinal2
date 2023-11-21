using System;
using System.Windows.Forms;
using ProyectoFinal;

namespace ProyectoFinal2
{
    public partial class FrmEliminarArticulo : Form
    {
        public FrmEliminarArticulo()
        {
            InitializeComponent();
        }


        private void LimpiarPantalla()
        {
            lblIdArticulo.Text = "IDArticulo: ";
            lblDetalle.Text = "Detalle:";
            lblPresentacion.Text = "Presentacion: ";
            lblPrecioCompra.Text = "Precio Compra: ";
            lblPrecioVenta.Text = "Precio Venta: ";
            lblStock.Text = "Stock: ";
        }

        private void LlenarDataGridView()
        {
            var ListaNombres = ArticuloController.GetListadoNombres();

            if (ListaNombres.Articulos.Count > 0)
            {
                dataGridView1.DataSource = ListaNombres.Articulos;
                // Asegúrate de que solo se muestren las columnas que necesitas
                dataGridView1.Columns["Articuloid"].Visible = false;
                dataGridView1.Columns[6].Visible = false;

                // Ajusta el ancho de las columnas según tus necesidades
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else
            {
                MessageBox.Show("No hay elementos para mostrar en el DataGridView.");
            }
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var dtoDetalle = (DtoDetalle)dataGridView1.SelectedRows[0].DataBoundItem;

                lblIdArticulo.Text = "IDArticulo: " + dtoDetalle.Articuloid.ToString();
                lblDetalle.Text = "Detalle: " + dtoDetalle.Detalle;
                lblPresentacion.Text = "Presentacion: " + dtoDetalle.Presentacion;
                lblPrecioCompra.Text = "Precio Compra: " + dtoDetalle.Precio_compra.ToString();
                lblPrecioVenta.Text = "Precio Venta: " + dtoDetalle.Precio_venta.ToString();
                lblStock.Text = "Stock: " + dtoDetalle.Stock.ToString();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var articulo = (Articulo)dataGridView1.SelectedRows[0].DataBoundItem;
                var articuloid = articulo.Articuloid;

                DialogResult respuesta = MessageBox.Show("¿Está seguro que desea eliminar este artículo?", articulo.Detalle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    var resultado = ArticuloController.EliminarArticulo(articuloid);
                    if (!resultado.IsValid)
                    {
                        MessageBox.Show("ERROR, no se pudo eliminar el artículo");
                    }
                    else
                    {
                        LimpiarPantalla();
                        LlenarDataGridView();
                    }
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            LimpiarPantalla();
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var articulo = (Articulo)dataGridView1.SelectedRows[0].DataBoundItem;
                lblIdArticulo.Text = "IDArticulo: " + articulo.Articuloid.ToString();
                lblDetalle.Text = "Detalle: " + articulo.Detalle;
                lblPresentacion.Text = "Presentacion: " + articulo.Presentacion;
                lblPrecioCompra.Text = "Precio Compra: " + articulo.Precio_compra.ToString();
                lblPrecioVenta.Text = "Precio Venta: " + articulo.Precio_venta.ToString();
                lblStock.Text = "Stock: " + articulo.Stock.ToString();
            }
        }

        private void FrmEliminarArticulo_Load_1(object sender, EventArgs e)
        {
            // Llena el DataGridView con los nombres o detalles de los artículos
            LlenarDataGridView();
            LimpiarPantalla();
        }
    }
}