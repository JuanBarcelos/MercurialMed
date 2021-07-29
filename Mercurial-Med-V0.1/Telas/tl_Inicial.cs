using Mercurial_Med_V0._1.Telas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mercurial_Med_V0._1
{
    public partial class tl_Inicial : Form
    {
        public tl_Inicial()
        {
            InitializeComponent();
        }

        private void Tl_Inicial_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            pbCarregar.Increment(20);
            if (pbCarregar.Value == 100)
            {
                tl_Login tl = new tl_Login();
                tl.Show();
                timer1.Stop();
                this.Hide();
            };
        }

        private void Tl_Inicial_Load_1(object sender, EventArgs e)
        {

        }
    }
}
