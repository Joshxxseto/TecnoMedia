using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TecnoMedia
{
    public class BDComentarios
    {
        static SqlConnection Conexion = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\JoshSeto\source\repos\TecnoMedia\TecnoMedia\App_Data\NuestraBase.mdf;Integrated Security=True");

        public List<Comentario> obtenerComentarios(string idArticulo)
        {
            List<Comentario> lista = new List<Comentario> { };
            Comentario coment;
            SqlCommand command = new SqlCommand("SELECT * FROM Comentarios WHERE Id_Articulo = @idArticulo", Conexion);
            command.Parameters.AddWithValue("@idArticulo", idArticulo);
            try
            {
                Conexion.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    coment = new Comentario();
                    coment.idComentario = (int)reader["Id_Comentario"];
                    coment.idArticulo = (int)reader["Id_Articulo"];
                    coment.contenido = (string)reader["Comentario"];
                    coment.idAutor = (int)reader["Id_Autor"];
                    coment.tipoAutor= (int)reader["TipoAutor"];
                    lista.Add(coment);
                }
                Conexion.Close();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
            }
            return lista;
        }

        public int crearComentario(Comentario coment)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Comentarios (Id_Articulo,Comentario,Id_Autor,TipoAutor) " +
                "VALUES (@Id_Articulo,@Comentario,@Id_Autor,@TipoAutor)", Conexion);
            command.Parameters.AddWithValue("@Id_Articulo",coment.idArticulo);
            command.Parameters.AddWithValue("@Comentario",coment.contenido);
            command.Parameters.AddWithValue("@Id_Autor", coment.idAutor);
            command.Parameters.AddWithValue("@TipoAutor",coment.tipoAutor);
            try
            {
                Conexion.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception e) { System.Diagnostics.Debug.WriteLine(e.ToString()); Conexion.Close(); return 0; }
            Conexion.Close();
            return 1;
        }
        public void eliminarComentarios(String idArticulo)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Comentarios WHERE Id_Articulo = @idArticulo", Conexion);
            command.Parameters.AddWithValue("@idArticulo",idArticulo);
            try
            {

                Conexion.Open();
                command.ExecuteNonQuery();
                Conexion.Close();

            }
            catch (Exception e) { System.Diagnostics.Debug.WriteLine(e.ToString()); Conexion.Close();}
        }
    }
}