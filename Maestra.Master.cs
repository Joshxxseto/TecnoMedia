using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TecnoMedia
{
    public partial class Maestra : System.Web.UI.MasterPage
    {
        private static  Usuarios usuarioSesion;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioEnSesion"] != null)
            {
                String Usuario = Session["UsuarioEnSesion"].ToString();
                Ajustar_Usuario(Usuario);
            }
            else
            {
                Session.Remove("UsuarioEnSesion");
                Response.Redirect("~/IniciarSesion.aspx");
            }
        }
        private void Ajustar_Usuario(String Usuario)
        {
            BDUsuarios obj = new BDUsuarios();
            usuarioSesion = obj.encontrarUsuario(Usuario);
            if (usuarioSesion.tipoUsuario != 1)
            {
                Crear_Articulo.Visible = false;
            }
            nameUsr.InnerText = usuarioSesion.nombre;
            profilePic.Src = "/img/" + usuarioSesion.imagen;
        }
        public Usuarios getUsuario
        {
            get { return usuarioSesion; }
        }
    }
}