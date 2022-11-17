# Fractions
Adds a *Fraction* struct to work with real numbers in fraction format without loss of precision.
## Usage:
Вы можете создавать дроби с помощью конструктора структуры Fraction либо с помощью статического метода Fraction.Parse.
```cs
var fraction1 = Fraction.Parse("1/3");
var fraction2 = new Fraction(1, 6);
Console.WriteLine("1 + fraction1 - fraction2");
```
