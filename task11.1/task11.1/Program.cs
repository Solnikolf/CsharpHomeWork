using System;

class Program
{
    
    static void PrintArray(int[] array)
    {
        foreach (int item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine(); 
    }

    static void Main()
    {
        Console.Write("Введите целое положительное число n: ");
        int n = int.Parse(Console.ReadLine());

        
        if (n <= 0)
        {
            Console.WriteLine("Число должно быть положительным.");
            return;
        }

        int[] numbers = new int[n];

        
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Введите элемент {i + 1}: ");
            numbers[i] = int.Parse(Console.ReadLine());
        }

        
        Console.WriteLine("Массив, который вы ввели:");
        PrintArray(numbers);
    }
}
