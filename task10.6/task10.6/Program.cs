using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10._6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Решение задачи про быков, коров и телят:");
            Console.WriteLine("Условия: бык = 10 руб., корова = 5 руб., телёнок = 0.5 руб.");
            Console.WriteLine("Нужно купить 100 голов и потратить ровно 100 рублей.\n");

            for (int bulls = 0; bulls <= 100; bulls++)
            {
                for (int cows = 0; cows <= 100 - bulls; cows++)
                {
                    int calves = 100 - bulls - cows;  // оставшиеся — телята

                    // Проверяем стоимость
                    double cost = bulls * 10 + cows * 5 + calves * 0.5;

                    if (Math.Abs(cost - 100) < 0.0001)
                    {
                        Console.WriteLine($"Быков: {bulls}, Коров: {cows}, Телята: {calves}");
                    }
                }
            }
        }
    }
}

