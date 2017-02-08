using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[massive.Length];
            FileStream fsi = new FileStream(@"C:\HW\a.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            FileStream fso = new FileStream(@"C:\HW\b.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader rs = new StreamReader(fsi);
            StreamWriter sw = new StreamWriter(fso);
            string s = rs.ReadLine();
            string massive = s.Split('/');
            for (int i = 0; i < massive.Length; i++)
                array[i] = int.Parse(massive[i]);
            int k = 0;
            int min = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 1; j < min; j++)
                {
                    if (array[i] % j == 0)
                    {
                        k++;
                    }
                }
                if (k == 2 && array[i] < min)
                {
                    min = array[i];
                }
                k = 0;
            }
            sw.WriteLine("Minumum prime number is: " + min);
            sw.Close();
            rs.Close();
        }
    }
}