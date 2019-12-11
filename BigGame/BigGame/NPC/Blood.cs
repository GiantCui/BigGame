using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BigGame.NPC
{
    class Blood:Goods
    {
        Image[] img = new Image[2];  //保存Blood的图像
        public Blood(int x, int y, int width, int height) : base(x, y, width, height)
        {
        }

        public override void InitializeImages()
        {
            img[0] = Properties.Resources.血袋1;
            img[1] = Properties.Resources.血袋2;
            //img[2] = Properties.Resources.加血3;
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
        }

        public override void Buffer()
        {
            if (SingleObject.GetSingle().BG.TP.currentlife < 3)
            {
                SingleObject.GetSingle().BG.TP.currentlife++;
            }         
        }
    }
}
