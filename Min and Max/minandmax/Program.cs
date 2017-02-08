using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace minandmax
{
    class Program
    {
       
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(@"C:\HW\a.txt");
            StreamWriter sw = new StreamWriter(@"C:\HW\b.txt");
            string s = sr.ReadLine();
            string[] massive = s.Split();
            int[] numbers= new int[massive.Length];
            for (int i = 0; i < massive.Length; i++)
            {
                numbers[i] = int.Parse(massive[i]);
            }
            int x = numbers[0];
            int a = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > x)
                    x = numbers[i];
                if (numbers[i] < a)
                    a = numbers[i];
           }
            sw.WriteLine("largest number is "+x);
            sw.WriteLine("smallest number is "+a);
            sr.Close();
            sw.Close();
            Console.ReadKey();

        }
    }
}
