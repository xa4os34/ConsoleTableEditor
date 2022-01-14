namespace TableEditor.Core.Tables.ValueTypes.Expressions.Analysis.Nodes;

internal abstract class NodeBase
{
    public TextSpan TextSpan { get; set; }

    public abstract void Accept(NodeVisitorBase visitor);
}
