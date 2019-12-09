using BigGame.Role.HERO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigGame.Role
{
    public class Weapon : GameObject
    {
        public Image[] img = new Image[2];
        private int index = 0;  //记录图片下标
        public Rectangle map { get; set; }   //记录地图坐标
        private Hero hero;
        private Point p = new Point();   //记录子弹最初的位置
        public Hero Hero { get => hero; set => hero = value; }
        public Weapon(int x, int y, int width, int height, Hero ob)
             : base(x, y, width, height)
        {
            this.Hero = ob;
            this.X = p.X=ob.X+60;
            this.Y =p.Y= ob.Y+30;
        }

        public override void InitializeImages()
        {
            img[0] = Properties.Resources.bullet_1;
            img[1] = Properties.Resources.bullet_2;
        }
    

        public void IsAtMonster()
        {
            int tag = 0;
            if (this.X <= p.X + 200)
            {
                for(int i=0;i < SingleObject.GetSingle().BG.ListMonster.Count(); i++)
                {
                    if (this.GetRectangle().IntersectsWith(SingleObject.GetSingle().BG.ListMonster[i].GetRectangle()))
                    {
                        SingleObject.GetSingle().BG.ListWeapon.RemoveAt(0);//移除武器
                        SingleObject.GetSingle().BG.ListMonster.RemoveAt(i);
                        tag = 2;
                        break;
                    }                
                }
                if (tag == 0)
                {
                    this.X = this.X+10;                   
                }
            }
           else if ((SingleObject.GetSingle().BG.ListWeapon.Count() != 0))
            {
                SingleObject.GetSingle().BG.ListWeapon.RemoveAt(0);//移除武器
            }           
        }

        public override void Draw(Graphics g)
        {

            IsAtMonster();
            if (SingleObject.GetSingle().BG.ListWeapon.Count() != 0)
            {
                if (index == 2)
                {
                    index = 0;
                }
                g.DrawImage(img[index], this.X, this.Y, this.Width, this.Height);
                index++;
            }      
        }
    }
}