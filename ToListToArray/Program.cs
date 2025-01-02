using BenchmarkDotNet.Running;

namespace ToListToArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Benchmark>();
        }
    }
}
