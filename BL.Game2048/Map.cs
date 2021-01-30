using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Game2048
{
    class Map
    {
        public int Size { get; private set; }
        public int[,] map;

        public Map(int size)
        {
            Size = size;
            map = new int[size, size];
        }
        public string DisplayMap()
        {
            string result = "";
            for(int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    result += map[x, y];
                    result += " | ";
                }
            }
            return result;
        }
        public int Get(int x, int y)
        {
            if (OnMap(x, y))
                return map[x, y];
            return -1;
        }

        public void Set(int x, int y, int number)
        {
            if (OnMap(x, y))
                map[x, y] = number;
        }

        public bool OnMap(int x, int y)
        {
            return x >= 0 && x < Size && y >= 0 && y < Size;
        }
    }
}
