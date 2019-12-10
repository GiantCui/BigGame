using BigGame.Role;
using BigGame.Role.HERO;
using BigGame.FactoryMonster;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigGame.NPC;
using BigGame.Action;

namespace BigGame.Map
{
    public class BackGround:GameObject
    {
        public static Bitmap BGImage = Properties.Resources.background4;
        public static Bitmap BGunder = Properties.Resources._5;
        public int speed { get; set; }
        public Hero TP { get; set; }
        private Hero_GetGold goldList;
        public List<Monster> ListMonster = new List<Monster>();  //怪物集合
        public List<Goods> ListGoods = new List<Goods>();   //物品集合
        public List<Weapon> ListWeapon = new List<Weapon>();
        //创建相机
        public Rectangle Camera { get; set; }
        public Hero_GetGold GoldList { get => goldList; set => goldList = value; }

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
            //更新角色存储的地图信息
            TP.map = new Rectangle(this.X, this.Y, BGImage.Width, BGImage.Height);
            TP.BackGd = this;
            TP.Draw(g);
            for(int i = 0; i < ListMonster.Count; i++)
            {
                ListMonster[i].map = new Rectangle(this.X, this.Y, BGImage.Width, BGImage.Height);
                ListMonster[i].Draw(g);
            }
            for (int i = 0; i < ListWeapon.Count; i++)
            {
                ListWeapon[i].map = new Rectangle(this.X, this.Y, BGImage.Width, BGImage.Height);
                ListWeapon[i].Draw(g);
            }
            /*
            for (int i = 0; i < ListGoods.Count; i++)
            {
                ListGoods[i].map = new Rectangle(this.X, this.y, BGImage.Width, BGImage.Height);
                ListGoods[i].Draw(g);
            }
            */
            GoldList.Draw(g);
        }

        public override void InitializeImages()
        {
            
        }
    }
}
