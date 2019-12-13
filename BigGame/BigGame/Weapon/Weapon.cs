using BigGame.Role.HERO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BigGame.NPC;
using BigGame.FactoryMonster;

namespace BigGame.Role
{
    [Serializable]  //可序列化
    public class Weapon : GameObject
    {
        public static int w = 20;
        public static int h = 20;
        public static int end = 200;
        public Image[] img = new Image[2];
        private int index = 0;  //记录图片下标
        private int isexit=0 ;  //记录图片下标
        public Rectangle map { get; set; }   //记录地图坐标
        private Hero hero;
        private Point p = new Point();   //记录子弹最初的位置
        public Hero Hero { get => hero; set => hero = value; }
        public int Isexit { get => isexit; set => isexit = value; }

        public Weapon(int x, int y, int width, int height, Hero ob)
             : base(x, y, width, height)
        {    
            this.Hero = ob;       
            if (hero.face == 0)
            {
                this.X = p.X = hero.X + 60;
                this.Y = p.Y = hero.Y + 30;              
            }
            else
            {
                this.X = p.X = hero.X+10;
                this.Y = p.Y = hero.Y + 30;
                img[0] = Properties.Resources.bullet_l_1;
                img[1] = Properties.Resources.bullet_l_2;
            }         
        }

        public override void InitializeImages()
        {
            img[0] = Properties.Resources.bullet_1;
            img[1] = Properties.Resources.bullet_2;   
        }

        public static void Restore()
        {
            w = 20;
            h = 20;
            end = 200;
        }

        public void IsAtMonster()
        {
            int tag = 0;
            if ((hero.face == 0&& this.Isexit == 0 )||(this.Isexit == 1))
            {
                this.Isexit = 1;
                if (this.X <= p.X + end)
                {
                    for (int i = 0; i < SingleObject.GetSingle().BG.ListMonster.Count(); i++)
                    {
                        if (this.GetRectangle().IntersectsWith(SingleObject.GetSingle().BG.ListMonster[i].GetRectangle()))
                        {
                            if (SingleObject.GetSingle().BG.ListWeapon.Count > 0)
                            {
                                SingleObject.GetSingle().BG.ListWeapon.RemoveAt(0);//移除武器
                            }
                            int x = SingleObject.GetSingle().BG.ListMonster[i].X;
                            int y = SingleObject.GetSingle().BG.ListMonster[i].y;
                            if(SingleObject.GetSingle().BG.ListMonster[i] is Boss)
                            {
                                if (SingleObject.GetSingle().BG.ListMonster[i].Hp == 0)
                                {
                                    // int number = 1;
                                    SoundPlayer.BossDie_BGM();
                                    SingleObject.GetSingle().BG.ListMonster.RemoveAt(i);
                                    SingleObject.GetSingle().BG.ListGoods.Add(FactoryGoods.createGoods(x, y + 250, "GoldenBag"));
                                    SoundPlayer.Eat_GoldBag();
                                }
                                else
                                {
                                    SingleObject.GetSingle().BG.ListMonster[i].Hp -= 5;
                                }
                            }
                            else
                            {
                                SingleObject.GetSingle().BG.ListMonster.RemoveAt(i);
                                SingleObject.GetSingle().BG.ListGoods.Add(FactoryGoods.createGoods(x, y + 5, "Gold"));
                                tag = 2;
                                SoundPlayer.MonsterDie_BGM();
                                break;
                            }                       
                        }
                    }
                    if (tag == 0)
                    {
                        this.X = this.X + 30;
                    }
                }
                else if ((SingleObject.GetSingle().BG.ListWeapon.Count() != 0))
                {
                    SingleObject.GetSingle().BG.ListWeapon.RemoveAt(0);//移除武器
                }
            }
            else if((hero.face == 1 && this.Isexit == 0) || (this.Isexit == 2))
            {
                this.Isexit = 2;
                if (this.X >= p.X - end)
                {
                    for (int i = 0; i < SingleObject.GetSingle().BG.ListMonster.Count(); i++)
                    {
                        if (this.GetRectangle().IntersectsWith(SingleObject.GetSingle().BG.ListMonster[i].GetRectangle()))
                        {
                            SingleObject.GetSingle().BG.ListWeapon.RemoveAt(0);//移除武器
                            int x = SingleObject.GetSingle().BG.ListMonster[i].X;
                            int y = SingleObject.GetSingle().BG.ListMonster[i].y;
                            SingleObject.GetSingle().BG.ListMonster.RemoveAt(i);
                            SingleObject.GetSingle().BG.ListGoods.Add(FactoryGoods.createGoods(x, y + 5, "Gold"));
                            tag = 2;
                            SoundPlayer.MonsterDie_BGM();
                            break;
                        }
                    }
                    if (tag == 0)
                    {
                        this.X = this.X - 30;
                    }
                }
                else if ((SingleObject.GetSingle().BG.ListWeapon.Count() != 0))
                {
                    SingleObject.GetSingle().BG.ListWeapon.RemoveAt(0);//移除武器
                }
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
                g.DrawImage(img[index], this.X+map.X, this.Y+map.Y, w, h);
                index++;
            }      
        }
    }
}