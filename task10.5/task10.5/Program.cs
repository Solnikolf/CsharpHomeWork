using System;

namespace task10_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите натуральное число:");

            int n;

            if (!int.TryParse(Console.ReadLine(), out n) || n <= 1)
            {
                Console.WriteLine("Ошибка ввода. Нужно ввести натуральное число (> 1).");
                return;
            }

            int smallestDivisor = 0;

            // Наименьший делитель, отличный от 1
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    smallestDivisor = i;
                    break;
                }
            }

            // Если делителя не найдено — число простое
            if (smallestDivisor == 0)
                smallestDivisor = n;

            Console.WriteLine($"Наименьший делитель числа {n}, отличный от 1: {smallestDivisor}");
        }
    }
}
