﻿using ReportesCine.Entidades.Maestras;
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

namespace CineApi.ReportesCine
{
    public partial class Form1 : Form
    {
        private ReportePeliculaGananciaService funcionService;
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
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

        }

        private async void llenarComboFunciones()
        {
            List<ReportePeliculasGanancia> lst = await funcionService.GetReport();

            cboFuncionReporte.DataSource = lst;

            cboFuncionReporte.DisplayMember = "codigo"; 

            cboFuncionReporte.ValueMember = "codigo";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            llenarComboFunciones();
        }
    }
}
