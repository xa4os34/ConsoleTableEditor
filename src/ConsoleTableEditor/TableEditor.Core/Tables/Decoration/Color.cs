namespace TableEditor.Core.Tables.Decoration;

public struct Color
{
    public readonly byte R;
    public readonly byte G;
    public readonly byte B;

    public Color(byte r, byte g, byte b)
    {
        R = r;
        G = g;
        B = b;
    }

    public static Color Black => new Color(0, 0, 0);
    public static Color White => new Color(255, 255, 255);
}
