namespace TableEditor.Core.Tables.ValueTypes.Expressions.Analysis.Nodes;

internal sealed class NumberNode : NodeBase
{
    public override void Accept(NodeVisitorBase visitor)
    {
        visitor.Visit(this);
    }
}
