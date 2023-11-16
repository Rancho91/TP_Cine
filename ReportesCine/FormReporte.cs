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


                List<ReportParameter> paramList = new List<ReportParameter>();
                for (int i = 0; i < lst.Count; i++)
                {
                    paramList.Clear();
                    // Suponiendo que ReporteButacasDisponibles tiene propiedades: Codigo, Fila, Numero y Estado
                    paramList.Add(new ReportParameter("Butaca", lst[i].Codigo.ToString()));
                    paramList.Add(new ReportParameter("Fila", lst[i].Fila));
                    paramList.Add(new ReportParameter("Numero", lst[i].Numero.ToString()));
                    paramList.Add(new ReportParameter("Estado", lst[i].Estado));

                    reportViewer1.LocalReport.SetParameters(paramList);
                }

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
