using System;

namespace Demo_1_Ref
{
    class Customer
    {
        public string? Name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var tmp = new Customer();
            tmp.Name = "CBA";

            TestOne(tmp);

            TestTwo(tmp);

            TestThree(ref tmp);
        }

        static void TestOne(Customer customer)
        {
            customer.Name = "ABC";
        }

        static void TestTwo(Customer customer)
        {
            customer = new Customer();
            customer.Name = "ABC";
        }

        static void TestThree(ref Customer customer)
        {
            customer = new Customer();
            customer.Name = "ABC";
        }
    }
}
