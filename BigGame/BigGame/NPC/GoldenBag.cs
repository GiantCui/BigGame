using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigGame.NPC
{
    [Serializable]  //可序列化
    class GoldenBag : Goods
    {
        Image[] img = new Image[2];  //保存Blood的图像
        public GoldenBag(int x, int y, int width, int height) : base(x, y, width, height)
        {
        }

        public override void InitializeImages()
        {
            img[0] = Properties.Resources.金袋;
            img[1] = Properties.Resources.金袋2;
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
            g.DrawImage(img[anm_frame], this.X + map.X, this.Y + map.Y, this.Width, this.Height);
        }

        public override void Buffer()
        {
            SingleObject.GetSingle().BG.TP.score += 150;
        }
    }
}
