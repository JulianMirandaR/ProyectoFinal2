using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinal2
{
    public class ProveedorController
    {
        public static readonly string ConnectionString = "Server=LAPTOP-ASUS;Database=AlmacenDosChinos; Trusted_Connection=True;TrustServerCertificate=True;";

        public static TResult<Proveedor> GetProveedores()
        {
            string cmdText = "SELECT * FROM Proveedor";
            List<Proveedor> list = new List<Proveedor>();
            TResult<Proveedor> tResult = new TResult<Proveedor>();
            try
            {
                SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    list.Add(new Proveedor(
                        int.Parse(sqlDataReader.GetValue(0).ToString()), // Proveedorid
                        sqlDataReader.GetValue(1).ToString(), // Nombre
                        long.Parse(sqlDataReader.GetValue(2).ToString()), // Cuit
                        sqlDataReader.GetValue(3).ToString(), // Email
                         long.Parse(sqlDataReader.GetValue(4).ToString()), // Celular
                        sqlDataReader.GetValue(5).ToString(), // Rubro
                        sqlDataReader.GetValue(6).ToString() // Direccion
                    ));
                }
                tResult.Proveedores = list;
                sqlCommand.Dispose();
                sqlDataReader.Dispose();
                return tResult;
            }
            catch (Exception ex)
            {
                tResult.Error = ex.Message.ToString();
                tResult.IsValid = false;
                return tResult;
            }
        }

        public static TResult<Proveedor> GetProveedor(int _proveedorid)
        {
            TResult<Proveedor> tResult = new TResult<Proveedor>();
            try
            {
                SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = "SELECT * FROM Proveedor WHERE Proveedorid = @id";
                sqlCommand.Connection = sqlConnection;
                sqlCommand.Parameters.AddWithValue("@id", _proveedorid);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    Proveedor proveedor = new Proveedor(
                        int.Parse(sqlDataReader.GetValue(0).ToString()), // Proveedorid
                        sqlDataReader.GetValue(1).ToString(), // Nombre
                        long.Parse(sqlDataReader.GetValue(2).ToString()), // Cuit
                        sqlDataReader.GetValue(3).ToString(), // Email
                        long.Parse(sqlDataReader.GetValue(4).ToString()), // Celular
                        sqlDataReader.GetValue(5).ToString(), // Rubro
                        sqlDataReader.GetValue(6).ToString() // Direccion
                    );
                    tResult.Proveedores = new List<Proveedor> { proveedor };
                }
                else
                {
                    tResult.Error = "El proveedor no ha sido encontrado.";
                    tResult.IsValid = false;
                }

                sqlCommand.Dispose();
                sqlDataReader.Dispose();
                return tResult;
            }
            catch (Exception ex)
            {
                tResult.Error = ex.Message.ToString();
                tResult.IsValid = false;
                return tResult;
            }
        }
        public static TResult<DtoDetalleProveedor> GetListadoNombres()
        {
            List<DtoDetalleProveedor> list = new List<DtoDetalleProveedor>();
            TResult<DtoDetalleProveedor> tResult = new TResult<DtoDetalleProveedor>();
            try
            {
                SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = "SELECT ProveedorID, Nombre, Cuit, Email, Celular, Rubro, Direccion FROM Proveedor";
                sqlCommand.Connection = sqlConnection;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    list.Add(new DtoDetalleProveedor(
                        int.Parse(sqlDataReader.GetValue(0).ToString()), // Proveedorid
                        sqlDataReader.GetValue(1).ToString(), // Nombre
                        long.Parse(sqlDataReader.GetValue(2).ToString()), // Cuit
                        sqlDataReader.GetValue(3).ToString(), // Email
                        long.Parse(sqlDataReader.GetValue(4).ToString()), // Celular
                        sqlDataReader.GetValue(5).ToString(), // Rubro
                        sqlDataReader.GetValue(6).ToString()  // Direccion
                    ));
                }

                tResult.Proveedores = list; // Establece la propiedad Articulos
                sqlCommand.Dispose();
                sqlDataReader.Dispose();
                return tResult;
            }
            catch (Exception ex)
            {
                tResult.Error = ex.Message.ToString();
                tResult.IsValid = false;
                return tResult;
            }
        }
        public static TResult<Proveedor> EliminarProveedor(int proveedorId)
        {
            TResult<Proveedor> tResult = new TResult<Proveedor>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandText = "DELETE FROM Proveedor WHERE Proveedorid = @id";
                    sqlCommand.Parameters.AddWithValue("@id", proveedorId);
                    sqlCommand.ExecuteNonQuery();
                }
                return tResult;
            }
            catch (Exception ex)
            {
                tResult.Error = ex.Message.ToString();
                tResult.IsValid = false;
                return tResult;
            }
        }

        public static TResult<Proveedor> ModificarProveedor(Proveedor proveedor)
        {
            TResult<Proveedor> tResult = new TResult<Proveedor>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandText = "UPDATE Proveedor SET Nombre = @Nombre, Cuit = @Cuit, Email = @Email, Celular = @Celular, Rubro = @Rubro, Direccion = @Direccion WHERE Proveedorid = @id";
                    sqlCommand.Parameters.AddWithValue("@id", proveedor.Proveedorid);
                    sqlCommand.Parameters.AddWithValue("@Nombre", proveedor.Nombre);
                    sqlCommand.Parameters.AddWithValue("@Cuit", proveedor.Cuit);
                    sqlCommand.Parameters.AddWithValue("@Email", proveedor.Email);
                    sqlCommand.Parameters.AddWithValue("@Celular", proveedor.Celular);
                    sqlCommand.Parameters.AddWithValue("@Rubro", proveedor.Rubro);
                    sqlCommand.Parameters.AddWithValue("@Direccion", proveedor.Direccion);
                    sqlCommand.ExecuteNonQuery();
                }
                return tResult;
            }
            catch (Exception ex)
            {
                tResult.Error = ex.Message.ToString();
                tResult.IsValid = false;
                return tResult;
            }
        }

        public static TResult<Proveedor> AgregarProveedor(Proveedor proveedor)
        {
            TResult<Proveedor> tResult = new TResult<Proveedor>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandText = "INSERT INTO Proveedor (Nombre, Cuit, Email, Celular, Rubro, Direccion) VALUES (@Nombre, @Cuit, @Email, @Celular, @Rubro, @Direccion)";
                    sqlCommand.Parameters.AddWithValue("@Nombre", proveedor.Nombre);
                    sqlCommand.Parameters.AddWithValue("@Cuit", proveedor.Cuit);
                    sqlCommand.Parameters.AddWithValue("@Email", proveedor.Email);
                    sqlCommand.Parameters.AddWithValue("@Celular", proveedor.Celular);
                    sqlCommand.Parameters.AddWithValue("@Rubro", proveedor.Rubro);
                    sqlCommand.Parameters.AddWithValue("@Direccion", proveedor.Direccion);
                    sqlCommand.ExecuteNonQuery();
                }
                return tResult;
            }
            catch (Exception ex)
            {
                tResult.Error = ex.Message.ToString();
                tResult.IsValid = false;
                return tResult;
            }
        }
    }
}