using BigGame.FactoryMonster;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigGame.UI
{
    class BossLife:GameObject
    {

        public static Image img;
        public static Image imgBack;

        public BossLife(int x, int y, int width, int height) : base(x, y, width, height)
        {
            InitializeImages();

        }

        public override void Draw(Graphics g)
        {
            for (int i = 0; i < SingleObject.GetSingle().BG.ListMonster.Count; i++)
            {
                if (SingleObject.GetSingle().BG.ListMonster[i] is Boss)
                {
                    Boss boss = SingleObject.GetSingle().BG.ListMonster[i] as Boss;
                    if (boss.X - SingleObject.GetSingle().BG.TP.X < 500)
                    {
                        float life = (float)(boss.Hp/2) / 100;
                        int w = (int)(img.Width * life);
                        g.DrawImage(imgBack, boss.X + 30 + boss.map.X, boss.Y - 80, imgBack.Width/2, imgBack.Height / 2);
                        g.DrawImage(img, boss.X + 30 + boss.map.X, boss.Y - 80, w, img.Height/2);
                    }
                }
            }
        }

        public override void InitializeImages()
        {
            img = Properties.Resources.血条2;
            imgBack = Properties.Resources.血条3;
        }
        void Init()
        {
            
        }

    }
}
