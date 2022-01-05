using System.Globalization;
using System.Text;
using TableEditor.Core;
using TableEditor.Core.Tables;
using TableEditor.Core.Tables.Decoration;
using String = TableEditor.Core.Tables.ValueTypes.String;

const int Width = 4;
const int Height = 4;
const int CellWidth = 30;
const int CellHeight = 1;

var TableCells = new List<TableCell>()
{
    new TableCell()
    {
        Position = new Position(0, 0),
        Value = new String("Login"),
        DecorationSettings = new DecorationSettings()
        {
            Border = new Border()
            {
                LeftBorder = BorderType.Thick,
                TopBorder = BorderType.Thick,
            }
        }
    },
    new TableCell()
    {
        Position = new Position(1, 0),
        Value = new String("Password"),
        DecorationSettings = new DecorationSettings()
        {
            Border = new Border()
            {
                LeftBorder = BorderType.Thick,
                TopBorder = BorderType.Thick,
            }
        }
    },
    new TableCell()
    {
        Position = new Position(0, 1),
        Value = new String("xa4"),
        DecorationSettings = new DecorationSettings()
        {
            Border = new Border()
            {
                LeftBorder = BorderType.Thick,
                TopBorder = BorderType.Thick,
            }
        }
    },
    new TableCell()
    {
        Position = new Position(1, 1),
        Value = new String("1268234LKsd("),
        DecorationSettings = new DecorationSettings()
        {
            Border = new Border()
            {
                LeftBorder = BorderType.Thick,
                TopBorder = BorderType.Thick,
            }
        }
    },
};

DateTime startRenderingTime = DateTime.Now;

var stringBuilder = new StringBuilder();

for (int y = 0; y < Height; y++)
{
    stringBuilder.Append(y != 0 ? '├' : '┌');
    for (int x = 0; x < Width; x++)
    {
        stringBuilder.Append(new string('─', CellWidth));
        stringBuilder.Append(y != 0 ? '┼' : '┬');
    }

    stringBuilder.AppendLine();

    for (int i = 0; i < CellHeight; i++)
    {
        for (int x = 0; x < Width; x++)
        {
            stringBuilder.Append('│');

            var position = new Position(x, y);

            TableCell? cell = TableCells.FirstOrDefault(x => x.Position == position);

            if (cell is null ||
                cell.Value is null ||
                cell.Value.IsNull)
            {
                stringBuilder.Append(new string(' ', CellWidth));
                continue;
            }

            string stringValue = cell.Value.ToString()!;

            int spaceLength = (int)MathF.Round((CellWidth - stringValue.Length) / 2f);

            if (spaceLength >= 0)
            {
                stringBuilder.Append($"{new string(' ', spaceLength)}{stringValue}{new string(' ', CellWidth - spaceLength - stringValue.Length)}");
                continue;
            }

            spaceLength = stringValue.Length - CellWidth + 2;

            stringBuilder.Append($"{stringValue[0..^spaceLength]}..");
        }
        stringBuilder.Append('│');
        stringBuilder.AppendLine();
    }
}

stringBuilder.Append('├');
for (int x = 0; x < Width; x++)
{
    stringBuilder.Append(new string('─', CellWidth));
    stringBuilder.Append('┼');
}


TimeSpan RenderingDelay = DateTime.Now - startRenderingTime;

Console.WriteLine(stringBuilder);
Console.WriteLine($"Rendering delay: {RenderingDelay.TotalMilliseconds}ms");

internal static class ColorConverter
{
    public static ConsoleColor ToConsoleColor(Color color)
    {
        int index = (color.R > 128 | color.G > 128 | color.B > 128) ? 8 : 0;
        index |= (color.R > 64) ? 4 : 0;
        index |= (color.G > 64) ? 2 : 0;
        index |= (color.B > 64) ? 1 : 0;
        return (ConsoleColor)index;
    }
}