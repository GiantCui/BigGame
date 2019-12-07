using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigGame.Role
{
    public abstract class Monster : GameObject
    {
        public int speed = 5;   //怪物移动的速度
        public int anm_frame = 0;   //记录当前帧
        public long last_frame_time = 0;    //记录上一帧时间
        public long frame_internal = 100; //记录两帧间隔
        public Rectangle map { get; set; }   //记录地图坐标
        public Monster(int x, int y, int width, int height, string name, int hp) : base(x, y, width, height)
        {
            this.Name = name;
            this.Hp = hp;
        }

        public string Name { get; set; }
        public int Hp { get; set; }

        public void overturn(Image[] img)   //使怪物的图片翻转，达到转身的效果。
        {
            for (int i = 0; i < img.Length; i++)
            {
                img[i].RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
        }
        public bool in_attack()  //英雄是否在怪物的攻击范围内
        {
            int hero_x = SingleObject.GetSingle().hero.X;
            if(System.Math.Abs(this.X - hero_x) < 100)  //攻击范围为100
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public abstract void attackHero();
        public abstract void Move();
        public abstract bool Die();
    }
}
