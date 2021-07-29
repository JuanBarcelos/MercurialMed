using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mercurial_Med_V0._1.Telas;

namespace Mercurial_Med_V0._1.Telas
{
    public partial class tl_Imprimir : Form
    {
        public tl_Imprimir(string nome, string data, string hora, string receita)
        {
            InitializeComponent();
            //tratando os dados do report view
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportEmbeddedResource = "Mercurial_Med_V0._1.Relatorios.Receita.rdlc";
            Microsoft.Reporting.WinForms.ReportParameter[] p = new
                Microsoft.Reporting.WinForms.ReportParameter[4];
            p[0] = new Microsoft.Reporting.WinForms.ReportParameter("Nome", nome);
            p[1] = new Microsoft.Reporting.WinForms.ReportParameter("Data", data);
            p[2] = new Microsoft.Reporting.WinForms.ReportParameter("Hora", hora);
            p[3] = new Microsoft.Reporting.WinForms.ReportParameter("Receita", receita);
            reportViewer1.LocalReport.SetParameters(p);
            reportViewer1.LocalReport.Refresh();
            reportViewer1.RefreshReport();

        }

        private void tl_Imprimir_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            tl_Receituario tl = new tl_Receituario();
            tl.Show();
            Dispose();
        }
    }
}
