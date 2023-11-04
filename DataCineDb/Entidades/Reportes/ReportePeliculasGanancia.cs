using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataCineDb.Entidades.Maestras;
namespace DataCineDb.Entidades.Reportes
{
    public class ReportePeliculasGanancia : Peliculas
    {
        public decimal Ganancia { get; set; }
        public int CantidadButacas { get; set; }

        public ReportePeliculasGanancia()
        {
            Ganancia= 0;
            CantidadButacas= 0;
        }
    }
}
