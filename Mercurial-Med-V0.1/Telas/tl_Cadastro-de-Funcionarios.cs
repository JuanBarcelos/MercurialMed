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
    public partial class tl_Cadastro_de_Funcionarios : Form
    {
        IFirebaseConfig Config = new FirebaseConfig
        {
            AuthSecret = "Njz3nIYAe3bprM5IbvuScjaEB1QMXLb1wDucsVDv",
            BasePath = "https://thunkable-kwnovx.firebaseio.com/"
        };
        IFirebaseClient client;
        public tl_Cadastro_de_Funcionarios()
        {
            InitializeComponent();
        }

        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            tl_Menu tl = new tl_Menu();
            tl.Show();
            Dispose();
        }

        private async void BtnSalvar_Click(object sender, EventArgs e)
        {
            #region CONDIÇÃO
            CampoVazio campo = new CampoVazio();
            if (campo.vazio1(txtNome, txtEstadoCivil, txtNaturalidade, txtDataNascimento, txtIdade, txtRG, txtCPF, txtSexo, txtNomeP, txtNomeM, txtEcolaridade, txtTelCelular, txtDataAD, txtCargo,
                txtFuncao, txtHora, txtSalario, txtUsuario, txtSenha, txtCEP, txtNumero))
            {
                return;
            }
            #endregion
            try
            {
                MemoryStream ms = new MemoryStream();
                pbFoto.Image.Save(ms, ImageFormat.Jpeg);
                byte[] a = ms.GetBuffer();
                string output = Convert.ToBase64String(a);

                FirebaseResponse resp = await client.GetAsync("Tb_total-de-Funcionario/Total");
                Chave_Primaria chave = resp.ResultAs<Chave_Primaria>();
                var Funcionario = new Funcionarios
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
                    Tipo_de_Admissao = txtTipoAD.Text,
                    Data_Admissao = txtDataAD.Text,
                    Cargo = txtCargo.Text,
                    Funcao = txtFuncao.Text,
                    Horario = txtHora.Text,
                    Salario = txtSalario.Text,
                    Usuario = txtUsuario.Text,
                    Senha = txtSenha.Text,
                    CEP = txtCEP.Text,
                    Endereco = txtEndereco.Text,
                    Bairro = txtBairro.Text,
                    Numero = txtNumero.Text,
                    Cidade = txtCidade.Text,
                    UF = txtUf.Text,
                    imagem = output,
                    Complemento = txtComplemento.Text

                };

                SetResponse response = await client.SetAsync(@"TB_Funcionario/" + Funcionario.ID, Funcionario);
                Funcionarios result = response.ResultAs<Funcionarios>();
                MessageBox.Show("FUNCIONÁRIO CADASTRADO anote o Codigo do Funcionario " + result.ID);
                var obj = new Chave_Primaria
                {
                    ID = Funcionario.ID
                };

                SetResponse response1 = await client.SetAsync("Tb_total-de-Funcionario/Total", obj);
            }
            catch
            {
                MessageBox.Show("Erro ao Cadastrar o Funcionário");
            }
        }

        private void Tl_Cadastro_de_Funcionarios_Load(object sender, EventArgs e)
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

        private async void BtnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                FirebaseResponse response = await client.GetAsync(@"TB_Funcionario/" + txtID.Text);
                Funcionarios Func = response.ResultAs<Funcionarios>();

                byte[] b = Convert.FromBase64String(Func.imagem);
                MemoryStream ms = new MemoryStream();
                ms.Write(b, 0, Convert.ToInt32(b.Length));
                Bitmap bm = new Bitmap(ms, false);
                ms.Dispose();

                pbFoto.Image = bm;
                txtNome.Text = Func.Nome;
                txtEstadoCivil.Text = Func.Estado_Civil;
                txtNaturalidade.Text = Func.Naturalidade;
                txtDataNascimento.Text = Func.Data_Nascimento;
                txtIdade.Text = Func.Idade;
                txtRG.Text = Func.Rg;
                txtCPF.Text = Func.CPF;
                txtSexo.Text = Func.Sexo;
                txtNomeP.Text = Func.Nome_do_Pai;
                txtNomeM.Text = Func.Nome_do_Mae;
                txtEcolaridade.Text = Func.Escolaridade;
                txtTelResidencial.Text = Func.Telefone_Residencial;
                txtTelRecado.Text = Func.Telefone_Recado;
                txtTelCelular.Text = Func.Telefone_Celular;
                txtTipoAD.Text = Func.Tipo_de_Admissao;
                txtDataAD.Text = Func.Data_Admissao;
                txtCargo.Text = Func.Cargo;
                txtFuncao.Text = Func.Funcao;
                txtHora.Text = Func.Horario;
                txtSalario.Text = Func.Salario;
                txtUsuario.Text = Func.Usuario;
                txtSenha.Text = Func.Senha;
                txtCEP.Text = Func.CEP;
                txtEndereco.Text = Func.Endereco;
                txtBairro.Text = Func.Bairro;
                txtNumero.Text = Func.Bairro;
                txtUf.Text = Func.UF;
                txtCidade.Text = Func.Cidade;
                txtComplemento.Text = Func.Complemento;
                MessageBox.Show("Pesquisa Realizada com Sucesso");
            }
            catch
            {
                MessageBox.Show("Esta Funcionario não existe em nosso sistema");
            }
        }

        private async void BtnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                var atualizar = new Funcionarios
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
                    Tipo_de_Admissao = txtTipoAD.Text,
                    Data_Admissao = txtDataAD.Text,
                    Cargo = txtCargo.Text,
                    Funcao = txtFuncao.Text,
                    Horario = txtHora.Text,
                    Salario = txtSalario.Text,
                    Usuario = txtUsuario.Text,
                    Senha = txtSenha.Text,
                    CEP = txtCEP.Text,
                    Endereco = txtEndereco.Text,
                    Bairro = txtBairro.Text,
                    Numero = txtNumero.Text,
                    Cidade = txtCidade.Text,
                    UF = txtUf.Text,
                    Complemento = txtComplemento.Text
                };

                FirebaseResponse response = await client.UpdateAsync(@"TB_Funcionario/" + txtID.Text, atualizar);
                Funcionarios funcionarios = response.ResultAs<Funcionarios>();
                MessageBox.Show("FUNCIONÁRIO ATUALIZADO " + funcionarios.ID);
            }
            catch 
            {
                MessageBox.Show("Erro ao atualizar este Funcionário");
            }
        }

        private async void BtnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                FirebaseResponse response = await client.DeleteAsync(@"TB_Funcionario/" + txtID.Text);
                MessageBox.Show("FUNCIONÁRIO DELETADO ");
            }
            catch 
            {
                MessageBox.Show("Não foi possivel deletar os dados deste Funcionário");
            }
        }
        //CODIGO DO COMBOX DE CARGOS PARA DEFINIR AS FUNÇÕES;
        private void txtCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            String valor = txtCargo.Text;
            if (valor == "Administrativo")
            {
                txtFuncao.Items.Clear();
                txtFuncao.Items.Add("Gerente");
                txtFuncao.Items.Add("SubGerente");
                txtFuncao.Items.Add("Técnico Administrativo");
                txtFuncao.Items.Add("Auxiliar Administrativo");
                txtFuncao.Items.Add("Atendente");
            }
            else if (valor == "Corpo de Medicos")
            {
                txtFuncao.Items.Clear();
                txtFuncao.Items.Add("Alergista/Imunologista");
                txtFuncao.Items.Add("Cardiologista");
                txtFuncao.Items.Add("Dermatologista");
                txtFuncao.Items.Add("Ginecologista e Obstetra");
                txtFuncao.Items.Add("Ortopedista");
                txtFuncao.Items.Add("Anestesista");
                txtFuncao.Items.Add("Pediatra");
                txtFuncao.Items.Add("Oftalmologista");
                txtFuncao.Items.Add("Psiquiatra");
                txtFuncao.Items.Add("Urologista");
            }
            else if (valor == "Serviços Gerais")
            {
                txtFuncao.Items.Clear();
                txtFuncao.Items.Add("Servente");
                txtFuncao.Items.Add("Auxiliar de Limpeza");

            }
        }

        private void pbFoto_MouseClick(object sender, MouseEventArgs e)
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
                catch (Exception )
                {
                    lblCEP.ForeColor = Color.Red;
                    lblCEP.Text = "CEP INVALIDO";
                }
            }
        }

    }
}
