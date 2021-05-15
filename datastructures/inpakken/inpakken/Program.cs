using System;
using System.Collections.Generic;
using System.Linq;

namespace inpakken
{
    class Program
    {
        public static void Main()
        {
            Inpakken();
        }
        private static int[] DissectInput()
        {
            string input = Console.ReadLine();
            string[] splitInput = input.Split(null);
            int[] dissectedNumbers = new int[splitInput.Length];
            for (int i = 0; i < 2; i++)
                dissectedNumbers[i] = Convert.ToInt32(splitInput[i]);

            return dissectedNumbers;
        }

        private static int DozenBinarySearch(int[] dozen, int pakketGrootte)
        {
            int minNum = 0, maxNum = dozen.Length - 1;

            int index = -1;
            while (minNum <= maxNum)
            {
                int middle = (minNum + maxNum) / 2;
                // Verplaatst de start van het middle punt naar rechts als het pakket groter is het doos
                if (dozen[middle] <= pakketGrootte)
                    minNum = middle + 1;

                // Anders naar links
                else
                {
                    index = middle;
                    maxNum = middle - 1;
                }
            }
            return dozen[index];
        }

        private static void Inpakken()
        {
            int[] input = DissectInput();
            long count = 0;
            int[] dozen = new int[input[0]];

            for (int i = 0; i < input[0]; i++)
                dozen[i] = Convert.ToInt32(Console.ReadLine().Split()[0]);

            int aantalPakketjes = input[1];
            string checkInput = "";
            while (aantalPakketjes > 0)
            {
                checkInput = Console.ReadLine().Split()[0];
                count += DozenBinarySearch(dozen, Convert.ToInt32(checkInput));
                aantalPakketjes--;
            }
            Console.WriteLine(count);
        }
    }
}