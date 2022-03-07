using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace TecnoMedia 
{
    public class BDUsuarios
    {
        static SqlConnection Conexion = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\JoshSeto\source\repos\TecnoMedia\TecnoMedia\App_Data\NuestraBase.mdf;Integrated Security=True");

        public int validarCorreo(String email)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Usuario WHERE Email = @Email", Conexion);
            command.Parameters.AddWithValue("@Email",email);
            try
            {
                Conexion.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Conexion.Close();
                    return 0;//Existe Un correo en Tabla
                }
                else
                {
                    Conexion.Close();
                    command = new SqlCommand("SELECT * FROM Administrador WHERE Email = @Email", Conexion);
                    command.Parameters.AddWithValue("@Email", email);
                    Conexion.Open();
                    reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        Conexion.Close();
                        return 0;//Existe Un correo en Tabla
                    }
                    else
                    {
                        Conexion.Close();
                        return 1;//NO Existe Un correo en Tabla
                    }
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                Conexion.Close();
                return -1;
            }
        }
        public int RegistrarUsuario(Usuarios usuario)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Usuario (Nombre,Email,Imagen,Contraseña)" +
                " VALUES(@Nombre,@Correo,@Imagen,@Contraseña)", Conexion);

            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = usuario.nombre;
            cmd.Parameters.Add("@Correo", SqlDbType.VarChar).Value = usuario.correo;
            cmd.Parameters.Add("@Imagen", SqlDbType.VarChar).Value = usuario.imagen;
            cmd.Parameters.Add("@Contraseña", SqlDbType.VarChar).Value = usuario.password;

            try
            {
                Conexion.Open();
                cmd.ExecuteNonQuery();
                Conexion.Close();
            }
            catch (Exception e) { System.Diagnostics.Debug.WriteLine(e.ToString()); return 0; }
            return 1;
        }
        public int validaPasword(String email, String password)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Usuario WHERE Email = @email", Conexion);
            cmd.Parameters.AddWithValue("@email", email);
            String comparar = "";
            try
            {
                Conexion.Open();
                SqlDataReader r = cmd.ExecuteReader();
                if (r.Read())
                {
                    System.Diagnostics.Debug.WriteLine("CorreoEnontrado");
                    comparar = r["Contraseña"].ToString();
                    if (comparar.Equals(password))
                    {
                        Conexion.Close();
                        return 1;
                    }
                    else
                    {
                        Conexion.Close();
                        return 0;
                    }
                }
                else
                {
                    Conexion.Close();
                    cmd = new SqlCommand("SELECT * FROM Administrador WHERE Email = @email", Conexion);
                    cmd.Parameters.AddWithValue("@email", email);
                    Conexion.Open();
                    r = cmd.ExecuteReader();
                    if (r.Read())
                    {
                        System.Diagnostics.Debug.WriteLine("CorreoEnontrado");
                        comparar = r["Contraseña"].ToString();
                        if (comparar.Equals(password))
                        {
                            Conexion.Close();
                            return 1;
                        }
                        else
                        {
                            Conexion.Close();
                            return 0;
                        }
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("CorreoNOEnontrado");
                        Conexion.Close();
                        return 0;
                    }
                }

            }
            catch (Exception e) { System.Diagnostics.Debug.WriteLine(e.ToString()); Conexion.Close(); return -1; }
        }

        public Usuarios encontrarUsuario(string email)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Usuario WHERE Email = @Email", Conexion);
            command.Parameters.AddWithValue("@Email", email);
            System.Diagnostics.Debug.WriteLine(email);
            Usuarios usuario = new Usuarios();
            try
            {
                Conexion.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    usuario.id = (int)reader["Id_Usuario"];
                    usuario.nombre = (string)reader["Nombre"];
                    usuario.correo = (string)reader["Email"];
                    usuario.imagen = (string)reader["Imagen"];
                    usuario.tipoUsuario = 0;
                    System.Diagnostics.Debug.WriteLine(usuario.id+usuario.nombre+usuario.tipoUsuario);
                    Conexion.Close();
                    return usuario;
                }
                else
                {
                    Conexion.Close();
                    command = new SqlCommand("SELECT * FROM Administrador WHERE Email = @Email", Conexion);
                    command.Parameters.AddWithValue("@Email", email);
                    Conexion.Open();
                    reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        usuario.id = (int)reader["Id_Admin"];
                        usuario.nombre = (string)reader["Nombre"];
                        usuario.correo = (string)reader["Email"];
                        usuario.imagen = (string)reader["Imagen"];
                        usuario.tipoUsuario = 1;
                        Conexion.Close();
                        return usuario;
                    }
                    else
                    {
                        Conexion.Close();
                        return usuario;
                    }
                }
                Conexion.Close();
            }
            catch (Exception e) { System.Diagnostics.Debug.WriteLine(e.ToString()); Conexion.Close();  return usuario; }
        }

        public Usuarios encontrarUsuario(int id)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM  Administrador WHERE Id_Admin = @id", Conexion);
            command.Parameters.AddWithValue("@id", id);
            Usuarios usuario = new Usuarios();
            try
            {
                Conexion.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    usuario.id = (int)reader["Id_Admin"];
                    usuario.nombre = (string)reader["Nombre"];
                    usuario.correo = (string)reader["Email"];
                    usuario.imagen = (string)reader["Imagen"];
                    usuario.tipoUsuario = 1;
                    Conexion.Close();
                    return usuario;
                }
                else
                {
                    Conexion.Close();
                    return usuario;
                }
                Conexion.Close();
            }
            catch (Exception e) { System.Diagnostics.Debug.WriteLine(e.ToString()); Conexion.Close(); return usuario; }
        }

        public Usuarios encontrarUsuario(int id,int tipo)
        {
            SqlCommand command;
            if (tipo==1)
            {
                command = new SqlCommand("SELECT * FROM  Administrador WHERE Id_Admin = @id", Conexion);
                command.Parameters.AddWithValue("@id", id);
            }
            else
            {
                command = new SqlCommand("SELECT * FROM  Usuario WHERE Id_Usuario = @id", Conexion);
                command.Parameters.AddWithValue("@id", id);
            }
            Usuarios usuario = new Usuarios();
            try
            {
                Conexion.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    if (tipo == 1)
                    {
                        usuario.id = (int)reader["Id_Admin"];
                    }
                    else
                    {
                        usuario.id = (int)reader["Id_Usuario"];
                    }   
                    usuario.nombre = (string)reader["Nombre"];
                    usuario.correo = (string)reader["Email"];
                    usuario.imagen = (string)reader["Imagen"];
                    usuario.tipoUsuario = tipo;
                    Conexion.Close();
                    return usuario;
                }
                else
                {
                    Conexion.Close();
                    return usuario;
                }
                Conexion.Close();
            }
            catch (Exception e) { System.Diagnostics.Debug.WriteLine(e.ToString()); Conexion.Close(); return usuario; }
        }


    }
}