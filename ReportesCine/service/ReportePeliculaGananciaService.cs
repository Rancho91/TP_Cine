using Newtonsoft.Json;
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

        public ReportePeliculaGananciaService(int? sala, string genero, int orden)
        {
            http = new DataHttp($"Reporte/butacas/{sala}/{genero}/{orden}");
        }

        public async Task<List<ReportePeliculasGanancia>> GetReporte()
        {
            List<ReportePeliculasGanancia> list = new List<ReportePeliculasGanancia>();
            try
            {
                string json = await http.Get();
                list = JsonConvert.DeserializeObject<List<ReportePeliculasGanancia>>(json);
                return list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return list;
        }
    }
}


