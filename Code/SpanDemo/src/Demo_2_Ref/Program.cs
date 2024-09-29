using System;

namespace Demo_2_Ref
{
    class Program
    {
        static void Main(string[] args)
        {   
            var store = new NumberStore();
            Console.WriteLine($"Original sequence: {store.ToString()}");

            int number = 16;
            ref var value = ref store.FindNumber(number);
            value *= 2;

            Console.WriteLine($"New sequence: {store.ToString()}");

            ref var tmp = ref number;
            tmp = 3;
        }
    }   

    class NumberStore
    {
        readonly int[] numbers = { 1, 3, 7, 15, 31, 63, 127, 255, 511, 1023 };

        public ref int FindNumber(int target)
        {
            for (int idx = 0; idx < numbers.Length; idx++)
            {
                if (numbers[idx] >= target)
                    return ref numbers[idx];
            }

            return ref numbers[0];
        }

        public override string ToString() => string.Join(" ", numbers);
    }
}
