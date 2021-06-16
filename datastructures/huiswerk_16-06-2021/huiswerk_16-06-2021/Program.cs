using System;
using System.Collections.Generic;
using System.Linq;

namespace huiswerk_16_06_2021
{
    class Program
    {
        // Initialize the game
        static List<string> A = new List<string>() { "aaa", "bbb", "ccc", "ddd"};
        static string r = "";
        static int counter = 0;
        static void Main(string[] args)
        {
            Merge(A);
            Console.WriteLine(r);
        }

        // Concat the string
        static void ConcatString(List<string> a, List<string> b)
        {
            // Check if is the first half
            if(counter < A.Count/2)
            {
                r += a[0] + b[0];
                counter++;
            }

        }

        // Basic implementation of the MergeSort, but to divide the arrays in recursion
        static List<string> Merge(List<string> a)
        {
            if (a.Count <= 1)
                return a;

            List<string> tempLeft = new List<string>(), tempRight = new List<string>();
            // First half goes to the left, and second half goes to the right
            for (int i = 0; i < a.Count; i++)
            {
                if (i < a.Count / 2)
                    tempLeft.Add(a[i]);
                else
                    tempRight.Add(a[i]);
            }

            // Recursion of both sides and do it till it's the last one.
            if(tempLeft.Count > 1 && tempRight.Count > 1)
            {
                tempLeft = Merge(tempLeft);
                tempRight = Merge(tempRight);
            }

            ConcatString(tempLeft, tempRight);

            return tempLeft;
        }
    }
}
