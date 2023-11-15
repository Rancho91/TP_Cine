using DataCineDb.Entidades.Maestras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCineDb.Entidades.Reportes
{
    public class ReportePeliculasXFecha:Funciones
    {
        public Salas Sala { get; set; }
        public ReportePeliculasXFecha()
        {
            Sala= new Salas();
        }
    }
}
