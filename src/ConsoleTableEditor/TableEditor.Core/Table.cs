using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using System.Text;

namespace TableEditor.Core
{
    public sealed class Table
    {

    }

    public enum ValueType
    {
        Empty,
        Null,
        String,
        Currency,
        Number,
        Expression,
    }

    public interface IValue
    {
        public ValueType Type { get; }
        public object? Value { get; }
        public bool IsNotNull => Value is not null;
        public bool IsNull => Value is null;
    }

    public sealed class TableCell
    {
        public Position Position { get; init; }
        public IValue? Value { get; set; }
        public IDecorationSettings DecorationSettings { get; set; } = new DefaultDecorationSettings();
    }

    public interface IDecorationSettings
    {
        public Border Border { get; }
        public Color BackgroundColor { get; }
        public Color ForegroundColor { get; }
    }

    public struct Color
    {
        public readonly byte R;
        public readonly byte G;
        public readonly byte B;

        public Color(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }

        public static Color Black => new Color(0, 0, 0);
        public static Color White => new Color(255, 255, 255);
    }

    public sealed class DefaultDecorationSettings : IDecorationSettings
    {
        public Border Border { get; } = new Border();
        public Color BackgroundColor => Color.Black;
        public Color ForegroundColor => Color.White;
    }

    public sealed class DecorationSettings : IDecorationSettings
    {
        public Border Border { get; set; } = new Border();
        public Color BackgroundColor { get; set; }
        public Color ForegroundColor { get; set; }
    }

    public sealed class Border
    {
        public BorderType TopBorder { get; set; }
        public BorderType LeftBorder { get; set; }
    }

    public enum BorderType
    {
        Default,
        Thick,
        VeryThick,
    }

    public interface IExpression : IValue
    {

    }

    public sealed class Expression : IExpression
    {
        public Expression()
        {
            throw new NotImplementedException();
        }

        public ValueType Type => ValueType.Expression;
        public object? Value { get; private set; }
    }

    public sealed class String : IValue
    {
        private readonly string _value;

        public String(string value)
        {
            _value = value;
        }

        public string StringValue => _value;
        public object? Value => _value;
        public ValueType Type => ValueType.String;

        public override string ToString()
        {
            return _value;
        }
    }

    public sealed class Currency : IValue
    {
        private readonly decimal _value;
     
        public Currency(decimal value, CultureInfo culture)
        {
            Culture = culture;
            _value = value;
        }

        public CultureInfo Culture { get; }
        public decimal NumberValue => _value;
        public object? Value => _value;
        public ValueType Type => ValueType.Currency;

        public override string ToString()
        {
            return $"{_value}{Culture.NumberFormat.CurrencySymbol}";
        }
    }

    public sealed class Number : IValue
    {
        private readonly double _value;

        public Number(double value)
        {
            _value = value;
        }

        public double NumberValue => _value;
        public object? Value => _value;
        public ValueType Type => ValueType.Number;

        public override string ToString()
        {
            return _value.ToString();
        }
    }

    public sealed class Null : IValue
    {
        public ValueType Type => ValueType.Null;
        public object? Value => null;

        public override string ToString()
        {
            return "Null";
        }
    }

    public sealed class Empty : IValue
    {
        public ValueType Type => ValueType.Empty;

        public object? Value => null;

        public override string ToString()
        {
            return string.Empty;
        }
    }

    public struct Position
    {
        public readonly BigInteger Column;
        public readonly BigInteger Row;

        public Position(BigInteger column, BigInteger row)
        {
            Column = column;
            Row = row;
        }

        public override string ToString()
        {
            string columnString = ColumnIndexConverter.ToString(Column);
            return $"{columnString}{Row}";
        }

        public override int GetHashCode()
        {
            int rowHeshCode = Row.GetHashCode();
            int columnHeshCode = Column.GetHashCode();

            return (columnHeshCode << 2) ^ rowHeshCode;
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is null || 
                !typeof(Position).Equals(obj.GetType()))
                return false;

            var position = (Position)obj;

            if (!Column.Equals(position.Column) ||
                !Row.Equals(position.Row))
                return false;

            return position.Column == Column && position.Row == Row;
        }

        public static bool operator ==(Position left, Position right)
        {
            return left.Column == right.Column && left.Row == right.Row;
        }

        public static bool operator !=(Position left, Position right)
        {
            return left.Column != right.Column || left.Row != right.Row;
        }
    }

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

    public static class StringBuilderExtensions
    {
        public static StringBuilder AppendFirst(this StringBuilder stringBuilder, char value)
        {
            return stringBuilder.Insert(0, value);
        }
    }
}