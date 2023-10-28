using Pim_FolhaPagamento.Dados;
using Pim_FolhaPagamento.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pim_FolhaPagamento.Telas
{
    public partial class Ferias : Form
    {
        CN_Ferias objetoCN = new CN_Ferias();
        private string idFerias = null;
        private bool Alterar = false;

        public Ferias()
        {
            InitializeComponent();
        }

        private void Ferias_Load(object sender, EventArgs e)
        {
            MostrarFerias();
        }
        private void MostrarFerias()
        {
            CN_Ferias objeto = new CN_Ferias();
            dataGridView1.DataSource = objeto.MostrarFeri();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (Alterar == true)
            {
                try
                {
                    objetoCN.AlterarFerias(comboBox1.Text, idFerias);
                    MessageBox.Show("Alteração Correta");
                    MostrarFerias();
                    Alterar = false;
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Não foi possivel alterar os dados" + ex);
                }
            }
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Alterar = true;
                textBox1.Text = dataGridView1.CurrentRow.Cells["Funcionario"].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells["DataInicioFerias"].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells["DataFimFerias"].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells["ValorFerias"].Value.ToString();
                comboBox1.Text = dataGridView1.CurrentRow.Cells["Status"].Value.ToString();
                

                idFerias = dataGridView1.CurrentRow.Cells["IdFerias"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Selecione a solicitação");
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;
            bs.Filter = "Status like '%" + textBox5.Text + "%'";
            dataGridView1.DataSource = bs.DataSource;
        }
    }
}
