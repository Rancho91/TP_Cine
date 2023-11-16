using DataCineDb.Entidades.Maestras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCineDb.Entidades.Reportes
{
    public class ReporteButacasDisponibles:Butacas
    {
        
        public string Estado { get; set; }

        public ReporteButacasDisponibles()
        {
            Estado = string.Empty;
        }

    }
}
