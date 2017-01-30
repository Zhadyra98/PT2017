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
// обьявляем атрибуты класса
            public string name;
            public string surname;
            public double gpa;
            public Student(string name, string surname) // конструктор, в котором отсутствует ГПА
            {
                this.name = name; // используем указатель this, с помощью которого указываем текущий обьект
                this.surname = surname;
            }
            public Student(string name, double gpa) // конструктор, в котором отсутствует фамилия
            {
                this.name = name;
                this.gpa = gpa;
            }

            public override string ToString() // Переписали метод Tostrin(). Функция возврощающая данные в виде string
            {
                return name + ' ' + surname + ' ' + gpa;
            }

        }

        static void Main(string[] args)
        {
            Student a = new Student("RustemBek", "Ualikhanov"); // инициализируем значения класса. При этом конструктор определяется автоматически
            a.gpa = 2.48;
            Student x = new Student("Aidos", 2.36);
            x.surname = "Baibek" ;
            Console.WriteLine(a);  // вывод на экран
            Console.WriteLine(x); // вывод на экран
            Console.ReadKey(); // окно не будет закрыто пока мы не нажмем какую-либо клавишу
        }
    }
}