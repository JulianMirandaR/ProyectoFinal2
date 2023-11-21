using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;
using ProyectoFinal;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using ZXing;
using static ProyectoFinal2.FrmLogin;
using static QuestPDF.Helpers.Colors;

namespace ProyectoFinal2
{
    public partial class FrmTransaccion : Form
    {
        private Mat Frame;
        private VideoCapture Camara;
        private BarcodeReader Reader;
        private List<Articulo> Articulos;
        private List<Articulo> listaArticulos = new List<Articulo>();
        private Articulo articuloSeleccionado;
        decimal total = 0;
        int UsuarioActivo = 0;

        public FrmTransaccion()
        {
            InitializeComponent();
            CargarArticulosEnComboBox();
            if (!timer1.Enabled) timer1.Enabled = true;
            if (!timer2.Enabled) timer2.Enabled = true;
            timer1.Start();
            timer2.Start();
            ConfigurarDataGridView();
            btnEliminar.Click += btnEliminar_Click;
        }

        private void FrmTransaccion_Load(object sender, EventArgs e)
        {
            Frame = new Mat();
            Camara = new VideoCapture();
            Reader = new BarcodeReader();
            timer1.Interval = 40;
            timer2.Interval = 250;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            Camara.Start();
            CargarArticulos();
        }
        private string DetalleArticulo(string _codigoBarra)
        {
            string detalle = string.Empty;
            if (!string.IsNullOrEmpty(_codigoBarra))
            {
                var articulo = Articulos.FirstOrDefault(art => art.Articuloid == long.Parse(_codigoBarra));
                if (articulo != null)
                {
                    detalle = articulo.Detalle;
                }
            }
            return detalle;
        }
        private void ConfigurarDataGridView()
        {
            dataGridView1.Columns.Add("ArticuloId", "Articulo ID");
            dataGridView1.Columns.Add("Detalle", "Detalle");
            dataGridView1.Columns.Add("Cantidad", "Cantidad");
            dataGridView1.Columns.Add("PrecioUnitario", "Precio Unitario");
            dataGridView1.Columns.Add("PrecioTotal", "Precio Total");

            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void CargarArticulosEnComboBox()
        {
            // se utiliza el método del controlador para obtener la lista de artículos
            var resultado = ArticuloController.GetArticulos();

            if (resultado.IsValid)
            {
                cmbArticulo.DataSource = resultado.Articulos;
                cmbArticulo.DisplayMember = "Detalle";
            }
            else
            {
                MessageBox.Show("Error al cargar la lista de artículos: " + resultado.Error);
            }
        }
        
        private void CalcularPrecioTotal()
        {
            total = 0;
            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                total += Convert.ToDecimal(fila.Cells["PrecioTotal"].Value);
            }
            lblTotal.Text = "TOTAL: ";
            lblTotal.Text += total.ToString("C");
        }
        private void LimpiarControles()
        {
            cmbArticulo.SelectedIndex = -1;
            articuloSeleccionado = null;
            txtCodigo.Text = "";
            lblPrecio.Text = "";
            lblPresentacion.Text = "";
            txtCantidad.Text = "1";
            pictureBox1.Image = null;
        }
        private void btnFinalizarVenta_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                long articuloId = Convert.ToInt64(fila.Cells["ArticuloId"].Value);
                int cantidad = Convert.ToInt32(fila.Cells["Cantidad"].Value);
                var resultado = ArticuloController.GetArticulo(articuloId);
                if (resultado.IsValid)
                {
                    Articulo articulo = resultado.Articulo;
                }
                else
                {
                    MessageBox.Show("Error al obtener el artículo para la venta: " + resultado.Error);
                }
            }

