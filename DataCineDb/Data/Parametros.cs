using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCineDb.Data
{
    public class Parametros
    {
        public string Nombre { get; set; }
        public object Valor { get; set; }

        public Parametros()
        {
            Nombre = string.Empty;
            Valor = null;
        }

        public Parametros(string nombre, object valor)
        {
            Nombre = nombre;
            Valor = valor;
        }

    }
}
