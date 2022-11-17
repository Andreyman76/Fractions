# Fractions
Adds a *Fraction* struct to work with real numbers in fraction format without loss of precision.
## Usage:
You can create fractions using the constructor of the *Fraction* structure or using the static *Fraction.Parse* method.
```cs
var f1 = Fraction.Parse("1/3");
var f2 = new Fraction(1, 6);
Console.WriteLine($"Fraction 1: {f1}");
Console.WriteLine($"Fraction 2: {f2}");
```
## Output:
```
Fraction 1: 1/3
Fraction 2: 1/6
```
Fractions are automatically reduced when possible.
```cs
var f = new Fraction(50, 100);
Console.WriteLine(f);
```
## Output:
```
1/2
```
For fractions, operators of **addition**, **subtraction**, **multiplication**, **division**, **unary minus** are defined.
```cs
var f1 = Fraction.Parse("1/3");
var f2 = new Fraction(1, 6);

Console.WriteLine($"{f1} + {f2} = {f1 + f2}");
Console.WriteLine($"{f1} - {f2} = {f1 - f2}");
Console.WriteLine($"{f1} * {f2} = {f1 * f2}");
Console.WriteLine($"{f1} / {f2} = {f1 / f2}");
Console.WriteLine($"-{f1} = {-f1}");
```
## Output:
```
1/3 + 1/6 = 1/2
1/3 - 1/6 = 1/6
1/3 * 1/6 = 1/18
1/3 / 1/6 = 2/1
-1/3 = -1/3
```
Also, comparison operators are defined for fractions.
```cs
var f1 = Fraction.Parse("5/100");
var f2 = Fraction.Parse("1/10");

Console.WriteLine($"{f1} == {f2} = {f1 == f2}");
Console.WriteLine($"{f1} != {f2} = {f1 != f2}");
Console.WriteLine($"{f1} > {f2} = {f1 > f2}");
Console.WriteLine($"{f1} < {f2} = {f1 < f2}");
Console.WriteLine($"{f1} >= {f2} = {f1 >= f2}");
Console.WriteLine($"{f1} <= {f2} = {f1 <= f2}");
```
## Output:
```
1/20 == 1/10 = False
1/20 != 1/10 = True
1/20 > 1/10 = False
1/20 < 1/10 = True
1/20 >= 1/10 = False
1/20 <= 1/10 = True
```
Integers (**int**) involved in operations with fractions are automatically converted to a *Fraction* structure.
```cs
var f1 = Fraction.Parse("1/3");
var f2 = new Fraction(1, 6);
Console.WriteLine(2 + f1 + f2 + 1);
```
## Output:
```
7/2
```
Fractions have several properties for getting the data of the fraction itself, as well as converting the representation of the fraction to another number type.
```cs
var f1 = new Fraction(10, 3);
Console.WriteLine($"Fraction 1: {f1}");
Console.WriteLine($"Top: {f1.Top}");
Console.WriteLine($"Bottom: {f1.Bottom}");
Console.WriteLine($"Float: {f1.Float}");
Console.WriteLine($"Double: {f1.Double}");
Console.WriteLine($"Decimal: {f1.Decimal}");          
Console.WriteLine($"Int: {f1.Int}");
Console.WriteLine($"Is int: {f1.IsInt}");

var f2 = Fraction.Parse("12/6");
Console.WriteLine($"\nFraction 2: {f2}");
Console.WriteLine($"Is int: {f2.IsInt}");
```
## Output:
```
Fraction 1: 10/3
Top: 10
Bottom: 3
Float: 3,333333
Double: 3,33333333333333
Decimal: 3,3333333333333333333333333333
Int: 3
Is int: False

Fraction 2: 2/1
Is int: True
```
An example showing the preservation of precision when using fractions.
```cs
var d = 1000_000_000.0;
var f = new Fraction(1000_000_000);

Console.WriteLine($"Double: {d} + 0.0000001 = {d + 0.0_000_001}");
Console.WriteLine($"Fraction: {f} + 1/10000000 = {f + new Fraction(1, 10_000_000)}");
```
## Output:
```
Double: 1000000000 + 0.0000001 = 1000000000
Fraction: 1000000000/1 + 1/10000000 = 10000000000000001/10000000
```