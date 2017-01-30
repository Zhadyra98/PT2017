using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;  // add IO for StreamReader and StreamWriter

namespace Work_with_file
{
    class Program
    {
        // function for checking a number to determine whether a number is a prime or not
        static bool check(int n)
        {
            //to define whether 'x' is divided into 'i'
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                    //it is not a prime number,a program has to finish cycle
                    return false;
            }
            // '1' is not a prime number
            if (n == 1)
                return false;
            return true;
        }
        //creat a function to find min and max in array
        public static void dFile()
        {
            //read from a.txt datas
            StreamReader sr = new StreamReader(@"C:\HW\a.txt");

            //write or display a result in b.txt
            StreamWriter sw = new StreamWriter(@"C:\HW\b.txt");

            //a string array that contains the substring of this instance, separated by "_"  
            string[] arr = sr.ReadLine().Split();

            //creat new, the biggest variable to find min 
            int x = 320000;

            //convert array to string 
            foreach (string p in arr)
            {
                //convert string to integer
                int h = int.Parse(p);

                //check the min
                if (h < x && check(h))
                    x = h; //if it is the min number assign a value to x
            }
            //write a result in .txt file
            sw.WriteLine("min:" + x);

            //StreamReader and StreamWriter must be closen to work
            sw.Close();
            sr.Close();
        }
        static void Main(string[] args)
        {
            //call a function
            dFile();
            //window will not close until we will not press any key
            Console.ReadKey();
        }
    }
}