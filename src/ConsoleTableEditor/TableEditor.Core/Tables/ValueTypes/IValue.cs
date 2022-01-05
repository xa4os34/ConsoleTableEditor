namespace TableEditor.Core.Tables.ValueTypes;

public interface IValue
{
    public ValueType Type { get; }
    public object? Value { get; }
    public bool IsNotNull => Value is not null;
    public bool IsNull => Value is null;
}

