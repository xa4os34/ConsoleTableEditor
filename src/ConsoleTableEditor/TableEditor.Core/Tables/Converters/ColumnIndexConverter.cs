using System.Numerics;
using System.Text;
using TableEditor.Core.Tables.Extensions;

namespace TableEditor.Core.Tables.Converters;

public static class ColumnIndexConverter
{
    private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public static string ToString(BigInteger value)
    {
        var stringBuilder = new StringBuilder();

        while (true)
        {
            if (value < Alphabet.Length)
            {
                stringBuilder.AppendFirst(Alphabet[(int)value]);
                break;
            }

            int index = (int)(value % Alphabet.Length);
            value = value / Alphabet.Length - 1;
            char c = Alphabet[index];
            stringBuilder.AppendFirst(c);
        }

        return stringBuilder.ToString();
    }

    public static BigInteger ToBigInteger(string value)
    {
        if (!IsStringConvertibleToBigInteger(value))
            throw new ArgumentException($"{nameof(value)} not convertible string.");

        BigInteger BigIntValue = value
            .Reverse()
            .Select((c, i) =>
            {
                BigInteger value = Alphabet.IndexOf(c) + 1;
                value *= BigInteger.Pow(Alphabet.Length, i);
                return value;
            })
            .Aggregate((l, r) => l + r);

        return BigIntValue - 1;
    }

    public static bool IsStringConvertibleToBigInteger(string? str)
    {
        if (string.IsNullOrWhiteSpace(str) ||
            str.Any(x => !Alphabet.Contains(x)))
            return false;

        return true;
    }
}