using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace BigGame.FactoryMonster
{
    class MonsterWalk:Monster
    {
        public int face = 0;    //face=1默认为右，face=0默认为左
        Image[] img = new Image[6]; //保存怪物的图像素材
        public int start = 0;   //怪物的移动范围
        public int end = 0;
        public MonsterWalk(int x, int y, int width, int height, string name, int hp)
            : base(x, y, width, height, name, hp)
        {
            this.Name = name;
            this.Hp = hp;
        }


        public override void InitializeImages()
        {
            updateRange();
            img[0] = Properties.Resources.walk1;
            img[1] = Properties.Resources.walk2;
            img[2] = Properties.Resources.walk3;
            img[3] = Properties.Resources.walk4;
            img[4] = Properties.Resources.walk5;
            img[5] = Properties.Resources.walk6;
        }

        public void updateRange()  //更新怪物的移动范围
        {
            start = this.X - 100;
            end = this.X + 100;
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
            //img[index][anm_frame].RotateFlip(RotateFlipType.Rotate180FlipY);
            g.DrawImage(img[anm_frame], this.X + map.X, this.Y + map.Y, this.Width, this.Height);
            if (in_attack())
            {
                attackHero();
                updateRange();  //怪物追击英雄后，更新怪物的移动范围
            }
            else
            {
                if (anm_frame % 2 == 1)
                {
                    Move();
                }
            }
        }

        public override void Move()
        {
            if (face == 0 && this.X > start)
            {
                this.X = this.X - speed;
            }
            if (face == 0 && this.X == start)
            {
                overturn(img);
                face = 1;
                this.X = this.X + speed;
            }
            if (face == 1 && this.X < end)
            {
                this.X = this.X + speed;
            }
            if (face == 1 && this.X == end)
            {
                overturn(img);
                face = 0;
                this.X = this.X - speed;
            }

        }

        public override void attackHero()
        {
            int offset = this.X - SingleObject.GetSingle().BG.TP.X;
            if (offset > 0)
            {
                if (face == 1)
                {
                    overturn(img);
                    face = 0;
                }
                this.X = this.X - speed;
            }
            if (offset < 0)
            {
                if (face == 0)
                {
                    overturn(img);
                    face = 1;
                }
                this.X = this.X + speed;
            }
            if (this.GetRectangle().IntersectsWith(SingleObject.GetSingle().BG.TP.GetRectangle()))
            {
                int life = SingleObject.GetSingle().BG.TP.origlife;
                if (life > 0)
                {
                    SingleObject.GetSingle().BG.TP.origlife = 0;
                }
            }
        }
    }
}

