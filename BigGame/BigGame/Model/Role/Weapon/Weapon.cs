using BigGame.Role.HERO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigGame.Role
{
   public  class Weapon : GameObject
    {
        public Image[] img = new Image[2];
        private Hero hero;
        private bool Isattack = false;
        public Hero Hero { get => hero; set => hero = value; }
        public Weapon(int x, int y, int width, int height, Hero ob)
             : base(x, y, width, height)
        {
            this.Hero = ob;
        }

        public override void InitializeImages()
        {
            img[0] = Properties.Resources.bullet_1;
            img[1] = Properties.Resources.bullet_2;
        }

        public  void key_ctrl(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.J)
            {
                Isattack = true;
            }
        }

         public void Move()
        {
            this.Y = hero.Y;
            this.X = hero.X;
        }

        public override void draw(Graphics g)
        {
            if (Isattack)
            {
                Move(hero.pointloc);

            }
            else
            {
                if (Gameobject.Game.Flame != null)
                {
                    Gameobject.Game.Flame.RemoveAt(0);
                }
            }
            //   i = ra.Next(0,3);
            g.DrawImage(img[3], this.X, this.Y, this.With, this.High);
        }
    }
}
