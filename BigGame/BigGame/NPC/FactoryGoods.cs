using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                goods = new Blood(x, y, 30, 40);
            }
            else if (goodsName == "Torch")
            {
                goods = new Torch(x, y, 30, 30);
            }
            else if (goodsName == "Door")
            {
                goods = new Door(x, y, 120, 120);
            }
            else if (goodsName == "Foods")
            {
                Random r = new Random(unchecked((int)DateTime.Now.Ticks)); //系统时间为参数
                goods = new Foods(x, y, 30, 30, r.Next(0, 40));
            }
            else
            {
                goods = new Gold(x, y, 30, 30);
            }
            return goods;
        }
    }
}
