using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoCine
{
    class pelicula
    {
        private int id;
        private string titulo;
        private DateTime estreno;
        private string idioma;
        private string sinopsis;
        private genero genero;
        private director director;
        private int calificacion;
        private int duracion;

        public int pId
        {
            get { return id; }
            set { id = value; }
        }
        public string pTitulo { get => titulo; set => titulo = value; }
        public DateTime pEstreno { get => estreno; set => estreno = value; }
        public string pIdioma { get => idioma; set => idioma = value; }
        public string pSinopsis { get => sinopsis; set => sinopsis = value; }
        public int pCalificacion { get => calificacion; set => calificacion = value; }
        public int pDuracion { get => duracion; set => duracion = value; }
        public genero pGenero { get => genero; set => genero = value; }
        public director pDirector { get => director; set => director = value; }

        public pelicula()
        {
            id = 0;
            titulo = "";
            idioma = "";
            sinopsis = "";
            calificacion = 0;
            duracion = 0;
            genero = null;
            director = null;
        }

        public pelicula(int id, string titulo, DateTime estreno, string idioma, string sinopsis, genero genero, director director, int calificacion, int duracion)
        {
            this.id = id;
            this.titulo = titulo;
            this.estreno = estreno;
            this.idioma = idioma;
            this.sinopsis = sinopsis;
            this.genero = genero;
            this.director = director;
            this.calificacion = calificacion;
            this.duracion = duracion;
        }

    }
}
