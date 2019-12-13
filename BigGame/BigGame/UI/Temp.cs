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
    public partial class Temp : Form
    {
        public Form1 f1;
        public int w;
        public int h;
        public Temp(Form1 f)
        {
            InitializeComponent();
            w = this.Width;
            h = this.Height;
            System.Windows.Forms.Button button1 = new Button();
            //button.Text = "按钮";
            button1 = button_set(button1, 0);
            button1.BackgroundImage = Properties.Resources.回主菜单;
            button1.Click += delegate { Return_Menu(); };
            this.Controls.Add(button1);
            System.Windows.Forms.Button button2 = new Button();
            //button.Text = "按钮";
            button2 = button_set(button2, 100);
            button2.BackgroundImage = Properties.Resources.保存进度;
            button2.Click += delegate { Exit_Game(); };
            this.Controls.Add(button2);
            //继续游戏
            System.Windows.Forms.Button button3 = new Button();
            button3 = button_set(button3, 200);
            button3.BackgroundImage = Properties.Resources.继续游戏;
            button3.Click += delegate { Return_Game(); };
            this.Controls.Add(button3);
            f1 = f;
        }

        private void Temp_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            this.Cursor = new Cursor("..//..//Resources//cur_default.cur");
        }

        private void Return_Menu()
        {
            Start s = new Start();
            this.Hide();
            DialogResult d = s.ShowDialog(this);
            if (d == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
            }
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Exit_Game()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("MyFile.bin", FileMode.Create,
            FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, SingleObject.GetSingle());
            stream.Close();
            MessageBox.Show("保存成功");
            //using (FileStream fs = new FileStream(@"In.txt", FileMode.OpenOrCreate, FileAccess.Write))
            //{
            //    BinaryFormatter bf = new BinaryFormatter();
            //    bf.Serialize(fs, SingleObject._single);
            //}
        }

        private void Return_Game()
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
            this.Dispose();
        }

        private Button button_set(Button btn, int n)
        {
            btn.Size = new Size(250, 70);
            btn.Location = new Point((int)(w / 2) + 120, (int)(h / 2) + n);
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
