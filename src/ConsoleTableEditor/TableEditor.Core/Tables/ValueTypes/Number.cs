namespace TableEditor.Core.Tables.ValueTypes;

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

