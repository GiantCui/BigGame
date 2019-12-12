using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BigGame.NPC
{
    class Foods:Goods
    {
        Image[] img = new Image[5];  //保存Blood的图像
        int a1;
        public Foods(int x, int y, int width, int height) : base(x, y, width, height)
        {
            Random r = new Random();
            a1 = r.Next(0, 5);
        }

        public override void InitializeImages()
        {
            img[0] = Properties.Resources.grass;
            img[1] = Properties.Resources.apple;
            img[2] = Properties.Resources.banana;
            img[3] = Properties.Resources.can;
            img[4] = Properties.Resources.grape;
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(img[a1], this.X + map.X, this.Y + map.Y, this.Width, this.Height);
        }


        public override void Buffer()
        {
            SingleObject.GetSingle().BG.TP.score += 1;
            SoundPlayer.GetGold_BGM();
        }
    }
}
