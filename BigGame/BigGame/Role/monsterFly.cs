using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace BigGame.Role
{
    class monsterFly : Monster
    {
        public int face = 0;    //face=1默认为右，face=0默认为左
        Image[] img = new Image[8]; //保存怪物的图像素材
        public monsterFly(int x, int y, int width, int height, string name, int hp, int start, int end)
            : base(x, y, width, height, name, hp)
        {
            this.Name = name;
            this.Hp = hp;
            this.Start = start;
            this.End = end;
        }

        public int End { get; set; }   //怪物在一定范围内移动
        public int Start { get; set; }

        public override void InitializeImages()
        {
            img[0] = Properties.Resources.alien_enemy_flying1;
            img[1] = Properties.Resources.alien_enemy_flying2;
            img[2] = Properties.Resources.alien_enemy_flying3;
            img[3] = Properties.Resources.alien_enemy_flying4;
            img[4] = Properties.Resources.alien_enemy_flying5;
            img[5] = Properties.Resources.alien_enemy_flying6;
            img[6] = Properties.Resources.alien_enemy_flying7;
            img[7] = Properties.Resources.alien_enemy_flying8;
        }

        public override bool Die()
        {
            return false;
        }

        public override void Draw(Graphics g)
        {
            if (comm.Time() - last_frame_time > frame_internal)
            {
                anm_frame++;
                last_frame_time = comm.Time();
            }
            if (anm_frame >= img.Length)
            {
                anm_frame = 0;
            }
            // img[index][anm_frame].RotateFlip(RotateFlipType.Rotate180FlipY);
            g.DrawImage(img[anm_frame], this.X + map.X, this.Y + map.Y, this.Width, this.Height);
            if (anm_frame % 2 == 1)
            {
                Move();
            }
        }

        public override void Move()
        {
            if (face == 0 && this.X > Start)
            {
                this.X = this.X - speed;
            }
            if (face == 0 && this.X == Start)
            {
                overturn(img);
                face = 1;
                this.X = this.X + speed;
            }
            if (face == 1 && this.X < End)
            {
                this.X = this.X + speed;
            }
            if (face == 1 && this.X == End)
            {
                overturn(img);
                face = 0;
                this.X = this.X - speed;
            }

        }
    }
}
