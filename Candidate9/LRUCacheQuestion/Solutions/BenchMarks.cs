using BenchmarkDotNet.Attributes;

namespace LRUCacheQuestion.Solutions;

[MemoryDiagnoser]
public class BenchMarks
{
    HashSet<int> randomValues = new();

    [Params(1_000, 10_000, 100_000)]
    public int RandomValueCount { get; set; }

    [IterationSetup]
    public void IterationSetup()
    {
        randomValues = Enumerable.Range(0, RandomValueCount).Select(_ => new Random().Next(0, RandomValueCount)).ToHashSet();
    }

    [Benchmark]
    public void SimpleSolution()
    {
        LRUCache cache = new(RandomValueCount);

        foreach (var value in randomValues)
        {
            cache.Put(value, value);
            cache.Get(value);
        }

        foreach (var value in randomValues)
        {
            cache.Put(value, value);
        }
    }

    [Benchmark]
    public void OptimizedSolution()
    {
        OptimizedLRUCache cache = new(RandomValueCount);

        foreach (var value in randomValues)
        {
            cache.Put(value, value);
            cache.Get(value);
        }

        foreach (var value in randomValues)
        {
            cache.Put(value, value);
        }
    }
}