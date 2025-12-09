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

            
            for (int i = 0; i < a.GetLength(0); i++)  
            {
                double sum = 0;

                
                for (int j = 0; j < a.GetLength(1); j++)  
                {
                    sum += a[i, j];
                }

                
                double average = sum / a.GetLength(1);

                
                Console.WriteLine($"Среднее арифметическое для строки {i}: {average:F2}");
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
