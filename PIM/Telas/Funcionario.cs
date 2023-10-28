using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pim_FolhaPagamento.Negocio;

namespace Pim_FolhaPagamento.Telas
{

    public partial class Funcionario : Form
    {
        CN_Funcionario objetoCN = new CN_Funcionario();
        private string idFuncionario = null;
        private bool  Alterar = false;

        public Funcionario()
        {
            InitializeComponent();
        }

        private void Funcionario_Load(object sender, EventArgs e)
        {
          
            MostrarFuncionario();
        }

        private void MostrarFuncionario()
        {
            CN_Funcionario objeto = new CN_Funcionario();
            dataGridView1.DataSource = objeto.MostrarFunc();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (Alterar == false)
            {
                try
                {
                    objetoCN.InserirFuncionario(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text,
                        textBox9.Text, textBox10.Text);
                    MessageBox.Show("Inserção Correta");
                    MostrarFuncionario();
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
                    objetoCN.AlterarFuncionario(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text,
                        textBox9.Text, textBox10.Text,idFuncionario);
                    MessageBox.Show("Alteração Correta");
                    MostrarFuncionario();
                    Alterar = false;

                }
                catch (Exception ex){

                    MessageBox.Show("Não foi possivel alterar os dados" + ex);
                }
            }
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                Alterar = true;
                textBox1.Text = dataGridView1.CurrentRow.Cells["Cargo"].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells["Nome"].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells["CPF"].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells["DataNasc"].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells["Telefone"].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells["Email"].Value.ToString();
                textBox7.Text = dataGridView1.CurrentRow.Cells["DataAdmissao"].Value.ToString();
                textBox8.Text = dataGridView1.CurrentRow.Cells["Instituicao"].Value.ToString();
                textBox9.Text = dataGridView1.CurrentRow.Cells["Agencia"].Value.ToString();
                textBox10.Text = dataGridView1.CurrentRow.Cells["ContaCorrente"].Value.ToString();
                idFuncionario = dataGridView1.CurrentRow.Cells["IdFuncionario"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Selecione o funcionario que deseja alterar");
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idFuncionario = dataGridView1.CurrentRow.Cells["IdFuncionario"].Value.ToString();
                objetoCN.DeletarFuncionario(idFuncionario);
                MessageBox.Show("Deletado");
                MostrarFuncionario();
            }
            else
                MessageBox.Show("Selecione o funcionario que deseja deletar");

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;
            bs.Filter = "Nome like '%" + textBox11.Text + "%'";
            dataGridView1.DataSource = bs.DataSource;
        }
    }
}
