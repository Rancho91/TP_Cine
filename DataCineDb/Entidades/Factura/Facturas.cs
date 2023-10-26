using DataCineDb.Entidades.Maestras;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCineDb.Entidades.Factura
{
    public class Facturas
    {
        public int Numero { get; set; }

        public List<Funciones> Funciones { get; set; }

        public DateTime Fecha { get; set; }

        public Clientes Cliente { get; set; }

        public FormasPagos FormaPago { get; set; }

        public TiposFacturas TipoFactura { get; set; }

        public int Descuento { get; set; }
        public Facturas()
        {
            Numero = 0;
            Fecha = DateTime.Now;
            Cliente = new Clientes();
            FormaPago = new FormasPagos();
            TipoFactura = new TiposFacturas();
            Descuento = 0;
            Funciones = new List<Funciones>();

        }
        public Facturas(int descuento, int numero, DateTime fecha, Clientes cliente, FormasPagos formaPago, TiposFacturas tiposFacturas)
        {
            Numero = numero;
            Fecha = fecha;
            Cliente = cliente;
            FormaPago = formaPago;
            TipoFactura = tiposFacturas;
            Descuento = descuento;
        }

        public void AgregarFuncion (Funciones funcion)
        {
            Funciones.Add(funcion);
        }

        public void QuitarFuncion(int index)
        {
            Funciones.RemoveAt(index);
        }

    }
}
