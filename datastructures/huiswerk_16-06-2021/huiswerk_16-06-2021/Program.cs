using System;
using System.Collections.Generic;
using System.Linq;

namespace huiswerk_16_06_2021
{
    class Program
    {
        static List<string> A = new List<string>() { "aaa", "bbb", "ccc", "ddd"};
        static string r = "";
        static int counter = 0;
        static void Main(string[] args)
        {
            Merge(A);
            Console.WriteLine(r);
        }

        static void ConcatString(List<string> a, List<string> b)
        {
            if(counter < A.Count/2)
            {
                r += a[0] + b[0];
                counter++;
            }

        }

        static List<string> Merge(List<string> a)
        {
            if (a.Count <= 1)
                return a;

            List<string> tempLeft = new List<string>(), tempRight = new List<string>();
            for (int i = 0; i < a.Count; i++)
            {
                if (i < a.Count / 2)
                    tempLeft.Add(a[i]);
                else
                    tempRight.Add(a[i]);
            }

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
