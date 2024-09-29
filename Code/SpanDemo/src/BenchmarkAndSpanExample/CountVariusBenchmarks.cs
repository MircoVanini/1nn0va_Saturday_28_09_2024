using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace BenchmarkAndSpanExample
{
    [RankColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [MemoryDiagnoser]
    public class CountVariusBenchmarks
    {
        private const string Text = "One Two Three Four Five Six Seven Eight Nine Ten";
        private int[]? data;
        private static readonly CountVarius Parser = new CountVarius();

        [GlobalSetup]
        public void Setup()
        {
            data = Enumerable.Repeat<int>(1, 1000).ToArray();
        }

        [Benchmark(Baseline = true)]
        public void ContainsCapitalLetters()
        {
            Parser.ContainsCapitalLetters(Text);
        }

        [Benchmark]
        public void ContainsCapitalLettersSpan()
        {
            Parser.ContainsCapitalLettersSpan(Text);
        }

        [Benchmark]
        public void Sum()
        {
            Parser.Sum(data);
        }

        [Benchmark]
        public void SumSpan()
        {
            Parser.SumSpan(data);
        }
    }
}
