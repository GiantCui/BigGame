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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BigGame
{
    public partial class Form1 : Form
    {
        Heroine h=new Heroine(0,400,100,100,"唐妮");

        Monster fly = FactoryM.createMonster(2000, "fly");
        Monster walk = FactoryM.createMonster(500, "walk");
        Monster walk1 = FactoryM.createMonster(1000, "Walk");

        Goods fire = FactoryGoods.createGoods(150, 550, "Fire");
        Goods blood = FactoryGoods.createGoods(570, 350, "Blood");
        Goods gold = FactoryGoods.createGoods(700, 520, "Gold");
        Goods torch = FactoryGoods.createGoods(150, 400, "Torch");

        Life life_UI = new Life(50, 10, 20, 20);
        Listing list_UI = new Listing(600, 30);

        Hero_GetGoods gold_list = new Hero_GetGoods();
        public Form1()
        {
            InitializeComponent();       
            InitialGame();

        }
        public Form1(bool IsR)
        {
            InitializeComponent();
            if (IsR == true)
            {
                InitialGame();
                using (FileStream fs = new FileStream(@"In.txt", FileMode.OpenOrCreate, FileAccess.Read))
                {
                  BinaryFormatter bf = new BinaryFormatter();
                  SingleObject._single = (SingleObject)bf.Deserialize(fs);
                }
 
            }
            else
            {
                InitialGame();
            }
          
        }

        public void InitialGame()
        {
            //记录窗体信息
            //加载背景图片
            SingleObject.GetSingle().AddGameObject(new BackGround(0, 0, 20));
            SingleObject.GetSingle().BG.SetCamera(new Rectangle(this.Location, this.Size));
            //加载测试游戏对象
            SingleObject.GetSingle().BG.TP = h;         
            //加入怪物
            SingleObject.GetSingle().BG.ListMonster.Add(fly);
            SingleObject.GetSingle().BG.ListMonster.Add(walk);
            SingleObject.GetSingle().BG.ListMonster.Add(walk1);
            //加入物品
            SingleObject.GetSingle().BG.ListGoods.Add(fire);
            SingleObject.GetSingle().BG.ListGoods.Add(blood);
            SingleObject.GetSingle().BG.ListGoods.Add(gold);
            SingleObject.GetSingle().BG.ListGoods.Add(torch);
            //加载UI界面
            SingleObject.GetSingle().AddGameObject(life_UI);
            SingleObject.GetSingle().AddGameObject(list_UI);
            //创建金币集对象
            SingleObject.GetSingle().BG.GoldList = gold_list;

        }
        public SecondaryBuffer secBuffer;//缓冲区对象    
        public Device secDev;//设备对象 
        private void Form1_Load(object sender, EventArgs e)
        {
            //测试
            //SingleObject.GetSingle().test();
            //在窗体加载的时候，解决窗体闪烁问题
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.ResizeRedraw
                | ControlStyles.AllPaintingInWmPaint, true);
            this.WindowState = FormWindowState.Maximized;
            //初始化播放器
            SoundPlayer.form = this;
            SoundPlayer.secDev.SetCooperativeLevel(this, CooperativeLevel.Normal);
            SoundPlayer.play_BGM();
            //sd.playLoop(Properties.Resources.play_BGM, sb);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            SingleObject.GetSingle().Draw(e.Graphics);
            if(SingleObject.GetSingle().BG.TP.finsh)
            {
                long start = comm.Time();
                long end = start + 500;
                while(start < end)
                {
                    start = comm.Time();
                }
                GameOver gameOver = new GameOver();
                this.Hide();
                gameOver.ShowDialog(this);
                this.Close();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            h.key_ctrl(e);
            if (e.KeyCode == Keys.Escape)
            {
                Temp t = new Temp(this);
                this.Visible = false;
                DialogResult d = t.ShowDialog(this);
                if(d== DialogResult.OK)
                {
                    this.Visible = true;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            h.index = 0;
            h.key_upctrl(e);
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //h.KeyPress(e);
        }
    }
}
