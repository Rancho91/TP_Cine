using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCineDb.Entidades
{
    public class Paises
    {
        public int Codigo { get; set; }
        public string Pais { get; set; }

        public Paises()
        {
            Codigo = 0;
            Pais = string.Empty;
        }
        public Paises(string pais)
        {
            this.Pais = pais;
        }

        public Paises(string pais, int codigo)
        {
            this.Codigo = codigo;
            this.Pais = pais;
        }


    }
}
