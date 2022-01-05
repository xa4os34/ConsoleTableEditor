using System.Globalization;

namespace TableEditor.Core.Tables.ValueTypes;

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

