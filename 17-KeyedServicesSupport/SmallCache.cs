using Microsoft.Extensions.Caching.Memory;

internal class SmallCache : IMemoryCache
{
    public ICacheEntry CreateEntry(object key)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public void Remove(object key)
    {
        throw new NotImplementedException();
    }

    public bool TryGetValue(object key, out object? value)
    {
        value = $"SmallCache {key}";
        return true;
    }
}