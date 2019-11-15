using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigGame.Role.HERO
{
    public class Heroine : Hero
    {
       
        public Heroine(int x, int y, int width, int height, string name)
           : base(x, y, width, height, name)
        {
            //继承自父类的属性
            this.Name = name;
        }

        public override void InitializeImages()
        {
            img = new Image[7];
            img[0] = Properties.Resources.walk_3;
            img[1] = Properties.Resources.walk_4;
            img[2] = Properties.Resources.walk_5;
            img[3]= Properties.Resources.walk_2;
            img[4]= Properties.Resources.walk_6;
            img[5]= Properties.Resources.walk_1;
        }

        public override void Draw(Graphics g)
        {
            if (comm.Time() - last_frame_time > frame_internal)
            {
                anm_frame++;
                last_frame_time = comm.Time();
                if (anm_frame == img.Length)
                {
                    anm_frame = 0;
                }
            }
            g.DrawImage(img[anm_frame], this.X, this.Y, this.Width, this.Height);
        }
    }
}
