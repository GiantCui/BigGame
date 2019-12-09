﻿using BigGame.Map;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigGame.Role.HERO
{
    public class Heroine : Hero
    {
        public Image[][] img = new Image[3][];   

        public int face = 0;    //face=0默认为右，face=1默认为左
        public int index = 0;   //存储数组标志,0是静态，1是走路,2是打枪
        public int guntag = 0;  //记录拿枪状态
        public int g = 10;  //重力加速度
        public Heroine(int x, int y, int width, int height, string name)
           : base(x, y, width, height, name)
        {
            //继承自父类的属性
            this.Name = name;
        }

        public override void InitializeImages()
        {
            img[0] = new Image[1];
            img[0][0] = Properties.Resources.walk_5;
            img[1] = new Image[5];
            img[1][0] = Properties.Resources.walk_5;
            img[1][1] = Properties.Resources.walk_4;
            img[1][2] = Properties.Resources.walk_2;
            img[1][3] = Properties.Resources.walk_6;
            img[1][4] = Properties.Resources.walk_1;
            img[2] = new Image[1];
            img[2][0] = Properties.Resources.Layer_4;
        }

        public override void key_ctrl(KeyEventArgs e)
        {
            int b_up = BackGround.BGunder.GetPixel(this.X + 50, this.Y+20).B;
            int b_down = BackGround.BGunder.GetPixel(this.X + 50, this.Y + 90 + this.speed).B;
            int b_left = BackGround.BGunder.GetPixel(this.X + 50 - this.speed, this.Y + 90 + this.speed).B;
            int b_right = BackGround.BGunder.GetPixel(this.X + 50 + this.speed, this.Y + 90 + this.speed).B;
            if (e.KeyCode == Keys.J)
            {
                anm_frame = 0;
                index = 2;
                Weapon w = new Weapon(this.X, this.Y, 20, 20, this);
                SingleObject.GetSingle().BG.ListWeapon.Add(w);
            }
            else if (e.KeyCode == Keys.S && this.Y < map.Height - 120 && b_down > 250)
            {
            
                this.Y = this.Y + speed;
            }
            else if (e.KeyCode == Keys.W && this.Y - 300 > map.Y && b_up > 250)
            {
               
                // this.Y = (int)(yVelocity);
                //this.Y = this.Y - (int)(yVelocity);
                 this.Y = this.Y - 100;
            }
            else if (e.KeyCode == Keys.A && this.X > map.X - 30)
            {          
                index = 1;
                if (face != 1)
                {
                    overturn();
                    face = 1;
                }
                this.X = this.X - speed;
            }
            else if (e.KeyCode == Keys.D && this.X < map.Width - 100)
            {
                index = 1;
                if (face != 0)
                {
                    overturn();
                    face = 0;
                }            
                this.X = this.X + speed;
            }
            else
            {
                  index = 0;
            }          
        }

        public void overturn()
        {
            int i = 0,j;
            for(j = 0; j < 3; j++)
            {
               for(i=0;i<img[j].Length;i++)
                {
                    img[j][i].RotateFlip(RotateFlipType.Rotate180FlipY);                  
                }
            }   
        }


        public override void Draw(Graphics g)
        {
            
            if (comm.Time() - last_frame_time > frame_internal)
            {
                anm_frame++;
                last_frame_time = comm.Time();
            }
            if (anm_frame >= img[index].Length)
            {
                anm_frame = 0;
            }
            if(this.Y < map.Height - 120)
            {
               
            }
            float yVelocity = 0;
            float jumpSpeed = 15.0f;
             
            float gravity = 0.98f;
            yVelocity = jumpSpeed;
            yVelocity -= (1 / 2) * (gravity * (comm.Time() - last_frame_time));
            this.Y = this.Y + (int)(yVelocity);
            this.OnMyValueChanged += WhenMove;
            // img[index][anm_frame].RotateFlip(RotateFlipType.Rotate180FlipY);
            g.DrawImage(img[index][anm_frame], this.X + map.X, this.Y + map.Y, this.Width, this.Height);
        }

        private void WhenMove()
        {
            if(BackGround.BGunder.Height < this.Y + this.Height)
            {
                this.y = BackGround.BGunder.Height - this.Height - 1;
            }
            int asd = BackGround.BGunder.GetPixel(0, 0).B;
            int val = BackGround.BGunder.GetPixel(this.X + 50, this.Y + this.Height).B;
            while (val < 10)
            {
                this.y--;
                val = BackGround.BGunder.GetPixel(this.X + 50, this.Y + this.Height).B;
            }
        }

        //public  void KeyPress(KeyPressEventArgs e)
        //{
        //    if(e.KeyChar=='j'|| e.KeyChar == 'J')
        //    {
        //        index = 2;
        //        anm_frame = 0;
        //        guntag = 1;
        //    }
        //}
    }
}
