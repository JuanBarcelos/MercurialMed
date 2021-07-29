using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercurial_Med_V0._1.Classes
{
    class Marcar_Consulta
    {
        public String IDPaciente { get; set; }
        public String IDConsulta { get; set; }
        public String Nome { get; set; }
        public String Data { get; set; }
        public String Hora { get; set; }
        public String Tipo_de_Consulta { get; set; }
        public String Tipo_de_Exame { get; set; }
        public String Medico { get; set; }
        public String Consulta { get; set; }
        public String Tel_Celular { get; set; }
        public String Email { get; set; }
        public String Observacao { get; set; }

        private static String Error = "SEM CONSULTAS PARA ESTÁ DATA";
        public static void ShowErro()
        {
            System.Windows.Forms.MessageBox.Show(Error);
        }

        public static bool IsEqual(Marcar_Consulta cons1, Marcar_Consulta cons2)
        {
            if (cons1 == null || cons2 == null)
            {
                return false;
            }
            if (cons1.Data != cons2.Data)
            {
                
                return false;
            }
            else if (cons1.Data != cons2.Data)
            {
               
                return false;
            }
            return true;
        }
    }
}
