using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigGame.Role.HERO
{
    public abstract class Hero : GameObject
    {
        public Hero(int x, int y, int width, int height, string name)
              : base(x, y, width, height)
        {
            this.Name = name;
        }
        public string Name { get;  set; }
        public void key_ctrl(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                this.Y = this.Y - 5;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.Y = this.Y + 5;
            }
            if (e.KeyCode == Keys.Left)
            {
                this.X = this.X - 5;
            }
            if (e.KeyCode == Keys.Right)
            {
                this.X = this.X + 5;
            }
        }
        
    }
}
