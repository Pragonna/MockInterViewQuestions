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
    public void Put(int key, int value)
    {
        throw new NotImplementedException();
    }

    public int Get(int key)
    {
        throw new NotImplementedException();
    }
}