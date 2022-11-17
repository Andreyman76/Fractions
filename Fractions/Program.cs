using System;

namespace Fractions
{
    class Program
    {
        static void Main(string[] args)
        {
            var f1 = Fraction.Parse("5/100");
            var f2 = Fraction.Parse("1/10");
            int i = 5;

            Console.WriteLine($"Fraction 1: {f1}");
            Console.WriteLine($"Top: {f1.Top}");
            Console.WriteLine($"Bottom: {f1.Bottom}");
            Console.WriteLine($"Double: {f1.Double}");
            Console.WriteLine($"Float: {f1.Float}");
            Console.WriteLine($"Int: {f1.Int}");
            Console.WriteLine($"Is int: {f1.IsInt}");
            Console.WriteLine();

            Console.WriteLine($"{f1} + {f2} = {f1 + f2}");
            Console.WriteLine($"{f1} - {f2} = {f1 - f2}");
            Console.WriteLine($"{f1} * {f2} = {f1 * f2}");
            Console.WriteLine($"{f1} / {f2} = {f1 / f2}");
            Console.WriteLine($"-{f1} = {-f1}");
            Console.WriteLine();

            Console.WriteLine($"{f1} == {f2} = {f1 == f2}");
            Console.WriteLine($"{f1} != {f2} = {f1 != f2}");
            Console.WriteLine($"{f1} > {f2} = {f1 > f2}");
            Console.WriteLine($"{f1} < {f2} = {f1 < f2}");
            Console.WriteLine($"{f1} >= {f2} = {f1 >= f2}");
            Console.WriteLine($"{f1} <= {f2} = {f1 <= f2}");
            Console.WriteLine();

            Console.WriteLine($"{f1} + {i} = {f1 + i}");
            Console.WriteLine($"{f1} - {i} = {f1 - i}");
            Console.WriteLine($"{f1} * {i} = {f1 * i}");
            Console.WriteLine($"{f1} / {i} = {f1 / i}");
        }
    }
}
