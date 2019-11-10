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
            Properties.Resources._1,
            Properties.Resources._2
        };
        public int anm_frame = 0;   //记录当前帧
        public long last_frame_time = 0;    //记录上一帧时间
        public long frame_internal = 500; //记录两帧间隔

        public TestPlayer(int x, int y):base(x, y, image[0], image[0].Height, image[0].Width)
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
            g.DrawImage(image[anm_frame], this.X, this.Y);
        }
    }
}
