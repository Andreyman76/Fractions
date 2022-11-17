using System;
using System.Linq;

namespace Fractions
{
    public struct Fraction
    {
        public int Top { get; private set; }
        public int Bottom { get; private set; }

        public float Float => (float)Top / Bottom;
        public double Double => (double)Top / Bottom;
        public int Int => Top / Bottom;
        public bool IsInt => Top % Bottom == 0;

        public Fraction(int top, int bottom = 1)
        {
            if (bottom == 0)
            {
                throw new DivideByZeroException("Bottom can not be a zero");
            }

            Top = top;
            Bottom = bottom;

            // Reduce fraction
            while (true)
            {
                var divisor = GCD(Top, Bottom);

                if (divisor == 1)
                {
                    break;
                }

                Top /= divisor;
                Bottom /= divisor;
            }

            if (Bottom < 0)
            {
                Top = -Top;
                Bottom = -Bottom;
            }
        }

        public override string ToString()
        {
            return $"{Top}/{Bottom}";
        }

        public static Fraction Parse(string fraction)
        {
            var topAndBot = fraction.Split('/').ToArray();

            if (topAndBot.Length != 2)
            {
                throw new FormatException($"Wrong fraction format: {fraction}");
            }


            if (!int.TryParse(topAndBot[0], out int top))
            {
                throw new FormatException($"Wrong fraction format: {fraction} at {topAndBot[0]}");
            }

            if (!int.TryParse(topAndBot[1], out int bot))
            {
                throw new FormatException($"Wrong fraction format: {fraction} at {topAndBot[1]}");
            }

            return new Fraction(top, bot);
        }

        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            var result = new Fraction(f1.Top * f2.Bottom + f2.Top * f1.Bottom, f1.Bottom * f2.Bottom);

            return result;
        }

        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            var result = new Fraction(f1.Top * f2.Bottom - f2.Top * f1.Bottom, f1.Bottom * f2.Bottom);

            return result;
        }

        public static Fraction operator -(Fraction f)
        {
            var result = new Fraction(-f.Top, f.Bottom);

            return result;
        }

        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            var result = new Fraction(f1.Top * f2.Top, f1.Bottom * f2.Bottom);

            return result;
        }

        public static Fraction operator /(Fraction f1, Fraction f2)
        {
            var result = new Fraction(f1.Top * f2.Bottom, f1.Bottom * f2.Top);

            return result;
        }

        public static implicit operator Fraction(int number)
        {
            return new Fraction(number);
        }

        private static int GCD(int a, int b)
        {
            while (b != 0)
            {
                var t = b;
                b = a % b;
                a = t;
            }

            return a;
        }
    }
}

