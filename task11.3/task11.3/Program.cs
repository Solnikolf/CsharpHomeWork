using System;

class Program
{
    // Метод для вычисления среднего арифметического элементов массива
    static double CalculateAverage(int[] array)
    {
        int sum = 0;
        for (int i = 0; i < array.Length; i++)
        {
            sum += array[i];
        }
        return (double)sum / array.Length;
    }

    static void Main()
    {
        // Пример массива
        int[] numbers = { 5, 10, 15, 20, 25 };

        // Вычисление среднего арифметического
        double average = CalculateAverage(numbers);

        // Вывод результата на консоль
        Console.WriteLine("Среднее арифметическое: " + average);
    }
}
