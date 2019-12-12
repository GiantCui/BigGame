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
            if (monsterType == "fly")
            {
                monster = new MonsterFly(x, y, 100, 100, "崔开金怪怪", 100);
            }
            else if (monsterType == "Boss")
            {
                monster = new Boss(x, y, 400, 400, "陈晓蝶", 100);
            }
            else
            {
                monster = new MonsterWalk(x, y, 100, 100, "宝琴怪", 100);
            }
            return monster;
        }
    }
}
