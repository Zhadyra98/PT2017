using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Studento
{
    class Program
    {
        class Student //создаем новый класс
        {
            public string name;
            public string surname;
            public double gpa;
            public Student(string name, string surname) // конструктор
            {
                this.name = name; // указываем обьект
                this.surname = surname;
            }
            public Student(string name, double gpa) // конструктор
            {
                this.name = name;
                this.gpa = gpa;
            }

            public override string ToString() // функция возврощающая данные в виде string
            {
                return name + ' ' + surname + ' ' + gpa;
            }

        }

        static void Main(string[] args)
        {
            Student a = new Student("RustemBek", "Ualikhanov"); // задаем все значения
            a.gpa = 2.48;
            Student x = new Student("Aidos", 2.36);
            x.surname = "Baibek" ;
            Console.WriteLine(a);
            Console.WriteLine(x); // вывод на экран
            Console.ReadKey(); // окно не будет закрыто пока мы не нажмем какую-либо клавишу
        }
    }
}