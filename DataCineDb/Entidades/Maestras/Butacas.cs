using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCineDb.Entidades.Maestras
{
    public class Butacas
    {
        public int Codigo { get; set; }
        public string Fila { get; set; }
        public int Numero { get; set; }
        public bool Vendida { get; set;}
        public bool Reservada { get; set; }

        public Butacas()
        {
            Codigo = 0;
            Numero=0;
            Fila = string.Empty;
            Vendida = false;
            Reservada = false;
        }
        public Butacas(int codigo, string fila, int numero, bool vendida, bool reservada )
        {
            Codigo = codigo;
             Fila = fila;
            Numero = numero;
            Vendida = vendida;
            Reservada = reservada;

        }

        public Butacas( string fila, int numero)
        {
            Fila = fila;
            Numero = numero;
            Vendida= false; 
            Reservada = false;
        }



    }
}
