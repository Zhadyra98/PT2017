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
        public static bool Gameover = false;
      public static int d = 5;
        public static int u = 0;
        public static int i = 0;
        public static int e = 0;
        public static Snake snake;
        public static Wall wall;
        public static Food food;
        public static Donsotmove dont; 
   

        static void Move() {
            Console.Clear();
            Console.SetCursorPosition(54, 30);
            Console.WriteLine("LEVEL:" + e);
            Console.SetCursorPosition(54, 32);
            Console.WriteLine("POINT:" + u);

            while (!Gameover)
            {
                wall = new Wall(i);
                if (d == 0)
                    snake.Move(1, 0);
                if (d == 1)
                    snake.Move(-1, 0);
                if (d == 2)
                    snake.Move(0, -1);
                if (d == 3)
                    snake.Move(0, 1);
                if (d == 5)
                    snake.Move(0, 0);
                if (d == 4)
                    break;
                if (Gameover = snake.CrushWithWall(wall) ||
                 snake.CrushWithBody(snake))
                    break;
            snake.Draw();
  
                wall.Draw();
                food.Draw();
               
               
                if (snake.CanEat(food))
                {
                    food.SetRandomPosition();
                    u++;
                  
                }
                 if (food.foodinwall(wall))
                {
                    while (food.foodinwall(wall))
                        food.SetRandomPosition();
                }
                if (snake.body.Count == 6)
                {
                    Console.Clear();
                    i++;
                    snake.SetSnake();
                 


                    e = i + 1;
                }

                Thread.Sleep(200);
      
            
            }


            Console.Clear();
            Console.SetCursorPosition(10, 10);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("GAME OVER!");
            Console.ReadKey();




        }
        static void Main(string[] args)
        {
            Console.SetWindowSize(70, 35);

            Console.CursorVisible = false;
          
             snake = new Snake();
           
            food = new Food();
            dont = new Donsotmove();
          
          
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(10, 20);
            Console.WriteLine("Would You like to play? " + "Then, press Enter to start");
            ConsoleKeyInfo button = Console.ReadKey();

            if (button.Key == ConsoleKey.Enter)
            {
                Thread thread = new Thread(Move);
                thread.Start();
            }
            while (!Gameover==true)
            {
              
              
                    ConsoleKeyInfo btn = Console.ReadKey();

                    if (dont.Donotmove(snake))
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

                                break;
                            case ConsoleKey.Escape:
                                break;


                        }
                    else if (dont.Donotmove1(snake))
                        switch (btn.Key)
                        {
                            case ConsoleKey.UpArrow:
                                d = 2;

                                break;
                            case ConsoleKey.DownArrow:
                                d = 3;
                                break;
                            case ConsoleKey.RightArrow:

                                break;
                            case ConsoleKey.LeftArrow:
                                d = 1;
                                break;
                            case ConsoleKey.Escape:
                                break;


                        }
                    else if (dont.Donotmove2(snake))
                        switch (btn.Key)
                        {
                            case ConsoleKey.UpArrow:

                                break;
                            case ConsoleKey.DownArrow:
                                d = 3;
                                break;
                            case ConsoleKey.RightArrow:
                                d = 0;
                                break;
                            case ConsoleKey.LeftArrow:
                                d = 1;
                                break;
                            case ConsoleKey.Escape:
                                break;


                        }
                    else if (dont.Donotmove3(snake))
                    {
                        switch (btn.Key)
                        {
                            case ConsoleKey.UpArrow:
                                d = 2;

                                break;
                            case ConsoleKey.DownArrow:

                                break;
                            case ConsoleKey.RightArrow:
                                d = 0;
                                break;
                            case ConsoleKey.LeftArrow:
                                d = 1;
                                break;
                            case ConsoleKey.Escape:
                                break;

                        }
                    }
                    else


                        switch (btn.Key)
                        {
                            case ConsoleKey.UpArrow:
                                d = 2;
                                break;
                            case ConsoleKey.DownArrow:
                                d = 3;
                                break;
                            case ConsoleKey.RightArrow:
                                d = 0;
                                break;
                            case ConsoleKey.LeftArrow:
                                d = 1;
                                break;
                            case ConsoleKey.Escape:
                                break;


                        }


           
               
                
            }
          
        }
    }
}
