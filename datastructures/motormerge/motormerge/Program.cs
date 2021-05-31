using System;
using System.Linq;
using System.Collections.Generic;

namespace motormerge
{
    class Program
    {
        static List<(string, int, int, int)> motors = new List<(string, int, int, int)>();
        enum Filter { Snelheid = 2, Gewicht = 3};
        Filter filter = new Filter();
        static void Main(string[] args)
        {
            MotorMerge();
        }

        static void MotorMerge()
        {
            int aantal = Convert.ToInt32(Console.ReadLine().Split(null)[0]);
            for (int i = 0; i < aantal; i++)
            {
                string[] motorInput = Console.ReadLine().Split(null);
                motors.Add((motorInput[0], Convert.ToInt32(motorInput[1]), Convert.ToInt32(motorInput[2]), Convert.ToInt32(motorInput[3])));
            }

            var mergeSortedList = MergeSort(motors, Filter.Snelheid);
            mergeSortedList.Reverse();
            Console.WriteLine(motors.Count);
            foreach (var item in mergeSortedList)
            {
                Console.WriteLine(item.Item1);
            }
        }

        static List<(string, int, int, int)> MergeSort(List<(string, int, int, int)> mergeMotors, Filter filter)
        {
            if (mergeMotors.Count <= 1)
                return mergeMotors;

            List<(string, int, int, int)> tempLeft = new List<(string, int, int, int)>();
            List<(string, int, int, int)> tempRight = new List<(string, int, int, int)>();

            int i = 0;
            foreach (var item in mergeMotors)
            {
                if (i < (mergeMotors.Count / 2))
                    tempLeft.Add(item);
                else
                    tempRight.Add(item);

                i++;
            }

            tempLeft = MergeSort(tempLeft, filter);
            tempRight = MergeSort(tempRight, filter);

            return Merge(tempLeft, tempRight, filter);
        }

        static bool MergeByRules(Filter filter, (string, int, int, int) a, (string, int, int, int) b)
        {
            if (filter == Filter.Snelheid)
            {
                int[] aSplit = a.Item3.ToString().Select(x => Convert.ToInt32(x.ToString())).ToArray();
                int[] bSplit = b.Item3.ToString().Select(x => Convert.ToInt32(x.ToString())).ToArray();
                if (aSplit[0] <= bSplit[0] && aSplit[1] <= bSplit[1] && aSplit[2] <= bSplit[2])
                    return true;
                else
                    return false;
            }
            else
            {
                return a.Item4 <= b.Item4;
            }
        }

        static List<(string, int, int, int)> Merge(List<(string, int, int, int)> left, List<(string, int, int, int)> right, Filter filter)
        {
            List<(string, int, int, int)> result = new List<(string, int, int, int)>();
            while (left.Count > 0 && right.Count > 0)
            {
                if (MergeByRules(filter, left[0], right[0])) // Sorteert nu alleen op snelheid (SORTEER REGELS HIER)
                {
                    result.Add(left[0]);
                    left.RemoveAt(0);
                }
                else
                {
                    result.Add(right[0]);
                    right.RemoveAt(0);
                }
            }

            while (left.Count > 0)
            {
                result.Add(left[0]);
                left.RemoveAt(0);
            }

            while (right.Count > 0)
            {
                result.Add(right[0]);
                right.RemoveAt(0);
            }
            return result;
        }
    }
}
