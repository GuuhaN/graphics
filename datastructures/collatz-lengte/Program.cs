using System;

namespace collatz_lengte
{
    class Program
    {
        static readonly int[] _testingNumbers = { 22, 11, 34, 17, 52, 26, 13, 40, 20, 10, 5, 16, 8, 4, 2, 1 };
        static void Main(string[] args)
        {
            CalculateCollatz(1);
        }
        
        static void CalculateCollatz(int value)
        {
            int collatzNumber = value;
            Console.WriteLine(collatzNumber);
            while (collatzNumber != 1)
            {
                if (collatzNumber % 2 != 0) // Odd number
                    collatzNumber = (collatzNumber * 3) + 1;
                else // Even number
                    collatzNumber = collatzNumber / 2;

                Console.WriteLine(collatzNumber);
            }
        }
    }
}
