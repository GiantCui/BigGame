using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigGame.UI
{
    class Life:GameObject
    {
        public static Image[] img = new Image[2];
        public static Image muscle = Properties.Resources.muscle_up;
        public int anm_frame = 0;   //记录当前帧
        public long last_frame_time = 0;    //记录上一帧时间
        public long frame_internal = 400; //记录两帧间隔

        public Life(int x, int y, int width, int height):base(x, y, width, height)
        {
            InitializeImages();
            
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
            g.DrawImage(muscle, this.X - 20, this.Y, muscle.Width / 10, muscle.Height / 10);
            for(int i = 1; i <= SingleObject.GetSingle().BG.TP.currentlife; i++)
            {
                g.DrawImage(img[anm_frame], this.X + i*40, this.Y + 25, img[anm_frame].Width / 2, img[anm_frame].Height / 2);
            }           
        }

        public override void InitializeImages()
        {
            img[0] = Properties.Resources.life_2;
            img[1] = Properties.Resources.life_3;
            //img[2] = Properties.Resources.life_3;
            //img[3] = Properties.Resources.life_2;
            //img[4] = Properties.Resources.life_1;
        }
    }
}
