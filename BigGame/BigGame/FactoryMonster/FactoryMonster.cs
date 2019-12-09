using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigGame.FactoryMonster
{
    class FactoryM
    {
        public static Monster createMonster(int x, string monsterType) //需要怪物的坐标和怪物的类型
        {
            Monster monster;
            if (monsterType == "fly")
            {
                monster = new MonsterFly(x, 400, 100, 100, "苍蝇怪", 100);
            }
            else
            {
                monster = new MonsterWalk(x, 515, 100, 100, "螃蟹怪", 100);
            }
            return monster;
        }
    }
}
