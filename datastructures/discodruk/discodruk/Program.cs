using System;
using System.Linq;
using System.Collections.Generic;

namespace discodruk
{
    class Program
    {
        static List<int> aankomst = new List<int>(), vertrek = new List<int>();
        static void Main(string[] args)
        {
            DiscoDruk();
        }

        static void Debug() 
        {
            aankomst.Add(12);
            aankomst.Add(18);
            aankomst.Add(25);
            aankomst.Add(13);
            aankomst.Add(32);

            vertrek.Add(30);
            vertrek.Add(25);
            vertrek.Add(40);
            vertrek.Add(15);
            vertrek.Add(36);

            aankomst.Sort();
            vertrek.Sort();
        }

        static void ReadInput()
        {
            int aantalBezoekers = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < aantalBezoekers; i++)
            {
                string[] incoming = Console.ReadLine().Split();
                aankomst.Add(Convert.ToInt32(incoming[1]));
                vertrek.Add(Convert.ToInt32(incoming[2]));
            }

            aankomst.Sort();
            vertrek.Sort();
        }

        static void DiscoDruk()
        {
            //Debug(); // DEBUG
            ReadInput(); // PRODUCTION
            int n = 0;
            int maxPersonenTemp = 0;
            int maximum = 0;

            List<int> personen = new List<int>();
            List<(int, int)> tijden = new List<(int, int)>();
            for (int i = 0; i < vertrek.Count; i++)
            {
                int duplicateTemp = -1;
                while (n < aankomst.Count && aankomst[n] <= vertrek[i])
                {
                    if (aankomst[n] != vertrek[i])
                    {
                        maxPersonenTemp++;
                        duplicateTemp = -1;
                    }
                    else
                    {
                        i++;
                        duplicateTemp--;
                    }

                    n++;
                }
                personen.Add(maxPersonenTemp);
                tijden.Add((aankomst[n + duplicateTemp], vertrek[i]));
                if (maxPersonenTemp > maximum)
                    maximum = maxPersonenTemp;
                maxPersonenTemp--;
            }

            Console.WriteLine(maximum);
            for (int i = 0; i < personen.Count; i++)
            {
                if(personen[i] == maximum)
                    Console.WriteLine("Van " + tijden[i].Item1 + " tot " + tijden[i].Item2);
            }
        }
    }
}
