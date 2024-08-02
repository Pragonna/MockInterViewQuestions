namespace LRUCacheQuestion.Solutions;
public class LRUCache
{
    private readonly int capacity;
    private readonly Dictionary<int, int> cache;
    private readonly List<int> usageOrder;

    public LRUCache(int capacity)
    {
        this.capacity = capacity;
        cache = new Dictionary<int, int>();
        usageOrder = new List<int>();
    }

    public int Get(int key)
    {
        if (!cache.ContainsKey(key))
            return -1;
        
        usageOrder.Remove(key);             // remove the key from the usage order
        usageOrder.Add(key);                // add the key to the end of the usage order

        return cache[key];
    }

    public void Put(int key, int value)
    {
        if (cache.ContainsKey(key))
        {
            cache[key] = value;             // update the value of the key
            usageOrder.Remove(key);         // remove the key from the usage order
            usageOrder.Add(key);            // add the key to the end of the usage order
        }
        else
        {
            if (cache.Count == capacity)    // reached capacity
            {
                int lruKey = usageOrder[0]; // get the least recently used key
                usageOrder.RemoveAt(0);     // remove the least recently used key
                cache.Remove(lruKey);       // remove the least recently used key from the cache
            }

            cache[key] = value;             // add the new key to the cache
            usageOrder.Add(key);            // add the new key to the usage order
        }
    }
}
