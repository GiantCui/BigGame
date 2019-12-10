using BigGame.Map;
using BigGame.NPC;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigGame.Action
{
    public class Hero_GetGold
    {

        public  void Draw(Graphics g)
        {
            int i;
            int x = SingleObject.GetSingle().BG.X;
            int y= SingleObject.GetSingle().BG.Y;
            int w = BackGround.BGImage.Width;
            int h = BackGround.BGImage.Height;
            for (i=0;i< SingleObject.GetSingle().BG.ListGoods.Count();i++)
            {
                GameObject god = SingleObject.GetSingle().BG.ListGoods[i];
                if (god.GetRectangle().IntersectsWith(SingleObject.GetSingle().BG.TP.GetRectangle()))
                {
                   // if(god is Gold)
                   // {
                    //    god.
                  //  }
                  //  S
                    SingleObject.GetSingle().BG.ListGoods.RemoveAt(i);
                }
                else
                {
                    SingleObject.GetSingle().BG.ListGoods[i].map = new Rectangle(x, y,w, h);
                    SingleObject.GetSingle().BG.ListGoods[i].Draw(g);
                }
            }
          
        }
    }
}
