using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Game2048
{
    public class Model
    {
        static Random ran = new Random();
        Map map;
        public int Size { get { return map.Size; } }

        public bool isGameOver;
        bool moved;
        public Model(int size)
        {
            map = new Map(size);
        }

        public string DisplayMap()=>map.DisplayMap();
        
        public bool IsGameOver()
        {
            if (isGameOver) 
                return isGameOver;
            for(int x = 0; x < Size; x++)
            {
                for(int y = 0; y < Size; y++)
                {
                    if(map.Get(x,y) == 0)
                    {
                        return false;
                    }
                }
            }

            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    if (map.Get(x, y) == map.Get(x+1, y) || map.Get(x,y) == map.Get(x, y+1))
                    {
                        return false;
                    }
                }
            }
            isGameOver = true;
            return isGameOver;
        }

        public void Start()
        {
            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    map.Set(x, y, 0);
                }
            }
            AddRandomNumber();
            AddRandomNumber();
        }

        private void AddRandomNumber()
        {
            if (isGameOver) return;
            int x = ran.Next(0, map.Size);
            int y = ran.Next(0, map.Size);
            if(map.Get(x,y) == 0)
            {
                map.Set(x, y, ran.Next(1, 3) * 2);
                return;
            }
            else
            {
                AddRandomNumber();
            }
        }

        private void Lift(int x, int y, int sx, int sy)
        {
            if(map.Get(x,y) > 0)
                while (map.Get(x+sx, y+sy) == 0)
                {
                    map.Set(x + sx, y + sy, map.Get(x, y));
                    map.Set(x, y, 0);
                    x += sx;
                    y += sy;
                    moved = true;

                }
        }

        private void Join(int x, int y, int sx, int sy)
        {
            if(map.Get(x,y)>0)
                if(map.Get(x+sx, y+sy) == map.Get(x, y))
                {
                    map.Set(x + sx, y + sy, map.Get(x, y) * 2);
                    while(map.Get(x-sx, y - sy) > 0)
                    {
                        map.Set(x, y, map.Get(x - sx, y - sy));
                        x -= sx;
                        y -= sy;
                        moved = true;

                    }
                    map.Set(x, y, 0);
                }
        }

        public void Left()
        {
            moved = false;
            for(int y = 0; y < map.Size; y++)
            {
                for(int x = 1; x < map.Size; x++)
                {
                    Lift(x, y, -1, 0);
                }
                for (int x = 1; x < map.Size; x++)
                {
                    Join(x, y, -1, 0);
                }
            }
            if(moved) AddRandomNumber();
        }

        public void Right()
        {
            moved = false;
            for (int y = 0; y < map.Size; y++)
            {
                for (int x = map.Size - 2; x >= 0; x--)
                {
                    Lift(x, y, +1, 0);
                }
                for (int x = map.Size - 2; x >= 0; x--)
                {
                    Join(x, y, +1, 0);
                }
            }
            if (moved) AddRandomNumber();
        }

        public void Up()
        {
            moved = false;
            for (int x = 0; x < map.Size; x++)
            {
                for(int y = 1; y < map.Size; y++)
                {
                    Lift(x, y, 0, -1);
                }
                for (int y = 1; y < map.Size; y++)
                {
                    Join(x, y, 0, -1);
                }
            }
            if(moved) AddRandomNumber();
        }

        public void Down()
        {
            moved = false;
            for (int x = 0; x < map.Size; x++)
            {
                for (int y = map.Size - 2; y >= 0; y--)
                {
                    Lift(x, y, 0, +1);
                }
                for (int y = map.Size - 2; y >= 0; y--)
                {
                    Join(x, y, 0, +1);
                }
            }
            if (moved) AddRandomNumber();
        }

        public int GetMap(int x, int y)
        {
            return map.Get(x, y);
        }
    }
}
