using DataCineDb.Entidades.Maestras;

namespace CineApi.BodyReportes
{
    public class BodyReporteButaca
    {
        public Funciones funcion { get; set; }
        public int disponible { get; set; }

        public int noDisponible { get; set; }

        public BodyReporteButaca()
        {
            funcion = new Funciones();
            disponible = -1;
            noDisponible = -1;
        }
    }
}
