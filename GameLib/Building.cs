using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib
{
    public class Building
    {
        public int X { get { return Floors[0].X; } }
        public int Y { get { return Floors[0].Y; } }
        public int Width { get { return Floors[0].Width; } }
        public int Height { get { return Floors[0].Height; } }
        public Floor[] Floors { get; private set; }

        public string Name { get; set; }

        public Building(int x, int y, int width, int height, int floorCount)
        {
            Name = "New Building";
            Floors = new Floor[floorCount];
            for(int i = 0; i < floorCount; ++i)
            {
                Floors[i] = new Floor(x, y, width, height);
            }
        }
    }

    public class Floor
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Floor(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
    }
}
