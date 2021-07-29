using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mercurial_Med_V0._1.Telas
{
    public partial class tl_Medico : Form
    {
        public tl_Medico()
        {
            InitializeComponent();
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja encerrar a aplicação ?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void LblSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja encerrar a aplicação ?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            tl_Menu tl = new tl_Menu();
            tl.Show();
            Dispose();
        }

        private void LblMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnPacientesMarcados_Click(object sender, EventArgs e)
        {
            tl_Pacientes_Marcados tl = new tl_Pacientes_Marcados();
            tl.Show();
            Dispose();
        }

        private void BtnReceitas_Click(object sender, EventArgs e)
        {
            tl_Receituario tl = new tl_Receituario();
            tl.Show();
            Dispose();
        }

        private void BtnRelatorioConsulta_Click(object sender, EventArgs e)
        {
            tl_Relatorio_de_Consulta tl = new tl_Relatorio_de_Consulta();
            tl.Show();
            Dispose();
        }
    }
}
