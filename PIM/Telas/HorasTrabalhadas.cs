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
    public partial class HorasTrabalhadas : Form
    {
        CN_Horas objetoCN = new CN_Horas();
        private string idHoras = null;
        private bool Alterar = false;
        public HorasTrabalhadas()
        {
            InitializeComponent();
        }

        private void HorasTrabalhadas_Load(object sender, EventArgs e)
        {
            MostrarHoras();
        }
        private void MostrarHoras()
        {
            CN_Horas objeto = new CN_Horas();
            dataGridView1.DataSource = objeto.MostrarHora();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Alterar == false)
            {
                try
                {
                    objetoCN.InserirHoras(textBox1.Text, dateTimePicker1.Text, textBox3.Text, textBox4.Text);
                    MessageBox.Show("Inserção Correta");
                    MostrarHoras();
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
                    objetoCN.AlterarHoras(textBox1.Text, dateTimePicker1.Text, textBox3.Text, textBox4.Text, idHoras);
                    MessageBox.Show("Alteração Correta");
                    MostrarHoras();
                    Alterar = false;
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Não foi possivel alterar os dados" + ex);
                }
            }
            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Alterar = true;
                textBox1.Text = dataGridView1.CurrentRow.Cells["Funcionario"].Value.ToString();
                dateTimePicker1.Text = dataGridView1.CurrentRow.Cells["DataHorasTrabalhadas"].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells["HoraEntradaHorasTrabalhadas"].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells["HoraSaidaHorasTrabalhadas"].Value.ToString();

                idHoras = dataGridView1.CurrentRow.Cells["IdHorasTrabalhadas"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Selecione o horário que deseja alterar");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                idHoras = dataGridView1.CurrentRow.Cells["IdHorasTrabalhadas"].Value.ToString();
                objetoCN.DeletarHoras(idHoras);
                MessageBox.Show("Deletado");
                MostrarHoras();
            }
            else
                MessageBox.Show("Selecione o cargo que deseja deletar");
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;
            bs.Filter = "DataHorasTrabalhadas like '%" + textBox5.Text + "%'";
            dataGridView1.DataSource = bs.DataSource;
        }
    }
    }

