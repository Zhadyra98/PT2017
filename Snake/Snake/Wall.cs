using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Snake
{
    class Wall
    {
        public char sign;
        public ConsoleColor color;
       public List<Point> body;

        public Wall(int x)
        {
            sign = '*';
            color = ConsoleColor.Green;
            body = new List<Point>();
            DirectoryInfo fs = new DirectoryInfo(@"c:\HW\folder");
            FileInfo[] files = fs.GetFiles();
            StreamReader sr = new StreamReader(files[x].FullName);
         
            int n = int.Parse(sr.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string line = sr.ReadLine();
                for (int j = 0; j < line.Length; j++)
                    if (line[j] == '*')
                        body.Add(new Point(j, i));
            }
            sr.Close();
        }

        public void Draw()
        {
            //Console.Clear();
            Console.ForegroundColor = color;
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.x, p.y);

                Console.Write(sign);
            }
        }
    }
}
