using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TecnoMedia
{
    public class BDArticulos
    {
        static SqlConnection Conexion = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\JoshSeto\source\repos\TecnoMedia\TecnoMedia\App_Data\NuestraBase.mdf;Integrated Security=True");

        public List<Articulos> obtenerArticulos()
        {
            List<Articulos> lista = new List<Articulos> { };
            Articulos articulo;
            SqlCommand command = new SqlCommand("SELECT * FROM Articulos", Conexion);
            try
            {
                Conexion.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    articulo = new Articulos();
                    articulo.idAutor = (int)reader["Id_Administrador"];
                    articulo.titulo= (string)reader["Titulo"];
                    articulo.imagen=(string)reader["Imagen"];
                    articulo.contenido = (string)reader["Contenido"];
                    articulo.idArticulo = (int)reader["Id_Articulo"]; 
                    lista.Add(articulo);
                }
                Conexion.Close();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
            }
            return lista;
        }
        public Articulos buscarArticulo(String id)
        {
            Articulos articulo = new Articulos();
            SqlCommand command = new SqlCommand("SELECT * FROM Articulos WHERE Id_Articulo = @IdArticulo", Conexion);
            command.Parameters.AddWithValue("@IdArticulo",id);
            try
            {
                Conexion.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    articulo.idAutor = (int)reader["Id_Administrador"];
                    articulo.titulo = (string)reader["Titulo"];
                    articulo.imagen = (string)reader["Imagen"];
                    articulo.contenido = (string)reader["Contenido"];
                    articulo.idArticulo = (int)reader["Id_Articulo"];
                }
                Conexion.Close();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
            }
            return articulo;
        }

        public int alterarArticulo(Articulos articulo)
        {
            SqlCommand command = new SqlCommand("UPDATE Articulos SET Titulo = @Titulo ," +
                " Contenido = @Contenido , Imagen = @Imagen WHERE Id_Articulo = @IdArticulo", Conexion);
            command.Parameters.AddWithValue("@Titulo", articulo.titulo);
            command.Parameters.AddWithValue("@Contenido", articulo.contenido);
            command.Parameters.AddWithValue("@Imagen", articulo.imagen);
            command.Parameters.AddWithValue("@IdArticulo", articulo.idArticulo);
            try
            {
                Conexion.Open();
                command.ExecuteNonQuery();
                Conexion.Close();
            }
            catch (Exception e) { System.Diagnostics.Debug.WriteLine(e.ToString()); return 0; }
            Conexion.Close();
            return 1;
        }
        public int agregarArticulo(Articulos articulo)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Articulos (Titulo,Contenido,Imagen,Id_Administrador) " +
                "VALUES (@Titulo,@Contenido,@Imagen,@IdAutor)", Conexion);
            command.Parameters.AddWithValue("@Titulo", SqlDbType.VarChar).Value = articulo.titulo;
            command.Parameters.AddWithValue("@Contenido", SqlDbType.VarChar).Value = articulo.contenido;
            command.Parameters.AddWithValue("@Imagen", SqlDbType.VarChar).Value = articulo.imagen;
            command.Parameters.AddWithValue("@IdAutor", SqlDbType.Int).Value = articulo.idAutor;
            try {

                Conexion.Open();
                command.ExecuteNonQuery();
            
            } catch (Exception e) { System.Diagnostics.Debug.WriteLine(e.ToString()); Conexion.Close(); return 0; }
            Conexion.Close();
            return 1;
        }

        public int eliminarArticulo(Articulos articulo)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Articulos WHERE Id_Articulo = @idArticulo",Conexion);
            command.Parameters.AddWithValue("@idArticulo", articulo.idArticulo);
            try {

                Conexion.Open();
                command.ExecuteNonQuery();
                Conexion.Close();
                BDComentarios obj = new BDComentarios();
                obj.eliminarComentarios(articulo.idArticulo.ToString());

            } catch (Exception e) { System.Diagnostics.Debug.WriteLine(e.ToString()); Conexion.Close(); return 0; }
            return 1;
        }
    }
}