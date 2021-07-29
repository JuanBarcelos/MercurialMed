using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
using Mercurial_Med_V0._1.Classes;
using Mercurial_Med_V0._1.Telas;

namespace Mercurial_Med_V0._1.Telas
{
    public partial class tl_Receituario : Form
    {
        public tl_Receituario()
        {
            InitializeComponent();
        }

        IFirebaseConfig Config = new FirebaseConfig
        {
            AuthSecret = "CJANfTZXV9kOpL7XONkRjBUgaBLS4pvL8sRu8hI2",
            BasePath = "https://mercurial-med.firebaseio.com/"
        };
        IFirebaseClient client;

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
            lblData.Text = DateTime.Now.ToLongDateString();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            tl_Medico tl = new tl_Medico();
            tl.Show();
            Dispose();
        }

       

        private void tl_Receituario_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(Config);
            }
            catch
            {
                MessageBox.Show("Erro ao se conectar por favor verifique a sua internet");
            }
        }

       

        private async void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                FirebaseResponse response = await client.GetAsync(@"TB_Paciente/" + txtID.Text);
                Pacientes pacientes = response.ResultAs<Pacientes>();
                txtNome.Text = pacientes.Nome;
                MessageBox.Show("Pesquisa Realizada com Sucesso");
            }
            catch
            {
                MessageBox.Show("Esta Paciente não existe em nosso sistema");
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            tl_Imprimir tl = new tl_Imprimir(txtNome.Text, lblData.Text, lblHora.Text, txtReceita.Text);
            tl.Show();
            Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tl_Menu tl = new tl_Menu();
            tl.Show();
            Dispose();
        }
    }
}
