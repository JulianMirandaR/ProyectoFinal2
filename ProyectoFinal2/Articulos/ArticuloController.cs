using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using ProyectoFinal;

namespace ProyectoFinal2
{
    public class ArticuloController
    {
        public static readonly string ConnectionString = "Server=LAPTOP-ASUS;Database=AlmacenDosChinos; Trusted_Connection=True;TrustServerCertificate=True;";

        public static TResult<Articulo> GetArticulos()
        {
            string cmdText = "SELECT * FROM Articulo";
            List<Articulo> list = new List<Articulo>();
            TResult<Articulo> tResult = new TResult<Articulo>();
            try
            {
                SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read()) 
                {
                    list.Add(new Articulo(long.Parse(sqlDataReader.GetValue(0).ToString()), sqlDataReader.GetValue(1).ToString(), sqlDataReader.GetValue(2).ToString(), decimal.Parse(sqlDataReader.GetValue(3).ToString()), decimal.Parse(sqlDataReader.GetValue(4).ToString()), int.Parse(sqlDataReader.GetValue(5).ToString()),sqlDataReader.GetValue(6).ToString()));
                }
                tResult.Articulos = list;
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

        public static TResult<Articulo> GetArticulo(long _articuloid)
        {
            TResult<Articulo> tResult = new TResult<Articulo>(); // Inicializa como null
            try
            {
                SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = "SELECT * FROM Articulo WHERE Articuloid = @Articuloid";
                sqlCommand.Connection = sqlConnection;
                sqlCommand.Parameters.AddWithValue("@Articuloid", _articuloid);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    Articulo articulo = new Articulo(
                        long.Parse(sqlDataReader.GetValue(0).ToString()),
                        sqlDataReader.GetValue(1).ToString(),
                        sqlDataReader.GetValue(2).ToString(),
                        decimal.Parse(sqlDataReader.GetValue(3).ToString()),
                        decimal.Parse(sqlDataReader.GetValue(4).ToString()),
                        int.Parse(sqlDataReader.GetValue(5).ToString()),
                        sqlDataReader.GetValue(6).ToString()
                    );
                }
                else
                {
                    tResult.Error = "El articulo no ha sido encontrado!!";
                    tResult.IsValid = false;
                }

                sqlCommand.Dispose();
                sqlDataReader.Dispose();
                return tResult;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return tResult;
            }
            
        }

        public static TResult<DtoDetalle> GetListadoNombres()
        {
            List<DtoDetalle> list = new List<DtoDetalle>();
            TResult<DtoDetalle> tResult = new TResult<DtoDetalle>();
            

            try
            {
                SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = "SELECT * FROM Articulo";
                sqlCommand.Connection = sqlConnection;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    list.Add(new DtoDetalle(long.Parse(sqlDataReader.GetValue(0).ToString()), sqlDataReader.GetValue(1).ToString(), sqlDataReader.GetValue(2).ToString(),decimal.Parse(sqlDataReader.GetValue(3).ToString()),decimal.Parse(sqlDataReader.GetValue(4).ToString()), int.Parse(sqlDataReader.GetValue(5).ToString()), sqlDataReader.GetValue(6).ToString()));
                }

                tResult.Articulos = list; // Establece la propiedad Articulos
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

        public static TResult<Articulo> EliminarArticulo(long articuloId)
        {
            TResult<Articulo> tResult = new TResult<Articulo>();
            try
            {
                SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "DELETE FROM Articulo WHERE Articuloid = @id";
                sqlCommand.Parameters.AddWithValue("@id", articuloId);
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Dispose();
                return tResult;
                
            }
            catch (Exception ex)
            {
                tResult.Error = ex.Message.ToString();
                tResult.IsValid = false;
                return tResult;
            }
        }

        public static TResult<Articulo> ModificarArticulo(Articulo articulo)
        {
            TResult<Articulo> tResult = new TResult<Articulo>();
            try
            {
                SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "UPDATE Articulo SET Detalle = @Detalle, Presentacion = @Presentacion, Precio_compra = @Precio_compra, Precio_venta = @Precio_venta, Stock = @Stock, Proveedor =@Proveedor WHERE Articuloid = @id";
                sqlCommand.Parameters.AddWithValue("@id", articulo.Articuloid);
                sqlCommand.Parameters.AddWithValue("@Detalle", articulo.Detalle);
                sqlCommand.Parameters.AddWithValue("@Presentacion", articulo.Presentacion);
                sqlCommand.Parameters.AddWithValue("@Precio_compra", articulo.Precio_compra);
                sqlCommand.Parameters.AddWithValue("@Precio_venta", articulo.Precio_venta);
                sqlCommand.Parameters.AddWithValue("@Stock", articulo.Stock);
                sqlCommand.Parameters.AddWithValue("@Proveedor", articulo.Proveedor);
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Dispose();
                return tResult;
            }
            catch (Exception ex)
            {
                tResult.Error = ex.Message.ToString();
                tResult.IsValid = false;
            }
            return tResult;
        }

        public static List<Articulo> AgregarArticulo(Articulo articulo)
        {
            List<Articulo> tResult = new List<Articulo>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandText = "INSERT INTO Articulo (Articuloid, Detalle, Presentacion, Precio_compra, Precio_venta, Stock,Proveedor) VALUES (@Articuloid, @Detalle, @Presentacion, @Precio_Compra, @Precio_Venta, @Stock,@Proveedor)";
                    sqlCommand.Parameters.AddWithValue("@Articuloid", articulo.Articuloid);
                    sqlCommand.Parameters.AddWithValue("@Detalle", articulo.Detalle);
                    sqlCommand.Parameters.AddWithValue("@Presentacion", articulo.Presentacion);
                    sqlCommand.Parameters.AddWithValue("@Precio_Compra", articulo.Precio_compra);
                    sqlCommand.Parameters.AddWithValue("@Precio_Venta", articulo.Precio_venta);
                    sqlCommand.Parameters.AddWithValue("@Stock", articulo.Stock);
                    sqlCommand.Parameters.AddWithValue("@Proveedor", articulo.Proveedor);
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return tResult;
        }
    }
}
