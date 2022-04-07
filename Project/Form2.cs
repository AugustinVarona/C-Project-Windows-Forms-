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
    public partial class Form2 : Form
    {
        bool mergiStanga, mergiDreapta, sari, jocTerminat;
        
        int vitezaSaritura;
        int forta;
        int score = 0;
        int vitezaJucator = 7;

        int vitezaOrizontala = 5;
        int vitezaVerticala = 4;

        int vitezaInamic1 = 5;
        int vitezaInamic2 = 3;
        
        public Form2()
        {
            InitializeComponent();
        }

        private void JocPrincipalTimp(object sender, EventArgs e)
        {
            scor.Text = "Scor:" + score;
            jucator.Top += vitezaSaritura;
            if(mergiStanga == true)
            {
                jucator.Left -= vitezaJucator;
            }
            if(mergiDreapta == true)
            {
                jucator.Left += vitezaJucator;
            }
            if(sari == true && forta <0)
            {
                sari = false;
            }
            if(sari == true)
            {
                vitezaSaritura = -10;
                forta -= 1;
            }
            else
            {
                vitezaSaritura = 10;
            }
            foreach(Control x in this.Controls)
            {
                if(x is PictureBox)
                {
                    if((string)x.Tag == "platforma")
                    {
                        if(jucator.Bounds.IntersectsWith(x.Bounds))
                        {
                            forta = 8;
                            jucator.Top = x.Top - jucator.Height;
                            if((string)x.Name =="platformaorizontala" && mergiStanga == false || (string)x.Name == "platformaorizontala" && mergiDreapta == false)
                            {
                                jucator.Left -= vitezaOrizontala;
                            }
                        }
                        x.BringToFront();
                    }
                    if((string)x.Tag == "banut")
                    {
                        if(jucator.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                        {
                            x.Visible = false;
                            score++;
                        }
                    }
                    if((string)x.Tag == "inamic")
                    {
                        if(jucator.Bounds.IntersectsWith(x.Bounds))
                        {
                            timpuljocului.Stop();
                            jocTerminat = true;
                            scor.Text = "Scor: " + score + Environment.NewLine + "Ai fost ucis in calatoria ta!";
                        }
                    }
                }
            }
            platformaorizontala.Left -= vitezaOrizontala;
            if(platformaorizontala.Left < 0 || platformaorizontala.Left + platformaorizontala.Width > this.ClientSize.Width)
            {
                vitezaOrizontala = -vitezaOrizontala;
            }
            platformaverticala.Top += vitezaVerticala;
            if(platformaverticala.Top < 190 || platformaverticala.Top > 600)
            {
                vitezaVerticala = -vitezaVerticala;
            }
            inamic1.Left -= vitezaInamic1;
            if(inamic1.Left < pictureBox6.Left || inamic1.Left + inamic1.Width > pictureBox6.Left + pictureBox6.Width)
            {
                vitezaInamic1 = -vitezaInamic1;
            }
            inamic2.Left += vitezaInamic2;
            if(inamic2.Left < pictureBox2.Left || inamic2.Left + inamic2.Width > pictureBox2.Left + pictureBox2.Width )
            {
                vitezaInamic2 = -vitezaInamic2;
            }
            if(jucator.Top + jucator.Height > this.ClientSize.Height + 50)
            {
                timpuljocului.Stop();
                jocTerminat = true;
                scor.Text = "Scor: " + score + Environment.NewLine + "Ai cazut!";
            }
            if(jucator.Bounds.IntersectsWith(usa.Bounds) && score == 37)
            {
                timpuljocului.Stop();
                jocTerminat = true;
                scor.Text = "Scor: " + score + Environment.NewLine + "Ai colectat toti banutii!";
            }
            
            
        }

        private void jocNouToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sari = false;
            mergiStanga = false;
            mergiDreapta = false;
            jocTerminat = false;
            score = 0;
            scor.Text = "Scor:" + score;
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Visible == false)
                {
                    x.Visible = true;
                }
            }

            jucator.Left = 72;
            jucator.Top = 656;

            inamic1.Left = 422;
            inamic2.Left = 280;

            platformaorizontala.Left = 221;
            platformaverticala.Top = 599;

            timpuljocului.Start();
        }

        private void meniuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            this.Hide();
            form.ShowDialog(); 
        }

        private void ieșireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void tastaJos(object sender, KeyEventArgs e)
        {
           if(e.KeyCode == Keys.Left)
            {
                mergiStanga = true;
            }
            if(e.KeyCode == Keys.Right)
            {
                mergiDreapta = true;
            }
            if(e.KeyCode == Keys.Space && sari == false)
            {
                sari = true;
            }
        }

        private void tastaSus(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                mergiStanga = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                mergiDreapta = false;
            }
            if(sari == true)
            {
                sari = false;
            }
            if(e.KeyCode == Keys.Enter && jocTerminat == true)
            {
                restart();
            }
        }

        private void restart()
        {
            sari = false;
            mergiStanga = false;
            mergiDreapta = false;
            jocTerminat = false;
            score = 0;
            scor.Text = "Scor:" + score;
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Visible == false)
                {
                    x.Visible = true;
                }
            }

            jucator.Left = 72;
            jucator.Top = 656;

            inamic1.Left = 422;
            inamic2.Left = 280;

            platformaorizontala.Left = 221;
            platformaverticala.Top = 599;

            timpuljocului.Start();

        }
    }
}
