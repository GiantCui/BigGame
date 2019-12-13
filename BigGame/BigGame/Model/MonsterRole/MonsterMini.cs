using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BigGame.FactoryMonster
{
    [Serializable]  //可序列化
    class MonsterMini : Monster
    {
        public int face = 0;    //face=1默认为右，face=0默认为左
        public int start = 0;   //怪物的移动范围
        public int end = 0;
        Image[] img = new Image[3]; //保存怪物的图像素材
        public MonsterMini(int x, int y, int width, int height, string name, int hp)
            : base(x, y, width, height, name, hp)
        {
            this.Name = name;
            this.Hp = hp;
        }


        public override void InitializeImages()
        {
            img[0] = Properties.Resources.小怪1;
            img[1] = Properties.Resources.小怪2;
            img[2] = Properties.Resources.小怪3;
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
            attackHero();
        }

        public override void Move()
        {
        }

        public override void attackHero()
        {
            this.X = this.X - 2;
            if (this.GetRectangle().IntersectsWith(SingleObject.GetSingle().BG.TP.GetRectangle()))
            {
                int life = SingleObject.GetSingle().BG.TP.currentlife;
                if (life > 0)
                {
                    SingleObject.GetSingle().BG.TP.currentlife--;
                    attackBack();
                }
            }
        }
    }
}
