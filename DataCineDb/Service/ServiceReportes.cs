﻿using DataCineDb.Data;
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

        public List<ReportePeliculasGanancia> GetReportePeliculasGanancias(int? sala, string? genero, int? order)

        {
            List<ReportePeliculasGanancia> list = new List<ReportePeliculasGanancia>();
            List<Parametros> listParam = new List<Parametros>();
            if (genero != null && genero.ToLower() != "todo")
                listParam.Add(new Parametros("@genero", genero));
            if (sala != 0)
                listParam.Add(new Parametros("@sala", sala.ToString()));
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

        public List<ReporteButacasDisponibles> getReporteButacasDisponibles(int funcion, string? estado)
        {
            List<ReporteButacasDisponibles> list = new List<ReporteButacasDisponibles>();
            List<Parametros> listParametros = new List<Parametros>() ;

            if (funcion != 0)
                listParametros.Add(new Parametros("@Codigo_funcion", funcion));
            
           listParametros.Add(new Parametros("@Estado", estado));
       

            DataTable dt = helper.Consultar("sp_butacas_disponibles_x_funcion", listParametros);
            foreach(DataRow row in dt.Rows)
            {
                ReporteButacasDisponibles reporte = new ReporteButacasDisponibles();
                reporte.Estado = row[4].ToString();
                reporte.Numero = (int)row[3];
                reporte.Fila = row[2].ToString();
                reporte.Codigo = (int)row[0];
                list.Add(reporte);
                 
            }


            return list;
        }

        public List<ReportePeliculasXFecha> reportePeliculasFechaHora(DateTime? fechaInicio, DateTime? fechaFinal, TimeSpan? horario)
        {
            List<ReportePeliculasXFecha> list = new List<ReportePeliculasXFecha>();
            List<Parametros> listParametros = new List<Parametros>();

            if (fechaInicio != null)
            {
                listParametros.Add(new Parametros("@fechainicio", fechaInicio));
            }
            if(fechaFinal != null)
            {
                listParametros.Add(new Parametros("@fechaFinal", fechaFinal));
            }
            if(horario != null)
            {
                listParametros.Add(new Parametros("@hora", horario));
            }

            DataTable dt = helper.Consultar("sp_pelicuas_x_fecha_hora", listParametros);
            foreach(DataRow row in dt.Rows)
            {
                ReportePeliculasXFecha fun = new ReportePeliculasXFecha();
                fun.Codigo = (int)row[0];
                fun.Pelicula.Nombre = row[1].ToString();
                fun.Sala.Codigo= (int)row[2];
                fun.Fecha = DateTime.Parse(row[3].ToString());
                fun.Pelicula.Clasificacion.Clasificacion = row[4].ToString();
                fun.Pelicula.Duracion = TimeSpan.Parse(row[5].ToString());
                fun.Horario = TimeSpan.Parse(row[6].ToString());
                fun.Idioma.Idioma = row[7].ToString();
                fun.Subtitulada = row[8].ToString() == "subtitulada";
                list.Add(fun);
                
            }
            return list;

        }


    }
}
