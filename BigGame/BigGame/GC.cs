using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigGame
{
    static class GC
    {
        public const bool horizontal = true;
        public const bool vertical = false;
        public enum Direction
        {
            up = -1,
            down = 1,
            left = -1,
            right = 1
        }
    }
}
