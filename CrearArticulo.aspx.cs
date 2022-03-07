using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TecnoMedia
{
    public partial class CrearArticulo : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
                if (Session["UsuarioEnSesion"] != null)
                {
                    String Correo = Session["UsuarioEnSesion"].ToString();
                    Asignar_Usuario(Correo);
                }
        }
        private Usuarios UsuarioEnSesion;
        private void Asignar_Usuario(String Correo)
        {
            BDUsuarios obj = new BDUsuarios();
            UsuarioEnSesion = obj.encontrarUsuario(Correo);
        }
        public void Actualizar_Click(object sender, EventArgs e)
        {
            String titulo = tituloArea.Text;
            String contenido = textArea.Text;
            Articulos articulo = new Articulos();
            if (titulo != "" && contenido != "" && titulo != null && contenido != null)
            {
                if (FileInput.HasFile)//Se desea Cambiar la Imagen
                {
                    String extension = System.IO.Path.GetExtension(FileInput.FileName).ToLower();
                    if (extension == ".jpg" || extension == ".png")
                    {
                        BDArticulos obj = new BDArticulos();
                        articulo.contenido = contenido;
                        articulo.titulo = titulo;
                        articulo.idAutor = UsuarioEnSesion.id;
                        articulo.imagen = FileInput.FileName;

                        if (obj.agregarArticulo(articulo) == 1)
                        {
                            FileInput.SaveAs(Server.MapPath("/img/" + FileInput.FileName));
                            Response.Write("Articulo Agregado Correctamente");
                            Response.Redirect("~/Inicio.aspx");
                        }
                        else
                        {
                            Response.Write("Error al Agregar Articulo");
                        }
                    }
                }
                else
                {
                    Response.Write("Necesita Agregar una imagen");
                }
            }
            else
            {
                Response.Write("Verifque que los campos esten llenados correctamente");
            }
        }
    }
}