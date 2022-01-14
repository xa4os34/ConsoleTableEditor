namespace TableEditor.Core.Tables.ValueTypes.Expressions.Analysis.Nodes;

internal class BinaryOperatorNode : NodeBase
{
    public override void Accept(NodeVisitorBase visitor)
    {
        visitor.Visit(this);
    }
}
