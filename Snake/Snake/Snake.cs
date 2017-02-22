using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Snake
{

    class Snake
    {
        
        public char sign;
        public ConsoleColor color;
        public List<Point> body;
       
        public Snake()
        {
            SetSnake();
            }
        
            public void SetSnake ()
        {
            int x = new Random().Next(1, 69);
            int y = new Random().Next(1, 34);
            sign = 'o';
            color = ConsoleColor.Red;
            body = new List<Point>();
            body.Add(new Point(x, y));
         
        }
        public void Move(int dx, int dy)
        {
           // if (cnt % 10 == 0)
               // body.Add(new Point(0, 0));   
        
        for (int i = body.Count - 1; i >= 1; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }
            body[0].x += dx;
            body[0].y += dy;

            if (body[0].x > Console.WindowWidth - 10)
                body[0].x = 1;
            if (body[0].x < 1)
                body[0].x = Console.WindowWidth - 10;

            if (body[0].y > Console.WindowHeight - 10)
                body[0].y = 1;
            if (body[0].y < 1)
                body[0].y = Console.WindowHeight - 10;


          //  cnt++;
        }
        public bool CanEat(Food f)
        {
            if (body[0].x == f.location.x && body[0].y == f.location.y)
            {
                body.Add(new Point(f.location.x, f.location.y)); // new Point(body[0].x, body[0].y)
                return true;
            }
            return false;
        }
        public bool CollistionWithWall(Wall w)
        {
            foreach (Point p in w.body)
            {
                if (body[0].x == p.x && body[0].y == p.y)
                    return true;
            }
            return false;
        }
      

        public void Draw()
        {
       
            Console.ForegroundColor = color;
        foreach (Point p in body)
        {
            Console.SetCursorPosition(p.x, p.y);

            Console.Write(sign);
        }

        }
    }
}
