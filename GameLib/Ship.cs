using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib
{
    public enum ShipType
    {
        ThreeMast
    }

    public class Ship
    {
        public ShipType Type { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }

        public Ship(int x, int y, ShipType type)
        {
            X = x;
            Y = y;
            Type = type;
        }
    }
}
