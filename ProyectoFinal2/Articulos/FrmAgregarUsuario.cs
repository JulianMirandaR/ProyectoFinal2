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
    public partial class FrmAgregarUsuario : Form
    {
        public static readonly string ConnectionString = "Server=LAPTOP-ASUS;Database=AlmacenDosChinos; Trusted_Connection=True;TrustServerCertificate=True;";
        public FrmAgregarUsuario()
        {
            InitializeComponent();
            CargarNivelesAcceso();
            CargarUsuarios();
        }

        private void CargarNivelesAcceso()
        {
            cmbNivelAcceso.Items.Add("Administrador");// Cargar opciones en el ComboBox para el nivel de acceso
            cmbNivelAcceso.Items.Add("Operador");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string email = txtEmail.Text;
            string telefono = txtTelefono.Text;
            string contraseña = txtContraseña.Text;
            string nivelAcceso = cmbNivelAcceso.SelectedItem.ToString();

            
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(email) ||string.IsNullOrWhiteSpace(telefono) || string.IsNullOrWhiteSpace(contraseña) ||string.IsNullOrWhiteSpace(nivelAcceso)) // Validar que se hayan proporcionado todos los datos
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
            InsertarUsuario(nombre, email, telefono, contraseña, nivelAcceso); // Insertar el nuevo usuario en la base de datos

            MessageBox.Show("Usuario agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);


            this.Close();
        }

        private void InsertarUsuario(string nombre, string email, string telefono, string contraseña, string nivelAcceso)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                
                string query = "INSERT INTO Usuario (nombre, email, celular, contraseña, acceso) VALUES (@nombre, @email, @celular, @contraseña, @acceso)";// crea la consulta SQL para la inserción
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@celular", telefono);
                    cmd.Parameters.AddWithValue("@contraseña", contraseña);
                    cmd.Parameters.AddWithValue("@acceso", nivelAcceso);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void CargarUsuarios()//carga el usuario al dataGridView
        {
            var dataTable = new System.Data.DataTable();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT usuarioID, nombre, email, celular, acceso FROM Usuario";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            dataGridView1.DataSource = dataTable;
            dataGridView1.Columns["nombre"].HeaderText = "Nombre";
            dataGridView1.Columns["email"].HeaderText = "Email";
            dataGridView1.Columns["celular"].HeaderText = "Celular";
            dataGridView1.Columns["acceso"].HeaderText = "Acceso";
        }
    }
}


