﻿using BigGame.Map;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BigGame.Role.HERO
{
    [Serializable]  //可序列化
    public class Heroine : Hero
    {
        public Image[][] img = new Image[4][];           
        
        public int guntag = 0;  //记录拿枪状态
        
        public int g = 10;  //重力加速度

        bool A_down, S_down, D_down, J_down, K_down, K_up, J_up = false;

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
            img[3] = new Image[5];
            img[3][0] = Properties.Resources.dead_1;
            img[3][1] = Properties.Resources.death2;
            img[3][2] = Properties.Resources.death3;
            img[3][3] = Properties.Resources.death4;
            img[3][4] = Properties.Resources.death5;
        }

        public override void key_ctrl(KeyEventArgs e)
        {
            if(e.KeyCode == Keys.K && K_up)
            {
                K_down = true;
                K_up = false;
                index = 2;
                SoundPlayer.bang_BGM();
            }
            else if(e.KeyCode == Keys.J && J_up)
            {
                J_down = true;
                J_up = false;
                
            }
            else if(e.KeyCode == Keys.A)
            {
                A_down = true;
                index = 1;
                SoundPlayer.run_BGM();
            }
            else if(e.KeyCode == Keys.D)
            {
                D_down = true;
                index = 1;
                SoundPlayer.run_BGM();
            }
            else
            {
               
                index = 0;
            }
                     
        }

        public override void key_upctrl(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.K)
            {
                K_down = false;
                K_up = true;
                if (A_down || D_down)
                {
                    index = 1;
                }
                else
                {
                    index = 0;
                }
            }
            else if (e.KeyCode == Keys.J)
            {
                J_down = false;
                J_up = true;
                SoundPlayer.Jump_BGM();
                if (A_down || D_down)
                {
                    index = 1;
                }
                else
                {
                    index = 0;
                }
            }
            else if (e.KeyCode == Keys.A)
            {
                A_down = false;
                SoundPlayer.stop_run();
            }
            else if (e.KeyCode == Keys.D)
            {
                D_down = false;
                SoundPlayer.stop_run();
            }
          
        }

        public void move()
        {
            if(this.Y - 100 < 0)
            {
                this.Y = 100;
            }
            int b_up = SingleObject.GetSingle().BG.BGunder.GetPixel(this.X + 50, this.Y - 100).B;
            int b_down = SingleObject.GetSingle().BG.BGunder.GetPixel(this.X + 50, this.Y + 90 + this.speed).B;
            int b_left = SingleObject.GetSingle().BG.BGunder.GetPixel(this.X + 40 - this.speed, this.Y + 90 + this.speed).B;
            int b_right = SingleObject.GetSingle().BG.BGunder.GetPixel(this.X + 50 + this.speed, this.Y + 90 + this.speed).B;

            if (K_down)
            {
                K_down = false;
                anm_frame = 0;
                
                Weapon w = new Weapon(this.X, this.Y, 20, 20, this);
                SingleObject.GetSingle().BG.ListWeapon.Add(w);
                
            }
            
            if (S_down && this.Y < map.Height - 120 && b_down > 250)
            {

                this.Y = this.Y + speed;
            }
            if (J_down && this.Y - 100 > 0 && b_up > 250)
            {
                J_down = false;
                this.Y = this.Y - 100;
            }
            if (A_down && this.X > map.X - 30 && b_left > 250)
            {              
                if (face != 1)
                {
                    overturn();
                    face = 1;
                }
                this.X = this.X - speed;
            }
            if (D_down && this.X < map.Width - 100 && b_right > 250)
            {              
                if (face != 0)
                {
                    overturn();
                    face = 0;
                }
                this.X = this.X + speed;          
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

        public bool Judge_life()
        {
            if (this.currentlife == 0)
            {
                index = 3;
                return true;
            }
            return false;
        }

        public override void Draw(Graphics g)
        {
            if (Judge_life()==false)
            {
                move();
                if (comm.Time() - last_frame_time > frame_internal)
                {
                    anm_frame++;
                    last_frame_time = comm.Time();
                }
                if (anm_frame >= img[index].Length)
                {
                    anm_frame = 0;
                }             
                float yVelocity = 0;
                float jumpSpeed = 15.0f;    //重力加速度
                float gravity = 0.98f;
                yVelocity = jumpSpeed;
                yVelocity -= (1 / 2) * (gravity * (comm.Time() - last_frame_time));
                this.Y = this.Y + (int)(yVelocity);
                this.OnMyValueChanged += WhenMove;        
            }
            else
            {
                if (comm.Time() - last_frame_time > frame_internal)
                {
                    anm_frame++;
                    last_frame_time = comm.Time();
                }
                if (anm_frame >= img[index].Length)
                {
                    anm_frame = img[index].Length - 1;                  
                    finsh = true;
                }
            }
            g.DrawImage(img[index][anm_frame], this.X + map.X, this.Y + map.Y, this.Width, this.Height);
        }

        private void WhenMove()
        {
            if(SingleObject.GetSingle().BG.BGunder.Height < this.Y + this.Height)
            {
                this.y = SingleObject.GetSingle().BG.BGunder.Height - this.Height - 1;
            }
            int asd = SingleObject.GetSingle().BG.BGunder.GetPixel(0, 0).B;
            int val = SingleObject.GetSingle().BG.BGunder.GetPixel(this.X + 50, this.Y + this.Height).B;
            while (val < 10)
            {
                this.y--;
                val = SingleObject.GetSingle().BG.BGunder.GetPixel(this.X + 50, this.Y + this.Height).B;
            }
        }
    }
}
