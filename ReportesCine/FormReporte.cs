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
            reporteDBService = new ReporteButacasDisponiblesService(1, "No Disponible");

        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                List<ReporteButacasDisponibles> lst = await reporteDBService.GetReporte();
                DataTable dataTable = ConvertListToDataTable(lst);

                reportViewer1.LocalReport.ReportPath = @"C:\Users\ramir\Desktop\Proyectos Facu\version ema\TP_Cine\ReportesCine\Reportes\Report1.rdlc";
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ButacasDisponiblesDataSet", lst));


                //foreach (ReporteButacasDisponibles rep in lst)
                //{
                //    List<ReportParameter> paramList = new List<ReportParameter>();

                //    paramList.Add(new ReportParameter("Codigo", rep.Codigo.ToString()));
                //    paramList.Add(new ReportParameter("Fila", rep.Fila));
                //    paramList.Add(new ReportParameter("Numero", rep.Numero.ToString()));
                //    paramList.Add(new ReportParameter("Estado", rep.Estado));
                //    reportViewer1.LocalReport.SetParameters(paramList);

                //}

                for (int i = 0; i < lst.Count; i++)
                {

                    List<ReportParameter> paramList = new List<ReportParameter>();

                    paramList.Add(new ReportParameter("Codigo", lst[i].Codigo.ToString()));
                    paramList.Add(new ReportParameter("Fila", lst[i].Fila));
                    paramList.Add(new ReportParameter("Numero", lst[i].Numero.ToString()));
                    paramList.Add(new ReportParameter("Estado", lst[i].Estado));
                    reportViewer1.LocalReport.SetParameters(paramList);

                }
                reportViewer1.RefreshReport();

                funcionService = new FuncionService();
                llenarComboFunciones();
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

        private DataTable ConvertListToDataTable(List<ReporteButacasDisponibles> list)
        {
            DataTable dataTable = new DataTable("ButacasDisponiblesDataSet");

            // Agrega las columnas al DataTable (asegúrate de que coincidan con las propiedades de ReporteButacasDisponibles)
            dataTable.Columns.Add("Butaca", typeof(int));
            dataTable.Columns.Add("Fila", typeof(string));
            dataTable.Columns.Add("Numero", typeof(int));
            dataTable.Columns.Add("Estado", typeof(string));

            // Agrega las filas al DataTable
            foreach (var item in list)
            {
                DataRow row = dataTable.NewRow();
                row["Butaca"] = item.Codigo;
                row["Fila"] = item.Fila;
                row["Numero"] = item.Numero;
                row["Estado"] = item.Estado;
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }


        private async void llenarComboFunciones()
        {
            List<ReportePeliculasGanancia> lst = await funcionService.GetReport();

            cboFuncionReporte.DataSource = lst;

            cboFuncionReporte.DisplayMember = "codigo"; 

            cboFuncionReporte.ValueMember = "codigo";

            cboFuncionReporte.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private  void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
