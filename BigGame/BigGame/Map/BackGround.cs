using BigGame.Role;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigGame.Map
{
    class BackGround:GameObject
    {
        private static Bitmap BGImage = Properties.Resources.background4;
        public int speed { get; set; }
        public TestPlayer TP { get; set; }
        public BackGround(int x, int y, int speed) : base(x, y, BGImage.Height, BGImage.Width)
        {
            this.speed = speed;
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(BGImage, this.X, this.Y);
        }

       

        public void Draw(TestPlayer testPlayer)
        {
            this.TP = testPlayer;
        }
        public override void InitializeImages()
        {
            
        }
    }
}
