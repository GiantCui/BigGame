using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigGame.Role.HERO
{
    public abstract class Hero : GameObject
    {
        public int speed = 5;
        public int anm_frame = 0;   //记录当前帧
        public long last_frame_time = 0;    //记录上一帧时间
        public long frame_internal = 500; //记录两帧间隔
        public Hero(int x, int y, int width, int height, string name)
              : base(x, y, width, height)
        {
            this.Name = name;
        }

        public string Name { get;  set; }

        public void key_ctrl(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                this.Y = this.Y - speed;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.Y = this.Y + speed;
            }
            if (e.KeyCode == Keys.Left)
            {
                this.X = this.X - speed;
            }
            if (e.KeyCode == Keys.Right)
            {
                this.X = this.X + speed;
            }
        }
        
    }
}
