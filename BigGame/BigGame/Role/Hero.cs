using BigGame.Map;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigGame.Role.HERO
{
    [Serializable]  //可序列化
    public abstract class Hero : GameObject
    {
        public BackGround BackGd { get; set; }
        public int speed = 10;
        public int face = 0;    //face=0默认为右，face=1默认为左
        public int origlife = 3;       //初始生命
        public int currentlife = 3;    //当前生命
        public int anm_frame = 0;   //记录当前帧
        public int score = 0;
        public long last_frame_time = 0;    //记录上一帧时间
        public long frame_internal = 150; //记录两帧间隔
        public Rectangle map { get; set; }   //记录地图坐标
        public bool finsh = false; //记录是否死亡
        public Hero(int x, int y, int width, int height, string name)
              : base(x, y, width, height)
        {
            this.Name = name;
        }

        public string Name { get;  set; }
     //   public Image[][] Img { get => img; set => img = value; }

        public abstract void key_ctrl(KeyEventArgs e);

        public override Rectangle GetRectangle()  //将矩阵缩小
        {
            return new Rectangle(this.X, this.Y, this.Width - 50, this.Height - 50);
        }
    }
}
