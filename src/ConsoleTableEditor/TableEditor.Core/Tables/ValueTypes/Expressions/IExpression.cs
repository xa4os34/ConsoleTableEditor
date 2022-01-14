namespace TableEditor.Core.Tables.ValueTypes.Expressions;

public interface IExpression : IValue
{
    public void UpdateValue(IUpdateContext context);
}
