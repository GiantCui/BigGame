using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BigGame.NPC
{
    class Fire:Goods
    {
        Image[] img = new Image[7];  //保存火堆的图像
        public Fire(int x,int y,int width,int height,int buffer) : base(x, y, width, height, buffer)
        {
            this.Buffer = buffer;
        }

        public override void InitializeImages()
        {
            img[0] = Properties.Resources.火堆1;
            img[1] = Properties.Resources.火堆2;
            img[2] = Properties.Resources.火堆3;
            img[3] = Properties.Resources.火堆4;
            img[4] = Properties.Resources.火堆5;
            img[5] = Properties.Resources.火堆6;
            img[6] = Properties.Resources.火堆7;
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
    }
}
