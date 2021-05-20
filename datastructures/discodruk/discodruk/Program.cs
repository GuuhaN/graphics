using System;
using System.Linq;
using System.Collections.Generic;

namespace discodruk
{
    class Program
    {
        static List<(int aankomst,int vertrek)> tijdstippen = new List<(int, int)>();
        static void Main(string[] args)
        {
            DiscoDruk();
        }

        static void Debug() 
        {
            tijdstippen.Add((12, 30));
            tijdstippen.Add((18, 25));
            tijdstippen.Add((25, 40));
            tijdstippen.Add((13, 15));
            tijdstippen.Add((32, 36));

            SortTijdstippen(tijdstippen);
        }

        static void ReadInput()
        {
            int aantalBezoekers = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < aantalBezoekers; i++)
            {
                string[] incoming = Console.ReadLine().Split();
                tijdstippen.Add((Convert.ToInt32(incoming[1]), Convert.ToInt32(incoming[2])));
            }

            SortTijdstippen(tijdstippen);
        }

        static void SortTijdstippen(List<(int aankomst, int vertrek)> lijstVanTijdstippen)
        {
            IEnumerable<(int, int)> lijstInOrder = lijstVanTijdstippen.OrderBy(x => x.aankomst);
            tijdstippen = lijstInOrder.ToList();
        }

        static void DiscoDruk()
        {
            //Debug(); // DEBUG
            ReadInput(); // PRODUCTION
            int laatstMaxBezoekersBinnen = 0;
            for (int time = tijdstippen.Min(x => x.aankomst); time < tijdstippen.Max(x => x.vertrek); time++)
            {
                int aantalBezoekersBinnen = 0;
                for (int i = 0; i < tijdstippen.Count; i++)
                {
                    if(tijdstippen[i].aankomst <= time && time < tijdstippen[i].vertrek)
                        aantalBezoekersBinnen++;
                }
                if (aantalBezoekersBinnen >= laatstMaxBezoekersBinnen)
                    laatstMaxBezoekersBinnen = aantalBezoekersBinnen;
            }
            Console.WriteLine(laatstMaxBezoekersBinnen.ToString());
        }
    }
}
