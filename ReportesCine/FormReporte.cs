using ReportesCine.Entidades.Maestras;
using ReportesCine.Entidades.Reportes;
using ReportesCine.service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReportesCine;
using Microsoft.Reporting.WinForms;
using ReportesCine.Entidades.Reportes;

namespace CineApi.ReportesCine
{
    public partial class Form1 : Form
    {
<<<<<<< HEAD
        private ReportePeliculaGananciaService funcionService;
=======
        private FuncionService funcionService;

        private ReporteButacasDisponiblesService reporteDBService;

>>>>>>> 058d5b1922e681b97967809802d2dd0bd3cb3d5c
        public Form1()
        {
            InitializeComponent();
            reporteDBService = new ReporteButacasDisponiblesService(1, "Disponible");

        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                List<ReporteButacasDisponibles> lst = await reporteDBService.GetReporte();

                reportViewer1.LocalReport.ReportPath = @"C:\Users\Emanuel\Desktop\Cine-App\TP_Cine\ReportesCine\Reportes\Report1.rdlc";
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ButacasDisponiblesDataSet", lst));


                ReportParameter[] param = new ReportParameter[lst.Count];

                    param[0] = new ReportParameter("Butaca", 1.ToString());
                    param[1] = new ReportParameter("Fila", "M");
                    param[2] = new ReportParameter("Numero", 1.ToString());
                    param[3] = new ReportParameter("Estado", "D");

                    reportViewer1.LocalReport.SetParameters(param[0]);
                    reportViewer1.LocalReport.SetParameters(param[1]);
                    reportViewer1.LocalReport.SetParameters(param[2]);
                    reportViewer1.LocalReport.SetParameters(param[3]);

                funcionService = new FuncionService();
                llenarComboFunciones();
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                // Manejar la excepción, por ejemplo, mostrar un mensaje de error o registrarla.
                MessageBox.Show($"Error al obtener datos: {ex.Message}");
            }
            this.reportViewer1.RefreshReport();
<<<<<<< HEAD
            funcionService = new ReportePeliculaGananciaService("Ñ",TimeSpan.Parse("00:00:00"),"Ñ");
            llenarComboFunciones();
        }

        private async void cboFuncionReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("http://localhost:41953/api/reporte");

            Console.WriteLine(response.Content);

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

=======
>>>>>>> 058d5b1922e681b97967809802d2dd0bd3cb3d5c
        }

        private async void llenarComboFunciones()
        {
            List<ReportePeliculasGanancia> lst = await funcionService.GetReport();

            cboFuncionReporte.DataSource = lst;

            cboFuncionReporte.DisplayMember = "codigo"; 

            cboFuncionReporte.ValueMember = "codigo";

            cboFuncionReporte.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
