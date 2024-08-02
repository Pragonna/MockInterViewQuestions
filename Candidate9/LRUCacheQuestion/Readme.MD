### Candidate: Harun Korkmaz
### Interviewer: Salih Cantekin
---


## LRU (Least Recently Used) Cache Implementation

### Objective:
Implement a cache that removes the least recently used item when it reaches its capacity.

### Operations:
- **`Get(int key)`**: Retrieve the value associated with the key if it exists in the cache. Return -1 if the key does not exist.
- **`Put(int key, int value)`**: Insert or update the key-value pair in the cache. If the cache reaches its capacity, remove the least recently used item before inserting the new item.

### Constraints:
- The key should be an integer.
- The value should be a positive integer.
- The cache should be initialized with a positive capacity.

### Example Scenario:

```csharp
LRUCache cache = new LRUCache(2); // Initialize the cache with capacity 2

cache.Put(1, 1); // Cache is {1=1}
cache.Put(2, 2); // Cache is {1=1, 2=2}
cache.Get(1);    // returns 1, Cache is {2=2, 1=1}
cache.Put(3, 3); // LRU key 2 is evicted, Cache is {1=1, 3=3}
cache.Get(2);    // returns -1 (not found)
cache.Put(4, 4); // LRU key 1 is evicted, Cache is {3=3, 4=4}
cache.Get(1);    // returns -1 (not found)
cache.Get(3);    // returns 3
cache.Get(4);    // returns 4
```