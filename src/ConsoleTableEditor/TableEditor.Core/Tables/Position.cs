using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using TableEditor.Core.Tables.Converters;

namespace TableEditor.Core.Tables;

public struct Position
{
    public readonly BigInteger Column;
    public readonly BigInteger Row;

    public Position(BigInteger column, BigInteger row)
    {
        Column = column;
        Row = row;
    }

    public override string ToString()
    {
        string columnString = ColumnIndexConverter.ToString(Column);
        return $"{columnString}{Row}";
    }

    public override int GetHashCode()
    {
        int rowHeshCode = Row.GetHashCode();
        int columnHeshCode = Column.GetHashCode();

        return (columnHeshCode << 2) ^ rowHeshCode;
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        if (obj is null ||
            !typeof(Position).Equals(obj.GetType()))
            return false;

        var position = (Position)obj;

        if (!Column.Equals(position.Column) ||
            !Row.Equals(position.Row))
            return false;

        return position.Column == Column && position.Row == Row;
    }

    public static bool operator ==(Position left, Position right)
    {
        return left.Column == right.Column && left.Row == right.Row;
    }

    public static bool operator !=(Position left, Position right)
    {
        return left.Column != right.Column || left.Row != right.Row;
    }
}