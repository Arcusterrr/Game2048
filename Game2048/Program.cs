using BL.Game2048;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2048
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Start();
        }

        public int getUserNumber()
        {
            Console.WriteLine("Введите размер поля:");
            int result = 0;

            if(Int32.TryParse(Console.ReadLine(), out result) && result >= 3 && result <= 8)
            {
                return result;
            } else
            {
                Console.WriteLine("Нужно ввести число");
                return getUserNumber();
            }
        }

        void Start()
        {
            int mapSize = getUserNumber();

            Model model = new Model(mapSize);

            model.Start();
            while (true)
            {
                model.IsGameOver();
                Show(model);
                switch (Console.ReadKey(false).Key)
                {
                    case ConsoleKey.LeftArrow:  model.Left(); break;
                    case ConsoleKey.RightArrow: model.Right(); break;
                    case ConsoleKey.UpArrow:    model.Up(); break;
                    case ConsoleKey.DownArrow:  model.Down(); break;
                    case ConsoleKey.Escape:     return;
                }
            }
        }

        void Show(Model model)
        {
            Console.Clear();
            for (int y = 0; y < model.Size; y++)
            {
                for (int x = 0; x < model.Size; x++)
                {
                    Console.SetCursorPosition(x * 5 + 5, y * 2 + 2);
                    int number = model.GetMap(x, y);
                    Console.Write(number == 0 ? " . " : " " + number.ToString() + " ");
                }
            }
            if (model.isGameOver)
            {
                Console.WriteLine("Game Over");
            }
            else
            {
                Console.WriteLine("\n\n\n\n\n\n Still play");
            }
        }
    }
}
