using DataCineDb.Data;
using DataCineDb.Entidades;
using DataCineDb.Entidades.Maestras;
using DataCineDb.Entidades.Reportes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCineDb.Service
{
    public class ServiceReportes
    {
        DbHelper helper = DbHelper.ObtenerInstancia();

        public List<ReportePeliculasGanancia> GetReportePeliculasGanancias(Salas? sala, Generos? genero, int? order)

        {
            List<ReportePeliculasGanancia> list = new List<ReportePeliculasGanancia>();
            List<Parametros> listParam = new List<Parametros>();
            if (genero.Genero != string.Empty && genero.Genero != "")
                listParam.Add(new Parametros("@genero", genero.Genero));
            if (sala.Numero != 0)
                listParam.Add(new Parametros("@sala", sala.Numero.ToString()));
            if (order ==0 || order==1)
                listParam.Add(new Parametros("@order", order));

            DataTable dt = helper.Consultar("sp_consultar_Butacas_peliculas", listParam);
            foreach(DataRow row in dt.Rows)
            {
                ReportePeliculasGanancia reporte = new ReportePeliculasGanancia();
                reporte.Ganancia = (decimal)row[1];
                reporte.CantidadButacas = (int)row[2];
                reporte.Genero = new Generos(row[3].ToString());
                reporte.Nombre = row[0].ToString();
                list.Add(reporte);
            }
            return list;
        }

        public List<ReporteButacasDisponibles> getReporteButacasDisponibles(Funciones? funcion, int? disponibles, int? noDisponibles)
        {
            List<ReporteButacasDisponibles> list = new List<ReporteButacasDisponibles>();
            List<Parametros> listParametros = new List<Parametros>() ;

            if (funcion != null)
                listParametros.Add(new Parametros("@Codigo_funcion", funcion.Codigo));
            if (disponibles > -1)
                listParametros.Add(new Parametros("@Disponible", disponibles));
            if (noDisponibles > -1)
                listParametros.Add(new Parametros("@noDisponible", noDisponibles));

            DataTable dt = helper.Consultar("sp_butacas_disponibles_x_funcion", listParametros);
            foreach(DataRow row in dt.Rows)
            {
                ReporteButacasDisponibles reporte = new ReporteButacasDisponibles();
                reporte.Estado = row[5].ToString();
                reporte.Numero = (int)row[4];
                reporte.Fila = row[3].ToString();
                reporte.Codigo = (int)row[0];
                list.Add(reporte);
                 
            }


            return list;
        }
    }
}
