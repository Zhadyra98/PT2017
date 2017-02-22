using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Food
    {
        //  public Point location;
        public int x;
        public int y;
        public ConsoleColor color = ConsoleColor.Red;
        public char sign = '$';
     

        public Food()
        {
            SetRandomPosition();
        }

        public void SetRandomPosition()
        {
           
            int x = new Random().Next(1, 69);
            int y = new Random().Next(1, 34);
            this.x = x;
            this.y = y;
            //location = new Point(x, y);
        }
        public bool foodinwall(Wall w)
        {
            foreach (Point p in w.body)
            {
                if (/*location.x == p.x && location.y == p.y*/ x==p.x && y==p.y)
                    return true;
            }
            return false;
        }
        public bool foodinsnake(Snake w)
        {
            foreach (Point p in w.body)
            {
                if (/*location.x == p.x && location.y == p.y*/ x == p.x && y == p.y)
                    return true;
            }
            return false;
        }


        public void Draw()
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(/*location.x, location.y*/ x, y);
            Console.Write(sign);
        }
      
    }

}

