using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace TecnoMedia
{
    public partial class VerArticulo : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioEnSesion"] != null)
            {
                String Correo = Session["UsuarioEnSesion"].ToString();
                Asignar_Usuario(Correo);
                String idRecibida = Request.QueryString["id"];
                Cargar_Contenido(idRecibida);
            }
            
        }
        private Usuarios UsuarioEnSesion;
        private void Asignar_Usuario(String Correo)
        {
            BDUsuarios obj = new BDUsuarios();
            UsuarioEnSesion = obj.encontrarUsuario(Correo);
        }

        public void Comentar_Click(object sender, EventArgs e)
        {
            String idRecibida = Request.QueryString["id"];
            BDComentarios obj = new BDComentarios();

            if (textarea.Text != null || textarea.Text != "")
            {
                Comentario coment = new Comentario(Int32.Parse(idRecibida), textarea.Text, UsuarioEnSesion.id, UsuarioEnSesion.tipoUsuario);
                if (obj.crearComentario(coment) == 1)
                {
                    Response.Write("Articulo Comentado");
                    Response.Redirect("~/VerArticulo.aspx?id=" + idRecibida);
                }
                else
                {
                    Response.Write("Error en la base de datos intentelo mas tarde");
                }
            }
            else {
                Response.Write("Debes de Comentar Algo");
            }
        }

        private void Cargar_Contenido(String IdRecibido)
        {
            /*
             * Pasos:
             * Encontrar articulo
             * Generar el contenido html
             * Mostrarlo en pantalla
             */
            BDArticulos obj = new BDArticulos();
            Articulos articulo = new Articulos();
            articulo = obj.buscarArticulo(IdRecibido);
            HtmlGenericControl contenedor, Img,titulo, contenido,Autor;
            contenedor = new HtmlGenericControl("div class=articulo");
            Img = new HtmlGenericControl("img class='imagenBlog' src=img/" + articulo.imagen);
            titulo = new HtmlGenericControl("h2 class=titulo-articulo") { InnerText = articulo.titulo };
            contenido = new HtmlGenericControl("p") { InnerText = articulo.contenido };

            //Encontrar Autor
            BDUsuarios obj2 = new BDUsuarios();
            Usuarios autorUser = new Usuarios();
            autorUser = obj2.encontrarUsuario(articulo.idAutor);
            Autor = new HtmlGenericControl("p") { InnerText = "Autor:"+autorUser.nombre };

            contenedor.Controls.Add(Img);
            contenedor.Controls.Add(titulo);
            contenedor.Controls.Add(contenido);
            contenedor.Controls.Add(Autor);
            Articulo.Controls.Add(contenedor);

            desplegarComentarios(IdRecibido);
        }
        private void desplegarComentarios(string IdRecibido)
        {
            /*
             * Pasos:
             * Encontrar articulo
             * Encontrar sus comentarios
             * Generar el contenido html
             * Mostrarlo en pantalla
             */
            BDComentarios obj = new BDComentarios();
            List<Comentario> lista = new List<Comentario> { };
            lista = obj.obtenerComentarios(IdRecibido);
            HtmlGenericControl coment, comntImg, Img, comntTexto, cmntAutor, comntContenido;
            //Encontrar Autor
            BDUsuarios obj2;
            Usuarios autor;
            for (int i = 0; i < lista.Count; i++)
            {
                autor = new Usuarios();
                obj2 = new BDUsuarios();
                autor =obj2.encontrarUsuario(lista[i].idAutor,lista[i].tipoAutor);

                coment = new HtmlGenericControl("article class='entrada-coment'");
                comntImg = new HtmlGenericControl("div class='imagen-coment'");
                Img = new HtmlGenericControl("img  src=img/" + autor.imagen);
                comntTexto = new HtmlGenericControl("div class='contenido-coment'");
                cmntAutor = new HtmlGenericControl("h3 class=no-margin") { InnerText = autor.nombre };
                comntContenido = new HtmlGenericControl("p") { InnerText = lista[i].contenido };

                comntImg.Controls.Add(Img);
                comntTexto.Controls.Add(cmntAutor);
                comntTexto.Controls.Add(comntContenido);
                coment.Controls.Add(comntImg);
                coment.Controls.Add(comntTexto);
                Comentarios.Controls.Add(coment);
            }
        }
    }
}