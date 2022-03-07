using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace TecnoMedia
{
    public partial class EditarArticulo : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UsuarioEnSesion"] != null)
                {
                    String Correo = Session["UsuarioEnSesion"].ToString();
                    Asignar_Usuario(Correo);
                    String idRecibida = Request.QueryString["id"];
                    Cargar_Contenido(idRecibida);
                }
            }
            else
            {
                if (Session["UsuarioEnSesion"] != null)
                {
                    String Correo = Session["UsuarioEnSesion"].ToString();
                    Asignar_Usuario(Correo);
                }
            }      
        }
        private Usuarios UsuarioEnSesion;
        private void Asignar_Usuario(String Correo)
        {
            BDUsuarios obj = new BDUsuarios();
            UsuarioEnSesion = obj.encontrarUsuario(Correo);
        }
        private void Cargar_Contenido(String IdRecibido)
        {
            /*
             * Pasos:
             * Encontrar articulo
             * Generar el contenido html
             * Mostrarlo en pantalla Llenado
             * 
             */
            BDArticulos obj = new BDArticulos();
            Articulos articulo = new Articulos();
            articulo = obj.buscarArticulo(IdRecibido);
            tituloArea.Text = articulo.titulo;
            textArea.Text = articulo.contenido;
            articuloEnEdicion = articulo;
        }
        private static Articulos articuloEnEdicion;
        public void Actualizar_Click(object sender, EventArgs e)
        {
            String titulo = tituloArea.Text;
            String contenido = textArea.Text;
            if (titulo != "" && contenido != "" &&  titulo != null && contenido != null )
            {
                articuloEnEdicion.titulo = titulo;
                articuloEnEdicion.contenido = contenido;

                if (FileInput.HasFile)//Se desea Cambiar la Imagen
                {
                    String extension = System.IO.Path.GetExtension(FileInput.FileName).ToLower();
                    if (extension == ".jpg" || extension == ".png")
                    {
                        System.IO.File.Delete(Server.MapPath("/img/" + articuloEnEdicion.imagen));
                        BDArticulos obj = new BDArticulos();
                        articuloEnEdicion.imagen = FileInput.FileName;
                        if (obj.alterarArticulo(articuloEnEdicion) == 1)
                        {
                            FileInput.SaveAs(Server.MapPath("/img/" + FileInput.FileName));
                            Response.Write("Articulo Alterado Correctamente");
                            Response.Redirect("~/Inicio.aspx");
                        }
                        else
                        {
                            Response.Write("Error al Realizar Cambio");
                        }
                    }
                }
                else //No se desea cambiar la iagen
                {
                    BDArticulos obj = new BDArticulos();
                    if (obj.alterarArticulo(articuloEnEdicion) == 1)
                    {
                        Response.Write("Articulo Alterado Correctamente");
                        Response.Redirect("~/Inicio.aspx");
                    }
                    else
                    {
                        Response.Write("Error al Realizar Cambio");
                    }
                }
            }
        }
    }
}