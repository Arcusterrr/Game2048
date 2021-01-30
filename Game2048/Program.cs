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

        void Start()
        {
            Model model = new Model(4);
            model.Start();
            while (true)
            {
                Show();
                switch (Console.ReadKey(false).Key)
                {
                    case ConsoleKey.LeftArrow:  model.Left(); break;
                    case ConsoleKey.RightArrow: model.Right(); break;
                    case ConsoleKey.UpArrow:    model.Up(); break;
                    case ConsoleKey.DownArrow:  model.Down(); break;
                    case ConsoleKey.Escape:     model.Start(); break;
                }
            }
        }

        void Show(Model model)
        {

        }
    }
}
