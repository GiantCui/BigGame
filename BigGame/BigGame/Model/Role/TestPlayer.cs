using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigGame.Role
{
    class TestPlayer:GameObject
    {
        static Bitmap[] image =
        {
            Properties.Resources.walk_1,
            Properties.Resources.walk_2,
            Properties.Resources.walk_3,
            Properties.Resources.walk_4,
            Properties.Resources.walk_5,
            Properties.Resources.walk_6
        };
        public int anm_frame = 0;   //记录当前帧
        public long last_frame_time = 0;    //记录上一帧时间
        public long frame_internal = 170; //记录两帧间隔
        public int speed = 5;

        public TestPlayer(int x, int y):base(x, y, image[0].Height, image[0].Width)
        {

        }

        public override void Draw(Graphics g)
        {
            if (comm.Time() - last_frame_time > frame_internal)
            {
                anm_frame++;
                last_frame_time = comm.Time();
                if(anm_frame == image.Length)
                {
                    anm_frame = 0;
                }
            }
            g.DrawImage(image[anm_frame], this.X, this.Y, image[anm_frame].Width *2, image[anm_frame].Height*2);
        }

        public void Move(bool axis, int dir)
        {
            if (axis == GC.horizontal)
            {
                this.X += dir * speed;
            }
            else
            {
                this.Y += dir * speed;
            }

        }

        public override void InitializeImages()
        {
            
        }
    }
}
