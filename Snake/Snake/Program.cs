using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Xml.Serialization;

namespace Snake
{
 
    public class Program
    {
        public static bool Gameover = false;
        public static int d = 5;
        public static int u = 0;
        public static int i = 0;
        public static int e = 0;
        public static int k =500;
        public static Snake snake;
        public static Wall wall;
        public static Food food;
        static void Save1()
        {
            snake.Save();
            food.Save();
            wall.Save();
        }
        static void Resume()
        {
            snake.Resume();
            food.Resume();
            wall.Resume();
        }

        static void Move() {
            Console.Clear();
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
                //if (d == 4)
                    //break;
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
                 if (food.Foodinwall(wall))
                {
                    while (food.Foodinwall(wall))
                        food.SetRandomPosition();
                }
                if (food.Foodinsnake(snake))
                {
                    while (food.Foodinsnake(snake))
                        food.SetRandomPosition();
                }

                if (snake.body.Count == 6)
                {
                    Console.Clear();
                    i++;
                    snake.SetSnake();
                    k = k - 100;
                    d = 5;
                }
                e = i + 1;
                Console.SetCursorPosition(10, 20);
                Console.WriteLine("LEVEL:" + e);
                Console.SetCursorPosition(10,22);
                Console.WriteLine("POINT:" + u);
                Thread.Sleep(k);
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
            snake.SetSnake();
            food = new Food(1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(10, 20);
            Console.WriteLine("Would You like to play? " + "Then, press Enter to start");
            ConsoleKeyInfo buton = Console.ReadKey();

            if (buton.Key == ConsoleKey.Enter)
            {
                Thread thread = new Thread(Move);
                thread.Start();
            }


             Stack<ConsoleKeyInfo> ba = new Stack<ConsoleKeyInfo>();
             if (ba.Count == 0)
            {
                ba.Push(Console.ReadKey());
                if (ba.Peek().Key == ConsoleKey.UpArrow )
                    d = 2;

                if (ba.Peek().Key == ConsoleKey.DownArrow)
                    d = 3;

                if (ba.Peek().Key == ConsoleKey.LeftArrow)
                    d = 1;

                if (ba.Peek().Key == ConsoleKey.RightArrow)
                    d = 0;
            }
            while (!Gameover == true)
            {
                if (ba.Count() > 0)
                {
                    ConsoleKeyInfo button = Console.ReadKey();

                    if (button.Key == ConsoleKey.F2)
                        Save1();
                    if (button.Key == ConsoleKey.F3)
                        Resume();

                    if (ba.Peek().Key == ConsoleKey.UpArrow && button.Key == ConsoleKey.DownArrow ||
                                     ba.Peek().Key == ConsoleKey.LeftArrow && button.Key == ConsoleKey.RightArrow ||
                                     ba.Peek().Key == ConsoleKey.DownArrow && button.Key == ConsoleKey.UpArrow ||
                                     ba.Peek().Key == ConsoleKey.RightArrow && button.Key == ConsoleKey.LeftArrow)
                    {

                    }

                    else
                    {
                        ba.Push(button);
                        if (button.Key == ConsoleKey.UpArrow)
                            d = 2;

                        if (button.Key == ConsoleKey.DownArrow)
                            d = 3;

                        if (button.Key == ConsoleKey.LeftArrow)
                            d = 1;

                        if (button.Key == ConsoleKey.RightArrow)
                            d = 0;
                    }
                }

            }
        }
     }
  }

