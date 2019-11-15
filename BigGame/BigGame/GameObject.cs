using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigGame
{
    public abstract class GameObject
    {
        //初始化构造函数
        public GameObject(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Height = height;
            Width = width;
            InitializeImages();
        }

        #region 横坐标，纵坐标，图片，高度，宽度
        public int X { get; set; }
        public int Y { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        #endregion

        //返回对象矩阵
        public Rectangle GetRectangle()
        {
            return new Rectangle(this.X, this.Y, this.Width, this.Height);
        }

        public abstract void InitializeImages();


        public abstract void Draw(Graphics g);

    }
}
