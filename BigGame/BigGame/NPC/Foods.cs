using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using BigGame.Role;
using System.Windows.Forms;

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
        public int index { get; set; }
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
            g.DrawImage(img[Random%4], this.X + map.X, this.Y + map.Y, this.Width, this.Height); 
        }

        public override void Buffer()
        {
            if (Random % 4 == 0)
            {
                SingleObject.GetSingle().BG.TP.currentlife = SingleObject.GetSingle().BG.TP.origlife;//恢复全部生命
            }
            else if (Random % 4 == 1)
            {
                SingleObject.GetSingle().BG.TP.currentlife--;//毒苹果
            }
            else if (Random % 4 == 2)
            {
                Weapon.w +=10; Weapon.h +=10;//子弹变大
            }
            else
            {
                Weapon.end *= 2;//子弹射程*2
            }
            SoundPlayer.Eat_BGM();
        }
    }
}
