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
using WinFormsApp2;
namespace WinFormsApp2
{
    public partial class Form3 : Form
    {
        Thread th;
        public Form3()
        {
            InitializeComponent();
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

    }     
    
}

