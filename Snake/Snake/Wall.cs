using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

using System.Xml.Serialization;


namespace Zmaika
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

            DirectoryInfo fs = new DirectoryInfo(@"c:\HW\folder1");
            FileInfo[] files = fs.GetFiles();
            if (x < 4)
            {
                StreamReader sr = new StreamReader(files[x].FullName);
                int n = int.Parse(sr.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    string line = sr.ReadLine();
                    for (int j = 0; j < line.Length; j++)
                        if (line[j] == '#')
                            body.Add(new Point(j, i));
                }
                sr.Close();
            }
            else if (x == 4)
            {

                Console.SetCursorPosition(10, 20);
                Console.WriteLine("LEVEL:" + Program.e); 
                Console.SetCursorPosition(10, 22);

                Console.WriteLine("POINT:" + Program.u);
                Console.SetCursorPosition(40, 40);
                Console.WriteLine("You have won! Flawles victory!");
            }

        }

        public void Save()
        {
           
                
            FileStream fs = new FileStream(@"C:\HW\wall.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(Wall));

            xs.Serialize(fs, this);
            fs.Close();
        }
        public void Resume()
        {
           

            FileStream fs = new FileStream(@"C:\HW\wall.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(Wall));

            Program.wall = xs.Deserialize(fs) as Wall;
            fs.Close();
        }
      //  public void Drawborder() { 
       // for ()
        
        
        //}

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

