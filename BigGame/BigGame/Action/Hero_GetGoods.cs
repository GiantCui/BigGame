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
    [Serializable]  //可序列化
    public class Hero_GetGoods
    {

        public  void Draw(Graphics g)
        {
            int i;
            int x = SingleObject.GetSingle().BG.X;
            int y= SingleObject.GetSingle().BG.Y;
            int w = SingleObject.GetSingle().BG.BGImage.Width;
            int h = SingleObject.GetSingle().BG.BGImage.Height;
            for (i=0;i< SingleObject.GetSingle().BG.ListGoods.Count();i++)
            {
               // GameObject god = SingleObject.GetSingle().BG.ListGoods[i];
                if (SingleObject.GetSingle().BG.ListGoods[i].GetRectangle().IntersectsWith(SingleObject.GetSingle().BG.TP.GetRectangle()))
                {
                    SingleObject.GetSingle().BG.ListGoods[i].Buffer();
                    if((SingleObject.GetSingle().BG.ListGoods[i] is Fire) ||(SingleObject.GetSingle().BG.ListGoods[i] is Torch) 
                        ||(SingleObject.GetSingle().BG.ListGoods[i] is Door))
                    {
                        SingleObject.GetSingle().BG.ListGoods[i].map = new Rectangle(x, y, w, h);
                        SingleObject.GetSingle().BG.ListGoods[i].Draw(g);
                    }
                    else{
                        SingleObject.GetSingle().BG.ListGoods.RemoveAt(i);
                    }           
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
