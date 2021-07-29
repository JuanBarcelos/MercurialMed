using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mercurial_Med_V0._1.Classes
{
    class CampoVazio
    {
        public bool vazio(Control user,Control senha)
        {
            if(user.Text == string.Empty || senha.Text == string.Empty)
            {
                MessageBox.Show("Preencha os campos obrigatorios");
               



                return true;
            }
            else
            {
                return false;
            }
        }
        #region
        public bool vazio1(Control nome,Control EstadoCivil, Control Nacionalidade, Control DataNascimento, Control idade, Control rg,Control cpf, Control sexo, Control NomePai, Control NomeMae, Control escolaridade, Control TelCel,
            Control DataAdmissão,Control cargo, Control funcao, Control hr, Control salario, Control usario, Control senha, Control cep, Control N)
        {
            if (nome.Text == string.Empty || EstadoCivil.Text == string.Empty || Nacionalidade.Text == string.Empty || DataNascimento.Text == string.Empty || idade.Text == string.Empty || rg.Text == string.Empty || 
                cpf.Text == string.Empty || sexo.Text == string.Empty || NomePai.Text == string.Empty || NomeMae.Text == string.Empty || escolaridade.Text == string.Empty || TelCel.Text == string.Empty ||
                DataAdmissão.Text == string.Empty || cargo.Text == string.Empty || funcao.Text == string.Empty || hr.Text == string.Empty || salario.Text == string.Empty || usario.Text == string.Empty || senha.Text == string.Empty ||
                cep.Text == string.Empty || N.Text == string.Empty )
            {
                MessageBox.Show("Preencha os campos obrigatorios");
                return true;
           }
            else
            {
                return false;
            }
        }
        #endregion
        //                                                                                                                                                                                                                                 txtTipoSangue, txtEmail,txtCEP, txtNumero
        public bool vazio2(Control nome, Control EstadoCivil, Control naturalidade, Control DataNascimento, Control idade, Control rg, Control cpf, Control sexo, Control NomePai, Control NomeMae, Control escolaridade, Control TelCel,Control telRes, Control TelRec, Control Sangue, Control Email, Control cep, Control N)
        {
            if (nome.Text == string.Empty || EstadoCivil.Text == string.Empty || naturalidade.Text == string.Empty || DataNascimento.Text == string.Empty || idade.Text == string.Empty || rg.Text == string.Empty ||
                cpf.Text == string.Empty || sexo.Text == string.Empty || NomePai.Text == string.Empty || NomeMae.Text == string.Empty || escolaridade.Text == string.Empty || TelRec.Text == string.Empty || telRes.Text == string.Empty || TelCel.Text == string.Empty || Sangue.Text == string.Empty || Email.Text == string.Empty || cep.Text == string.Empty || N.Text == string.Empty)
            {
                MessageBox.Show("Preencha os campos obrigatorios");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
