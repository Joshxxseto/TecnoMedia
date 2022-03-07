using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TecnoMedia
{
    public class Articulos
    {
        private int IdArticulo;
        private String Contenido;
        private String Titulo;
        private String Imagen;
        private int IdAutor;

        public Articulos() { }
        public Articulos(string tit, string cnt, string img, int idA)
        {
            this.Titulo = tit;
            this.Contenido = cnt;
            this.Imagen = img;
            this.IdAutor = idA;
        }

        public int idArticulo
        {
            get { return IdArticulo; }
            set { IdArticulo = value; }
        }
        public string titulo
        {
            get { return Titulo; }
            set { Titulo = value; }
        }
        public string contenido
        {
            get { return Contenido; }
            set { Contenido = value; }
        }
        public string imagen
        {
            get { return Imagen; }
            set { Imagen = value; }
        }
        public int idAutor
        {
            get { return IdAutor; }
            set { IdAutor = value; }
        }
    }
}