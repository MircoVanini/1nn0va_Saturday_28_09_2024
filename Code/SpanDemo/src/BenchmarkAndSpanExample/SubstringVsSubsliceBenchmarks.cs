using System;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace BenchmarkAndSpanExample
{
    [RankColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [MemoryDiagnoser]
    public class SubstringVsSubsliceBenchmarks
    {
        private string text = string.Empty;

        [Params(10, 10_000)]
        public int CharactersCount { get; set; }

        [GlobalSetup]
        public void Setup() => text = new string(Enumerable.Repeat('a', CharactersCount).ToArray());

        [Benchmark]
        public string Substring() => text.Substring(0, text.Length / 2);

        [Benchmark(Baseline = true)]
        public ReadOnlySpan<char> Slice() => text.AsSpan(0, text.Length / 2);
    }
}
