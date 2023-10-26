using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCineDb.Entidades
{
    public class Clasificaciones
    {
        public int Codigo { get; set; }
        public string Clasificacion { get; set; }
        public Clasificaciones()
        {
            Codigo = 0;
            Clasificacion = string.Empty;
        }
        public Clasificaciones(string clasifiacion)
        {
            this.Clasificacion = clasifiacion;
        }

        public Clasificaciones( string clasifiacion, int codigo)
        {
            this.Clasificacion = clasifiacion;
            this.Codigo = codigo;
        }

    }
}
