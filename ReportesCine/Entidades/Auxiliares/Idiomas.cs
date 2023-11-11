using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportesCine.Entidades.Auxiliares
{
    public class Idiomas
    {
        public int Codigo { get; set; }
        public string Idioma { get; set; }
        public Idiomas()
        {
            Codigo = 0;
            Idioma = string.Empty;
        }
        public Idiomas(string idioma)
        {
            Idioma = idioma;
        }
        public Idiomas(string idioma, int codigo)
        {
            Codigo = codigo;
            Idioma = idioma;
        }

    }
}
