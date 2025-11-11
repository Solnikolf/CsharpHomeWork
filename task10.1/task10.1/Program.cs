using System;

namespace Task10_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите целое число, отличное от 0:");

            int b;

            if (!int.TryParse(Console.ReadLine(), out b))
            {
                Console.WriteLine("Ошибка ввода");
                return;
            }

            if (b == 0)
            {
                Console.WriteLine("Число не должно быть равно 0");
                return;
            }

            double sum = 0.0;

            for (int i = 1; i <= b; i++)
            {
                sum += 1.0 / i;
            }

            Console.WriteLine($"Частичная сумма гармонического ряда для {b} членов: {sum}");
        }
    }
}
