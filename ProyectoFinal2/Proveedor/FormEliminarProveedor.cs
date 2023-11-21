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
    public partial class FormEliminarProveedor : Form
    {
        public static readonly string ConnectionString = "Server=LAPTOP-ASUS;Database=AlmacenDosChinos; Trusted_Connection=True;TrustServerCertificate=True;";
        public FormEliminarProveedor()
        {
            InitializeComponent();
            CargarProveedores();
        }

        private void CargarProveedores()
        {
            cmbProveedor.ValueMember = "proveedorID";
            using (SqlConnection connection = new SqlConnection(ConnectionString))// cargar opciones en el ComboBox para seleccionar el proveedor
            {
                connection.Open();
                string consulta = "SELECT proveedorID, nombre FROM Proveedor";
                SqlDataAdapter adaptador = new SqlDataAdapter(consulta, connection);
                DataTable tablaProveedores = new DataTable();
                adaptador.Fill(tablaProveedores);

                
                cmbProveedor.DataSource = tablaProveedores;// enlazar datos al ComboBox
                cmbProveedor.DisplayMember = "nombre";
                cmbProveedor.ValueMember = "proveedorID";
            }
        }

        private void MostrarDetallesProveedor(int proveedorID)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string consulta = "SELECT proveedorID, nombre, cuit, email, celular, rubro, direccion FROM Proveedor WHERE proveedorID = @proveedorID";
                SqlCommand comando = new SqlCommand(consulta, connection);
                comando.Parameters.AddWithValue("@proveedorID", proveedorID);

                SqlDataReader lector = comando.ExecuteReader(); 

                if (lector.Read())
                {
                    LimpiarDetallesProveedor();
                    lblIdProveedor.Text += lector["proveedorID"].ToString();
                    lblNombre.Text += lector["nombre"].ToString();
                    lblCuit.Text += lector["cuit"].ToString();
                    lblEmail.Text += lector["email"].ToString();
                    lblCelular.Text += lector["celular"].ToString();
                    lblRubro.Text += lector["rubro"].ToString();
                    lblDireccion.Text += lector["direccion"].ToString();
                }
                else
                {
                    MessageBox.Show("Proveedor no encontrado");
                    LimpiarDetallesProveedor();
                }
            }
        }

        private void LimpiarDetallesProveedor()
        {
            lblIdProveedor.Text = "Id del Proveedor: ";
            lblNombre.Text = "Nombre: ";
            lblCuit.Text = "Cuit: ";
            lblEmail.Text = "Email: ";
            lblCelular.Text = "Celular: ";
            lblRubro.Text = "Rubro: ";
            lblDireccion.Text = "Dirección: ";
        }

        private void EliminarProveedor(int proveedorID)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string consulta = "DELETE FROM Proveedor WHERE proveedorID = @proveedorID";
                SqlCommand comando = new SqlCommand(consulta, connection);
                comando.Parameters.AddWithValue("@proveedorID", proveedorID); //Agrega el parámetro @proveedorID al comando para utilizarlo en la consulta SQL.

                int filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Proveedor eliminado correctamente");
                    LimpiarDetallesProveedor();
                    CargarProveedores(); // Actualiza la lista de proveedores en el ComboBox
                }
                else
                {
                    MessageBox.Show("Error al eliminar el proveedor");
                }
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (cmbProveedor.SelectedValue != null)
            {
                int proveedorIDSeleccionado = (int)cmbProveedor.SelectedValue;
                MostrarDetallesProveedor(proveedorIDSeleccionado);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (cmbProveedor.SelectedValue != null)
            {
                if (int.TryParse(cmbProveedor.SelectedValue.ToString(), out int proveedorID))
                {
                    EliminarProveedor(proveedorID);
                }
                else
                {
                    MessageBox.Show("El Id del proveedor no es un número válido.");
                }
            }
        }
    }
}
