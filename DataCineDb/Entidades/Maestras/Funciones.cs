using DataCineDb.Entidades.Auxiliares;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCineDb.Entidades.Maestras
{
    public class Funciones
    {

        public int Codigo { get; set; }
        public Pelicula Pelicula { get; set; }
        public Idiomas Idioma { get; set; }
        public TimeSpan Horario { get; set; }
        public DateTime Fecha { get; set; }

        public bool TerceraDimencion { get; set; }
        public bool Subtitulada { get; set; }

        public decimal Precio { get; set; }

        public List<Butacas> Butacas { get; set; }
        public Funciones()
        {
            Codigo = 0;
            Fecha= DateTime.Now;
            Idioma = new Idiomas();
            Pelicula = new Pelicula();
            Horario = TimeSpan.FromHours(0) + TimeSpan.FromMinutes(0);
            Precio = 0;
            Subtitulada = false;
            TerceraDimencion= false;

            Butacas = new List<Butacas>();
        }
        public void agregarButaca(Butacas butaca)
        {
            Butacas.Add(butaca);
        } 
        public void quitarButaca(int index)
        {
            Butacas.RemoveAt(index);
        }
    }
}
