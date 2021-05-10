using System;
using System.Linq;

namespace huiswerk_19_05_2021
{
    class Program
    {
        // 2n - 3 flips
        static int amountOfFlips = 0;
        static void Main(string[] args)
        {
            PancakeSort(new int[] { 8, 4, 5, 10 });
            // QuickSort(new double[] { 3.12, 1.00, 4.2, 0.40, 15.3, 18.2, 5.7, 8.234, 10, 2.5 });
        }

        static int FindBiggestPancake(int[] pancakes, int length)
        {
            int biggest = 0;
            for (int i = 1; i <= length; i++)
            {
                if (pancakes[i] > pancakes[biggest])
                {
                    biggest = i;
                }
            }

            return biggest;
        }

        static void Flip(int[] pancakes, int length)
        {
            // [8, 4, 5, 10]
            for (int i = 0; i < length; i++) // Omdat je moet flippen en niet alleen pannekoeken omwisselt
            {
                var temp = pancakes[i]; // temp = [8] -> i zit op index 0 || temp = [4] -> i zit op index 1
                pancakes[i] = pancakes[length]; //pancake[8] -> pancake[10] = [10, 4, 5, 10] || pancakes[4] -> pancakes[5] = [10, 5, 5, 8]
                pancakes[length] = temp; // pancake[10] -> pancake[8] = [10, 4, 5, 8] || pancakes[5] -> pancakes[4] = [10, 5, 4, 8]
                length--; // i = 1 & length = 3 || i = 2 & length = 2
                amountOfFlips++;
            }
        }

        static void Flip(double[] wagens, int left, int right)
        {
            double temp = wagens[left]; // [10.0]
            wagens[left] = wagens[right]; // [10.0] -> [5.0]
            wagens[right] = temp; // [5.0] -> [10.0]
        }

        static int[] PancakeSort(int[] pancakes)
        {
            for (var i = pancakes.Length - 1; i >= 0; i--)
            {
                // get the position of the maximum element of the subarray
                var indexOfMax = FindBiggestPancake(pancakes, i);
                if (indexOfMax != i)
                {
                    // flip the array to the maximum element index
                    // the maximum element of the subarray will be located at the beginning
                    Flip(pancakes, indexOfMax); // [10, 5, 4, 8]
                    // flip the entire subarray
                    Flip(pancakes, i); // [8, 4, 5, 10]
                }
            }

            ShowSorting(pancakes);
            return pancakes;
        }

        static void ShowSorting(int[] pancakes)
        {
            string sorted = "";
            foreach (int pancake in pancakes)
            {
                sorted += pancake + ", ";
            }
            Console.WriteLine(sorted);
            Console.WriteLine("Flips needed: " + amountOfFlips);
        }

        static void QuickSort(double[] wagens, int left, int right)
        {
            int pivot = wagens.Length / 2;
            int index = Partition(wagens, left, right, pivot);
            for (int i = 0; i < wagens.Length; i++)
            {
                double temp = wagens[i];
            }
        }

        static int Partition(double[] wagens, int left, int right, int pivot)
        {
            while (left <= right)
            {
                while (wagens[left] < pivot)
                    left++;

                while (wagens[right] > pivot)
                    right++;

                if(left <= right)
                {
                    Flip(wagens, left, right);
                    left++;
                    right--;
                }
            }

            return left;
        }
    }
}
