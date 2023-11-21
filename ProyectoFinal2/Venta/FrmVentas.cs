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
                            
                            while (reader.Read())// Leer datos y agregar a la lista de ventas
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

            // Agregar columnas al DataTable
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
    }
}

