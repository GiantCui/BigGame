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

        public Form1(bool load_game)
        {
            InitializeComponent();
            this.load_game = load_game;
        }

        //声音设备
        public SecondaryBuffer secBuffer;//缓冲区对象    
        public Device secDev;//设备对象 
        public bool load_game = false;

        private void Form1_Load(object sender, EventArgs e)
        {
 
            //在窗体加载的时候，解决窗体闪烁问题
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);
            //最大化窗口
            this.WindowState = FormWindowState.Maximized;
            //初始化播放器
            SoundPlayer.form = this;
            SoundPlayer.secDev.SetCooperativeLevel(this, CooperativeLevel.Normal);
            SoundPlayer.play_BGM();
            this.Cursor.Dispose();
            //初始化游戏
            Init_Game();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            SingleObject.GetSingle().Draw(e.Graphics);
            If_Finished();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            SingleObject.GetSingle().BG.TP.key_ctrl(e);   
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            SingleObject.GetSingle().BG.TP.key_upctrl(e);
            Door.new_level(e);
            If_Pause(e);
        }

        public void Init_Game()
        {
            if (load_game)
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("MyFile.bin", FileMode.Open,
                FileAccess.Read, FileShare.Read);
                SingleObject.SetSingle((SingleObject)formatter.Deserialize(stream));
                stream.Close();
            }
            else
            {
                Level.InitialGame_1(this);
            }
        }

        public void If_Finished()
        {
            if (SingleObject.GetSingle().BG.TP.finsh)
            {
                timer1.Stop();
                comm.Wait_500();
                GameOver gameOver = new GameOver();
                this.Hide();
                gameOver.ShowDialog(this);
                Start f = new Start();
                this.Hide();
                f.ShowDialog(this);
                this.Close();
            }
            if (SingleObject.GetSingle().BG.TP.Vector)
            {
                timer1.Stop();
                long start = comm.Time();
                long end = start + 500;
                while (start < end)
                {
                    start = comm.Time();
                }
                Congraduation c = new Congraduation();
                this.Hide();
                c.ShowDialog(this);
                Start f = new Start();
                this.Hide();
                f.ShowDialog(this);
                this.Close();
            }
        }

        public void If_Pause(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Temp t = new Temp(this);
                t.f1 = this;
                this.Visible = false;
                DialogResult d = t.ShowDialog(this);
                if (d == DialogResult.OK)
                {
                    this.Visible = true;
                }
                else
                {
                    this.Close();
                }
            }
        }
    }
}
