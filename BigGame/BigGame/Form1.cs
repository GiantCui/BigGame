using BigGame.Map;
using System;
using System.Drawing;
using System.Windows.Forms;
using BigGame.Role.HERO;
using BigGame.FactoryMonster;
using BigGame.UI;
using BigGame.NPC;
using BigGame.Action;
using Microsoft.DirectX;
using Microsoft.DirectX.DirectSound;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace BigGame
{
    [Serializable]  //可序列化
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();   
        }
        
        public SecondaryBuffer secBuffer;//缓冲区对象    
        public Device secDev;//设备对象 

        private void Form1_Load(object sender, EventArgs e)
        {
 
            //在窗体加载的时候，解决窗体闪烁问题
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.ResizeRedraw
                | ControlStyles.AllPaintingInWmPaint, true);
            this.WindowState = FormWindowState.Maximized;
            //初始化播放器
            SoundPlayer.form = this;
            SoundPlayer.secDev.SetCooperativeLevel(this, CooperativeLevel.Normal);
            SoundPlayer.play_BGM();
            this.Cursor.Dispose();
            Level.InitialGame_1(this);
            Level.InitialGame_2();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            SingleObject.GetSingle().Draw(e.Graphics);
            if(SingleObject.GetSingle().BG.TP.finsh)
            {
                timer1.Stop();
                long start = comm.Time();
                long end = start + 500;
                while(start < end)
                {
                    start = comm.Time();
                }
                GameOver gameOver = new GameOver();
                this.Hide();
                gameOver.ShowDialog(this);
                Start f = new Start();
                this.Hide();
                f.ShowDialog(this);
                this.Close();
                
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            SingleObject.GetSingle().BG.TP.key_ctrl(e);
            if (e.KeyCode == Keys.Escape)
            {
                Temp t = new Temp(this);
                t.f1 = this;
                this.Visible = false;
                DialogResult d = t.ShowDialog(this);
                if(d== DialogResult.OK)
                {
                    this.Visible = true;
                }
                else
                {
                    this.Close();
                }
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            SingleObject.GetSingle().BG.TP.index = 0;
            SingleObject.GetSingle().BG.TP.key_upctrl(e);
            Door.new_level(e);
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //SingleObject.GetSingle().BG.TP.KeyPress(e);
        }
    }
}
