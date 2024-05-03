using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Security.Cryptography.X509Certificates;
using static System.Windows.Forms.DataFormats;
namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        Thread th;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(open);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        public void open(object obj)
        {
            Application.Run(new Form2());
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(opeg);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        public void opeg(object obj)
        {
            Application.Run(new Form2());
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(oped);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        public void oped(object obj)
        {
            Application.Run(new Form4());
        }
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(oper);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        public void oper(object obj)
        {
            Application.Run(new Form5());
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(opeu);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        public void opeu(object obj)
        {
            Application.Run(new Form6());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(operr);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        public void operr(object obj)
        {
            Application.Run(new Form7());
        }

        private void ־עקועû_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(operrt);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        public void operrt(object obj)
        {
            Application.Run(new Form8());
        }

        private void ֿמלמשü_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(operrti);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        public void operrti(object obj)
        {
            Application.Run(new Top_label());
        }
    }    
}
