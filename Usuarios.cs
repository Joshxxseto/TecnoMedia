using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TecnoMedia
{
    public class Usuarios
    {
        private int ID;
        private String Nombre;
        private String Email;
        private String Imagen;
        private String Password;
        private int TipoUsuario;

        public Usuarios() { }
        public Usuarios(String Nombre, String email, String Imagen, String Password)
        {
            this.Nombre = Nombre;
            this.Email = email;
            this.Imagen = Imagen;
            this.Password = Password;
        }
        public Usuarios(int Id, String Nombre, String email,String Imagen, String Password)
        {
            this.ID = id;
            this.Nombre = Nombre;
            this.Email = email;
            this.Imagen = Imagen;
            this.Password = Password;
        }
        public int id
        {
            get { return ID; }
            set { ID = value; }
        }
        public int tipoUsuario
        {
            get { return TipoUsuario; }
            set { TipoUsuario = value; }
        }
        public string nombre
        {
            get { return Nombre; }
            set { Nombre = value; }
        }
        public string correo
        {
            get { return Email; }
            set { Email = value; }
        }
        public string imagen
        {
            get { return Imagen; }
            set { Imagen = value; }
        }
        public string password
        {
            get { return Password; }
            set { Password = value; }
        }
    }
}