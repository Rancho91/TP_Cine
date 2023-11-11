using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportesCine.Entidades.Maestras
{
    public class Clientes
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento { get; set; }

        public string Direccion { get; set; }

        public Clientes()
        {
            Codigo = 0;
            Nombre = string.Empty;
            Apellido= string.Empty;
            Documento = string.Empty;
            Direccion = string.Empty;
        }
        public Clientes(int codigo, string nombre, string apellido, string documento, string direccion)
        {
            Codigo = codigo;
            Nombre = nombre;
            Apellido = apellido;
            Documento = documento;
            Direccion = direccion;


        }

    }
}
