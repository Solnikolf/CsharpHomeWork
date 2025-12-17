using System;

class Program
{
    static void Main()
    {
        
        Console.Write("Введите количество элементов массива (n): ");
        int n = int.Parse(Console.ReadLine());

        
        int[] numbers = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Введите элемент {i + 1}: ");
            numbers[i] = int.Parse(Console.ReadLine());
        }

        
        Console.WriteLine("Исходный массив:");
        PrintArray(numbers);

        
        Console.Write("Введите число k для умножения элементов массива: ");
        int k = int.Parse(Console.ReadLine());
        MultiplyArray(numbers, k);
        Console.WriteLine("Массив после умножения на k:");
        PrintArray(numbers);

        
        double average = CalculateAverage(numbers);
        Console.WriteLine($"Среднее арифметическое элементов массива: {average}");

        
        int[] reversedArray = ReverseArray(numbers);
        Console.WriteLine("Массив с элементами в обратном порядке:");
        PrintArray(reversedArray);
    }

    
    static void PrintArray(int[] arr)
    {
        foreach (int num in arr)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }

    
    static void MultiplyArray(int[] arr, int k)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] *= k;
        }
    }

    
    static double CalculateAverage(int[] arr)
    {
        int sum = 0;
        foreach (int num in arr)
        {
            sum += num;
        }
        return (double)sum / arr.Length;
    }

    
    static int[] ReverseArray(int[] arr)
    {
        int[] reversed = new int[arr.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            reversed[i] = arr[arr.Length - 1 - i];
        }
        return reversed;
    }
}
