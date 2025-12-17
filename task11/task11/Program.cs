using System;

class Program
{
    
    static void PrintArray(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i]);
            if (i < arr.Length - 1) Console.Write(", ");
        }
        Console.WriteLine();
    }

    
    static void ChangeSigns(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = -arr[i];
        }
    }

    
    static double SqrtOfSumOfSquares(int[] arr)
    {
        double sumOfSquares = 0;
        foreach (int num in arr)
        {
            sumOfSquares += num * num;
        }
        return Math.Sqrt(sumOfSquares);
    }

    
    static int[] FactorialOfAbs(int[] arr)
    {
        int[] factorials = new int[arr.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            int num = Math.Abs(arr[i]);
            factorials[i] = Factorial(num);
        }
        return factorials;
    }

    
    static int Factorial(int n)
    {
        if (n == 0 || n == 1) return 1;
        int result = 1;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }

    static void Main(string[] args)
    {
        
        Console.Write("Введите количество элементов массива (n): ");
        int n = int.Parse(Console.ReadLine());

        
        Console.Write("Введите значение a (нижняя граница): ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Введите значение b (верхняя граница): ");
        int b = int.Parse(Console.ReadLine());

        
        Random random = new Random();
        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            arr[i] = random.Next(a, b + 1); 
        }

        
        Console.WriteLine("Исходный массив:");
        PrintArray(arr);

        
        ChangeSigns(arr);
        Console.WriteLine("Массив после изменения знаков:");
        PrintArray(arr);

        
        double resultSqrt = SqrtOfSumOfSquares(arr);
        Console.WriteLine($"Квадратный корень из суммы квадратов элементов массива: {resultSqrt}");

        
        int[] factorials = FactorialOfAbs(arr);
        Console.WriteLine("Массив факториалов модулей элементов:");
        PrintArray(factorials);
    }
}
