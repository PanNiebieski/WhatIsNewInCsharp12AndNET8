using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;

internal class BigCache : IMemoryCache
{
    public ICacheEntry CreateEntry(object key)
    {
        return null;
    }

    public void Dispose()
    {

    }

    public void Remove(object key)
    {

    }

    public bool TryGetValue(object key, out object? value)
    {
        value = $"BigCache {key}";
        return true;
    }
}

