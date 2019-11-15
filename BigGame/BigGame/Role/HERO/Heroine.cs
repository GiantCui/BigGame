using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigGame.Role.HERO
{
    public class Heroine : Hero
    {
        public Heroine(int x, int y, int width, int height, string name)
           : base(x, y, width, height, name)
        {
            //继承自父类的属性
            this.Name = name;
        }

        public override void InitializeImages()
        {
            img = new Image[4];
            img[0] = Properties.Resources;

        }

        public override void draw(Graphics g)
        {
            g.DrawImage(img[this.Index], this.X, this.Y, this.With, this.High);
        }
    }
}
