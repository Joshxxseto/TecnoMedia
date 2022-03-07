using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TecnoMedia
{
    public partial class Registrarse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioEnSesion"] != null)
            {
                Session.Remove("UsuarioEnSesion");
            }
        }
        protected void Registrar_Click(object sender, EventArgs e)
        {
            /*
             * Pasos.
             * 1.- Verificar que los campos esten llenos
             * 2.- Verficar que la Imagen sea Aceptable
             * 3.- Verificar que el correo electronico no se repita
             * 4.- Registrar al usuario
             */
            String nombre = NombreInput.Text;
            String email = EmailInput.Text;
            String password = PassInput.Text;
            if(nombre!=""&&email!="" && password != ""&&nombre!=null && email != null && password != null)
            {
                if (FileInput.HasFile)
                {
                    String extension = System.IO.Path.GetExtension(FileInput.FileName).ToLower();
                    if (extension == ".jpg" || extension == ".png")
                    {
                        BDUsuarios objeto = new BDUsuarios();
                        if (objeto.validarCorreo(email) == 1)
                        {
                            Usuarios nuevoUsuario = new Usuarios(nombre,email,FileInput.FileName,password);
                            if (objeto.RegistrarUsuario(nuevoUsuario) == 1)
                            {
                                FileInput.SaveAs(Server.MapPath("/img/" + FileInput.FileName));
                                Response.Write("Usuario Registrado Correctamente");
                                Response.Redirect("~/IniciarSesion.aspx");
                            }
                            else
                            {
                                Response.Write("Error al Registrar Usuario");
                            }
                        }
                        else if (objeto.validarCorreo(email) == 0)
                        {
                            Response.Write("Ya exite una cuenta registrada a este correo");
                        }
                        else if (objeto.validarCorreo(email) == -1)
                        {
                            Response.Write("Error en Conexion con la BD, Verifique sus campos");
                        }
                    }
                }
            }
            else
            {
                Response.Write("Verifique que sus campos esten llenados correctamente");
            }

        }
    }
}