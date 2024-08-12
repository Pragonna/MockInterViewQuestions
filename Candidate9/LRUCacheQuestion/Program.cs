using BenchmarkDotNet.Running;

var cache = new LRUCache(2);

cache.Put(1, 1);                        // Adds the key 1 with value 1 to the cache
cache.Put(2, 2);                        // Adds the key 2 with value 2 to the cache
Console.WriteLine(cache.Get(1));        // returns 1
cache.Put(3, 3);                        // evicts key 2
Console.WriteLine(cache.Get(2));        // returns -1 (not found)
cache.Put(4, 4);                        // evicts key 1
Console.WriteLine(cache.Get(1));        // returns -1 (not found)
Console.WriteLine(cache.Get(3));        // returns 3
Console.WriteLine(cache.Get(4));        // returns 4


class LRUCache(int capacity)
{
   Dictionary<int, int> cache = new Dictionary<int, int>(capacity: cacheCapacity);
Dictionary<int, int> tempCache = new Dictionary<int, int>(capacity: cacheCapacity);
public int Get(int key)
{
    int value;
    if (cache.ContainsKey(key))
    {
        cache.Remove(key, out value);

        foreach (var c in cache)
            tempCache.Add(c.Key, c.Value);

        tempCache.Add(key, value);

        cache = ToCopyDictionary(tempCache, cache);
        return cache[key];
    }

    return -1;
}

public void Put(int key, int value)
{
    if (!cache.ContainsKey(key) && cacheCapacity == cache.Count)
    {
        cache.Remove(cache.First().Key);

        foreach (var c in cache)
            tempCache.Add(c.Key, c.Value);
        tempCache.Add(key, value);
        cache = ToCopyDictionary(tempCache, cache);
        return;
    }
    else if (cache.ContainsKey(key))
        return;

    cache.Add(key, value);
}

public Dictionary<int,int> ToCopyDictionary(Dictionary<int, int> from, Dictionary<int, int> to)
{
    to.Clear();
    foreach (var c in from)
        to.Add(c.Key, c.Value);
    tempCache.Clear();
    return to;
}
}
