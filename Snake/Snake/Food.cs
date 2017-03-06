using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Zmaika
{ 
    [Serializable]

    public class Food
    {
        public Point location;
        public ConsoleColor color = ConsoleColor.Red;
        public char sign = '$';
        public Food() { }

        public Food(int a)
        {
            SetRandomPosition();
            
        }

        public void SetRandomPosition()
        {
           
            int x = new Random().Next(8, 43);
            int y = new Random().Next(2, 19);
           location = new Point(x, y);
        }
        public bool Foodinsnake(Snake w)
        {
            foreach (Point p in w.body)
            {
                if (location.x == p.x && location.y == p.y)
                    return true;
            }
            return false;
        }
        public bool Foodinwall(Wall w)
        {
            foreach (Point p in w.body)
            {
                if (location.x == p.x && location.y == p.y)
                    return true;
            }
            return false;
        }


        public void Draw()
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(location.x, location.y);
            Console.Write(sign);
        }
        public void Save()
        {
           
           
               
            FileStream fs = new FileStream(@"C:\HW\food.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(Food));
            xs.Serialize(fs, this);
            fs.Close();
        }
        public void Resume()
        {
            
            FileStream fs = new FileStream(@"C:\HW\food.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(Food));
    
               Program.food = xs.Deserialize(fs) as Food;
            fs.Close();
        }

    }

}

