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
        public Peliculas Pelicula { get; set; }
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
            Pelicula = new Peliculas();
            Horario = TimeSpan.FromHours(0) + TimeSpan.FromMinutes(0);
            Precio = 0;
            Subtitulada = false;
            TerceraDimencion= false;

            Butacas = new List<Butacas>();
        }

        public Funciones(int codigo, Peliculas pelicula, DateTime fecha, TimeSpan horario)
        {
            Codigo = codigo;
            Pelicula = pelicula;
            Fecha = fecha;
            Horario = horario;
            Idioma = new Idiomas();
            Subtitulada = false;
            TerceraDimencion = false;
            Butacas = new List<Butacas>();
        }

        public Funciones(int codigo, Peliculas pelicula, DateTime fecha, TimeSpan horario, decimal precio, bool subtitulada, bool terceraDimencion, Idiomas idioma)
        {
            Codigo = codigo;
            Pelicula = pelicula;
            Fecha = fecha;
            Horario = horario;
            Idioma = idioma;
            Precio = precio;
            Subtitulada = subtitulada;
            TerceraDimencion = terceraDimencion;

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
