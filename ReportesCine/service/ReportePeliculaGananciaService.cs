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
        public ReportePeliculaGananciaService(string genero, TimeSpan duracion, string clasificacion)
        {
            http = new DataHttp($"reporte/peliculasGeneroClasi/{genero}/{duracion}/{clasificacion}");
        }

        public async Task<List<ReportePeliculasGanancia>> GetReport()
        {
            List<ReportePeliculasGanancia> list = new List<ReportePeliculasGanancia>();
            try
            {
                string json = await http.Get();
                list = JsonConvert.DeserializeObject<List<ReportePeliculasGanancia>>(json);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return list;
        }
    }
}
