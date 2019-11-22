﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigGame.Role.HERO
{
    public abstract class Hero : GameObject
    {
       
        public int speed = 50;
        public int anm_frame = 0;   //记录当前帧
        public long last_frame_time = 0;    //记录上一帧时间
        public long frame_internal = 150; //记录两帧间隔
        public Rectangle map { get; set; }   //记录地图坐标
        public Hero(int x, int y, int width, int height, string name)
              : base(x, y, width, height)
        {
            this.Name = name;
        }

        public string Name { get;  set; }
     //   public Image[][] Img { get => img; set => img = value; }

        public abstract void key_ctrl(KeyEventArgs e);


    }
}
