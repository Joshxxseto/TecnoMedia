using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace TecnoMedia
{
    public partial class Inicio : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioEnSesion"] != null)
            {
                String Correo = Session["UsuarioEnSesion"].ToString();
                Asignar_Usuario(Correo);
                Cargar_Contenido();
            }            
        }
        private Usuarios UsuarioEnSesion;
        private void Asignar_Usuario(String Correo)
        {
            BDUsuarios obj = new BDUsuarios();
            UsuarioEnSesion = obj.encontrarUsuario(Correo);
        }
        private void Ver_Click(object sender, EventArgs e)
        {
            Button btn = new Button();
            btn = (Button)sender;
            string s = btn.ID;
            string[] subs = s.Split('_');
            Response.Redirect("~/VerArticulo.aspx?id="+subs[1]);
        }
        private void Editar_Click(object sender, EventArgs e)
        {
            Button btn = new Button();
            btn = (Button)sender;
            string s = btn.ID;
            string[] subs = s.Split('_');
            Response.Redirect("~/EditarArticulo.aspx?id=" + subs[1]);
        }
        private void Eliminar_Click(object sender, EventArgs e)
        {
            Button btn = new Button();
            btn = (Button)sender;
            string s = btn.ID;
            string[] subs = s.Split('_');
            BDArticulos obj = new BDArticulos();
            Articulos articuloAEliminar = new Articulos();
            articuloAEliminar=obj.buscarArticulo(subs[1]);
            obj.eliminarArticulo(articuloAEliminar);
            System.IO.File.Delete(Server.MapPath("/img/" + articuloAEliminar.imagen));
            Response.Redirect("~/Inicio.aspx");
        }
        private void Cargar_Contenido()
        {
            BDArticulos obj = new BDArticulos();
            List<Articulos> lista = new List<Articulos> { };
            /*
             * Pasos:
             * 1.- Obtener  lista de artuculos
             * 2.- Generar elementos HTML.
             * 3.- Imprimir articulos en HTML.
             */
            lista = obj.obtenerArticulos();
            HtmlGenericControl articulo,contImg,Img,contTexto,titulo,contenido;
            for (int i = 0; i < lista.Count; i++)
            { 
                articulo = new HtmlGenericControl("article class='entrada-blog'");
                contImg = new HtmlGenericControl("div class='imagen-blog'");
                Img = new HtmlGenericControl("img  src=img/" + lista[i].imagen);
                contTexto = new HtmlGenericControl("div class='contenido-blog'");
                titulo = new HtmlGenericControl("h3 class=no-margin") { InnerText = lista[i].titulo };
                contenido = new HtmlGenericControl("p class=elipsis") { InnerText = lista[i].contenido };
                Button btnVer = new Button();
                btnVer.ID = "ver_"+lista[i].idArticulo.ToString();
                btnVer.Attributes.Add("runat","server");
                btnVer.Attributes.Add("class", "boton boton-primario");
                btnVer.Click += Ver_Click;
                btnVer.Text = "Leer Más";

                contImg.Controls.Add(Img);
                contTexto.Controls.Add(titulo);
                contTexto.Controls.Add(contenido);
                contTexto.Controls.Add(btnVer);
                articulo.Controls.Add(contImg);

                if (UsuarioEnSesion.tipoUsuario==1)
                {
                    Button btnEliminar = new Button();
                    Button btnEditar = new Button();
                    btnEliminar.ID = "delete_"+lista[i].idArticulo.ToString();
                    btnEditar.ID = "edit_"+lista[i].idArticulo.ToString();
                    btnEliminar.Attributes.Add("runat", "server");
                    btnEditar.Attributes.Add("runat", "server");
                    btnEliminar.Attributes.Add("class", "boton boton-primario delete");
                    btnEditar.Attributes.Add("class", "boton boton-primario edit");
                    btnEliminar.Click += Eliminar_Click;
                    btnEditar.Click += Editar_Click;
                    btnEliminar.Text = "Eliminar";
                    btnEditar.Text = "Editar";
                    contTexto.Controls.Add(btnEditar);
                    contTexto.Controls.Add(btnEliminar);
                }
                articulo.Controls.Add(contTexto);
                ListaArticulos.Controls.Add(articulo);
            }
        }
    }
}