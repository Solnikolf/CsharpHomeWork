using System;
using System.Collections.Generic;

class Program
{
    static bool IsSimple(int n)
    {
        if (n <= 1) return false;
        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0) return false;
        }
        return true;
    }

    static bool IsSemiSimple(int n)
    {
        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0 && IsSimple(i) && IsSimple(n / i))
            {
                return true;
            }
        }
        return false;
    }

    static void Main()
    {
        int limit = 10000000;
        int count = 0;

        for (int i = 4; i < limit; i++)
        {
            if (IsSemiSimple(i))
            {
                count++;
            }
        }

        Console.WriteLine($"Количество полупростых чисел меньше {limit}: {count}");
    }
}
