namespace TableEditor.Core.Tables.ValueTypes.Expressions.Analysis.Nodes;

internal sealed class LinkToCellNode : NodeBase
{
    public override void Accept(NodeVisitorBase visitor)
    {
        visitor.Visit(this);
    }
}
