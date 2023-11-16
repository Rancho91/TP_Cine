﻿using Newtonsoft.Json;
using ReportesCine.Entidades.Reportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportesCine.service
{
    public class ReportePeliculaGananciaService
    {
        private DataHttp http { get; set; }
<<<<<<< HEAD
        public ReportePeliculaGananciaService(string genero, TimeSpan duracion, string clasificacion)
        {
            http = new DataHttp($"reporte/peliculasGeneroClasi/{genero}/{duracion}/{clasificacion}");
        }

        public async Task<List<ReportePeliculasGanancia>> GetReport()
=======

        public ReportePeliculaGananciaService(int? sala, string genero, int orden)
        {
            http = new DataHttp($"Reporte/butacas/{sala}/{genero}/{orden}");
        }

        public async Task<List<ReportePeliculasGanancia>> GetReporte()
>>>>>>> 41991cbed336e3ffb23b08f712233c5ad0f0160c
        {
            List<ReportePeliculasGanancia> list = new List<ReportePeliculasGanancia>();
            try
            {
                string json = await http.Get();
                list = JsonConvert.DeserializeObject<List<ReportePeliculasGanancia>>(json);
<<<<<<< HEAD
=======
                return list;
>>>>>>> 41991cbed336e3ffb23b08f712233c5ad0f0160c
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return list;
        }
    }
}
<<<<<<< HEAD
=======


>>>>>>> 41991cbed336e3ffb23b08f712233c5ad0f0160c
