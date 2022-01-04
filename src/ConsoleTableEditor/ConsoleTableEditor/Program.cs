using ConsoleTableEditor.Core;
using System.Globalization;

Console.WriteLine(decimal.MaxValue);
Console.WriteLine(float.MaxValue);
Console.WriteLine(double.MaxValue);


for (int i = 0; i < 100; i++)
{
    Console.WriteLine(new Number(1.0d + i / 100d));
    Console.WriteLine(new Currency(1.0m + i / 100m, new CultureInfo("US-us")));
    Console.WriteLine(new Currency(1.0m + i / 100m, new CultureInfo("RU-ru")));
    Console.WriteLine(new Currency(1.0m + i / 100m, new CultureInfo("JP-jp")));
}