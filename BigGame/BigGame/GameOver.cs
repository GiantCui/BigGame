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
    public partial class GameOver : Form
    {
        public GameOver()
        {
            InitializeComponent();
        }

        private void GameOver_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            //this.BackgroundImage = Properties.Resources.end;
            //time_close();
            
        }

        public void time_close()
        {
            long start = comm.Time();
            long end = start + 2000;
            while (start < end)
            {
                start = comm.Time();
            }
            this.Hide();
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time_close();
            
        }
    }
}
