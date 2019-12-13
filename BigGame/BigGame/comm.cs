using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigGame
{
    class comm
    {
        
        public static long Time()
        {
            DateTime dtl = new DateTime(1970, 1, 1);
            TimeSpan ts = DateTime.Now - dtl;
            return (long)ts.TotalMilliseconds;
        }

        public static void Wait_500()
        {
            long start = comm.Time();
            long end = start + 500;
            while (start < end)
            {
                start = comm.Time();
            }
        }
    }
}
