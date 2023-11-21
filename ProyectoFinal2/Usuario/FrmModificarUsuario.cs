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
    public partial class FrmModificarUsuario : Form
    {
        public static readonly string ConnectionString = "Server=LAPTOP-ASUS;Database=AlmacenDosChinos; Trusted_Connection=True;TrustServerCertificate=True;";
        private List <string> acceso = new List<string>() {"Administrador","Operador" };//solo son esas dos opciones
        public FrmModificarUsuario()
        {
            InitializeComponent();
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT usuarioID, nombre FROM Usuario";
                SqlDataAdapter adaptador = new SqlDataAdapter(query, connection);
                DataTable tablaUsuarios = new DataTable();
                adaptador.Fill(tablaUsuarios);

                cmbUsuario.DataSource = tablaUsuarios;
                cmbUsuario.DisplayMember = "nombre";
                cmbUsuario.ValueMember = "usuarioID";
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (cmbUsuario.SelectedValue != null)
            {
                int idUsuarioSeleccionado = (int)cmbUsuario.SelectedValue;
                MostrarDetallesUsuario(idUsuarioSeleccionado);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cmbUsuario.SelectedValue != null)
            {
                int idUsuarioSeleccionado = (int)cmbUsuario.SelectedValue;
                ModificarUsuario(idUsuarioSeleccionado);
            }
        }

        private void MostrarDetallesUsuario(int usuarioID)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT usuarioID, nombre, email, celular, acceso FROM Usuario WHERE usuarioID = @usuarioID";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@usuarioID", usuarioID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Mostrar detalles en los controles correspondientes
                            txtNombre.Text = reader["nombre"].ToString();
                            txtEmail.Text = reader["email"].ToString();
                            txtCelular.Text = reader["celular"].ToString();
                            cmbAcceso.SelectedItem = reader["acceso"].ToString();
                        }
                    }
                }
            }
        }

        private void ModificarUsuario(int usuarioID)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "UPDATE Usuario SET nombre = @nombre, email = @email, celular = @celular, acceso = @acceso WHERE usuarioID = @usuarioID";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@usuarioID", usuarioID);
                    cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@celular", txtCelular.Text);
                    cmd.Parameters.AddWithValue("@acceso", cmbAcceso.SelectedItem.ToString());
                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Usuario modificado correctamente");
                        CargarUsuarios(); // Actualizar la lista de usuarios en el ComboBox
                        LimpiarControles();
                    }
                    else
                    {
                        MessageBox.Show("Error al modificar el usuario");
                    }
                }
            }
        }

        private void LimpiarControles()
        {
            txtNombre.Clear();
            txtEmail.Clear();
            txtCelular.Clear();
            cmbAcceso.SelectedIndex = -1;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmModificarUsuario_Load(object sender, EventArgs e)
        {
            Utils.LLenarCombobox(cmbAcceso, acceso);
        }
    }
}
