using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

using System.Xml.Serialization;


namespace Snake
{
    [Serializable]

    public class Wall
    {
       
        public char sign;
        public ConsoleColor color;
        public List<Point> body;
        public Wall() { }
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
        public void Save()
        {
            string fileName = "";

            fileName = @"C:\HW\wall.xml";
            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(Wall));

            xs.Serialize(fs, this);
            fs.Close();
        }
        public void Resume()
        {
            string fileName = "";

            fileName = @"C:\HW\wall.xml";
            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(Wall));

            Program.wall = xs.Deserialize(fs) as Wall;
            fs.Close();
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
