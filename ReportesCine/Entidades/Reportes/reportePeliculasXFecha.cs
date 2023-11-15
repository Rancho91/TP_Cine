using ReportesCine.Entidades.Maestras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportesCine.Entidades.Reportes
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
