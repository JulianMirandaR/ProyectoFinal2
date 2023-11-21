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
    public partial class FrmLogin : Form
    {
        public static readonly string ConnectionString = "Server=LAPTOP-ASUS;Database=AlmacenDosChinos; Trusted_Connection=True;TrustServerCertificate=True;";
        public FrmLogin()
        {
            InitializeComponent();
        }

        public static class UsuarioActual
        {
            public static int UsuarioID { get; set; }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            int usuarioid = int.Parse(txtUsuario.Text);
            string contraseña = txtContraseña.Text;
            if (ValidarCredenciales(usuarioid, contraseña))
            {
                string tipoAcceso = ObtenerTipoAcceso(usuarioid); //obtiene el tipo de acceso del usuario
                MessageBox.Show("Inicio de sesión exitoso");
                Sesion nuevaSesion = new Sesion
                {
                    SesionID = 1,
                    UsuarioID = usuarioid,
                    Fecha = DateTime.Now.Date,
                    HoraInicio = DateTime.Now.TimeOfDay
                };
                GuardarSesion(nuevaSesion);// Guarda la sesión en la base de datos
                if (tipoAcceso == "Administrador")// Se la ventana correspondiente según el tipo de acceso
                {  
                    var ventanaAdmin = new InicioAdministrador();
                    UsuarioActual.UsuarioID = usuarioid;
                    ventanaAdmin.ShowDialog();
                }
                else if (tipoAcceso == "Operador")
                {
                    var ventanaOperador = new InicioOperador();
                    UsuarioActual.UsuarioID = usuarioid;
                    ventanaOperador.ShowDialog();
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas. Por favor, inténtalo de nuevo.");
            }
        }
        private bool ValidarCredenciales(int usuarioid, string contraseña)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Usuario WHERE usuarioID = @usuarioID AND contraseña = @contraseña";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@usuarioID", usuarioid);
                    cmd.Parameters.AddWithValue("@contraseña", contraseña);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
                }
            }
        }

        private string ObtenerTipoAcceso(int usuarioid)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT Acceso FROM Usuario WHERE usuarioID = @usuarioID";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@usuarioID", usuarioid);
                    object resultado = cmd.ExecuteScalar(); //Utilizo ExecuteScalar para obtener un único valor(en este caso, el tipo de acceso)
                    if (resultado != null)
                    {
                        return resultado.ToString();
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
            }
        }

        private void GuardarSesion(Sesion sesion)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Sesion (UsuarioID, Fecha, HoraInicio) VALUES (@UsuarioID, @Fecha, @HoraInicio); SELECT SCOPE_IDENTITY();";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@UsuarioID", sesion.UsuarioID);
                        cmd.Parameters.AddWithValue("@Fecha", sesion.Fecha);
                        cmd.Parameters.AddWithValue("@HoraInicio", sesion.HoraInicio);
                        int sesionID = Convert.ToInt32(cmd.ExecuteScalar());// obtiene el ID de la sesión recién insertada
                        sesion.SesionID = sesionID; //asigna el ID de la sesión al objeto Sesion
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar la sesión: " + ex.Message);
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

