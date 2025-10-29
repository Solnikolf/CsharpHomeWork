using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task09._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите значение x:");
            var x = double.Parse(Console.ReadLine());

            Console.WriteLine($"f({x}) = {F(x)}");
            
        }

        static double F(double x)
        { if (Math.Cos(x) != 0)
                return Math.Tan(x);

            else if (Math.Cos(x) == 0 && Math.Sin(x) > 0)
                return (x / Math.PI - 0.5);

            else
                return (-x/Math.PI-0.5);

        }
    }
}
