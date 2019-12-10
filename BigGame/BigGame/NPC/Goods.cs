using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BigGame.NPC
{
    public abstract class Goods:GameObject
    {
        public int anm_frame = 0;   //记录当前帧
        public long last_frame_time = 0;    //记录上一帧时间
        public long frame_internal = 100; //记录两帧间隔
        public Rectangle map { get; set; }   //记录地图坐标
        public Goods(int x,int y,int width,int height):base(x, y, width, height)
        {  
        }

        public abstract void Buffer();
    }
}
