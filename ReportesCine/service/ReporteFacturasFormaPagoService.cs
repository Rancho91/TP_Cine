using DataCineDb.Entidades.Reportes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportesCine.service
{
    public class ReporteFacturasFormaPagoService
    {
        private DataHttp http { get; set; }

        public ReporteFacturasFormaPagoService(DateTime fechaInicio, DateTime fechaFinal, TimeSpan hora)
        {
            http = new DataHttp($"Reporte/funciones/{fechaInicio}/{fechaFinal}/{hora}");
        }

        public async Task<List<ReporteFacturasFormaPago>> GetReporte()
        {
            List<ReporteFacturasFormaPago> list = new List<ReporteFacturasFormaPago>();
            try
            {
                string json = await http.Get();
                list = JsonConvert.DeserializeObject<List<ReporteFacturasFormaPago>>(json);
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
