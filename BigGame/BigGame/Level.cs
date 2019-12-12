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

namespace BigGame
{
    class Level
    {


        public static void InitialGame_1(Form1 form)
        {
            Heroine h = new Heroine(0, 400, 100, 100, "唐妮");

            Monster fly = FactoryM.createMonster(2000, "fly");
            Monster walk = FactoryM.createMonster(500, "walk");
            Monster walk1 = FactoryM.createMonster(1000, "Walk");

            Goods fire = FactoryGoods.createGoods(150, 550, "Fire");
            Goods blood = FactoryGoods.createGoods(570, 350, "Blood");
            Goods gold = FactoryGoods.createGoods(700, 520, "Gold");
            Goods Door = FactoryGoods.createGoods(2750, 270, "Door");
            Goods torch = FactoryGoods.createGoods(150, 450, "Torch");
            Goods torch1 = FactoryGoods.createGoods(500, 450, "Torch");
            Goods foods = FactoryGoods.createGoods(500, 350, "Foods");
            Goods foods1 = FactoryGoods.createGoods(1200, 520, "Foods");
            Goods foods2 = FactoryGoods.createGoods(800, 520, "Foods");
            Goods foods3 = FactoryGoods.createGoods(2000, 350, "Foods");
            Goods foods4 = FactoryGoods.createGoods(2500, 350, "Foods");

            Life life_UI = new Life(50, 10, 20, 20);
            Listing list_UI = new Listing(600, 30);

            Hero_GetGoods gold_list = new Hero_GetGoods();

            //记录窗体信息
            //加载背景图片
            SingleObject.GetSingle().AddGameObject(new BackGround(0, 0, 20));
            SingleObject.GetSingle().BG.SetCamera(new Rectangle(form.Location, form.Size));
            //加载测试游戏对象
            SingleObject.GetSingle().BG.TP = h;
            //加入怪物
            SingleObject.GetSingle().BG.ListMonster.Add(fly);
            SingleObject.GetSingle().BG.ListMonster.Add(walk);
            SingleObject.GetSingle().BG.ListMonster.Add(walk1);
            //加入物品
            SingleObject.GetSingle().BG.ListGoods.Add(fire);
            SingleObject.GetSingle().BG.ListGoods.Add(blood);
            SingleObject.GetSingle().BG.ListGoods.Add(gold);
            SingleObject.GetSingle().BG.ListGoods.Add(torch);
            SingleObject.GetSingle().BG.ListGoods.Add(torch1);
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
    }
}
