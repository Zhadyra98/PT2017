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
         
            sign = 'o';
            color = ConsoleColor.Yellow;
            body = new List<Point>();
            body.Add(new Point(30, 40));
         
        }
        public void Move(int dx, int dy)
        {
            // if (cnt % 10 == 0)
            // body.Add(new Point(0, 0)); 
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.x, p.y);

                Console.Write(' ');
            }
          
            for (int i = body.Count - 1; i >= 1; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }
                
               
          
            body[0].x =body[0].x+dx;
            body[0].y = body[0].y+dy;

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
                body.Add(new Point(f.location.x, f.location.y));
                Console.SetCursorPosition(f.location.x, f.location.y);
                Console.WriteLine(' '); // new Point(body[0].x, body[0].y)
                return true;
            }
            return false;
        }
        public bool CrushWithWall(Wall w)
        {
            foreach (Point p in w.body)
            {
                if (body[0].x == p.x && body[0].y == p.y)
                    return true;
            }
            return false;
        }
        public bool CrushWithBody(Snake sn)
        {
            for (int i = 2; i < this.body.Count; i++)
            {
                if (this.body[i].x == this.body[0].x && this.body[i].y == this.body[0].y)
                    return true;
                //  else if (this.body[1].x == this.body[0].x && this.body[1].y == this.body[0].y)
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
