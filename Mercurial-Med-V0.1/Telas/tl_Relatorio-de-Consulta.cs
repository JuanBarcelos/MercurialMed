using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Interfaces;
using FireSharp.Response;
using FireSharp.Config;
using Mercurial_Med_V0._1.Classes;

namespace Mercurial_Med_V0._1.Telas
{
    public partial class tl_Relatorio_de_Consulta : Form
    {
        IFirebaseConfig Config = new FirebaseConfig
        {
            AuthSecret = "Njz3nIYAe3bprM5IbvuScjaEB1QMXLb1wDucsVDv",
            BasePath = "https://thunkable-kwnovx.firebaseio.com/"
        };
        IFirebaseClient client;
        public tl_Relatorio_de_Consulta()
        {
            InitializeComponent();

        }
        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            tl_Medico tl = new tl_Medico();
            tl.Show();
            Dispose();
        }

        private void Tl_Relatorio_de_Consulta_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(Config);

        }

        String IdP;
        String dt;
        String hr;
        String tc;
        String te;
        String med;
        String cons;
        String email;
        String tel;

        private async void BtnPesquisarConsulta_Click(object sender, EventArgs e)
        {

            try
            {
                FirebaseResponse response = await client.GetAsync(@"TB_Consulta/" + txtIDConsulta.Text);
                Marcar_Consulta consulta = response.ResultAs<Marcar_Consulta>();
                txtNome.Text = consulta.Nome;
                txtRelatorio.Text = consulta.Observacao;
                IdP = consulta.IDPaciente;
                dt = consulta.Data;
                hr = consulta.Hora;
                tc = consulta.Tipo_de_Consulta;
                te = consulta.Tipo_de_Exame;
                med = consulta.Medico;
                cons = consulta.Consulta;
                email = consulta.Email;
                tel = consulta.Tipo_de_Consulta;
                MessageBox.Show("Pesquisa Realizada com Sucesso");
            }
            catch
            {
                MessageBox.Show("Esta consulta não existe em nosso sistema");
            }

        }

        private async void btnRelatorio_Click(object sender, EventArgs e)
        {

            try
            {
                var Relatorio = new Marcar_Consulta { 
                IDPaciente = IdP,
                IDConsulta = txtIDConsulta.Text,
                    Nome = txtNome.Text,
                    Data = dt,
                    Hora = hr,
                    Tipo_de_Consulta = tc,
                    Tipo_de_Exame = te,
                    Medico = med,
                    Consulta = cons,
                    Tel_Celular = tel,
                    Email = email,
                    Observacao = txtRelatorio.Text
                };
                FirebaseResponse response = await client.UpdateAsync(@"TB_Consulta/" + txtIDConsulta.Text,Relatorio);
                Marcar_Consulta _Consulta = response.ResultAs<Marcar_Consulta>();
                MessageBox.Show("Relatorio Salvo com sucesso");
            }
            catch
            {
                MessageBox.Show("Erro ao Salvar o Relatorio");
            }
           

        }
    }
}
