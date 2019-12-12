using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigGame.NPC
{
    [Serializable]  //可序列化
    public class Door: Goods
    {
        public Image[][] img = new Image[3][];
        private int index = 0;
        public Door(int x, int y, int width, int height) : base(x, y, width, height)
        {
        }

        public override void InitializeImages()
        {
            img[0] = new Image[1];
            img[0][0] = Properties.Resources.door1;
            img[1] = new Image[1];
            img[1][0] = Properties.Resources.door2;
            //img[2] = Properties.Resources.加血3;
        }

        public override void Draw(Graphics g)
        {
            if(!(SingleObject.GetSingle().BG.TP.GetRectangle().IntersectsWith(this.GetRectangle())))
            {
                index = 0;
            }
            if (comm.Time() - last_frame_time > frame_internal)
            {
                anm_frame++;
                last_frame_time = comm.Time();
            }
            if (anm_frame >= img[index].Length)
            {
                anm_frame = 0;
            }
            // img[index][anm_frame].RotateFlip(RotateFlipType.Rotate180FlipY);
            g.DrawImage(img[index][anm_frame], this.X + map.X, this.Y + map.Y, this.Width, this.Height);
        }

        public override void Buffer()
        {
            index = 1;
         //   SingleObject.GetSingle().BG.TP;
        }
    }
}
