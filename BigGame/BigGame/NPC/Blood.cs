﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BigGame.NPC
{
    class Blood:Goods
    {
        Image[] img = new Image[3];  //保存Blood的图像
        public Blood(int x, int y, int width, int height, int buffer) : base(x, y, width, height, buffer)
        {
            this.Buffer = buffer;
        }

        public override void InitializeImages()
        {
            img[0] = Properties.Resources.加血1;
            img[1] = Properties.Resources.加血2;
            img[2] = Properties.Resources.加血3;
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
