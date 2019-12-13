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
            switch (goodsName)
            {
                case "Fire":
                    goods = new Fire(x, y, 50, 50);
                    break;
                case "Blood":
                    goods = new Blood(x, y, 30, 40);
                    break;
                case "Torch":
                    goods = new Torch(x, y, 30, 30);
                    break;
                case "Door":
                    goods = new Door(x, y, 120, 120);
                    break;
                case "Foods":
                    Random r = new Random(unchecked((int)DateTime.Now.Ticks)); //系统时间为参数
                    goods = new Foods(x, y, 30, 30, r.Next(0, 40));
                    break;
                case "GoldenBag":
                    goods = new GoldenBag(x, y, 200, 200);
                    break;
                default:
                    goods = new Gold(x, y, 30, 30);
                    break;
            }
            return goods;
        }
    }
}
