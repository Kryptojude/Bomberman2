using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Bomberman2
{
    class Player
    {
        public static int ts;
        public static Bitmap[][] walkFrames = new Bitmap[3][];

        /// <summary>
        /// coordinates in map space, not world space
        /// </summary>
        public Point MapLocation;
        /// <summary>
        /// 4 = idle, 0 = walk up, 1 = walk right, etc.
        /// </summary>
        public int action = 0;
        public int frame = 0;

        public Player(int x, int y, ref int ts)
        {
            MapLocation = new Point(x, y);
            Player.ts = ts;
        }

        public Point getAbsoluteLocation()
        {
            return new Point(MapLocation.X * ts, MapLocation.Y * ts);
        }

        public Image getFrame()
        {
            return walkFrames[action][frame];
        }
    }
}
