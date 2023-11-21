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
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace ProyectoFinal2
{
    public partial class FrmVentas : Form
    {
        public static readonly string ConnectionString = "Server=LAPTOP-ASUS;Database=AlmacenDosChinos; Trusted_Connection=True;TrustServerCertificate=True;";
        public FrmVentas()
        {
            InitializeComponent();
            CargarDatosVentas();
        }

        private void CargarDatosVentas()
        {
            List<Venta> ventas = new List<Venta>();//lista para almacenar las ventas
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Venta";// consulta SQL para obtener datos de ventas
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())// leer datos y agregar a la lista de ventas
                            {
                                Venta venta = new Venta
                                {
                                    VentaID = Convert.ToInt32(reader["VentaID"]),
                                    Monto = Convert.ToDecimal(reader["Monto"]),
                                    Fecha = Convert.ToDateTime(reader["Fecha"]),
                                    UsuarioID = Convert.ToInt32(reader["UsuarioID"])
                                };
                                ventas.Add(venta);
                            }
                        }
                    }
                }                
                dataGridView1.DataSource = ConvertirListaADatatable(ventas);// muestra las ventas en el DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos de ventas: " + ex.Message);
            }
        }

        private DataTable ConvertirListaADatatable(List<Venta> ventas)
        {
            DataTable dataTable = new DataTable();

            // agregar columnas al DataTable
            dataTable.Columns.Add("VentaID", typeof(int));
            dataTable.Columns.Add("Monto", typeof(decimal));
            dataTable.Columns.Add("Fecha", typeof(DateTime));
            dataTable.Columns.Add("UsuarioID", typeof(string));

            foreach (Venta venta in ventas)
            {
                dataTable.Rows.Add(venta.VentaID, venta.Monto, venta.Fecha, venta.UsuarioID);
            }
            return dataTable;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            var fecha = DateTime.Now.ToString("dd/MM/yyyy"); // día para el ticket
            decimal totalGeneral = 0;
            QuestPDF.Settings.License = LicenseType.Community;
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Content().Column(col =>
                    {
                        col.Item().PaddingBottom(10).Text(text =>
                        {
                            text.Span("Los Dos Chinos").FontSize(12).SemiBold();
                        });

                        col.Item().LineHorizontal(0.8f).LineColor("#101010");
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
                                header.Cell().Background("#CC90FF").Padding(2).AlignCenter().Text("VentaID").FontSize(11).FontColor("000000");
                                header.Cell().Background("#CC90FF").Padding(2).AlignCenter().Text("Monto").FontSize(11).FontColor("000000");
                                header.Cell().Background("#CC90FF").Padding(2).AlignCenter().Text("Fecha").FontSize(11).FontColor("000000");
                                header.Cell().Background("#CC90FF").Padding(2).AlignRight().Text("UsuarioID").FontSize(11).FontColor("000000");
                            });

                            foreach (DataGridViewRow fila in dataGridView1.Rows)
                            {
                                if (fila.Cells["VentaID"].Value != null && fila.Cells["Monto"].Value != null && fila.Cells["Fecha"].Value != null && fila.Cells["UsuarioID"].Value != null)
                                {
                                    string ventaID = fila.Cells["VentaID"].Value.ToString();
                                    string monto = fila.Cells["Monto"].Value.ToString();
                                    string fechaVenta = fila.Cells["Fecha"].Value.ToString();
                                    string usuarioID = fila.Cells["UsuarioID"].Value.ToString();

                                    tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9").Padding(2).AlignCenter().Text(ventaID).FontSize(10);
                                    tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9").Padding(2).AlignCenter().Text(monto).FontSize(10);
                                    tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9").Padding(2).AlignCenter().Text(fechaVenta).FontSize(10);
                                    tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9").Padding(2).AlignRight().Text(usuarioID).FontSize(10);

                                    totalGeneral += Convert.ToDecimal(monto);
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
                document.GeneratePdf(@"C:\Users\juuli\Desktop\ProyectoFinal2\listadeventas.pdf");
                MessageBox.Show("El listado de ventas se imprimió correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            DateTime fechaDesde = dateDesde.Value.Date;
            DateTime fechaHasta = dateHasta.Value.Date.AddDays(1).AddSeconds(-1); // Para incluir todas las ventas del día seleccionado

            List<Venta> ventasFiltradas = ObtenerVentasFiltradas(fechaDesde, fechaHasta);

            if (ventasFiltradas.Count > 0)
            {
                dataGridView1.DataSource = ConvertirListaADatatable(ventasFiltradas);
            }
            else
            {
                MessageBox.Show("No se encontraron ventas en el rango de fechas seleccionado.");
            }
        }

        private List<Venta> ObtenerVentasFiltradas(DateTime fechaDesde, DateTime fechaHasta)
        {
            List<Venta> ventasFiltradas = new List<Venta>();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Venta WHERE Fecha >= @FechaDesde AND Fecha <= @FechaHasta";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@FechaDesde", fechaDesde);
                        cmd.Parameters.AddWithValue("@FechaHasta", fechaHasta);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Venta venta = new Venta
                                {
                                    VentaID = Convert.ToInt32(reader["VentaID"]),
                                    Monto = Convert.ToDecimal(reader["Monto"]),
                                    Fecha = Convert.ToDateTime(reader["Fecha"]),
                                    UsuarioID = Convert.ToInt32(reader["UsuarioID"])
                                };

                                ventasFiltradas.Add(venta);
                            }
                        }
                    }
                }

                return ventasFiltradas;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos de ventas: " + ex.Message);
                return ventasFiltradas;
            }
        }
    }
}

