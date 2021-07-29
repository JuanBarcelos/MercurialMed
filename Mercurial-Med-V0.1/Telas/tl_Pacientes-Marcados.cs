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

namespace Mercurial_Med_V0._1.Telas
{
    public partial class tl_Pacientes_Marcados : Form
    {
        DataTable dt = new DataTable();

        IFirebaseConfig Config = new FirebaseConfig
        {
            AuthSecret = "Njz3nIYAe3bprM5IbvuScjaEB1QMXLb1wDucsVDv",
            BasePath = "https://thunkable-kwnovx.firebaseio.com/"
        };
        IFirebaseClient client;
        public tl_Pacientes_Marcados()
        {
            InitializeComponent();
        }

        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            tl_Medico tl = new tl_Medico();
            tl.Show();
            Dispose();
        }

        private  void BtnVerificar_Click(object sender, EventArgs e)
        {
            #region Condição
            if (string.IsNullOrWhiteSpace(txtData.Text))
            {
                MessageBox.Show("Preencha todos os campos por favor");
                return;
            }
            #endregion
            export();
        }
      
        private async void export()
        {
            try
            {
                dt.Rows.Clear();
                int i = 0;
                FirebaseResponse response = await client.GetAsync(@"Tb_total-de-Consultas/Total");
                Chave_Primaria chave = response.ResultAs<Chave_Primaria>();
                int cnt = Convert.ToInt32(chave.ID);
                while (true)
                {
                    if (i == cnt)
                    {
                        break;
                    }
                    i++;
                    try
                    {
                        FirebaseResponse response1 = await client.GetAsync(@"TB_Consulta/" + i);
                        Marcar_Consulta consulta = response1.ResultAs<Marcar_Consulta>();
                        Marcar_Consulta consulta1 = new Marcar_Consulta
                        {
                            Data = txtData.Text

                        };
                        if (Marcar_Consulta.IsEqual(consulta, consulta1))
                        {
                            DataRow row = dt.NewRow();
                            row["Codigo da consulta"] = consulta.IDConsulta;
                            row["Nome do paciente"] = consulta.Nome;
                            row["Hora da consulta"] = consulta.Hora;
                            row["Data da Consulta"] = consulta.Data;
                            row["Tipo de consulta"] = consulta.Tipo_de_Consulta;
                            row["Tipo de Exame"] = consulta.Tipo_de_Exame;
                            row["Consulta"] = consulta.Consulta;
                            dt.Rows.Add(row);
                            MessageBox.Show("Estas são as suas consultas de hoje Doutor");
                        }
                    }
                    catch
                    {
                      
                    }
                }
              
            }
            catch
            {
                MessageBox.Show("Não possui consultas marcadas nesta data ");
            }
        }
        private void Tl_Pacientes_Marcados_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(Config);

            dt.Columns.Add("Codigo da consulta");
            dt.Columns.Add("Nome do paciente");
            dt.Columns.Add("Hora da consulta");
            dt.Columns.Add("Tipo de consulta");
            dt.Columns.Add("Tipo de exame");
            dt.Columns.Add("Consulta");
            dt.Columns.Add("Data da Consulta");
            dgvConsultas.DataSource = dt;

        }

        
    }
}
