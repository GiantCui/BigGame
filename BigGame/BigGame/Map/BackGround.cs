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
    public class BackGround:GameObject
    {
        public static Bitmap BGImage = Properties.Resources.background4;
        public static Bitmap BGunder = Properties.Resources.new4;
        public int speed { get; set; }
        public Hero TP { get; set; }
        public Monster MS { get; set; }
        //创建相机
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
            g.DrawImage(BGunder, this.X, this.Y, BGunder.Width, BGunder.Height);
            g.DrawImage(BGImage, this.X, this.Y, BGImage.Width, BGImage.Height);
            //人物遇到地图左边界
            if(TP.X < Camera.Width / 2)
            {
                this.X = 0;
            }
            //人物遇到地图右边界
            else if(TP.X > BGImage.Width - (Camera.Width / 2))
            {
                this.X = Camera.Width - BGImage.Width;
            }
            //人物在地图中间
            else
            {
                this.X = (Camera.Width / 2) - TP.X;
            }
            //人物遇到地图上边界
            if (TP.Y < Camera.Width / 2)
            {
                this.Y = 0;
            }
            //人物遇到地图下边界
            else if (TP.Y > BGImage.Width - (Camera.Height / 2))
            {
                this.Y = Camera.Height - BGImage.Height;
            }
            //人物在地图中间
            else
            {
                this.Y = (Camera.Height / 2) - TP.Y;
            }
            //更新角色存储的地图信息
            TP.map = new Rectangle(this.X, this.Y, BGImage.Width, BGImage.Height);
            MS.map = new Rectangle(this.X, this.Y, BGImage.Width, BGImage.Height);
            TP.BackGd = this;
            TP.Draw(g);
            MS.Draw(g);
        }

        public override void InitializeImages()
        {
            
        }
    }
}
