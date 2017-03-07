using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace complex
{
    class Program

    {
        public static Complex sub = new Complex(0, 0); // created class and declared atributes as zeros
        public static Complex sum = new Complex(0, 0); // created class and declared atributes as zeros
        public static Complex div = new Complex(0, 0); // created class and declared atributes as zeros
        public static Complex mul = new Complex(0, 0); // created class and declared atributes as zeros
        static void resume(Complex c)
        {
        
            FileStream fs = new FileStream("", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(Complex));
            c = xs.Deserialize(fs) as Complex;
            fs.Close();
        }
        static void Main(string[] args) // function to split complex numbers
        {
            
            string s = Console.ReadLine();
                string[] arr = s.Split(); // breaks a complex numbers into parts until space: 1/2 3/4
               foreach (string ss in arr) // instead of for we use foreach to work with string array
            {
             
                string[] t = ss.Split('/'); // breaks a complex numbers into parts until "/": 1 2 3  4
                    Complex p = new Complex(int.Parse(t[0]), int.Parse(t[1]));
                    if (sum.x == 0 & sum.y == 0) // because we have declared class as zeros, first condition is always true
                    {
                        sum = p;
                    }
                    else
                    {
                        sum = sum + p; // adds one complex number to another 
                    }
                }

          
                foreach (string ss in arr)
                {
                    string[] t = ss.Split('/');// breaks a complex numbers into parts until "/": 1 2 3  4
                    Complex p = new Complex(int.Parse(t[0]), int.Parse(t[1]));
                    if (sub.x == 0 & sub.y == 0) // because we have declared class as zeros, first condition is always true
                    {
                        sub = p; // we declare first element as an first complex number that we write through console
                                 
                    }
                    else
                    {
                        sub = sub - p;
                    }
                }
                Complex mul = new Complex(0, 0); // created class and declared atributes as zeros
                foreach (string ss in arr) // 
                {
                    string[] t = ss.Split('/');
                    Complex p = new Complex(int.Parse(t[0]), int.Parse(t[1]));
                    if (mul.x == 0 & mul.y == 0) // because we have declared class as zeros, first condition is always true
                    {
                        mul = p;
                         // we declare first element as an first complex number that we write through console
                         // if we wrote like that  mul.x = p.x;  mul.x = p.y;, it would be easier to understand what happens

                    }
                    else
                    {
                        mul = mul * p; // multiply current complex number with previous
                    }
                }

                Complex div = new Complex(0, 0);
                foreach (string ss in arr) // instead of for we use foreach to work with string array
                {
                    string[] t = ss.Split('/');
                    Complex p = new Complex(int.Parse(t[0]), int.Parse(t[1]));
                    if (div.x == 0 & div.y == 0)
                    {
                        div = p; // we declare first element as an first complex number that we write through console
                    }
                    else
                    {
                        div = div / p; // divides current complex number by previous
                    }

                }
            // coz we have changed Tostring(), now it shows atributs of complex number as an complex number
            
           
            while (true)
            {
                ConsoleKeyInfo btn = Console.ReadKey();
                if (btn.Key == ConsoleKey.F2)
                {
                 
                    sub.save();
                    div.save();
                    mul.save();
                    sum.save();

                }
                if (btn.Key == ConsoleKey.F3)
                {
                    resume(sum);
                    resume(sub);
                    resume(div);
                    resume(mul);
                   
                    Console.ReadKey();
                }
            }





        }
    }
    }