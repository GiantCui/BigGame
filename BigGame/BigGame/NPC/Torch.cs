using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BigGame.NPC
{
    [Serializable]  //可序列化
    class Torch:Goods
    {
        Image[] img = new Image[4];
        public Torch(int x,int y,int width,int height) : base(x, y, width, height)
        {

        }
        public override void InitializeImages()
        {
            img[0] = Properties.Resources.火1;
            img[1] = Properties.Resources.火2;
            img[2] = Properties.Resources.火3;
            img[3] = Properties.Resources.火4;
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
        }
    }
}
