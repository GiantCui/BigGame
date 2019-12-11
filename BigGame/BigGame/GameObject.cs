using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigGame
{
    [Serializable]  //可序列化
    public abstract class GameObject
    {
        //初始化构造函数
        public GameObject(int x, int y, int width, int height)
        {
            this.X = x;
            this.y = y;
            Height = height;
            Width = width;
            InitializeImages();
        }
        //定义时间委托
        public delegate void MyValueChanged();

        //与委托相关联的事件
        public event MyValueChanged OnMyValueChanged;

        #region 横坐标，纵坐标，图片，高度，宽度
        public int X { get; set; }
        public int y;
        public int Y
        {
            get { return this.y; }
            set
            {
                //如果变量改变调用事件触发函数
                if(value != this.y)
                {
                    this.y = value;
                    if (OnMyValueChanged != null)
                    {
                        OnMyValueChanged();
                    }       
                                       
                }                
            }
        }
        public int Height { get; set; }
        public int Width { get; set; }
        #endregion

        //返回对象矩阵
        public virtual Rectangle GetRectangle()
        {
            return new Rectangle(this.X, this.Y, this.Width, this.Height);
        }

        public abstract void InitializeImages();


        public abstract void Draw(Graphics g);

       // public abstract void Draw(Graphics g,int map_x,int map_y);

    }
}
