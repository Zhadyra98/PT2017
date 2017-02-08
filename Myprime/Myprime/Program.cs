using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myprime
{
    class Program
    {
        static bool Sol(int y)
        {
            int n = Math.Abs(y);
            if (n == 1)
                return false;
            if (n == 2)
                return true;
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                    return false;
            }

            return true;
        }
        static void Calc()
        {
            FileStream fsi = new FileStream(@"C:\HW\a.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            FileStream fso = new FileStream(@"C:\HW\b.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fsi);
            StreamWriter sw = new StreamWriter(fso);

            string[] massive = sr.ReadLine().Split();
            int[] numbers = new int[massive.Length];
            for (int i = 0; i < massive.Length; i++)
            {

                numbers[i] = int.Parse(massive[i]);
            }
            int x = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
          
             { if (Sol(numbers[i]))
                x = numbers[i];
             
             }

            
           
            
            for (int i = 1; i < numbers.Length; i++)
            {
                if (Sol(numbers[i]) && numbers[i] < x)
                    x = numbers[i];

            }
            Console.WriteLine(x);
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            Calc();
            Console.ReadKey();
        }
    }
}
