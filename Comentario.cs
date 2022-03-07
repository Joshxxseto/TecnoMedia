using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TecnoMedia
{
    public class Comentario
    {
        private int IdArticulo;
        private int IdComentario;
        private String Contenido;
        private int IdAutor;
        private int TipoAutor;

        public Comentario() { }
        public Comentario(int idArt, int idComent, string cont, int idAutor, int TAutor)
        {
            this.IdArticulo = idArt;
            this.IdComentario = idComent;
            this.Contenido = cont;
            this.IdAutor = idAutor;
            this.TipoAutor = TAutor;
        }
        public Comentario(int idArt,string cont, int idAutor, int TAutor)
        {
            this.IdArticulo = idArt;
            this.Contenido = cont;
            this.IdAutor = idAutor;
            this.TipoAutor = TAutor;
        }

        public int idArticulo
        {
            get { return IdArticulo; }
            set { IdArticulo = value; }
        }
        public int idComentario
        {
            get { return IdComentario; }
            set { IdComentario = value; }
        }
        public string contenido
        {
            get { return Contenido; }
            set { Contenido = value; }
        }
        public int idAutor
        {
            get { return IdAutor; }
            set { IdAutor = value; }
        }
        public int tipoAutor
        {
            get { return TipoAutor; }
            set { TipoAutor = value; }
        }
    }
}