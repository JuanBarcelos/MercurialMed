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
    public partial class tl_Menu : Form
    {
        public tl_Menu()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja encerrar a aplicação ?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnDeslogar_Click(object sender, EventArgs e)
        {
            tl_Login tl = new tl_Login();
            tl.Show();
            Dispose();
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja encerrar a aplicação ?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void BtnMedico_Click(object sender, EventArgs e)
        {
            tl_Medico tl = new tl_Medico();
            tl.Show();
            Dispose();
        }

        private void BtnConsulta_Click(object sender, EventArgs e)
        {
            tl_Marcar_Consulta tl = new tl_Marcar_Consulta();
            tl.Show();
            Dispose();

        }

        private void BtnPaciente_Click(object sender, EventArgs e)
        {
            Cad_Paciente tl = new Cad_Paciente();
            tl.Show();
            Dispose();
        }

        private void BtnFuncionario_Click(object sender, EventArgs e)
        {
            tl_Cadastro_de_Funcionarios tl = new tl_Cadastro_de_Funcionarios();
            tl.Show();
            Dispose();
        }

        private void LblSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja encerrar a aplicação ?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Label2_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
