using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigGame
{
    public partial class Temp : Form
    {
        Form1 f1;

        public Temp(Form1 f)
        {
            InitializeComponent();         
            System.Windows.Forms.Button button1 = new Button();
            //button.Text = "按钮";
            int w = this.Width;
            int h = this.Height;
            button1.Size = new Size(250, 70);
            button1.Location = new Point((int)(w/2)+120,(int)(h/2));
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.BackgroundImage = Properties.Resources.回主菜单;
            button1.Click += delegate { Return_Menu(); };
            this.Controls.Add(button1);
            System.Windows.Forms.Button button2 = new Button();
            //button.Text = "按钮";
            button2.Size = new Size(250, 70);
            button2.Location = new Point((int)(w / 2) + 120, (int)(h / 2)+100);
            button2.BackgroundImageLayout = ImageLayout.Stretch;
            button2.BackgroundImage = Properties.Resources.保存进度;
            button2.Click += delegate { Exit_Game(); };
            this.Controls.Add(button2);
            //继续游戏
            System.Windows.Forms.Button button3 = new Button();
            button3.Size = new Size(250, 70);
            button3.Location = new Point((int)(w / 2) + 120, (int)(h / 2) + 200);
            button3.BackgroundImageLayout = ImageLayout.Stretch;
            button3.BackgroundImage = Properties.Resources.继续游戏;
            button3.Click += delegate { Return_Game(); };
            this.Controls.Add(button3);
            f1 = f;
        }

        private void Temp_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;         
        }

        private void Return_Menu()
        {
          //  Form1 f1 = new Form1();
          //  this.Hide();
          //  f1.ShowDialog(this);
            this.Close();
        }

        private void Exit_Game()
        {
            using (FileStream fs = new FileStream(@"In.txt", FileMode.OpenOrCreate, FileAccess.Write))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, SingleObject._single);
            }
        }

        private void Return_Game()
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
            this.Dispose();
        }

      
    }
}
