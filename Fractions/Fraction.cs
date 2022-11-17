using System;

namespace Fractions
{
    public struct Fraction
    {
        public long Top { get; private set; }
        public long Bottom { get; private set; }

        public float Float => (float)Top / Bottom;
        public double Double => (double)Top / Bottom;
        public decimal Decimal => (decimal)Top / Bottom;
        public long Int => Top / Bottom;
        public bool IsInt => Bottom == 1;

        public Fraction(long top, long bottom = 1L)
        {
            if (bottom == 0)
            {
                throw new DivideByZeroException("Bottom can not be a zero");
            }

            Top = top;
            Bottom = bottom;

            Reduce();
        }

        private void Reduce()  // Reduce fraction
        {
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
            var topAndBot = fraction.Split('/');

            if (topAndBot.Length != 2)
            {
                throw new FormatException($"Wrong fraction format: {fraction}");
            }

            if (!long.TryParse(topAndBot[0], out long top))
            {
                throw new FormatException($"Wrong fraction format: {fraction} at {topAndBot[0]}");
            }

            if (!long.TryParse(topAndBot[1], out long bot))
            {
                throw new FormatException($"Wrong fraction format: {fraction} at {topAndBot[1]}");
            }

            return new Fraction(top, bot);
        }

        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            var bottom = GetCommonDenominator(f1, f2, out var f1Top, out var f2Top);
            var result = new Fraction(f1Top + f2Top, bottom);

            return result;
        }

        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            var bottom = GetCommonDenominator(f1, f2, out var f1Top, out var f2Top);
            var result = new Fraction(f1Top - f2Top, bottom);

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

        public static bool operator ==(Fraction f1, Fraction f2)
        {
            return f1.Top == f2.Top && f1.Bottom == f2.Bottom;
        }

        public static bool operator !=(Fraction f1, Fraction f2)
        {
            return !(f1 == f2);
        }

        public static bool operator >(Fraction f1, Fraction f2)
        {
            GetCommonDenominator(f1, f2, out var f1Top, out var f2Top);

            return f1Top > f2Top;
        }

        public static bool operator <(Fraction f1, Fraction f2)
        {
            GetCommonDenominator(f1, f2, out var f1Top, out var f2Top);

            return f1Top < f2Top;
        }

        private static long GetCommonDenominator(Fraction f1, Fraction f2, out long f1Top, out long f2Top)
        {
            var bottom = MLC(f1.Bottom, f2.Bottom);
            f1Top = f1.Top * (bottom / f1.Bottom);
            f2Top = f2.Top * (bottom / f2.Bottom);

            return bottom;
        }

        public static bool operator >=(Fraction f1, Fraction f2)
        {
            return f1 == f2 || f1 > f2;
        }

        public static bool operator <=(Fraction f1, Fraction f2)
        {
            return f1 == f2 || f1 < f2;
        }

        public static implicit operator Fraction(long number)
        {
            return new Fraction(number);
        }

        private static long GCD(long a, long b)
        {
            while (b != 0)
            {
                var t = b;
                b = a % b;
                a = t;
            }

            return a;
        }

        private static long MLC(long a, long b)
        {
            return (a * b) / GCD(a, b);
        }
    }
}

