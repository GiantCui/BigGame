using BigGame.Map;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BigGame;
using BigGame.Role;

namespace BigGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitialGame();
        }

        public void InitialGame()
        {
            //加载背景图片
            SingleObject.GetSingle().AddGameObject(new BackGround(-10, -10, 20));
            //加载测试游戏对象
            SingleObject.GetSingle().AddGameObject(new TestPlayer(150, 180));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //测试
            //SingleObject.GetSingle().test();
            //在窗体加载的时候，解决窗体闪烁问题
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.ResizeRedraw
                | ControlStyles.AllPaintingInWmPaint, true);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            SingleObject.GetSingle().Draw(e.Graphics);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.W)
            {
                SingleObject.GetSingle().BG.Move(GC.vertical, (int)GC.Direction.up);
            }
            if(e.KeyCode == Keys.A)
            {
                SingleObject.GetSingle().BG.Move(GC.horizontal, (int)GC.Direction.left);
            }
            if(e.KeyCode == Keys.S)
            {
                SingleObject.GetSingle().BG.Move(GC.vertical, (int)GC.Direction.down);
            }
            if(e.KeyCode == Keys.D)
            {
                SingleObject.GetSingle().BG.Move(GC.horizontal, (int)GC.Direction.right);
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
