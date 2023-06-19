using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

public record Coordinates(int Latitude, int Longitude) : ISpanParsable<Coordinates>

{
    public static Coordinates Parse(ReadOnlySpan<char> s,
        IFormatProvider? provider = null)
    {
        return ParseInternal(s, provider);
    }

    public static Coordinates Parse(string s,
        IFormatProvider? provider)
    {
        return ParseInternal(s, provider);
    }

    public static bool TryParse(ReadOnlySpan<char> s,
        IFormatProvider? provider,
        [MaybeNullWhen(false)] out Coordinates result)
    {
        try
        {
            result = ParseInternal(s, provider);
            return true;
        }
        catch (Exception)
        {
            result = new Coordinates(0, 0);
            return false;
        }
    }

    public static bool TryParse([NotNullWhen(true)] string? s,
        IFormatProvider? provider,
        [MaybeNullWhen(false)] out Coordinates result)
    {
        try
        {
            result = ParseInternal(s, provider);
            return true;
        }
        catch (Exception)
        {
            result = new Coordinates(0, 0);
            return false;
        }
    }

    private static Coordinates ParseInternal(string s,
        IFormatProvider? provider)
    {
        var splitText = s.Split(',');
        var lat = splitText[0].Parse<int>();
        var lon = splitText[1].Parse<int>();

        return new Coordinates(lat, lon);
    }

    private static Coordinates ParseInternal(ReadOnlySpan<char> s,
        IFormatProvider? provider)
    {
        Span<Range> dest = stackalloc Range[2];
        s.Split(dest, '-');

        var lat = s[dest[0]];
        var lon = s[dest[1]];

        var latAsInt = int.Parse(lat);
        var lonAsInt = int.Parse(lon);

        return new Coordinates(latAsInt, lonAsInt);
    }
}







public record Coordinates<T>(T Latitude, T Longitude) : ISpanParsable<Coordinates<T>>
    where T : INumber<T>

{
    public static Coordinates<T> Parse(ReadOnlySpan<char> s,
        IFormatProvider? provider = null)
    {
        return ParseInternal(s, provider);
    }

    public static Coordinates<T> Parse(string s,
        IFormatProvider? provider)
    {
        return ParseInternal(s, provider);
    }

    public static bool TryParse(ReadOnlySpan<char> s,
        IFormatProvider? provider,
        [MaybeNullWhen(false)] out Coordinates<T> result)
    {
        try
        {
            result = ParseInternal(s, provider);
            return true;
        }
        catch (Exception)
        {
            result = new Coordinates<T>(T.Zero, T.Zero);
            return false;
        }
    }

    public static bool TryParse([NotNullWhen(true)] string? s,
        IFormatProvider? provider,
        [MaybeNullWhen(false)] out Coordinates<T> result)
    {
        try
        {
            result = ParseInternal(s, provider);
            return true;
        }
        catch (Exception)
        {
            result = new Coordinates<T>(T.Zero, T.Zero);
            return false;
        }
    }

    private static Coordinates<T> ParseInternal(string s,
        IFormatProvider? provider)
    {
        var splitText = s.Split('-');
        var x = splitText[0].Parse<T>();
        var y = splitText[1].Parse<T>();

        return new Coordinates<T>(x, y);
    }

    private static Coordinates<T> ParseInternal(ReadOnlySpan<char> s,
        IFormatProvider? provider)
    {
        Span<Range> dest = stackalloc Range[2];
        s.Split(dest, '-');

        var lat = s[dest[0]];
        var lon = s[dest[1]];

        // sounds like a bad idea
        var latAsString = lat.ToString();
        var lonAsString = lon.ToString();

        var latAsT = latAsString.Parse<T>();
        var lonAsT = lonAsString.Parse<T>();

        return new Coordinates<T>(latAsT, lonAsT);
    }
}

public static class SpanExtensions
{
    public static unsafe string AsString(this System.ReadOnlySpan<char> source)
    {
        string result = new string(' ', source.Length);
        fixed (char* dest = result, src = &MemoryMarshal.GetReference(source))
        {
            for (int i = 0; i < source.Length; i++)
            {
                *(dest + i) = *(src + i);
            }
        }
        return result;
    }
}


