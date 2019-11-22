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
            if (e.KeyCode == Keys.J)
            {
                index = 2;
                anm_frame = 0;
                guntag = 1;
            }
            else
            {
                guntag = 0;
            }

            if (e.KeyCode == Keys.Down)
            {
                this.Y = this.Y + speed;
            }
            else if (e.KeyCode == Keys.Up)
            {
                this.Y = this.Y - speed;
            }
            else if (e.KeyCode == Keys.Left)
            {
                if (guntag == 0)
                {
                    index = 1;
                }
                if (face != 1)
                {
                    overturn();
                    face = 1;
                }         
                this.X = this.X - speed;
            }
            else if (e.KeyCode == Keys.Right)
            {
                if (guntag == 0)
                {
                    index = 1;
                }
                if (face != 0)
                {
                    overturn();
                    face = 0;
                }            
                this.X = this.X + speed;
            }
            else
            {
                if (guntag == 0)
                {
                    index = 0;
                }  
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

            // img[index][anm_frame].RotateFlip(RotateFlipType.Rotate180FlipY);
            g.DrawImage(img[index][anm_frame], this.X + map.X, this.Y + map.Y, this.Width, this.Height);
        }
    }
}
