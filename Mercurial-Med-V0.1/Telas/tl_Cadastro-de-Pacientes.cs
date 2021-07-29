using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Correios;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Mercurial_Med_V0._1.Classes;

namespace Mercurial_Med_V0._1.Telas
{
    public partial class Cad_Paciente : Form
    {
        IFirebaseConfig Config = new FirebaseConfig
        {
            AuthSecret = "Njz3nIYAe3bprM5IbvuScjaEB1QMXLb1wDucsVDv",
            BasePath = "https://thunkable-kwnovx.firebaseio.com/"
        };
        IFirebaseClient client;
        public Cad_Paciente()
        {
            InitializeComponent();
        }

        private void Tl_Cadastro_de_Pacientes_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(Config);
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao se conectar por favor verifique a sua internet");
            }


        }
        private void pbFoto_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbFoto.ImageLocation = openFileDialog1.FileName;
                pbFoto.Load();
            }
        }
        private void txtCPF_TextChanged(object sender, EventArgs e)
        {
            ValidarCPF cpf = new ValidarCPF();
            if (txtCPF.MaskFull)
            {
                if (cpf.verificar(txtCPF) == true)
                {
                    lblCPF.ForeColor = Color.Green;
                    lblCPF.Text = "CPF VALIDO";
                }
                else
                {
                    lblCPF.ForeColor = Color.Red;
                    lblCPF.Text = "CPF INVALIDO";
                }
            }
        }

        private void txtCEP_TextChanged(object sender, EventArgs e)
        {
            if (txtCEP.MaskFull)
            {
                try
                {
                    CorreiosApi correios = new CorreiosApi();
                    var verifica = correios.consultaCEP(txtCEP.Text);
                    if (verifica is null)
                    {
                        lblCEP.ForeColor = Color.Red;
                        lblCEP.Text = "CEP INVALIDO";
                        return;
                    }

                    lblCEP.ForeColor = Color.Green;
                    lblCEP.Text = "CEP VALIDO";
                    txtUf.Text = verifica.uf;
                    txtCidade.Text = verifica.cidade;
                    txtBairro.Text = verifica.bairro;
                    txtEndereco.Text = verifica.end;
                    txtComplemento.Text = verifica.complemento;
                }
                catch (Exception)
                {
                    lblCEP.ForeColor = Color.Red;
                    lblCEP.Text = "CEP INVALIDO";
                }
            }
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                var atualizar = new Pacientes
                {
                    ID = txtID.Text,
                    Nome = txtNome.Text,
                    Estado_Civil = txtEstadoCivil.Text,
                    Naturalidade = txtNaturalidade.Text,
                    Data_Nascimento = txtDataNascimento.Text,
                    Idade = txtIdade.Text,
                    Rg = txtRG.Text,
                    CPF = txtCPF.Text,
                    Sexo = txtSexo.Text,
                    Nome_do_Pai = txtNomeP.Text,
                    Nome_do_Mae = txtNomeM.Text,
                    Escolaridade = txtEcolaridade.Text,
                    Telefone_Residencial = txtTelResidencial.Text,
                    Telefone_Recado = txtTelRecado.Text,
                    Telefone_Celular = txtTelCelular.Text,
                    Email = txtEmail.Text,
                    CEP = txtCEP.Text,
                    Endereco = txtEndereco.Text,
                    Bairro = txtBairro.Text,
                    Numero = txtNumero.Text,
                    Cidade = txtCidade.Text,
                    UF = txtUf.Text,
                    Complemento = txtComplemento.Text,
                    Data_de_Cadastro = txtDataCadastro.Text,
                    Tipo_Sanguineo = txtTipoSangue.Text
                };

                FirebaseResponse response = await client.UpdateAsync(@"TB_Paciente/" + txtID.Text, atualizar);
                Pacientes pacientes = response.ResultAs<Pacientes>();
                MessageBox.Show("PAciente Atualizado: " + pacientes.ID);
            }
            catch
            {

                MessageBox.Show("Erro ao atualizar os dados deste Paciente");
            }
        }

        private async void button2_Click_1(object sender, EventArgs e)
        {
            CampoVazio campo = new CampoVazio();
            if (campo.vazio2(txtNome, txtEstadoCivil, txtNaturalidade, txtDataNascimento, txtIdade, txtRG, txtCPF, txtSexo, txtNomeP, txtNomeM, txtEcolaridade, txtTelResidencial, txtTelRecado,txtTelCelular, txtTipoSangue, txtEmail,txtCEP, txtNumero))
            {
                return;
            }
            try
            {

                MemoryStream ms = new MemoryStream();
                pbFoto.Image.Save(ms, ImageFormat.Jpeg);
                byte[] a = ms.GetBuffer();
                string output = Convert.ToBase64String(a);

                FirebaseResponse resp = await client.GetAsync("Tb_total-de-Pacientes/Total");
                Chave_Primaria chave = resp.ResultAs<Chave_Primaria>();
                var pacientes = new Pacientes
                {
                    ID = (Convert.ToInt32(chave.ID) + 1).ToString(),
                    Nome = txtNome.Text,
                    Estado_Civil = txtEstadoCivil.Text,
                    Naturalidade = txtNaturalidade.Text,
                    Data_Nascimento = txtDataNascimento.Text,
                    Idade = txtIdade.Text,
                    Rg = txtRG.Text,
                    CPF = txtCPF.Text,
                    Sexo = txtSexo.Text,
                    Nome_do_Pai = txtNomeP.Text,
                    Nome_do_Mae = txtNomeM.Text,
                    Escolaridade = txtEcolaridade.Text,
                    Telefone_Residencial = txtTelResidencial.Text,
                    Telefone_Recado = txtTelRecado.Text,
                    Telefone_Celular = txtTelCelular.Text,
                    Email = txtEmail.Text,
                    CEP = txtCEP.Text,
                    Endereco = txtEndereco.Text,
                    Bairro = txtBairro.Text,
                    Numero = txtNumero.Text,
                    Cidade = txtCidade.Text,
                    UF = txtUf.Text,
                    Complemento = txtComplemento.Text,
                    Data_de_Cadastro = txtDataCadastro.Text,
                    imagem = output,
                    Tipo_Sanguineo = txtTipoSangue.Text

                };
                SetResponse response = await client.SetAsync(@"TB_Paciente/" + pacientes.ID, pacientes);
                Pacientes result = response.ResultAs<Pacientes>();
                MessageBox.Show("PACIENTE CADASTRADO anote o Codigo do paciente:  " + result.ID);
                var obj = new Chave_Primaria
                {
                    ID = pacientes.ID
                };

                SetResponse response1 = await client.SetAsync("Tb_total-de-Pacientes/Total", obj);
            }
            catch
            {
                MessageBox.Show("Erro ao cadastrar o Paciente");
            }
        }

        private async void button5_Click_1(object sender, EventArgs e)
        {
            try
            {
                FirebaseResponse response = await client.GetAsync(@"TB_Paciente/" + txtID.Text);
                Pacientes pacientes = response.ResultAs<Pacientes>();

                byte[] b = Convert.FromBase64String(pacientes.imagem);
                MemoryStream ms = new MemoryStream();
                ms.Write(b, 0, Convert.ToInt32(b.Length));
                Bitmap bm = new Bitmap(ms, false);
                ms.Dispose();

                pbFoto.Image = bm;
                txtNome.Text = pacientes.Nome;
                txtEstadoCivil.Text = pacientes.Estado_Civil;
                txtNaturalidade.Text = pacientes.Naturalidade;
                txtDataNascimento.Text = pacientes.Data_Nascimento;
                txtIdade.Text = pacientes.Idade;
                txtRG.Text = pacientes.Rg;
                txtCPF.Text = pacientes.CPF;
                txtSexo.Text = pacientes.Sexo;
                txtNomeP.Text = pacientes.Nome_do_Pai;
                txtNomeM.Text = pacientes.Nome_do_Mae;
                txtEcolaridade.Text = pacientes.Escolaridade;
                txtTelResidencial.Text = pacientes.Telefone_Residencial;
                txtTelRecado.Text = pacientes.Telefone_Recado;
                txtTelCelular.Text = pacientes.Telefone_Celular;
                txtEmail.Text = pacientes.Email;
                txtCEP.Text = pacientes.CEP;
                txtEndereco.Text = pacientes.Endereco;
                txtBairro.Text = pacientes.Bairro;
                txtNumero.Text = pacientes.Bairro;
                txtUf.Text = pacientes.UF;
                txtCidade.Text = pacientes.Cidade;
                txtComplemento.Text = pacientes.Complemento;
                txtDataCadastro.Text = pacientes.Data_de_Cadastro;
                txtTipoSangue.Text = pacientes.Tipo_Sanguineo;
                MessageBox.Show("Pesquisa Realizada com Sucesso");
            }
            catch
            {
                MessageBox.Show("Esta Paciente não existe em nosso sistema");
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            tl_Menu tl = new tl_Menu();
            tl.Show();
            Dispose();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void pbFoto_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbFoto.ImageLocation = openFileDialog1.FileName;
                pbFoto.Load();
            }
        }

        private async void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                FirebaseResponse response = await client.DeleteAsync(@"TB_Paciente/" + txtID.Text);
                MessageBox.Show("Paciente Deletado");
            }
            catch
            {
                MessageBox.Show("Erro ao deletar estes dados ");
            }
        }

        private void txtCEP_TextChanged_1(object sender, EventArgs e)
        {
            if (txtCEP.MaskFull)
            {

                try
                {
                    CorreiosApi correios = new CorreiosApi();
                    var verifica = correios.consultaCEP(txtCEP.Text);
                    if (verifica is null)
                    {
                        lblCEP.ForeColor = Color.Red;
                        lblCEP.Text = "CEP INVALIDO";
                        return;
                    }

                    lblCEP.ForeColor = Color.Green;
                    lblCEP.Text = "CEP VALIDO";
                    txtUf.Text = verifica.uf;
                    txtCidade.Text = verifica.cidade;
                    txtBairro.Text = verifica.bairro;
                    txtEndereco.Text = verifica.end;
                    txtComplemento.Text = verifica.complemento;

                }
                catch (Exception)
                {
                    lblCEP.ForeColor = Color.Red;
                    lblCEP.Text = "CEP INVALIDO";
                }
            }
        }

        private void txtCPF_TextChanged_1(object sender, EventArgs e)
        {
            ValidarCPF cpf = new ValidarCPF();
            if (txtCPF.MaskFull)
            {
                if (cpf.verificar(txtCPF) == true)
                {
                    lblCPF.ForeColor = Color.Green;
                    lblCPF.Text = "CPF VALIDO";
                }
                else
                {
                    lblCPF.ForeColor = Color.Red;
                    lblCPF.Text = "CPF INVALIDO";
                }
            }
        }
    }
    
}
