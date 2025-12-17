using System;

class Program
{
    // Метод для вывода элементов массива на консоль через пробел
    static void PrintArray(int[] array)
    {
        foreach (int item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    // Метод, умножающий каждый элемент массива на число k
    static void MultiplyArray(int[] array, int k)
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] *= k;
        }
    }

    // Метод для вычисления среднего арифметического элементов массива
    static double AverageArray(int[] array)
    {
        if (array.Length == 0)
            return 0;

        double sum = 0;
        foreach (int item in array)
        {
            sum += item;
        }
        return sum / array.Length;
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

        Console.WriteLine("Исходный массив:");
        PrintArray(numbers);


        Console.Write("Введите число k для умножения элементов массива: ");
        int k = int.Parse(Console.ReadLine());


        MultiplyArray(numbers, k);

        Console.WriteLine($"Массив после умножения на {k}:");
        PrintArray(numbers);


        double average = AverageArray(numbers);
        Console.WriteLine($"Среднее арифметическое элементов массива: {average}");
    }
}
