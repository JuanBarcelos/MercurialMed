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
using System.Windows.Media;

namespace Mercurial_Med_V0._1.Telas
{
    public partial class tl_Login : Form
    {
        IFirebaseConfig Config = new FirebaseConfig
        {
            AuthSecret = "Njz3nIYAe3bprM5IbvuScjaEB1QMXLb1wDucsVDv",
            BasePath = "https://thunkable-kwnovx.firebaseio.com/"
        };
        IFirebaseClient client;
        public tl_Login()
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

        private void LblMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private  void BtnLogar_Click(object sender, EventArgs e)
        {
           
            logar();
        }

        private async void logar()
        {
           try
            {
                try
                {
                    #region Condição
                    CampoVazio campo = new CampoVazio();
                    if (campo.vazio(txtUsuario, txtSenha))
                    {

                        return;
                    }

                    #endregion
                    int i = 0;
                    FirebaseResponse response = await client.GetAsync(@"Tb_total-de-Funcionario/Total");
                    Chave_Primaria chave = response.ResultAs<Chave_Primaria>();
                    int cnt = Convert.ToInt32(chave.ID);
                    while (true)
                    {
                        if (i == cnt)
                        {
                            break;
                        }
                        i++;
                        FirebaseResponse response1 = await client.GetAsync(@"TB_Funcionario/" + i);
                        Funcionarios funcionarios = response1.ResultAs<Funcionarios>();
                        Funcionarios funcionarios1 = new Funcionarios
                        {
                            Usuario = txtUsuario.Text,
                            Senha = txtSenha.Text
                        };
                        if (Funcionarios.IsEqual(funcionarios, funcionarios1))
                        {
                            tl_Menu tl = new tl_Menu();
                            tl.Show();
                            Dispose();
                            MessageBox.Show("Bem Vindo ao Mercurial-Med");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message); 
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Senha ou Usuario Invalidos");

            }
           
            
           
        }
        private void Tl_Login_Load(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("conectado");
                client = new FireSharp.FirebaseClient(Config);
               
            }
            catch (Exception)
            { 
                MessageBox.Show("Erro ao conctar porfavor verifique a sua internet");
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
