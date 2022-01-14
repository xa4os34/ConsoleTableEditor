namespace TableEditor.Core.Tables.ValueTypes.Expressions.Analysis.Symbols;

internal struct Symbol
{
    public Symbol(SymbolType type, TextSpan textSpan)
    {
        Type = type;
        TextSpan = textSpan;
    }

    public SymbolType Type { get; }
    public TextSpan TextSpan { get; }
}
