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
using FireSharp.Interfaces;
using FireSharp.Response;
using Mercurial_Med_V0._1.Classes;


namespace Mercurial_Med_V0._1.Telas
{
    public partial class tl_Marcar_Consulta : Form
    {
        IFirebaseConfig Config = new FirebaseConfig
        {
            AuthSecret = "Njz3nIYAe3bprM5IbvuScjaEB1QMXLb1wDucsVDv",
            BasePath = "https://thunkable-kwnovx.firebaseio.com/"
        };
        IFirebaseClient client;
        public tl_Marcar_Consulta()
        {
            InitializeComponent();
        }

        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            tl_Menu tl = new tl_Menu();
            tl.Show();
            Dispose();
        }

        private void Tl_Marcar_Consulta_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(Config);
            }
            catch
            {
                MessageBox.Show("Erro ao conectar por favor verifique a sua internet");
            }
        }

        private async void BtnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                FirebaseResponse response = await client.GetAsync("Tb_total-de-Consultas/Total");
                Chave_Primaria chave = response.ResultAs<Chave_Primaria>();
                var consulta = new Marcar_Consulta
                {
                    IDConsulta = (Convert.ToInt32(chave.ID) + 1).ToString(),
                    Nome = txtNome.Text,
                    Data = txtData.Text,
                    Hora = txtHora.Text,
                    Tipo_de_Consulta = txtTpConsulta.Text,
                    Tipo_de_Exame = txtTpExame.Text,
                    Medico = txtMedico.Text,
                    Consulta = txtConsulta.Text,
                    Tel_Celular = txtTelCelular.Text,
                    Email = txtEmail.Text,
                    Observacao = txtObservação.Text
                };
                SetResponse response1 = await client.SetAsync(@"TB_Consulta/" + consulta.IDConsulta, consulta);
                Marcar_Consulta marcar = response1.ResultAs<Marcar_Consulta>();
                MessageBox.Show("CONSULTA MARCADA COM SUCESO, ANOTE O CODIGO DA SUA CONSULTA PARA VERIFICAÇÃO MAIS TARDE: " + marcar.IDConsulta);
                var obj = new Chave_Primaria
                {
                    ID = consulta.IDConsulta
                };
                SetResponse response2 = await client.SetAsync("Tb_total-de-Consultas/Total", obj);
            }
            catch
            {
                MessageBox.Show("Erro ao salvar a nova consulta");
            }
        }

        private async void BtnPesquisarConsulta_Click(object sender, EventArgs e)
        {
            try
            {
                FirebaseResponse response = await client.GetAsync(@"TB_Consulta/" + txtIDConsulta.Text);
                Marcar_Consulta consulta = response.ResultAs<Marcar_Consulta>();
                txtNome.Text = consulta.Nome;
                txtData.Text = consulta.Data;
                txtHora.Text = consulta.Hora;
                txtMedico.Text = consulta.Medico;
                txtTpConsulta.Text = consulta.Tipo_de_Consulta;
                txtTpExame.Text = consulta.Tipo_de_Exame;
                txtConsulta.Text = consulta.Consulta;
                txtTelCelular.Text = consulta.Tel_Celular;
                txtEmail.Text = consulta.Email;
                txtObservação.Text = consulta.Observacao;
                MessageBox.Show("Pesquisa Realizada com Sucesso");
            }
            catch
            {
                MessageBox.Show("Esta consulta não foi encontrada no nosso sistema");
            }
        }

        private async void BtnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                FirebaseResponse response = await client.GetAsync(@"TB_Paciente/" + txtIDPaciente.Text);
                Pacientes pacientes = response.ResultAs<Pacientes>();
                txtNome.Text = pacientes.Nome;
                txtTelCelular.Text = pacientes.Telefone_Celular;
                txtEmail.Text = pacientes.Email;
                MessageBox.Show("Pesquisa Realizada com Sucesso");
            }
            catch
            {
                MessageBox.Show("Este Paciente não foi encontrada no nosso sistema");
            }
        }

        private async void BtnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                var atualizar = new Marcar_Consulta
                {
                    IDConsulta = txtIDConsulta.Text,
                    IDPaciente = txtIDPaciente.Text,
                    Nome = txtNome.Text,
                    Data = txtData.Text,
                    Hora = txtHora.Text,
                    Tipo_de_Consulta = txtTpConsulta.Text,
                    Tipo_de_Exame = txtTpExame.Text,
                    Medico = txtMedico.Text,
                    Consulta = txtConsulta.Text,
                    Tel_Celular = txtTelCelular.Text,
                    Email = txtEmail.Text,
                    Observacao = txtObservação.Text
                };
                FirebaseResponse response = await client.UpdateAsync(@"TB_Consulta/" + txtIDConsulta.Text, atualizar);
                Marcar_Consulta consulta = response.ResultAs<Marcar_Consulta>();
                MessageBox.Show("CONSULTA ATUALIZADA! NUMERO DA CONSULTA: " + consulta.IDConsulta);
            }
            catch
            {
                MessageBox.Show("Erro ao atualizar a consulta");
            }
        }

        private async void BtnDeletar_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = await client.DeleteAsync(@"TB_Consulta/" + txtIDConsulta.Text);
            MessageBox.Show("CONSULTA CANCELADA COM SUCESSO");
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txtMedico_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
