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
    public partial class Cargo : Form
    {
        CN_Cargo objetoCN = new CN_Cargo();
        private string idCargo = null;
        private bool Alterar = false;
       


        public Cargo()
        {
            InitializeComponent();
        }

        

        private void  Cargo_Load(object sender, EventArgs e)
        {

            MostrarCargo();
        }

        private void MostrarCargo()
        {
            CN_Cargo objeto = new CN_Cargo();
            dataGridView1.DataSource = objeto.MostrarCarg();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Alterar == false)
            {
                try
                {
                    objetoCN.InserirCargo(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                    MessageBox.Show("Inserção Correta");
                    MostrarCargo();
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
                    objetoCN.AlterarCargo(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, idCargo);
                    MessageBox.Show("Alteração Correta");
                    MostrarCargo();
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
                textBox1.Text = dataGridView1.CurrentRow.Cells["NomeCargo"].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells["CargaHoraria"].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells["SalarioBase"].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells["INSS"].Value.ToString();
               
                idCargo = dataGridView1.CurrentRow.Cells["IdCargo"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Selecione o cargo que deseja alterar");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idCargo = dataGridView1.CurrentRow.Cells["IdCargo"].Value.ToString();
                objetoCN.DeletarCargo(idCargo);
                MessageBox.Show("Deletado");
                MostrarCargo();
            }
            else
                MessageBox.Show("Selecione o cargo que deseja deletar");
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;
            bs.Filter = "NomeCargo like '%" + textBox5.Text + "%'";
            dataGridView1.DataSource = bs.DataSource;
        }
    }
}
