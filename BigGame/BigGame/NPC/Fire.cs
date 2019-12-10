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
        public Fire(int x,int y,int width,int height) : base(x, y, width, height)
        {
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

        public void attackBack() //击退英雄
        {
            int face;
            if (SingleObject.GetSingle().BG.TP.face == 0)
            {
                face = -1;
            }
            else
            {
                face = 1;
            }
            SingleObject.GetSingle().BG.TP.X = SingleObject.GetSingle().BG.TP.X + face * 100;
        }

        public override Rectangle GetRectangle()  //将矩阵缩小
        {
            return new Rectangle(this.X, this.Y-30, this.Width, this.Height);
        }
        public override void Buffer()
        {
            SingleObject.GetSingle().BG.TP.currentlife--;
            attackBack();
        }
    }
}
