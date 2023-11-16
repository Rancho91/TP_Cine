using DataCineDb.Entidades.Factura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCineDb.Entidades.Reportes
{
    public class ReporteFacturasFormaPago :FormasPagos
    {
        public int CantVentas { get; set; }
        public decimal SumaTotal { get; set; }
        public decimal totalDescuento { get; set; }
        public decimal totalFacturado { get; set; }
        public int cantidadFunciones { get; set; }
        public  decimal PromedioGananciaFuncion { get; set; }
         


    }
}
