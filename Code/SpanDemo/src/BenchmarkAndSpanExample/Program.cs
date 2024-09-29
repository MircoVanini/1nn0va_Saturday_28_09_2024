using System;
using System.Numerics;
using BenchmarkDotNet.Running;

namespace BenchmarkAndSpanExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var summaryOne   = BenchmarkRunner.Run<NameParserBenchmarks>();
            var summaryTwo   = BenchmarkRunner.Run<SubstringVsSubsliceBenchmarks>();
            var summaryThree = BenchmarkRunner.Run<StringIntarrayParserBenchmarks>();           
        }
    }
}
