using BigGame.Action;
using BigGame.FactoryMonster;
using BigGame.Map;
using BigGame.NPC;
using BigGame.Role.HERO;
using BigGame.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigGame
{
    class Level
    {
        static Rectangle rec;

        public static void InitialGame_1(Form1 form)
        {
            BackGround.BGImage = Properties.Resources.background4; ;
            BackGround.BGunder = Properties.Resources._5;

            Heroine h = new Heroine(0, 400, 100, 100, "唐妮");

            Monster fly_1 = FactoryM.createMonster(2000,440,"fly");
            Monster fly_2 = FactoryM.createMonster(1500, 250, "fly");
            Monster walk = FactoryM.createMonster(500, 520, "walk");
            Monster walk1 = FactoryM.createMonster(700,340, "Walk");

            Goods fire = FactoryGoods.createGoods(150, 550, "Fire");
            Goods blood = FactoryGoods.createGoods(570, 350, "Blood");
            Goods gold_1 = FactoryGoods.createGoods(700, 520, "Gold");
            Goods gold_2 = FactoryGoods.createGoods(730, 520, "Gold");
            Goods gold_3 = FactoryGoods.createGoods(760, 520, "Gold");
            Goods gold_4 = FactoryGoods.createGoods(670, 520, "Gold");
            Goods gold_5 = FactoryGoods.createGoods(1510, 360, "Gold");
            Goods gold_6 = FactoryGoods.createGoods(1540, 350, "Gold");
            Goods gold_7 = FactoryGoods.createGoods(1570, 340, "Gold");
            Goods gold_8 = FactoryGoods.createGoods(1600, 330, "Gold");
            Goods Door = FactoryGoods.createGoods(2795, 300, "Door");
            Goods torch = FactoryGoods.createGoods(150, 450, "Torch");
            Goods torch1 = FactoryGoods.createGoods(500, 450, "Torch");
            Goods torch2 = FactoryGoods.createGoods(1500, 300, "Torch");
            Goods torch3 = FactoryGoods.createGoods(1900, 320, "Torch");
            Goods torch4 = FactoryGoods.createGoods(2250, 320, "Torch");
            Goods torch5 = FactoryGoods.createGoods(500, 450, "Torch");
            Goods torch6 = FactoryGoods.createGoods(1100, 300, "Torch");
            Goods foods = FactoryGoods.createGoods(500, 350, "Foods");
            Goods foods1 = FactoryGoods.createGoods(1200, 520, "Foods");
            Goods foods2 = FactoryGoods.createGoods(2000, 350,"Foods");
            Goods foods3 = FactoryGoods.createGoods(800, 520, "Foods");
            Goods foods4 = FactoryGoods.createGoods(2500, 350, "Foods");

            Life life_UI = new Life(50, 10, 20, 20);
            Listing list_UI = new Listing(600, 30);

            Hero_GetGoods gold_list = new Hero_GetGoods();

            //记录窗体信息
            //加载背景图片
            SingleObject.GetSingle().AddGameObject(new BackGround(0, 0, 20));
            rec = new Rectangle(form.Location, form.Size);
            SingleObject.GetSingle().BG.SetCamera(rec);

            //加载测试游戏对象
            SingleObject.GetSingle().BG.TP = h;
            //加入怪物
            SingleObject.GetSingle().BG.ListMonster.Add(fly_1);
            SingleObject.GetSingle().BG.ListMonster.Add(fly_2);
            SingleObject.GetSingle().BG.ListMonster.Add(walk);
            SingleObject.GetSingle().BG.ListMonster.Add(walk1);
            //加入物品
            SingleObject.GetSingle().BG.ListGoods.Add(fire);
            SingleObject.GetSingle().BG.ListGoods.Add(blood);
            SingleObject.GetSingle().BG.ListGoods.Add(gold_1);
            SingleObject.GetSingle().BG.ListGoods.Add(gold_2);
            SingleObject.GetSingle().BG.ListGoods.Add(gold_3);
            SingleObject.GetSingle().BG.ListGoods.Add(gold_4);
            SingleObject.GetSingle().BG.ListGoods.Add(gold_5);
            SingleObject.GetSingle().BG.ListGoods.Add(gold_6);
            SingleObject.GetSingle().BG.ListGoods.Add(gold_7);
            SingleObject.GetSingle().BG.ListGoods.Add(gold_8);
            SingleObject.GetSingle().BG.ListGoods.Add(torch);
            SingleObject.GetSingle().BG.ListGoods.Add(torch1);
            SingleObject.GetSingle().BG.ListGoods.Add(torch2);
            SingleObject.GetSingle().BG.ListGoods.Add(torch3);
            SingleObject.GetSingle().BG.ListGoods.Add(torch4);
            SingleObject.GetSingle().BG.ListGoods.Add(torch5);
            SingleObject.GetSingle().BG.ListGoods.Add(torch6);
            SingleObject.GetSingle().BG.ListGoods.Add(Door);
            SingleObject.GetSingle().BG.ListGoods.Add(foods);
            SingleObject.GetSingle().BG.ListGoods.Add(foods1);
            SingleObject.GetSingle().BG.ListGoods.Add(foods2);
            SingleObject.GetSingle().BG.ListGoods.Add(foods3);
            SingleObject.GetSingle().BG.ListGoods.Add(foods4);
            //加载UI界面
            SingleObject.GetSingle().AddGameObject(life_UI);
            SingleObject.GetSingle().AddGameObject(list_UI);
            //创建金币集对象
            SingleObject.GetSingle().BG.GoldList = gold_list;

        }

        public static void InitialGame_2()
        {
            BackGround backGround = new BackGround(0, 0, 20);
            BackGround.BGImage = Properties.Resources.Caverns;
            BackGround.BGunder = Properties.Resources.Caverns1;
            SingleObject.GetSingle().AddGameObject(backGround);
            Heroine h = new Heroine(0, 400, 100, 100, "唐妮");


            //Boss
            Monster boss = FactoryM.createMonster(1500, 270, "Boss");

            Goods fire = FactoryGoods.createGoods(750, 620, "Fire");
            Goods blood = FactoryGoods.createGoods(900, 600, "Blood");
            Goods blood1 = FactoryGoods.createGoods(750, 530, "Blood");
            Goods gold = FactoryGoods.createGoods(760, 460, "Gold");
            Goods gold_1 = FactoryGoods.createGoods(200, 320, "Gold");
            Goods gold_2 = FactoryGoods.createGoods(230, 320, "Gold");
            Goods gold_3 = FactoryGoods.createGoods(260, 320, "Gold");
            Goods gold_4 = FactoryGoods.createGoods(290, 320, "Gold");
            Goods Door = FactoryGoods.createGoods(2750, 270, "Door");
            Goods torch = FactoryGoods.createGoods(150, 270, "Torch");
            Goods torch1 = FactoryGoods.createGoods(500, 270, "Torch");
            Goods foods = FactoryGoods.createGoods(500, 320, "Foods");
     
            //UI
            Life life_UI = new Life(50, 10, 20, 20);
            Listing list_UI = new Listing(600, 30);
            BossLife bossLife = new BossLife(700, 20, 20, 20);

            Hero_GetGoods gold_list = new Hero_GetGoods();

            //记录窗体信息
            //加载背景图片
            SingleObject.GetSingle().AddGameObject(new BackGround(0, 0, 20));
            SingleObject.GetSingle().BG.SetCamera(rec);
            //加载测试游戏对象
            SingleObject.GetSingle().BG.TP = h;
            //加入物品
            SingleObject.GetSingle().BG.ListMonster.Add(boss);
            SingleObject.GetSingle().BG.ListGoods.Add(fire);
            SingleObject.GetSingle().BG.ListGoods.Add(blood);
            SingleObject.GetSingle().BG.ListGoods.Add(blood1);
            SingleObject.GetSingle().BG.ListGoods.Add(gold);
            SingleObject.GetSingle().BG.ListGoods.Add(gold_1);
            SingleObject.GetSingle().BG.ListGoods.Add(gold_2);
            SingleObject.GetSingle().BG.ListGoods.Add(gold_3);
            SingleObject.GetSingle().BG.ListGoods.Add(gold_4);
            SingleObject.GetSingle().BG.ListGoods.Add(torch);
            SingleObject.GetSingle().BG.ListGoods.Add(torch1);
            SingleObject.GetSingle().BG.ListGoods.Add(Door);
            SingleObject.GetSingle().BG.ListGoods.Add(foods);
            //加载UI界面
            SingleObject.GetSingle().AddGameObject(life_UI);
            SingleObject.GetSingle().AddGameObject(list_UI);
            SingleObject.GetSingle().AddGameObject(bossLife);
            //创建金币集对象
            SingleObject.GetSingle().BG.GoldList = gold_list;
        }
    }


}
