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
        private static Bitmap BGImage = Properties.Resources.BG;
        public int speed { get; set; }
        
        public BackGround(int x, int y, int speed) : base(x, y, BGImage, BGImage.Height, BGImage.Width)
        {
            this.speed = speed;
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(BGImage, this.X, this.Y);
        }

        public void Move(bool axis, int dir)
        {
            if(axis == GC.horizontal)
            {
                this.X += dir * speed;
            }
            else
            {
                this.Y += dir * speed;
            }
            
        }
    }
}
