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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Pim_FolhaPagamento.Telas
{
    public partial class Pagamento : Form
    {
        CN_Pagamento objetoCN = new CN_Pagamento();
        private string idPag = null;
        private bool Alterar = false;

        public Pagamento()
        {
            InitializeComponent();
        }

        private void Pagamento_Load(object sender, EventArgs e)
        {
            MostrarPagamento();
        }
        private void MostrarPagamento()
        {
            CN_Pagamento objeto = new CN_Pagamento();
            dataGridView1.DataSource = objeto.MostrarPag();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Alterar == false)
            {
                try
                {
                    objetoCN.InserirPagamento(textBox1.Text, dateTimePicker1.Text, textBox2.Text);
                    MessageBox.Show("Inserção Correta");
                    MostrarPagamento();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possivel inserir os dados" + ex);
                }
            }
            if (Alterar == true)
            {
                try
                {
                    objetoCN.AlterarPagamento(textBox1.Text, dateTimePicker1.Text, textBox2.Text, idPag);
                    MessageBox.Show("Alteração Correta");
                    MostrarPagamento();
                    Alterar = false;
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Não foi possivel alterar os dados" + ex);
                }
                textBox1.Clear();
                textBox2.Clear();
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Alterar = true;
                textBox1.Text = dataGridView1.CurrentRow.Cells["Funcionario"].Value.ToString();
                dateTimePicker1.Text = dataGridView1.CurrentRow.Cells["DataPagamento"].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells["ValorPago"].Value.ToString();
               

                idPag = dataGridView1.CurrentRow.Cells["IdPagamento"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Selecione o Pagamento que deseja alterar");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idPag = dataGridView1.CurrentRow.Cells["IdPagamento"].Value.ToString();
                objetoCN.DeletarPagamento(idPag);
                MessageBox.Show("Deletado");
                MostrarPagamento();
            }
            else
                MessageBox.Show("Selecione o cargo que deseja deletar");
        }
    }
}
