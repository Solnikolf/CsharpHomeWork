using System;

namespace Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество студентов (m): ");
            int m = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите количество экзаменов (k): ");
            int k = int.Parse(Console.ReadLine());

            for (int i = 1; i <= m; i++)
            {
                int sum = 0; 
                Console.WriteLine($"Введите оценки для студента {i} (всего {k} экзаменов):");

                for (int j = 1; j <= k; j++)
                {
                    Console.WriteLine($"Оценка за экзамен {j}: ");
                    int grade = int.Parse(Console.ReadLine());
                    sum += grade; 
                }

                Console.WriteLine($"Сумма баллов студента {i}: {sum}");
            }
        }
    }
}
