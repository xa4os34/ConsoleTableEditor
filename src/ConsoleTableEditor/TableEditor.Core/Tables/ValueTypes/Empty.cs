namespace TableEditor.Core.Tables.ValueTypes;

public sealed class Empty : IValue
{
    public ValueType Type => ValueType.Empty;

    public object? Value => null;

    public override string ToString()
    {
        return string.Empty;
    }
}

