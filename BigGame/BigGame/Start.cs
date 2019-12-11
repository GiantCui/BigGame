using BigGame.Map;
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
        public Start()
        {
            int w = this.Width;
            int h = this.Height;
            InitializeComponent();
            System.Windows.Forms.Button button1 = new Button();
            //button.Text = "按钮";
            button1.Size = new Size(250, 70);
            button1.Location = new Point((int)(w/2)+450, (int)(h/2)+100);
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.BackgroundImage = Properties.Resources.开始游戏;
            button1.Click += delegate { start_game(); };
            this.Controls.Add(button1);
            System.Windows.Forms.Button button2 = new Button();
            //button.Text = "按钮";
            button2.Size = new Size(250, 70);
            button2.Location = new Point((int)(w / 2) + 450, (int)(h / 2)+300);
            button2.BackgroundImageLayout = ImageLayout.Stretch;
            button2.BackgroundImage = Properties.Resources.结束游戏;
            button2.Click += delegate { end(); };
            this.Controls.Add(button2);
            //继续游戏
            System.Windows.Forms.Button button3 = new Button();
            button3.Size = new Size(250, 70);
            button3.Location = new Point((int)(w / 2) + 450, (int)(h / 2) + 500);
            button3.BackgroundImageLayout = ImageLayout.Stretch;
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
        }

        private void start_game()
        {
            Form1 f1 = new Form1();
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
            
            Form1 f = new Form1();

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("MyFile.bin", FileMode.Open,
            FileAccess.Read, FileShare.Read);
            SingleObject._single = (SingleObject)formatter.Deserialize(stream);
            stream.Close();

            //using (FileStream fs = new FileStream(@"In.txt", FileMode.OpenOrCreate, FileAccess.Read))
            //{
            //    BinaryFormatter bf = new BinaryFormatter();
            //    //Gameobject
            //    SingleObject._single = (SingleObject)bf.Deserialize(fs);
            //}
            this.Hide();
            
            f.ShowDialog(this);
            
            this.Close();

        }
 
    }
}
