using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using BigGame.Role;

namespace BigGame.NPC
{
    [Serializable]  //可序列化
    class Foods:Goods
    {
        Image[] img = new Image[4];  //保存Blood的图像
        public Foods(int x, int y, int width, int height,int random) : base(x, y, width, height)
        {
            this.Random = random;
        }
        public int Random { get; set; }
        public override void InitializeImages()
        {
            img[0] = Properties.Resources.grass;
            img[1] = Properties.Resources.apple;
            img[2] = Properties.Resources.banana;
            img[3] = Properties.Resources.can;
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(img[Random], this.X + map.X, this.Y + map.Y, this.Width, this.Height);
        }


        public override void Buffer()
        {
            switch (Random)
            {
                case 0:SingleObject.GetSingle().BG.TP.currentlife = SingleObject.GetSingle().BG.TP.origlife;break;//恢复全部生命
                case 1: SingleObject.GetSingle().BG.TP.currentlife--;break;//毒苹果
                case 2:Weapon.w *= 2;Weapon.h *= 2;break;//子弹变大
                case 3: Weapon.end *= 2; break;//子弹射程*2
            }
            SoundPlayer.Eat_BGM();
        }
    }
}
