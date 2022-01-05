namespace TableEditor.Core.Tables.Decoration;

public sealed class DefaultDecorationSettings : IDecorationSettings
{
    public Border Border { get; } = new Border();
    public Color BackgroundColor => Color.Black;
    public Color ForegroundColor => Color.White;
}
