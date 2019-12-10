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
            for(i=0;i< SingleObject.GetSingle().BG.ListGoods.Count();i++)
            {
                if (SingleObject.GetSingle().BG.ListGoods[i].GetRectangle().IntersectsWith(SingleObject.GetSingle().BG.TP.GetRectangle()))
                {
                    SingleObject.GetSingle().BG.TP.score += 5;
                    SingleObject.GetSingle().BG.ListGoods.RemoveAt(i);
                }
                else
                {
                    SingleObject.GetSingle().BG.ListGoods[i].Draw(g);
                }
            }
          
        }
    }
}
