using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Pim_FolhaPagamento.Telas;

namespace Pim_FolhaPagamento
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(panel1.Width == 250) {
                panel1.Width = 37;
            }
            else
            {
                panel1.Width = 250;
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);

        }

        private void AbrirFormInPanel(object FormEu)
        {
            if(this.panel3.Controls.Count > 0)
                this.panel3.Controls.RemoveAt(0);
            Form fh = FormEu as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panel3.Controls.Add(fh);
            this.panel3.Tag = fh;
            fh.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Funcionario());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Cargo());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new HorasTrabalhadas());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Ferias());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Pagamento());
        }

        

        private void label1_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Home());
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    }

