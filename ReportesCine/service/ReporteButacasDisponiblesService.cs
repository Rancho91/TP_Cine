using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using ReportesCine.Entidades.Maestras;
using System.Data;
using System.Linq;
using System.Text;
using ReportesCine.Entidades.Reportes;


namespace ReportesCine.service
{
    public class ReporteButacasDisponiblesService
    {
        private DataHttp http { get; set; }

        public ReporteButacasDisponiblesService(int cod, string estado)
        {
            http = new DataHttp($"Reporte/butacas/{cod}/{estado}");
        }

        public async Task<List<ReporteButacasDisponibles>> GetReporte()
        {
            List<ReporteButacasDisponibles> list = new List<ReporteButacasDisponibles>();
            try
            {
                string json = await http.Get();
                list = JsonConvert.DeserializeObject<List<ReporteButacasDisponibles>>(json);
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
