using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mercurial_Med_V0._1.Classes
{
    class Funcionarios
    {
        public String ID { get; set; }
        public String Nome { get; set; }
        public String Estado_Civil { get; set; }
        public String Naturalidade { get; set; }
        public String Data_Nascimento { get; set; }
        public String Idade { get; set; }
        public String Rg { get; set; }
        public String CPF { get; set; }
        public String Sexo { get; set; }
        public String Nome_do_Pai { get; set; }
        public String Nome_do_Mae { get; set; }
        public String Escolaridade { get; set; }
        public String Telefone_Residencial { get; set; }
        public String Telefone_Recado { get; set; }
        public String Telefone_Celular { get; set; }
        public String Tipo_de_Admissao { get; set; }
        public String Data_Admissao { get; set; }
        public String Cargo { get; set; }
        public String Funcao { get; set; }
        public String Horario { get; set; }
        public String Salario { get; set; }
        public String Usuario { get; set; }
        public String Senha { get; set; }
        public String CEP { get; set; }
        public String Endereco { get; set; }
        public String Bairro { get; set; }
        public String Numero { get; set; }
        public String Cidade { get; set; }
        public String UF { get; set; }
        public String Complemento { get; set; }
        public String imagem { get; set; }

        private static String Error = "Usuário ou Senha não exixte ";
        public static void ShowErro()
        {
            MessageBox.Show(Error);
        }
        public static bool IsEqual(Funcionarios func1, Funcionarios func2)
        {
            if(func1 == null || func2 == null)
            {
                return false;
            }
            if (func1.Usuario != func2.Usuario)
            {
                Error = "Usuario ou Senha invalidos ou não existe";
                return false;
            }
            else if(func1.Senha != func2.Senha)
            {
                Error = "Senha invalida ou não existe";
                return false;
            }
            return true;
        }


      
    }

   


}
