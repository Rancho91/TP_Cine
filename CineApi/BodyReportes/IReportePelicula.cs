using DataCineDb.Entidades;
using DataCineDb.Entidades.Maestras;

namespace CineApi.interfaceReportes
{
    public class ReportePelicula
    {
        public Salas Sala { get; set; }
        public Generos Genero { get; set; }
        public int orden { get; set; }
        public ReportePelicula()
        {
            Sala = new Salas();
            Genero = new Generos();
            orden = 0;
        }
    }
}
