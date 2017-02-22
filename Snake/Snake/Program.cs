using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Snake
{
    class Program
    {
      /*public static int d = 0;
        public static Snake snake;
        public static Wall wall;
        static void Move() {
            while (true)
            {
                if (d == 0)
                    snake.Move(1, 0);
                if (d == 1)
                    snake.Move(-1, 0);
                if (d == 2)
                    snake.Move(0, -1);
                if (d == 3)
                    snake.Move(0, 1);
                if (d== 4)
                    break;
                Console.Clear();
                snake.Draw();
                wall.Draw();
               
                Thread.Sleep(500);
      
            
            }
            }
        */
        
        
        
        
        
        
        static void Main(string[] args)
        {
            Console.SetWindowSize(70, 35);

            Console.CursorVisible = false;
            Food food = new Food();
            Snake snake = new Snake();
            Wall wall = new Wall();
       /* snake = new Snake();
             wall = new Wall();
            Thread thread = new Thread(Move);
             thread.Start();
           
            Console.WriteLine("test");*/
          

            bool Gameover = false;
           

            while (!Gameover==true)
            {
                ConsoleKeyInfo btn = Console.ReadKey();
                switch (btn.Key)
                {
                    case ConsoleKey.UpArrow:
                        snake.Move(0, -1);
                        break;
                    case ConsoleKey.DownArrow:
                        snake.Move(0, 1);
                        break;
                    case ConsoleKey.RightArrow:
                        snake.Move(1, 0);
                        break;
                    case ConsoleKey.LeftArrow:
                        snake.Move(-1, 0);
                        break;
                    case ConsoleKey.Escape:
                        break;
                     
                }
                Gameover = snake.CollistionWithWall(wall);

                if (snake.CanEat(food))
                {
                    food.SetRandomPosition();
                }
            



                if (food.foodinwall(wall))
                {
                    while (food.foodinwall(wall))
                        food.SetRandomPosition();
                }

                if (food.foodinsnake(snake))
                {
                    while(food.foodinsnake(snake))
                    food.SetRandomPosition();
               }

                Console.Clear();
                snake.Draw();
                wall.Draw();
                food.Draw();

            }
            Console.Clear();
            Console.SetCursorPosition(10, 10);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("GAME OVER!");
            Console.ReadKey();
        }
    }
}
