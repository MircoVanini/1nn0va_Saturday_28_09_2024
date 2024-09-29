using System;
using System.Linq;

namespace BenchmarkAndSpanExample
{
    public class CountVarius
    {
        public bool ContainsCapitalLetters(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsUpper(s[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public bool ContainsCapitalLettersSpan(ReadOnlySpan<char> s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsUpper(s[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public int Sum(int[] a)
        {
            int sum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                sum += a[i];
            }
            return sum;
        }

        public int SumSpan(ReadOnlySpan<int> a)
        {
            int sum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                sum += a[i];
            }
            return sum;
        }
    }
}
