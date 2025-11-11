using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите натуральное число:");

            int n;

            if (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.WriteLine("Ошибка ввода. Нужно ввести натуральное число (> 0).");
                return;
            }

            int maxDigit = 0;
            int minDigit = 9;
            int temp = n;

            while (temp > 0)
            {
                int digit = temp % 10;  
                if (digit > maxDigit)
                    maxDigit = digit;
                if (digit < minDigit)
                    minDigit = digit;

                temp /= 10; 
            }

            int difference = maxDigit - minDigit;

            Console.WriteLine($"Разность между максимальной ({maxDigit}) и минимальной ({minDigit}) цифрами числа {n} равна {difference}");
        }
    }
}
