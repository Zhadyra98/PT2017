using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace MyFar
{
    class Program
    {
        static void Showdf(DirectoryInfo dir, int cursor)
        {
            Console.Clear();
            FileSystemInfo[] df = dir.GetFileSystemInfos();
            for (int i = 0; i < df.Length; i++)
            {
                if (cursor == i)
                    Console.BackgroundColor = ConsoleColor.Red;
                else
                    Console.BackgroundColor = ConsoleColor.Black;
                if (df.GetType() == typeof(DirectoryInfo))
                    Console.ForegroundColor = ConsoleColor.Yellow;
                else
                    Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(df[i].Name);



            }
            Console.BackgroundColor = ConsoleColor.Black;
         
            Console.WriteLine(' ');
           
        } 
             static void Main(string[] args)
        {
            Console.CursorVisible = false;
            DirectoryInfo dir = new DirectoryInfo(@"c:\HW");
            int cursor = 0;
            while (true) {
                Showdf(dir, cursor);
                ConsoleKeyInfo btn = Console.ReadKey();
                switch (btn.Key) {
                    case ConsoleKey.UpArrow:
                        if (cursor > 0)
                            cursor = cursor - 1;
                       else if (cursor == 0)
                            cursor = dir.GetFileSystemInfos().Length - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        if (cursor < dir.GetFileSystemInfos().Length - 1)
                            cursor = cursor + 1;
                       else if (cursor == dir.GetFileSystemInfos().Length - 1)
                            cursor = 0;
                        break;
                    case ConsoleKey.Enter:
                        FileSystemInfo fs = dir.GetFileSystemInfos()[cursor];
                        cursor = 0;
                        if (fs.GetType() == typeof(DirectoryInfo))
                        {
                            dir = new DirectoryInfo(fs.FullName);
                        }
                        else
                        {
                            Console.Clear();
                            StreamReader sr = new StreamReader(fs.FullName);
                            string arr = sr.ReadToEnd();
                            Console.WriteLine(arr);
                            sr.Close();
                            Console.Read();
                          

                        
                        
                        }
                        break;
                    case ConsoleKey.Escape:
                        dir = dir.Parent;
                        break;

                }
            
            
            
            }




            
        }
        
    }
}
