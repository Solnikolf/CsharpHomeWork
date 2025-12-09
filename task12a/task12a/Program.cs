using System;

namespace Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] a = new int[4, 5];

            var rnd = new Random();


            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    a[i, j] = rnd.Next(100);
                }
            }


            PrintArray(a);


            bool isOrdered = true;
            for (int j = 0; j < a.GetLength(1); j++)
            {
                for (int i = 0; i < a.GetLength(0) - 1; i++)
                {
                    if (a[i, j] < a[i + 1, j])
                    {

                        Console.WriteLine($"Порядок нарушен на строке {i}, столбце {j}. ({a[i, j]} < {a[i + 1, j]})");
                        isOrdered = false;
                        break;
                    }
                }
                if (!isOrdered) break;
            }


            if (isOrdered)
            {
                Console.WriteLine("Все столбцы упорядочены по убыванию.");
            }
        }


        static void PrintArray(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write($"{a[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
