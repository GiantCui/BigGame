using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigGame.Role
{
    class monster:GameObject
    {
        static Bitmap[] image =
        {
            Properties.Resources.alien_enemy_flying1,
            Properties.Resources.alien_enemy_flying2,
            Properties.Resources.alien_enemy_flying3,
            Properties.Resources.alien_enemy_flying4,
            Properties.Resources.alien_enemy_flying5,
            Properties.Resources.alien_enemy_flying6,
            Properties.Resources.alien_enemy_flying7,
            Properties.Resources.alien_enemy_flying8
        };

        public int anm_frame = 0;   //记录当前帧
        public long last_frame_time = 0;    //记录上一帧时间
        public long frame_internal = 500; //记录两帧间隔

        public monster(int x,int y, int width, int height,int hp):base(int x, int y, int width, int height)
        {

        }
        public override void InitializeImages()
        {
            throw new NotImplementedException();
        }
        public override void Draw(Graphics g)
        {
            throw new NotImplementedException();
        }
    }
}