            listaArticulos.Clear();
            dataGridView1.Rows.Clear();
            CalcularPrecioTotal();
            MessageBox.Show("Venta finalizada y guardada en la base de datos.");
        }
        private void cmbArticulo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbArticulo.SelectedIndex != -1)
            {
                articuloSeleccionado = (Articulo)cmbArticulo.SelectedItem;
                lblPrecio.Text = "Precio: ";
                lblPresentacion.Text = "Presentacion: ";
                lblPrecio.Text += articuloSeleccionado.Precio_venta.ToString("C");
                lblPresentacion.Text += articuloSeleccionado.Presentacion;
                txtCodigo.Text = articuloSeleccionado.Articuloid.ToString();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            long codigoBarras = 2342; // Simulación de lectura de código de barras y luego se reeemplaza esto con el valor real 
            foreach (Articulo articulo in cmbArticulo.Items)// Busca el artículo correspondiente en la lista
            {
                if (articulo.Articuloid == codigoBarras)
                {
                    cmbArticulo.SelectedItem = articulo;
                    break;
                }
            }
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {

            if (articuloSeleccionado == null)// Verifica si se ha seleccionado un artículo
            {
                MessageBox.Show("Selecciona un artículo antes de agregarlo.");
                return;
            }

            // Añade el artículo a la lista de venta
            int cantidad = Convert.ToInt32(txtCantidad.Text);
            decimal precioTotal = cantidad * articuloSeleccionado.Precio_venta;
            DataGridViewRow fila = new DataGridViewRow();
            fila.CreateCells(dataGridView1, articuloSeleccionado.Articuloid, articuloSeleccionado.Detalle, cantidad, articuloSeleccionado.Precio_venta, precioTotal);
            dataGridView1.Rows.Add(fila);
            CalcularPrecioTotal();// Calcula y muestra el precio total
            LimpiarControles();// Limpia los controles para el próximo artículo
        }

        private void CargarArticulos()
        {
            Articulos = new List<Articulo>();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Camara.IsOpened)
            {
                Camara.Read(Frame);
                pictureBox1.Image = Frame.ToBitmap();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Result resultado;
            if (pictureBox1.Image != null)
            {
                resultado = Reader.Decode((Bitmap)pictureBox1.Image);
                if (resultado != null)
                {
                    txtCodigo.Text = resultado.Text;// Asigna el código de barras al TextBox
                    foreach (Articulo articulo in cmbArticulo.Items)
                    {
                        if (articulo.Articuloid == long.Parse(resultado.Text))
                        {
                            cmbArticulo.SelectedItem = articulo;
                            break;
                        }
                    }
                }
            }
        }

        private void FrmTransaccion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Camara != null && Camara.IsOpened)
            {
                Camara.Stop();
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            var fecha = DateTime.Now.ToString("dd/MM/yyyy");
            decimal totalGeneral = 0;
            QuestPDF.Settings.License = LicenseType.Community;

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Content().Column(col =>
                    {
                        col.Item().Text(text =>
                        {
                            text.Span("Fecha: ").FontSize(9).SemiBold();
                            text.Span(fecha).FontSize(9);
                        });

                        col.Item().LineHorizontal(0.8f).LineColor("#101010");

                        col.Item().PaddingTop(10).Table(tabla =>
                        {
                            tabla.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn(3);
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });
                            tabla.Header(header =>
                            {
                                header.Cell().Background("#CC90FF").Padding(2).AlignCenter().Text("CANTIDAD").FontSize(11).FontColor("000000");
                                header.Cell().Background("#CC90FF").Padding(2).AlignCenter().Text("DESCRIPCION").FontSize(11).FontColor("000000");
                                header.Cell().Background("#CC90FF").Padding(2).AlignCenter().Text("PRECIO").FontSize(11).FontColor("000000");
                                header.Cell().Background("#CC90FF").Padding(2).AlignRight().Text("SUBTOTAL").FontSize(11).FontColor("000000");
                            });

                            foreach (DataGridViewRow fila in dataGridView1.Rows)
                            {
                                if (fila.Cells["Cantidad"].Value != null && fila.Cells["Detalle"].Value != null && fila.Cells["PrecioUnitario"].Value != null)
                                {
                                    string cantidad = fila.Cells["Cantidad"].Value.ToString();
                                    string descripcion = fila.Cells["Detalle"].Value.ToString();
                                    string precio = fila.Cells["PrecioUnitario"].Value.ToString();
                                    tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9").Padding(2).AlignCenter().Text(cantidad).FontSize(10);
                                    tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9").Padding(2).AlignCenter().Text(descripcion).FontSize(10);
                                    tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9").Padding(2).AlignCenter().Text(precio).FontSize(10);

                                    decimal subtotal = Convert.ToDecimal(precio) * Convert.ToDecimal(cantidad);
                                    totalGeneral += subtotal;

                                    tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9").Padding(2).AlignRight().Text(subtotal.ToString("C")).FontSize(10);
                                }
                            }
                        });

                        col.Item().Padding(2).AlignRight().Text(text =>
                        {
                            text.Span("TOTAL: $").FontSize(11).SemiBold();
                            text.Span(totalGeneral.ToString()).FontSize(11);
                        });
                    });
                });
            });

            try
            {
                document.GeneratePdf(@"C:\Users\juuli\Desktop\ProyectoFinal2\ticket.pdf");
                MessageBox.Show("El ticket se imprimió correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            Venta nuevaVenta = new Venta// Crear un objeto Venta con los datos de la venta actual
            {
                VentaID = 1,
                Monto = total,
                Fecha = DateTime.Now.Date,
                Hora = DateTime.Now.TimeOfDay,
                UsuarioID = obtenerIdUsuarioActivo()
            };

            if (VentaController.AgregarVenta(nuevaVenta))
            {
                listaArticulos.Clear();// Limpia la lista de artículos vendidos y el DataGridView después de guardar la venta
                dataGridView1.Rows.Clear();
                CalcularPrecioTotal();

                MessageBox.Show("Venta finalizada");
            }
            else
            {
                MessageBox.Show("Error al guardar la venta en la base de datos.");
            }
        }
        private int obtenerIdUsuarioActivo()
        {
            return UsuarioActual.UsuarioID;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                
                long articuloId = Convert.ToInt64(row.Cells["ArticuloId"].Value);// Se puede almacenar el ArticuloId en una variable para su posterior eliminación
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count >= 0)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                   decimal cantidad = Convert.ToDecimal(row.Cells["Cantidad"].Value);
                   decimal precioUnitario = Convert.ToDecimal(row.Cells["PrecioUnitario"].Value);
                   decimal subtotalArticulo = cantidad * precioUnitario;
                   total -= subtotalArticulo;
                    // O simplemente puedes eliminar la fila directamente
                    if (!row.IsNewRow)
                    {
                        dataGridView1.Rows.Remove(row);
                    }
                }

                // Reinicia el valor de total antes de recalcularlo
                total = 0;
                foreach (DataGridViewRow fila in dataGridView1.Rows)
                {
                    if (fila.Cells["Cantidad"].Value != null && fila.Cells["PrecioUnitario"].Value != null)
                    {
                        decimal cantidad = Convert.ToDecimal(fila.Cells["Cantidad"].Value);
                        decimal precioUnitario = Convert.ToDecimal(fila.Cells["PrecioUnitario"].Value);
                        total += cantidad * precioUnitario;
                    }
                }

                // Actualiza el total en la interfaz
                lblTotal.Text = "TOTAL: " + total.ToString("C");
            }
            else
            {
                MessageBox.Show("Selecciona una fila para eliminar.");
            }
        }
    }
}