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
namespace WinFormsApp2
{
    public partial class Top_label : Form
    {
        Thread th;

        double PLU, min, star, b; 

        public Top_label()
        {
            InitializeComponent();
            top_label1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(opeg);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        public void opeg(object obj)
        {
            Application.Run(new Form1());

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            top_label1.Text += this.button1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            top_label1.Text += this.button2.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            top_label1.Text += this.button3.Text;
        }

        private void button4PLU_Click(object sender, EventArgs e)
        {
            PLU = Convert.ToDouble(top_label1.Text);
            top_label1.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            top_label1.Text += this.button5.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            top_label1.Text += this.button6.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            top_label1.Text += this.button7.Text;
        }

        private void button8MIN_Click(object sender, EventArgs e)
        {
            min = Convert.ToDouble(top_label1.Text);
            top_label1.Text = "";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            top_label1.Text += this.button9.Text;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            top_label1.Text += this.button10.Text;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            top_label1.Text += this.button11.Text;
        }

        private void button12STAR_Click(object sender, EventArgs e)
        {
            star = Convert.ToDouble(top_label1.Text);
            top_label1.Text = "";
        }

        private void button13AC_Click(object sender, EventArgs e)
        {
            top_label1.Text = "";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            top_label1.Text += this.button14.Text;
        }

        private void button15AAA_Click(object sender, EventArgs e)
        {
            top_label1.Text += this.button15AAA.Text;
        }

        private void button16ROVN_Click(object sender, EventArgs e)
        {
            if (PLU != 0);
            { 
                b = Convert.ToDouble(top_label1.Text);
                top_label1.Text = Convert.ToString(PLU + b);
            }
            if (min != 0);
            {
                b = Convert.ToDouble(top_label1.Text);
                top_label1.Text = Convert.ToString(min - b); 
            }
            if (star != 0);
            {
                b = Convert.ToDouble(top_label1.Text);
                top_label1.Text = Convert.ToString(star * b);
            }
        }   
    }
}
 
