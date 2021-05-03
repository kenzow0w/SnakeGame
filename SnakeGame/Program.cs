using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace SnakeGame
{
    class Program
    {
        public static void WriteAt(string text, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(x, y);
                Console.Write(text);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.Write(e.Message);

            }

        }



        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 24);
            Console.SetBufferSize(80, 24);
            

            Console.ForegroundColor = ConsoleColor.Green;

            WriteAt("S N A K E       G A M E", 34, 5);

            Console.ResetColor();

            WriteAt("1. Начать игру ", 34, 8);
            WriteAt("2. Выйти из игры ", 34, 10);
            WriteAt("Ваш ввод: ", 34, 11);
            int caseSwitch = Convert.ToInt32(Console.ReadLine());
            switch (caseSwitch)
            {
                case 1:
                    Console.Clear();
                    break;
                case 2:
                    WriteAt("Всего доброго ", 34, 12);
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Некорректный ввод. /n Выберите 1 или 2.");
                    break;
            }

            // отрисовка рамки

            Walls walls = new Walls(80, 24);
            walls.Draw();



            Point p = new Point(4, 4, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Drow();

            FoodCreator foodCreator = new FoodCreator(78, 22, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();


            while (true)
            {
                if (walls.IsHit(snake))
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    WriteAt("G A M E       O V E R", 34, 12);

                    Console.ResetColor();
                    break;


                }
                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }


                Thread.Sleep(200);



                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
                Thread.Sleep(200);
                snake.Move();
            }
            Console.ReadKey();
        }

    }

}
