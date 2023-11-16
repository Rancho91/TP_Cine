using ReportesCine.Entidades.Maestras;
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
        private FuncionService funcionService;

        private ReporteButacasDisponiblesService reporteDBService;

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
                for (int i = 0; i < lst.Count; i++)
                {
                    param[0] = new ReportParameter("COD_BUTACA", lst[0].Codigo.ToString());
                    param[1] = new ReportParameter("FILA", lst[2].Fila);
                    param[2] = new ReportParameter("NUMERO", lst[3].Numero.ToString());
                    param[3] = new ReportParameter("Estado", lst[4].Estado);
                }

                reportViewer1.LocalReport.SetParameters(param);



                this.reportViewer1.RefreshReport();
                funcionService = new FuncionService();
                llenarComboFunciones();
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                // Manejar la excepción, por ejemplo, mostrar un mensaje de error o registrarla.
                MessageBox.Show($"Error al obtener datos: {ex.Message}");
            }
        }

        private async void llenarComboFunciones()
        {
            List<Funciones> lst = await funcionService.Get();

            cboFuncionReporte.DataSource = lst;

            cboFuncionReporte.DisplayMember = "codigo"; 

            cboFuncionReporte.ValueMember = "codigo";

            cboFuncionReporte.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
