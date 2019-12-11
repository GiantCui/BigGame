﻿using System;
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
        Image[] img = new Image[11];
        public Torch(int x,int y,int width,int height) : base(x, y, width, height)
        {

        }
        public override void InitializeImages()
        {
            img[0] = Properties.Resources.火把1;
            img[1] = Properties.Resources.火把2;
            img[2] = Properties.Resources.火把3;
            img[3] = Properties.Resources.火把4;
            img[4] = Properties.Resources.火把5;
            img[5] = Properties.Resources.火把6;
            img[6] = Properties.Resources.火把7;
            img[7] = Properties.Resources.火把8;
            img[8] = Properties.Resources.火把9;
            img[9] = Properties.Resources.火把10;
            img[10] = Properties.Resources.火把11;
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
