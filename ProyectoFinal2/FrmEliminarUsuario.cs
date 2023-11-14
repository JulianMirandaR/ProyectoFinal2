using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal2
{
    public partial class FrmEliminarUsuario : Form
    {
        public static readonly string ConnectionString = "Server=LAPTOP-ASUS;Database=AlmacenDosChinos; Trusted_Connection=True;TrustServerCertificate=True;";
        public FrmEliminarUsuario()
        {
            InitializeComponent();
            CargarUsuarios();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (cmbUsuario.SelectedValue != null)
            {
                int idUsuarioSeleccionado = (int)cmbUsuario.SelectedValue;
                MostrarDetallesUsuario(idUsuarioSeleccionado);
            }
        }

        private void CargarUsuarios()
        {
            using (SqlConnection conexion = new SqlConnection(ConnectionString))
            {
                conexion.Open();
                string consulta = "SELECT usuarioID, nombre FROM Usuario";
                SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
                DataTable tablaUsuarios = new DataTable();
                adaptador.Fill(tablaUsuarios);

                // Enlaza los datos al ComboBox
                cmbUsuario.DataSource = tablaUsuarios;
                cmbUsuario.DisplayMember = "nombre";
                cmbUsuario.ValueMember = "usuarioID";
            }
        }

        private void MostrarDetallesUsuario(int usuarioID)
        {
            using (SqlConnection conexion = new SqlConnection(ConnectionString))
            {
                conexion.Open();
                string consulta = "SELECT usuarioID, email, nombre, celular, acceso FROM Usuario WHERE usuarioID = @usuarioID";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@usuarioID", usuarioID);

                SqlDataReader lector = comando.ExecuteReader();

                if (lector.Read())
                {
                    LimpiarDetallesUsuario();
                    lblIdUsuario.Text += lector["usuarioID"].ToString();
                    lblEmail.Text += lector["email"].ToString();
                    lblNombre.Text += lector["nombre"].ToString();
                    lblTelefono.Text += lector["celular"].ToString();
                    lblAcceso.Text += lector["acceso"].ToString();
                }
                else
                {
                    MessageBox.Show("Usuario no encontrado");
                    LimpiarDetallesUsuario();
                }
            }
        }

        private void LimpiarDetallesUsuario()
        {
            lblIdUsuario.Text = "Id del Usuario: ";
            lblEmail.Text = "Email: ";
            lblNombre.Text = "Nombre: ";
            lblTelefono.Text = "Telefono:";
            lblAcceso.Text = "Nivel de Acceso:";
        }

        private void EliminarUsuario(int usuarioID)
        {
            using (SqlConnection conexion = new SqlConnection(ConnectionString))
            {
                conexion.Open();
                string consulta = "DELETE FROM Usuario WHERE usuarioID = @usuarioID";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@usuarioID", usuarioID);

                int filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Usuario eliminado correctamente");
                    LimpiarDetallesUsuario();
                    CargarUsuarios(); // Actualizar la lista de usuarios en el ComboBox
                }
                else
                {
                    MessageBox.Show("Error al eliminar el usuario");
                }
            }
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            
            if (cmbUsuario.SelectedValue != null)// Obtener el valor del usuario seleccionado en el ComboBox
            {
                if (int.TryParse(cmbUsuario.SelectedValue.ToString(), out int usuarioID))
                {
                    EliminarUsuario(usuarioID);
                }
                else
                {
                    MessageBox.Show("El Id de usuario no es un número válido.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un usuario.");
            }
        }
    }
}



