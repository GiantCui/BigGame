using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigGame.FactoryMonster
{

    class FactoryM
    {
        public static Monster createMonster(int x,int y,string monsterType) //需要怪物的坐标和怪物的类型
        {
            Monster monster;
            switch (monsterType)
            {
                case "fly":
                    monster = new MonsterFly(x, y, 100, 100, "崔开金怪怪", 100);
                    break;
                case "Boss":
                    monster = new Boss(x, y, 400, 400, "陈晓蝶", 100);
                    break;
                case "Mini":
                    monster = new MonsterMini(x, 565, 100, 100, "", 100); ;
                    break;
                default:
                    monster = new MonsterWalk(x, y, 100, 100, "宝琴怪", 100);
                    break;
            }
            return monster;
        }
    }
}
