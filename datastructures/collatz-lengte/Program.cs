using System;

namespace collatz_lengte
{
    class Program
    {
        static void Main(string[] args)
        {
            long input = Convert.ToUInt32(Console.ReadLine());
            long input2 = Convert.ToUInt32(Console.ReadLine());
            long input3 = Convert.ToUInt32(Console.ReadLine());
            long input4 = Convert.ToUInt32(Console.ReadLine());
            CalculateCollatz(input, input2, input3, input4); // Take 4 input values
        }
        
        static void CalculateCollatz(long value1, long value2, long value3, long value4)
        {
            long[] values = { value1, value2, value3, value4 }; // Using long instead of int, because one of the tests exceeds 2.1billion (max number of an int and even exceeds from unsigned int)
            foreach (long number in values)
            {
                long collatzNumber = number;
                // string collatz = number.ToString(); Enable this to visualize it, but having this will affect performance
                int steps = 0;
                while (collatzNumber != 1)
                {
                    if (collatzNumber % 2 != 0) // Odd number
                        collatzNumber = (collatzNumber * 3) + 1;
                    else // Even number
                        collatzNumber = collatzNumber / 2;

                    //collatz += "->" + collatzNumber; Enable this to visualize it, but having this will affect performance
                    steps += 1;
                }
                Console.WriteLine(steps);
            }
        }
    }
}
