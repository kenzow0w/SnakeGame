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
                if (snake.Eat (food))
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
