namespace TableEditor.Core.Tables.ValueTypes.Expressions;

public sealed class Expression : IExpression
{
    public Expression()
    {
        throw new NotImplementedException();
    }

    public ValueType Type => ValueType.Expression;
    public object? Value { get; private set; }

    public void UpdateValue(IUpdateContext context)
    {
        throw new NotImplementedException();
    }
}