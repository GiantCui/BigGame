using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            //g.DrawImage(img, this.X, this.y, this.Width, this.Height);
            Brush linearGradientBrush = new LinearGradientBrush(new Rectangle(85, 85, 85, 85), Color.Blue, Color.BlueViolet, 45);
            g.DrawString("Score:" + i.ToString(), new Font("Consolas", 23, FontStyle.Bold), linearGradientBrush, 80, 80);
        }

        
    }
}
