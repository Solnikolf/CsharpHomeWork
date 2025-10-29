using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число a:");
            var a = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите число b:");
            var b = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите число c:");
            var c = int.Parse(Console.ReadLine());

            if (SummOfaTriangle(a, b, c))
                Console.WriteLine("Треугольник существует");
            else Console.WriteLine("Такого треугольника не существует");
        }
        static bool SummOfaTriangle(int a, int b, int c) => (a + b > c) && (b + c > a) && (c + a > b);
    }
}