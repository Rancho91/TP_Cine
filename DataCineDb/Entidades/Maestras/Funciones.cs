using DataCineDb.Entidades.Auxiliares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCineDb.Entidades.Maestras
{
    public class Funciones
    {
        public int Codigo { get; set; }
        public Pelicula Pelicula { get; set; }
        public Idiomas idioma { get; set; }
        public TimeSpan Horario { get; set; }
        public DateTime Fecha { get; set; }

        public bool TerceraDimencion { get; set; }
        public bool Subtitulada { get; set; }

    }
}
