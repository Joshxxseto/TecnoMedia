using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TecnoMedia
{
    public partial class IniciarSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioEnSesion"] != null)
            {
                Session.Remove("UsuarioEnSesion");
            }
        }
        protected void Inciar_Click(object sender, EventArgs e)
        {
            /*
             * Pasos.
             * 1.- Verificar que los campos esten llenos
             * 2.- Verficar que el usuario exista
             * 3.- Verificar que la contraseña sea correcta
             * 4.- Iniciar Sesion
             */
            String email = EmailInput.Text;
            String password = PassInput.Text;
            if (email != "" && password != "" && email != null && password != null)
            {
                BDUsuarios objeto = new BDUsuarios();
                if (objeto.validaPasword(email,password)==1)
                {
                    Session["UsuarioEnSesion"] = email;
                    Response.Redirect("~/Inicio.aspx");
                }
                else if (objeto.validaPasword(email, password) == 0)
                {
                    Response.Write("Error al Ingresar Correo o Contraseña");
                }
                else if (objeto.validaPasword(email, password) == -1)
                {
                    Response.Write("Error en Conexion con la BD, Verifique sus campos");
                }
            }
            else
            {
                Response.Write("Verifique que sus campos esten llenados correctamente");
            }

        }
    }
}