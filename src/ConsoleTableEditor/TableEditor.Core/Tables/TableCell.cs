using TableEditor.Core.Tables.Decoration;
using TableEditor.Core.Tables.ValueTypes;

namespace TableEditor.Core.Tables;

public sealed class TableCell
{
    public Position Position { get; init; }
    public IValue? Value { get; set; }
    public IDecorationSettings DecorationSettings { get; set; } = new DefaultDecorationSettings();
}
