using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportesCine.Entidades.Factura
{
    public class FormasPagos
    {

        public int Codigo { get; set; }
        public string FormaPago { get; set; }
        public FormasPagos()
        {
            Codigo = 0;
            FormaPago = string.Empty;
        }
        public FormasPagos(int codigo, string formaPago)
        {
            Codigo = codigo;
            FormaPago = formaPago;
        }

        public FormasPagos(string formaPago)
        {
            FormaPago = formaPago;
        }

    }
}
