﻿using BigGame.Map;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BigGame;
using BigGame.Role;
using BigGame.Role.HERO;
using BigGame.FactoryMonster;
using BigGame.UI;
using BigGame.NPC;

namespace BigGame
{
    public partial class Form1 : Form
    {
        Heroine h=new Heroine(0,400,100,100,"唐妮");

        Monster fly = FactoryM.createMonster(2000, "fly");
        Monster walk = FactoryM.createMonster(500, "walk");
        Monster walk1 = FactoryM.createMonster(1000, "Walk");

        Goods fire = FactoryGoods.createGoods(100,550, "Fire");
        Goods blood = FactoryGoods.createGoods(300, 520, "Blood");
        Goods gold = FactoryGoods.createGoods(700, 520, "Gold");

        Life life_UI = new Life(50, 10, 20, 20);
        public Form1()
        {
            InitializeComponent();
            InitialGame();
        }

        public void InitialGame()
        {
            //记录窗体信息
            //加载背景图片
            SingleObject.GetSingle().AddGameObject(new BackGround(0, 0, 20));
            SingleObject.GetSingle().BG.SetCamera(new Rectangle(this.Location, this.Size));
            //加载测试游戏对象
          //  SingleObject.GetSingle().AddGameObject(new TestPlayer(150, 180));
           // SingleObject.GetSingle().AddGameObject(h );
            SingleObject.GetSingle().BG.TP = h;
            // SingleObject.GetSingle().AddGameObject(fly);
            // SingleObject.GetSingle().AddGameObject(walk);
            //加入怪物
            SingleObject.GetSingle().BG.ListMonster.Add(fly);
            SingleObject.GetSingle().BG.ListMonster.Add(walk);
            SingleObject.GetSingle().BG.ListMonster.Add(walk1);
            //加入物品
            SingleObject.GetSingle().BG.ListGoods.Add(fire);
            SingleObject.GetSingle().BG.ListGoods.Add(blood);
            SingleObject.GetSingle().BG.ListGoods.Add(gold);
            SingleObject.GetSingle().AddGameObject(life_UI);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //测试
            //SingleObject.GetSingle().test();
            //在窗体加载的时候，解决窗体闪烁问题
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.ResizeRedraw
                | ControlStyles.AllPaintingInWmPaint, true);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            SingleObject.GetSingle().Draw(e.Graphics);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            h.key_ctrl(e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            h.index = 0;
            h.key_upctrl(e);
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //h.KeyPress(e);
        }
    }
}
