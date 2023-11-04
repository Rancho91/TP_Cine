using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCineDb.Entidades.Auxiliares
{
    public class TiposSalas
    {
        public int Codigo { get; set; }
        public string Tipo { get; set; }

        public TiposSalas()
        {
            Codigo= 0;
            Tipo = string.Empty;
        }
        public TiposSalas(string tipo)
        {
            Tipo = tipo;
        }
        public TiposSalas( string tipo, int codigo)
        {
            Codigo = codigo;
            Tipo = tipo;
        }

    }
}
