using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atestat
{
    public partial class Form1 : Form
    {
        bool turn = true; //true = X; false = 0
        bool computer = false;
        int turn_count = 0;
        
        public Form1()
        {
            InitializeComponent();
        }
        
        private void despreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By Augustin");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            if ((p1.Text == "Player 1") || (p2.Text == "Player 2"))
            {
                MessageBox.Show("Trebuie să specifici numele jucătorilor înainte de a începe jocul!\nTasteaza Computer (pentru Player 2) pentru a juca împotriva calculatorului.");
            }
            else
            {
                Button b = (Button)sender;
                if (turn)
                    b.Text = "X";
                else
                    b.Text = "0";
                turn = !turn;
                b.Enabled = false;
                turn_count++;
                label2.Focus();
                verificareCastigator();
            }

            if((!turn) && (computer))
            {
                computer_miscare();
            }
        }

        private void computer_miscare()
        {
            Button move = null;
            move = castig_sau_blocare("0");
            if(move == null)
            {
                move = castig_sau_blocare("X");
                if(move == null)
                {
                    move = colturi();
                    if(move == null)
                    {
                        move = loc_liber();
                    }
                }
            }
            move.PerformClick();
        }

        private Button castig_sau_blocare(string mark)
        {
            Console.WriteLine("Ma uit dupa castig sau blocare: " + mark);
            //TESTE PE ORIZONTALA
            if ((A1.Text == mark) && (A2.Text == mark) && (A3.Text == ""))
                return A3;
            if ((A2.Text == mark) && (A3.Text == mark) && (A1.Text == ""))
                return A1;
            if ((A1.Text == mark) && (A3.Text == mark) && (A2.Text == ""))
                return A2;

            if ((B1.Text == mark) && (B2.Text == mark) && (B3.Text == ""))
                return B3;
            if ((B2.Text == mark) && (B3.Text == mark) && (B1.Text == ""))
                return B1;
            if ((B1.Text == mark) && (B3.Text == mark) && (B2.Text == ""))
                return B2;

            if ((C1.Text == mark) && (C2.Text == mark) && (C3.Text == ""))
                return C3;
            if ((C2.Text == mark) && (C3.Text == mark) && (C1.Text == ""))
                return C1;
            if ((C1.Text == mark) && (C3.Text == mark) && (C2.Text == ""))
                return C2;

            //TESTE PE VERTICALA
            if ((A1.Text == mark) && (B1.Text == mark) && (C1.Text == ""))
                return C1;
            if ((B1.Text == mark) && (C1.Text == mark) && (A1.Text == ""))
                return A1;
            if ((A1.Text == mark) && (C1.Text == mark) && (B1.Text == ""))
                return B1;

            if ((A2.Text == mark) && (B2.Text == mark) && (C2.Text == ""))
                return C2;
            if ((B2.Text == mark) && (C2.Text == mark) && (A2.Text == ""))
                return A2;
            if ((A2.Text == mark) && (C2.Text == mark) && (B2.Text == ""))
                return B2;

            if ((A3.Text == mark) && (B3.Text == mark) && (C3.Text == ""))
                return C3;
            if ((B3.Text == mark) && (C3.Text == mark) && (A3.Text == ""))
                return A3;
            if ((A3.Text == mark) && (C3.Text == mark) && (B3.Text == ""))
                return B3;

            //TESTE PE DIAGONALA
            if ((A1.Text == mark) && (B2.Text == mark) && (C3.Text == ""))
                return C3;
            if ((B2.Text == mark) && (C3.Text == mark) && (A1.Text == ""))
                return A1;
            if ((A1.Text == mark) && (C3.Text == mark) && (B2.Text == ""))
                return B2;

            if ((A3.Text == mark) && (B2.Text == mark) && (C1.Text == ""))
                return C1;
            if ((B2.Text == mark) && (C1.Text == mark) && (A3.Text == ""))
                return A3;
            if ((A3.Text == mark) && (C1.Text == mark) && (B2.Text == ""))
                return B2;

            return null;
        }

        private Button colturi()
        {
            Console.WriteLine("Ma uit dupa colturi libere.");
            if (A1.Text == "0")
            {
                if (A3.Text == "")
                    return A3;
                if (C3.Text == "")
                    return C3;
                if (C1.Text == "")
                    return C1;
            }

            if (A3.Text == "0")
            {
                if (A1.Text == "")
                    return A1;
                if (C3.Text == "")
                    return C3;
                if (C1.Text == "")
                    return C1;
            }

            if (C3.Text == "0")
            {
                if (A1.Text == "")
                    return A3;
                if (A3.Text == "")
                    return A3;
                if (C1.Text == "")
                    return C1;
            }

            if (C1.Text == "0")
            {
                if (A1.Text == "")
                    return A3;
                if (A3.Text == "")
                    return A3;
                if (C3.Text == "")
                    return C3;
            }

            if (A1.Text == "")
                return A1;
            if (A3.Text == "")
                return A3;
            if (C1.Text == "")
                return C1;
            if (C3.Text == "")
                return C3;

            return null;
        }

        private Button loc_liber()
        {
            Console.WriteLine("Ma uit dupa spatiu liber.");
            Button b = null;
            foreach (Control c in Controls)
            {
                b = c as Button;
                if(b != null)
                {
                    if (b.Text == "")
                        return b;
                }
            }
            return null;
        }

        private void verificareCastigator()
        {
            bool castigator = false;

            //ORIZONTALA
            if((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                    castigator = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                    castigator = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                    castigator = true;

            //VERTICALA
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                castigator = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                castigator = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                castigator = true;

            //DIAGONALA
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                castigator = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
                castigator = true;
           
            if (castigator)
            {
                dez();
                String win = "";
                if (turn)
                {
                    win = p2.Text;
                    o_wins.Text = (Int32.Parse(o_wins.Text) + 1).ToString();
                }

                else
                {
                    win = p1.Text;
                    x_wins.Text = (Int32.Parse(x_wins.Text) + 1).ToString();
                }
                MessageBox.Show(win + " Castiga!");
                jocNouToolStripMenuItem.PerformClick();
            }
            else
            {
                if (turn_count == 9)
                {
                    egalitate.Text = (Int32.Parse(egalitate.Text) + 1).ToString();
                    MessageBox.Show("Egalitate!");
                    jocNouToolStripMenuItem.PerformClick();
                }

            }
            

        }

        private void dez()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch { };
        }

        private void jocNouToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;
                foreach (Control c in Controls)
                {
                    try
                    {

                        Button b = (Button)c;
                        b.Enabled = true;
                        b.Text = "";
                    }catch { };
                
                }
        }

        private void button_enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                if (turn)

                    b.Text = "X";
                else
                    b.Text = "0";
            }
        }

        private void button_leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if(b.Enabled)
            {
                b.Text = "";
            }
        }

        private void resetWinsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            o_wins.Text = "0";
            x_wins.Text = "0";
            egalitate.Text = "0";
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            setPlayerDefaultsToolStripMenuItem.PerformClick();
        }

        private void p2_TextChanged(object sender, EventArgs e)
        {
            if (p2.Text == "Computer")
                computer = true;
            else
                computer = false;
        }

        private void setPlayerDefaultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            p1.Text = "Augustin";
            p2.Text = "Computer";
        }

        private void meniuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
             this.Hide();
            form.ShowDialog();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
