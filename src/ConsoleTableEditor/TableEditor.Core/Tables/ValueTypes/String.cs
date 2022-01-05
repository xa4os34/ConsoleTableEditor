namespace TableEditor.Core.Tables.ValueTypes;

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

