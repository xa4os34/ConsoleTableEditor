using System.Text;

namespace TableEditor.Core.Tables.Extensions;

public static class StringBuilderExtensions
{
    public static StringBuilder AppendFirst(this StringBuilder stringBuilder, char value)
    {
        return stringBuilder.Insert(0, value);
    }
}
