using System.Diagnostics.CodeAnalysis;
using System.Numerics;



public record Point3D(int X, int Y, int Z) : IParsable<Point3D>
{
    public static Point3D Parse(string s,
        IFormatProvider? provider = null)
    {
        return ParseInternal(s, provider);
    }

    public static bool TryParse([NotNullWhen(true)] string? s,
        IFormatProvider? provider, [MaybeNullWhen(false)] out Point3D result)
    {
        try
        {
            result = ParseInternal(s, provider);
            return true;
        }
        catch (Exception)
        {
            result = new Point3D(0, 0, 0);
            return false;
        }
    }

    private static Point3D ParseInternal(string s, IFormatProvider? provider)
    {
        var splitText = s.Split('-');
        var x = splitText[0].Parse<int>();
        var y = splitText[1].Parse<int>();
        var z = splitText[2].Parse<int>();

        return new Point3D(x, y, z);
    }
}


public record Point3D<T>(T X, T Y, T Z)
    : IParsable<Point3D<T>> where T : INumber<T>
{
    public static Point3D<T> Parse(string s,
        IFormatProvider? provider = null)
    { return ParsePrivate(s, provider); }

    public static bool TryParse([NotNullWhen(true)] string? s,
        IFormatProvider? provider,
        [MaybeNullWhen(false)] out Point3D<T> result)
    {
        try
        {
            result = ParsePrivate(s, provider);
            return true;
        }
        catch (Exception)
        {
            result = new Point3D<T>(T.Zero, T.Zero, T.Zero);
            return false;
        }
    }

    private static Point3D<T> ParsePrivate(string s, IFormatProvider? provider)
    {
        var splitText = s.Split('-');
        var x = splitText[0].Parse<T>();
        var y = splitText[1].Parse<T>();
        var z = splitText[2].Parse<T>();

        return new Point3D<T>(x, y, z);
    }
}

