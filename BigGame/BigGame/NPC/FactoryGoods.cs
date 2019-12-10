using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigGame.NPC
{
    class FactoryGoods
    {
        public static Goods createGoods(int x, int y,string goodsName)
        {
            Goods goods;
            if (goodsName == "Fire")
            {
                goods = new Fire(x, y, 50, 50);
            }
            else if(goodsName == "Blood")
            {
                goods = new Blood(x, y, 50, 50);
            }
            else
            {
                goods = new Gold(x, y, 50, 50);
            }
            return goods;
        }
    }
}
