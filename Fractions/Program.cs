using System;

namespace Fractions
{
    class Program
    {
        static void Main(string[] args)
        {
            var fraction1 = Fraction.Parse("1/3");
            var fraction2 = new Fraction(1, 6);
            Console.WriteLine(1 + fraction1 - fraction2);
        }
    }
}
