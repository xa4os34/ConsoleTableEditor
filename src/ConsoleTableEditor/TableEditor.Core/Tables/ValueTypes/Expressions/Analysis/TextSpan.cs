namespace TableEditor.Core.Tables.ValueTypes.Expressions.Analysis;

public struct TextSpan
{
    public TextSpan(string baseText, int position, int length)
        : this(baseText.Substring(position, length), position)
    {
    }

    public TextSpan(string text, int position)
    {
        Text = text;
        Position = position;
        Length = text.Length;
    }

    public string Text { get; }
    public int Position { get; }
    public int Length { get; }
}
