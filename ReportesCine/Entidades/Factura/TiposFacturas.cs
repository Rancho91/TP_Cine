using System.ComponentModel.DataAnnotations;

namespace ReportesCine.Entidades.Factura
{
    public class TiposFacturas
    {

        public int Codigo { get; set; }
        public string TipoFactura { get; set; }

        public TiposFacturas()
        {
            Codigo = 0;
            TipoFactura = string.Empty;
        }
        public TiposFacturas(int codigo, string tipoFactura)
        {
            Codigo = codigo;
            TipoFactura = tipoFactura;
        }

        public TiposFacturas(string tipoFactura)
        {
            TipoFactura = tipoFactura;
        }

    }
}