using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string s = Console.ReadLine();
            string[] p = s.Split();
            

            Console.WriteLine(p.Max() + ' ' + p.Min());
            Console.ReadKey();
        }
    }
}