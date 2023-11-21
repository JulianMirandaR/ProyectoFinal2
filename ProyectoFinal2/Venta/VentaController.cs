using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal2
{
    public class VentaController
    {
        public static bool AgregarVenta(Venta venta)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Server=LAPTOP-ASUS;Database=AlmacenDosChinos; Trusted_Connection=True;TrustServerCertificate=True;"))
                {
                    connection.Open();

                    string query = "INSERT INTO Venta (monto, fecha, usuarioID) VALUES (@monto, @fecha, @usuarioID)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@monto", venta.Monto);
                        command.Parameters.AddWithValue("@fecha", venta.Fecha);
                        command.Parameters.AddWithValue("@usuarioID", venta.UsuarioID);

                        command.ExecuteNonQuery();
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar la venta: " + ex.Message);
                return false;
            }
        }
    }
}
