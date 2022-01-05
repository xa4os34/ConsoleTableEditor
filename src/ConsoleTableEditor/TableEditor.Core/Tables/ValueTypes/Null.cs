namespace TableEditor.Core.Tables.ValueTypes;

public sealed class Null : IValue
{
    public ValueType Type => ValueType.Null;
    public object? Value => null;

    public override string ToString()
    {
        return "Null";
    }
}

