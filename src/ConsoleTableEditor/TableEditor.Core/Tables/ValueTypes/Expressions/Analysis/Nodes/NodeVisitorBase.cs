namespace TableEditor.Core.Tables.ValueTypes.Expressions.Analysis.Nodes;

internal abstract class NodeVisitorBase
{
    public virtual void Visit(NumberNode numberNode)
    {
    }

    public virtual void Visit(CurrencyNode currencyNode)
    {
    }

    public virtual void Visit(StringNode stringNode)
    {
    }

    public virtual void Visit(LinkToCellNode linkToCellNode)
    {
    }

    public virtual void Visit(LinkToCellSpanNode linkToCellSpanNode)
    {
    }

    public virtual void Visit(BinaryOperatorNode binaryOperatorNode)
    {
    }

    public virtual void Visit(UnaryOperatorNode unaryOperatorNode)
    {
    }

    public virtual void Visit(FunctionNode functionNode)
    {
    }
}
