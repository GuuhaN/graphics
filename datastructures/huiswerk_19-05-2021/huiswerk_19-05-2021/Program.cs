using System;
using System.Collections.Generic;

namespace huiswerk_19_05_2021
{
    class Program
    {
        /* 
         Gemaakt door Mirza & Nigel
         Huiswerk voor 19-05-2021
         */

        // 2n - 3 flips
        static int amountOfFlips = 0;
        static double[] wagens;
        static void Main(string[] args)
        {
            PancakeSort(new int[] { 8, 4, 5, 10 }); // PancakeSort uitvoeren
            // DoQuickSort(); // QuickSort uitvoeren
            // ZwareKlus(Convert.ToInt32(Console.ReadLine())); // Zware klus uitvoeren (vraag 4b) & vraagt input user van aantal tonnen
            LinearAlgoritme(); // Linear algoritme voor 5b
        }
        static int FindBiggestPancake(int[] pancakes, int length) // Alleen om de grootste pannenkoek te vinden
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

        static int[] PancakeSort(int[] pancakes)
        {
            for (var i = pancakes.Length - 1; i >= 0; i--)
            {
                // Vind de index van de grootste pannenkoek
                var indexOfMax = FindBiggestPancake(pancakes, i);
                if (indexOfMax != i)
                {
                    // Flip de grootste pannenkoek
                    Flip(pancakes, indexOfMax); // [10, 5, 4, 8]
                    // Flip de hele stapel pannenkoeken :)
                    Flip(pancakes, i); // [8, 4, 5, 10]
                }
            }

            ShowSorting(pancakes);
            return pancakes;
        }
        static void ShowSorting(int[] pancakes) // ALLEEN OM DE TEKST LEESBAAR TE MAKEN
        {
            string sorted = "";
            foreach (int pancake in pancakes)
            {
                sorted += pancake + ", ";
            }
            Console.WriteLine(sorted);
            Console.WriteLine("Flips needed: " + amountOfFlips);
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
        static void DoQuickSort()
        {
            wagens = new double[] { 3.12, 1.00, 4.2, 0.40, 15.3, 18.2, 5.7, 8.234, 10, 2.5 }; // Definieer de wagens
            QuickSort(wagens, 0, wagens.Length - 1); // Start de quicksort
            string totaleWagensTekst = ""; /* ALLEEN OM TEKST MOOI TE MAKEN */
            foreach (var item in wagens)
            {
                totaleWagensTekst += item + ", ";
            }
            Console.WriteLine(totaleWagensTekst);
        }
        static void ZwareKlus(int tonnenLimiet)
        {
            double tonnen = 0; // Teller voor tonnen
            List<double> totaleWagens = new List<double>(); // List makkelijker objecten toe te voegen dan array.
            for (int i = wagens.Length - 1; i >= 0; i--)
            {
                if (tonnen >= tonnenLimiet) // Over het limiet? Break de loop
                    break;

                tonnen += wagens[i]; // Zo niet, dan optellen en wagen toe te voegen.
                totaleWagens.Add(wagens[i]);
            }

            string totaleWagensTekst = ""; /* OOK ALLEEN VOOR TEKST :) */
            foreach (double item in totaleWagens)
                totaleWagensTekst += item + ", ";

            Console.WriteLine(totaleWagensTekst + " - Tonnen: " + tonnen);
        }

        static void Flip(double[] wagens, int left, int right)
        {
            double temp = wagens[left]; // [10.0]
            wagens[left] = wagens[right]; // [10.0] -> [5.0]
            wagens[right] = temp; // [5.0] -> [10.0]
        }

        static void QuickSort(double[] wagens, int left, int right)
        {
            if (left >= right) // Als de linker nummer >= dan rechts, dan is de quicksort goed :)
                return;

            double pivot = wagens[(left + right) / 2]; // Voor de snelste performance, is bij quicksort de middelste pivot het beste.
            int index = Partition(wagens, left, right, pivot); // Index vinden van de pivot en elke keer als je em in stukken snijd.
            QuickSort(wagens, left, index - 1); // Recursion, want er moeten verschillende indexen worden verwisseld. Dus deze verplaatst iets naar de linkerkant van de pivot
            QuickSort(wagens, index, right); // En hier ook recursion, van alles naar rechts verplaatsen.
        }

        static int Partition(double[] wagens, int left, int right, double pivot)
        {
            while (left <= right)
            {
                while (wagens[left] < pivot) // Blijft zoeken tot er een waarde links van kleiner dan de pivot is
                    left++;

                while (wagens[right] > pivot) // Blijft zoeken tot er een waarde rechts van kleiner dan de pivot is
                    right--;

                if(left <= right) // Alleen omwisselen als de waarde links van de pivot staat
                {
                    Flip(wagens, left, right); // Hier flip je
                    left++; // na de flip doorgaan met zoeken van links
                    right--; // en van rechts
                }
            }
            return left;
        }

        static void LinearAlgoritme()
        {
            int wantedTotal = 50;
            double[] array = { 3.12, 1.00, 4.2, 0.4, 15.3, 18.2, 5.7, 8.234, 10, 2.5 };
            double total = 0;
            double grootste = 0;
            int position = 0;
            string biggestText = "";
            while (total < wantedTotal)
            {
                grootste = 0;
                for (int t = 0; t < array.Length; t++)
                {
                    if (grootste < array[t])
                    {
                        grootste = array[t];
                        position = t;
                    }
                }
                array[position] = 0;
                total = total + grootste;
                biggestText = biggestText + " " + grootste;
            }
            Console.WriteLine(biggestText);
        }
    }
}
