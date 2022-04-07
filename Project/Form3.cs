using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atestat
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1  form = new Form1();
            this.Hide();
            form.ShowDialog();
          
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
             this.Hide();
            form.ShowDialog();
            
        }
        

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
