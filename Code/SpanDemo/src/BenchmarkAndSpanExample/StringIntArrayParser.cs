using System;
namespace BenchmarkAndSpanExample
{
    public class StringIntArrayParser
    {
        public int StringParseSum(string data)
        {
            int sum = 0;

            // allocates
            string[] splitString = data.Split(',');

            for (int i = 0; i < splitString.Length; i++)
            {
                sum += int.Parse(splitString[i]);
            }

            return sum;
        }

        public int StringParseSumWithSpan(ReadOnlySpan<char> span)
        {
            int sum = 0;

            while (true)
            {
                int index = span.IndexOf(',');
                if (index == -1)
                {
                    sum += int.Parse(span);
                    break;
                }
                sum += int.Parse(span.Slice(0, index));
                span = span.Slice(index + 1);
            }
            return sum;
        }
    }
}
