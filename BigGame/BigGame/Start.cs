using BigGame.Map;
using BigGame.Role;
using Microsoft.DirectX.DirectSound;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigGame
{
    public partial class Start : Form
    {
        public int w;
        public int h;

        public Start()
        {         
            InitializeComponent();
            w = this.Width;
            h = this.Height;
            System.Windows.Forms.Button button1 = new Button();
            //button.Text = "按钮";
            button1 = button_set(button1, 100);
            button1.BackgroundImage = Properties.Resources.开始游戏;
            button1.Click += delegate { start_game(); };
            this.Controls.Add(button1);
            System.Windows.Forms.Button button2 = new Button();
            //button.Text = "按钮";
            button2 = button_set(button2, 500);
            button2.BackgroundImage = Properties.Resources.结束游戏;
            button2.Click += delegate { end(); };
            this.Controls.Add(button2);
            //继续游戏
            System.Windows.Forms.Button button3 = new Button();
            button3 = button_set(button3, 300);
            button3.BackgroundImage = Properties.Resources.继续游戏1;
            button3.Click += delegate { Return_game(); };
            this.Controls.Add(button3);
        }

        private void Start_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            this.BackgroundImage = Properties.Resources.界面;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.Width = 900;
            this.Height = 600;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            //BGM
            Device secDev = new Device();//设备对象  
            secDev.SetCooperativeLevel(this, CooperativeLevel.Normal);
            SecondaryBuffer secBuffer = new SecondaryBuffer(Properties.Resources.start_game, secDev);
            secBuffer.Play(0, BufferPlayFlags.Looping);//设置缓冲区为默认播放 

            this.Cursor = new Cursor("..//..//Resources//cur_default.cur");
        }

        private void start_game()
        {
            Form1 f1 = new Form1();
            Weapon.Restore();
            this.Hide();
            f1.ShowDialog(this);
            this.Close();
        }

        private void end()
        {
            this.Close();
        }

        private void Return_game()
        {
           // this.DialogResult = DialogResult.OK;
            
            Form1 f = new Form1(true);
            this.Hide();
            
            f.ShowDialog(this);
            
            this.Close();
        }
        
        private Button button_set(Button btn, int n)
        {
            btn.Size = new Size(250, 70);
            btn.Location = new Point((int)(w / 2) + 300, (int)(h / 2) + n);
            btn.BackgroundImageLayout = ImageLayout.Stretch;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = System.Drawing.Color.Transparent;
            btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btn.Cursor = Cursors.Hand;
            btn.Cursor = new Cursor("..//..//Resources//cur.cur");
            return btn;
        }
    }
}
