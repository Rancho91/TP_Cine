using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCineDb.Entidades
{
    public class Generos
    {
        public int Codigo { get; set; }
        public  string Genero { get; set; }
        public Generos()
        {
            Codigo = 0;
            Genero = string.Empty;
        }
        public Generos(string gnro)
        {
            this.Genero = gnro;
                   }

        public Generos(string genero, int codigo)
        {
            this.Genero = genero;
            this.Codigo = codigo;
        }

    }
}
