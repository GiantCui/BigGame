using BigGame.Map;
using BigGame.Role;
using BigGame.Role.HERO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BigGame.FactoryMonster;

namespace BigGame
{
    class SingleObject
    {
        #region 单例设计模式
        //1.声明全局唯一对象
        private static SingleObject _single;
        //2.构造函数私有化
        private SingleObject() { }
        //3.提供一个静态函数返回一个唯一对象
        public static SingleObject GetSingle()
        {
            if (_single == null)
            {
                _single = new SingleObject();
            }
            return _single;
        }
        #endregion

        public void test()
        {
            MessageBox.Show("this is a test");
        }

        //背景对象
        public BackGround BG { get; set; }
        
        public void AddGameObject(GameObject go)
        {
            if(go is BackGround)
            {
                BG = go as BackGround;
            }
            
        }

        //绘制游戏对象
        public void Draw(Graphics g)
        {
            BG.Draw(g);
        }
    }
}
