using DataCineDb.Entidades.Auxiliares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCineDb.Entidades.Maestras
{
    public class Salas
    {
        public int Codigo { get; set; }
        public int Numero { get; set;}
        public TiposSalas Tipo { get; set; }
        public List<Funciones> Funciones { get; set; }

        public Salas()
        {
            Codigo = 0;
            Numero = 0;
            Tipo = new TiposSalas();
            Funciones = new List<Funciones>();
        }

        public Salas(int numero, TiposSalas tipo)
        {
            Numero = numero;
            Tipo = tipo;
            Funciones = new List<Funciones>();

        }

        public Salas(int codigo, int numero, TiposSalas tipo)
        {
            Codigo = codigo;
            Numero = numero;
            Tipo = tipo;
            Funciones = new List<Funciones>();
        }

        public void agregarFuncion(Funciones funcion)
        {
            Funciones.Add(funcion);
        }

        public void quitarFuncion(int index)
        {
            Funciones.RemoveAt(index);
        }
        }
    
}
