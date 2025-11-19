using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10._3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Введите натуральное число n:");

            int n;

            if (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.WriteLine("Ошибка ввода. Нужно ввести натуральное число (> 0).");
                return;
            }

            int f1 = 1;
            int f2 = 1;
            int fNext = f1 + f2;

            while (fNext <= n)
            {
                f1 = f2;
                f2 = fNext;
                fNext = f1 + f2;
            }

            Console.WriteLine($"Первое число Фибоначчи, большее {n}, равно {fNext}");
        }
    }
}
