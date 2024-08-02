using System.Collections.Generic;

namespace LRUCacheQuestion.Solutions;
public class OptimizedLRUCache
{
    private readonly int capacity;
    private readonly Dictionary<int, LinkedListNode<(int key, int value)>> cache;
    private readonly LinkedList<(int key, int value)> lruList;

    public OptimizedLRUCache(int capacity)
    {
        this.capacity = capacity;
        cache = new Dictionary<int, LinkedListNode<(int key, int value)>>(capacity);
        lruList = new LinkedList<(int key, int value)>();
    }

    public int Get(int key)
    {
        if (!cache.TryGetValue(key, out var node))
            return -1;
        
        lruList.Remove(node);
        lruList.AddFirst(node);
        
        return node.Value.value;
    }

    public void Put(int key, int value)
    {
        if (cache.TryGetValue(key, out var node))
        {
            lruList.Remove(node);
            node.Value = (key, value);
            lruList.AddFirst(node);
        }
        else
        {
            if (cache.Count == capacity)
            {
                var lruNode = lruList.Last;
                cache.Remove(lruNode.Value.key);
                lruList.RemoveLast();
            }

            var newNode = new LinkedListNode<(int key, int value)>((key, value));
            lruList.AddFirst(newNode);
            cache[key] = newNode;
        }
    }
}
