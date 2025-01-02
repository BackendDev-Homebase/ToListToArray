using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace ToListToArray;

[SimpleJob(RuntimeMoniker.Net80)]
[SimpleJob(RuntimeMoniker.Net90)]
[MemoryDiagnoser]

public class Benchmark
{
    private List<Person> _source = default!;

    private List<Person> _smallSource = default!;
    
    [GlobalSetup]
    public void Setup()
    {
        _source = Enumerable.Range(0, 10_000)
            .Select(i => new Person())
            .ToList();
        _smallSource = Enumerable.Range(0, 100)
            .Select(i => new Person())
            .ToList();
    }

    [Benchmark]
    public Person[] NoSkipToArray() => _source.ToArray();

    [Benchmark]
    public List<Person> NoSkipToList() => _source.ToList();

    [Benchmark]
    public Person[] ToArray() => _source.Skip(1).ToArray();

    [Benchmark(Baseline = true)]
    public List<Person> ToList() => _source.Skip(1).ToList();
    
    [Benchmark]
    public Person[] SmallToArray() => _smallSource.Skip(1).ToArray();

    [Benchmark]
    public List<Person> SmallToList() => _smallSource.Skip(1).ToList();
}
