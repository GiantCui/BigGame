using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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


    }
}
