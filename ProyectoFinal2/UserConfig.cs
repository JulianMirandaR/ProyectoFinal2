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
using static ProyectoFinal2.FrmLogin;

namespace ProyectoFinal2
{
    public partial class UserConfig : Form
    {
        private string connectionString = "Server=LAPTOP-ASUS;Database=AlmacenDosChinos; Trusted_Connection=True;TrustServerCertificate=True;";
        private string usuarioID;
        public UserConfig()
        {
            InitializeComponent();
            this.usuarioID = usuarioID;
            CargarDatosUsuario();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CargarDatosUsuario()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Asegúrate de tener el UsuarioID almacenado al iniciar sesión
                int usuarioID = UsuarioActual.UsuarioID;

                // Utiliza el usuarioID para obtener la información del usuario
                string query = "SELECT * FROM Usuario WHERE usuarioID = @usuarioID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Utiliza el UsuarioID almacenado al iniciar sesión
                    command.Parameters.AddWithValue("@usuarioID", usuarioID);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        // Llena los controles con los datos del usuario
                        txtNombre.Text = reader["nombre"].ToString();
                        txtEmail.Text = reader["email"].ToString();
                        txtCelular.Text = reader["celular"].ToString();
                    }
                    reader.Close();
                }

                connection.Close();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarContraseña())
            {
                if (ModificarDatosUsuario())
                {
                    MessageBox.Show("Los cambios se guardaron correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al guardar los cambios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("La contraseña actual no es válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarContraseña()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Verifica la contraseña actual en la base de datos
                string query = "SELECT contraseña FROM Usuario WHERE usuarioID = @usuarioID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Asegúrate de tener el valor para el parámetro usuarioID
                    if (string.IsNullOrEmpty(usuarioID))
                    {
                        // Maneja la falta de usuarioID según tus requisitos
                        return false;
                    }

                    command.Parameters.AddWithValue("@usuarioID", usuarioID);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        string contraseñaActualEnBD = reader["contraseña"].ToString();
                        return (txtContraseñaActual.Text == contraseñaActualEnBD);
                    }
                    reader.Close();
                }

                connection.Close();
            }
            return false;
        }

        private bool ModificarDatosUsuario()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Actualiza los datos del usuario en la base de datos
                string query = "UPDATE Usuario SET nombre = @nombre, email = @email, celular = @celular, contraseña = @NuevaContraseña WHERE usuarioID = @usuarioID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nombre", txtNombre.Text);
                    command.Parameters.AddWithValue("@email", txtEmail.Text);
                    command.Parameters.AddWithValue("@celular", txtCelular.Text);
                    command.Parameters.AddWithValue("@NuevaContraseña", txtNuevaContraseña.Text); // Nueva contraseña
                    command.Parameters.AddWithValue("@usuarioID", usuarioID);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        return true; // Los datos se actualizaron correctamente
                    }
                    return false; // No se pudo actualizar
                }
            }
        }
    }
}
