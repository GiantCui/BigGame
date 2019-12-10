using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BigGame.NPC
{
    class Gold:Goods
    {
        Image[] img = new Image[4];  //保存Blood的图像
        public Gold(int x, int y, int width, int height) : base(x, y, width, height)
        {
        }

        public override void InitializeImages()
        {
            img[0] = Properties.Resources.金币1;
            img[1] = Properties.Resources.金币2;
            img[2] = Properties.Resources.金币3;
            img[3] = Properties.Resources.金币4;
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

        public override Rectangle GetRectangle()  //将矩阵缩小
        {
            return new Rectangle(this.X, this.Y, this.Width - 50, this.Height - 50);
        }

        public override void Buffer()
        {
            SingleObject.GetSingle().BG.TP.score += 5;
        }
    }
}
