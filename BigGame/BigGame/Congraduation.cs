using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigGame
{
    public partial class Congraduation : Form
    {
        public Congraduation()
        {
            InitializeComponent();          
        }

        private void Congraduation_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            
        }

        public void time_close()
        {
            timer1.Stop();
            print_score();
            comm.Wait(2000);
            this.Hide();
            this.Close();
        }

        private void Timer1_Tick_1(object sender, EventArgs e)
        {
            time_close();
        }

        private void print_score()
        {
            label1.Text = SingleObject.GetSingle().BG.TP.score.ToString();
            label1.Location = new Point((int)(this.Width/2 + 150), (int)(this.Height/2 + 30));
        }
    }
}
