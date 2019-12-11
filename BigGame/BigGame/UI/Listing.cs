using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigGame.UI
{
    [Serializable]  //可序列化
    class Listing : GameObject
    {
        public static Image img = Properties.Resources.木牌2;

        public Listing(int x, int y):base(x, y, img.Width, img.Height)
        {

        }

        public override void InitializeImages()
        {
            
        }

        public override void Draw(Graphics g)
        {
            int i = SingleObject.GetSingle().BG.TP.score;
            g.DrawImage(img, this.X, this.y, this.Width, this.Height);
            g.DrawString("Score\n  " + i.ToString(), new Font("Consolas", 25, FontStyle.Bold), Brushes.LightGray, 630, 100);
        }

        
    }
}
