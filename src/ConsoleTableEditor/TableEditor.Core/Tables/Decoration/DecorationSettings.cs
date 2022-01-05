namespace TableEditor.Core.Tables.Decoration;

public sealed class DecorationSettings : IDecorationSettings
{
    public Border Border { get; set; } = new Border();
    public Color BackgroundColor { get; set; }
    public Color ForegroundColor { get; set; }
}
