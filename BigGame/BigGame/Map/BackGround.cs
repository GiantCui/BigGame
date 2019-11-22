using BigGame.Role;
using BigGame.Role.HERO;
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
        public Hero TP { get; set; }
        public Rectangle Camera { get; set; }
        public BackGround(int x, int y, int speed) : base(x, y, BGImage.Height, BGImage.Width)
        {
            this.speed = speed;
        }
        public void SetCamera(Rectangle rec)
        {
            this.Camera = rec;
        }
        public override void Draw(Graphics g)
        {
            g.DrawImage(BGImage, this.X, this.Y, BGImage.Width, BGImage.Height);
            if(TP.X < Camera.Width / 2)
            {
                this.X = 0;
            }
            else if(TP.X > BGImage.Width - (Camera.Width / 2))
            {
                this.X = Camera.Width - BGImage.Width;
            }
            else
            {
                this.X = (Camera.Width / 2) - TP.X;
            }
            TP.map = new Rectangle(this.X, this.Y, BGImage.Width, BGImage.Height);
            TP.Draw(g);
        }

        public override void InitializeImages()
        {
            
        }
    }
}
