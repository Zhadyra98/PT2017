using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication10
{
    class Program
    {
        static void dirfiles(string path) {
            int i = 0;
            Stack<string> directory= new Stack<string>() ;
            directory.Push(path);
       
           for ( i=0;i<=directory.Count;i++)
            {
                DirectoryInfo current = new DirectoryInfo(directory.Pop());
                DirectoryInfo[] dir = current.GetDirectories();
                FileInfo[] fil = current.GetFiles();
                Console.WriteLine(current.FullName);
                for (i = 0; i < fil.Length; i++)
                { Console.WriteLine(fil[i].Name); }
                for (i = 0; i < dir.Length; i++)
                { Console.WriteLine(dir[i]); }
                Console.WriteLine("There are " + fil.Length + " files");
                Console.WriteLine("There are " + dir.Length + " directories");
                for (i = 0; i < dir.Length; i++)
                { directory.Push((dir[i].FullName)); }
            }
            }
        static void Main(string[] args)
        {
            dirfiles(@"C:\HW");
            Console.ReadKey();
        }
    }
}
