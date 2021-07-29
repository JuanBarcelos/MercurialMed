using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mercurial_Med_V0._1.Classes
{
    class ValidarCPF
    {
        public bool verificar(Control validar)
        {
                if (validar.Text.Length == 14)
                {
                    int n1 = Convert.ToInt32(validar.Text.Substring(0, 1));
                    int n2 = Convert.ToInt32(validar.Text.Substring(1, 1));
                    int n3 = Convert.ToInt32(validar.Text.Substring(2, 1));
                    int n4 = Convert.ToInt32(validar.Text.Substring(4, 1));
                    int n5 = Convert.ToInt32(validar.Text.Substring(5, 1));
                    int n6 = Convert.ToInt32(validar.Text.Substring(6, 1));
                    int n7 = Convert.ToInt32(validar.Text.Substring(8, 1));
                    int n8 = Convert.ToInt32(validar.Text.Substring(9, 1));
                    int n9 = Convert.ToInt32(validar.Text.Substring(10, 1));
                    int n10 = Convert.ToInt32(validar.Text.Substring(12, 1));
                    int n11 = Convert.ToInt32(validar.Text.Substring(13, 1));
                    if (n1 == n2 && n2 == n3 && n3 == n4 && n4 == n5 && n5 == n6 && n6 == n7 && n7 == n8 && n8 == n9)
                    {
                        return false;
                    }
                    else
                    {
                        int Soma1 = n1 * 10 + n2 * 9 + n3 * 8 + n4 * 7 + n5 * 6 + n6 * 5 + n7 * 4 + n8 * 3 + n9 * 2;
                        int digitoVerificador1 = Soma1 % 11;

                        if (digitoVerificador1 < 2)
                        {
                            digitoVerificador1 = 0;
                        }
                        else
                        {
                            digitoVerificador1 = 11 - digitoVerificador1;
                        }
                        int Soma2 = n1 * 11 + n2 * 10 + n3 * 9 + n4 * 8 + n5 * 7 + n6 * 6 + n7 * 5 + n8 * 4 + n9 * 3 + digitoVerificador1 * 2;
                        int digitoverificador2 = Soma2 % 11;

                        if (digitoverificador2 < 2)
                        {
                            digitoverificador2 = 0;
                        }
                        else
                        {
                            digitoverificador2 = 11 - digitoverificador2;
                        }

                        if (digitoVerificador1 == n10 && digitoverificador2 == n11)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }

                }
                else
                {
                    return false;
                }



            
        }

    }
}
