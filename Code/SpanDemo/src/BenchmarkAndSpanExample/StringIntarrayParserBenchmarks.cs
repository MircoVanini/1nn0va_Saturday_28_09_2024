using System.Linq;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace BenchmarkAndSpanExample
{
    [RankColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [MemoryDiagnoser]
    public class StringIntarrayParserBenchmarks
    {
        private string text = string.Empty;
        private static readonly StringIntArrayParser Parser = new StringIntArrayParser();

        [Params(10, 100_000)]
        public int ItemCount { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            StringBuilder sb = new StringBuilder(ItemCount * 5);
            for(int i = 0; i < ItemCount; i++)
            {
                sb.AppendFormat($"{i},");
            }

            text = sb.ToString(0, sb.Length - 2);
        }

        [Benchmark(Baseline = true)]
        public void StringParseSum()
        {
            Parser.StringParseSum(text);
        }

        [Benchmark]
        public void StringParseSumWithSpan()
        {
            Parser.StringParseSumWithSpan(text);
        }
    }
}
