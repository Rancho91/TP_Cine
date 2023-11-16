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
    public class ReportePeliculasGeneroClasiService
    {
        private DataHttp http { get; set; }

        public ReportePeliculasGeneroClasiService(DateTime fechaInicio, DateTime fechaFinal, TimeSpan hora)
        {
            http = new DataHttp($"Reporte/funciones/{fechaInicio}/{fechaFinal}/{hora}");
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
