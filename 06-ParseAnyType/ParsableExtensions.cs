﻿

public static class ParsableExtensions
{
    public static T Parse<T>(this string input,
        IFormatProvider? formatProvider = null)
        where T : IParsable<T>
    {
        return T.Parse(input, formatProvider);
    }

}

