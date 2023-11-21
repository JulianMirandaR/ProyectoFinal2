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
    public partial class FormModificarProveedor : Form
    {
        public static readonly string ConnectionString = "Server=LAPTOP-ASUS;Database=AlmacenDosChinos; Trusted_Connection=True;TrustServerCertificate=True;";
        public FormModificarProveedor()
        {
            InitializeComponent();
            CargarProveedores();
        }
        private void CargarProveedores()
        {
            cmbProveedor.ValueMember = "ProveedorID";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string consulta = "SELECT ProveedorID, Nombre FROM Proveedor";
                SqlDataAdapter adaptador = new SqlDataAdapter(consulta, connection);
                DataTable tablaProveedores = new DataTable();
                adaptador.Fill(tablaProveedores);

                cmbProveedor.DataSource = tablaProveedores;
                cmbProveedor.DisplayMember = "Nombre";
                cmbProveedor.ValueMember = "ProveedorID";
            }
        }


        private void MostrarDetallesProveedor(int proveedorID)//llena los text box
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string consulta = "SELECT ProveedorID, Nombre, Cuit, Email, Celular, Rubro, Direccion FROM Proveedor WHERE ProveedorID = @proveedorID";
                SqlCommand comando = new SqlCommand(consulta, connection);
                comando.Parameters.AddWithValue("@proveedorID", proveedorID);
                SqlDataReader lector = comando.ExecuteReader();
                if (lector.Read())
                {
                    txtIdProveedor.Text = lector["ProveedorID"].ToString();
                    txtNombre.Text = lector["Nombre"].ToString();
                    txtCuit.Text = lector["Cuit"].ToString();
                    txtCelular.Text = lector["Celular"].ToString();
                    txtRubro.Text = lector["Rubro"].ToString();
                    txtDireccion.Text = lector["Direccion"].ToString();
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
            txtIdProveedor.Clear();
            txtNombre.Clear();
            txtCuit.Clear();
            txtCelular.Clear();
            txtRubro.Clear();
            txtDireccion.Clear();
        }

        private void ActualizarProveedor(int proveedorID)// actualiza los datos
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string consulta = "UPDATE Proveedor SET Nombre = @Nombre, Cuit = @Cuit, Celular = @Celular, Rubro = @Rubro, Direccion = @Direccion WHERE ProveedorID = @ProveedorID";
                SqlCommand comando = new SqlCommand(consulta, connection);
                comando.Parameters.AddWithValue("@ProveedorID", proveedorID);
                comando.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                comando.Parameters.AddWithValue("@Cuit", txtCuit.Text);
                comando.Parameters.AddWithValue("@Celular", txtCelular.Text);
                comando.Parameters.AddWithValue("@Rubro", txtRubro.Text);
                comando.Parameters.AddWithValue("@Direccion", txtDireccion.Text);

                int filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Proveedor actualizado correctamente");
                    LimpiarDetallesProveedor();
                    CargarProveedores(); // Actualizar la lista de proveedores en el ComboBox
                }
                else
                {
                    MessageBox.Show("Error al actualizar el proveedor");
                }
            }
        }


        private void btnSeleccionar_Click_1(object sender, EventArgs e)
        {
            if (cmbProveedor.SelectedValue != null)
            {
                int proveedorIDSeleccionado;
                if (int.TryParse(cmbProveedor.SelectedValue.ToString(), out proveedorIDSeleccionado))
                {
                    MostrarDetallesProveedor(proveedorIDSeleccionado);
                }
                else
                {
                    MessageBox.Show("El Id del proveedor no es un número válido.");
                }
            }
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIdProveedor.Text))
            {
                if (int.TryParse(txtIdProveedor.Text, out int proveedorID))
                {
                    ActualizarProveedor(proveedorID);
                }
                else
                {
                    MessageBox.Show("El Id del proveedor no es un número válido.");
                }
            }
            else
            {
                MessageBox.Show("Selecciona un proveedor antes de guardar.");
            }
        }
    }
}