using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
namespace complex
{

  public class Complex //create a class 
    {
        public Complex() { }
        //added data
        public int x;
        public int y;
        public Complex(int x, int y) //make a constructor
        {
            //initialize class attributes
            this.x = x;
            this.y = y;
        }
        //rewrite function ToString()
        public override string ToString()
        {
            return x + "/" + y;
        }
        //function to find gcd of two complex numbers
        static int gcd(int x, int y)
        {
            if (x == 0)
                return y;
            return gcd(y % x, x);
        }
        //provide overload a binary operator +

        public static Complex operator +(Complex a, Complex b)
        {
            Complex c = new Complex(a.x * b.y + a.y * b.x / gcd(a.x * b.y + a.y * b.x, a.y * b.y), a.y * b.y / gcd(a.x * b.y + a.y * b.x, a.y * b.y));


            return c;
        }







        //provide overload a binary operator -
        public static Complex operator -(Complex x, Complex y)
        {
            //changed the purpose of  -  by adding new class 
            Complex c = new Complex((x.x * y.y - y.x * x.y) / gcd(x.x * y.y + y.x * x.y, x.y * y.y), x.y * y.y / gcd(x.x * y.y + y.x * x.y, x.y * y.y));
            return c;
        }
        //provide overload a binary operator /
        public static Complex operator /(Complex x, Complex y)
        {
            //changed the purpose of  /  by adding new class 
            Complex c = new Complex(x.x * y.y / gcd(x.x * y.y, x.y * y.x), x.y * y.x / gcd(x.x * y.y, x.y * y.x));
            return c;
        }
        //provide overload a binary operator *
        public static Complex operator *(Complex x, Complex y)
        {
            //changed the purpose of  *  by adding new class 
            Complex c = new Complex(x.x * y.x / gcd(x.x * y.x, x.y * y.y), x.y * y.y / gcd(x.x * y.x, x.y * y.y));

            return c;
        }
       public void save()
        {
        
            FileStream fs = new FileStream("", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(Complex));
            xs.Serialize(fs, this);
            fs.Close();
        }
       
    }
}
 