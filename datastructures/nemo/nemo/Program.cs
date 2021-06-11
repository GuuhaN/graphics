using System;
using System.Collections.Generic;
using System.Linq;

namespace nemo
{
    class Program
    {
        static int[] bedreigdeAnimals;
        static Dictionary<int, int> configurations = new Dictionary<int, int>();

        static int maxAnimalTypes = 0;
        static int maxCages = 0;
        static int maxWeight = 0;

        static int huidigeAantal = 0;
        static int huidigeHokken = 0;
        static int huidigeGewicht = 0;

        static uint animalsInCart = 0;
        static uint animalsInCartTemp = 0;

        static void Main(string[] args)
        {
            ReadInput();
        }

        static void ReadInput()
        {
            string[] firstLine = Console.ReadLine().Split();
            string[] animalLine = Console.ReadLine().Split();

            maxAnimalTypes = Convert.ToInt32(firstLine[0]);
            maxCages = Convert.ToInt32(firstLine[1]);
            maxWeight = Convert.ToInt32(firstLine[2]);

            bedreigdeAnimals = new int[maxAnimalTypes];
            for (int i = 0; i < maxAnimalTypes; i++)
                bedreigdeAnimals[i] = Convert.ToInt32(animalLine[i]);

            while(true)
            {
                string commandLine = Console.ReadLine();
                if (commandLine == "e")
                    break;

                SetRules(commandLine);
            }
        }

        static void SetRules(string line)
        {
            string[] split = line.Split();
            if(split[0].Equals("p"))
            {
                int animalKey = Convert.ToInt32(split[1]);
                if ((animalsInCart & (1 << animalKey)) > 0)
                {
                    Console.WriteLine("WEIGER {0}", animalKey);
                }
                else
                {
                    if (bedreigdeAnimals[animalKey] + huidigeGewicht <= maxWeight &&
                        huidigeHokken + 1 <= maxCages)
                    {
                        animalsInCart |= (uint)(1 << animalKey);
                        huidigeGewicht += bedreigdeAnimals[animalKey];
                        huidigeAantal++;
                        huidigeHokken++;
                    }
                    else if(bedreigdeAnimals[animalKey] + huidigeGewicht > maxWeight ||
                        huidigeHokken + 1 > maxCages)
                    {
                        Console.WriteLine("WEIGER {0}", animalKey);
                    }
                }
                animalsInCartTemp |= (uint)(1 << animalKey);
                if (configurations.ContainsKey((int)animalsInCartTemp))
                    configurations[(int)animalsInCartTemp] += 1;
                else
                    configurations.Add((int)animalsInCartTemp, 1);

            }
            if (split[0].Equals("l"))
            {
                int animalKey = Convert.ToInt32(split[1]);

                for (int i = 0; i < maxAnimalTypes; i++)
                {
                    if ((animalsInCart & (1 << i)) > 0)
                    {
                        animalsInCart &= (uint)~(1 << animalKey);
                        huidigeGewicht -= bedreigdeAnimals[animalKey];
                        huidigeAantal--;
                        huidigeHokken--;
                    }
                }
                animalsInCartTemp &= (uint)~(1 << animalKey);
                if (configurations.ContainsKey((int)animalsInCartTemp))
                    configurations[(int)animalsInCartTemp] += 1;
            }
            if (split[0].Equals("a"))
            {
                string test = "";
                for (int i = 0; i < maxAnimalTypes; i++)
                {
                    if ((animalsInCart & (1 << i)) > 0)
                    {
                        test += i + " ";
                    }
                }
                Console.WriteLine(test);
            }
            if (split[0].Equals("c"))
            {
                if(configurations.ContainsKey((int)animalsInCart))
                    Console.WriteLine("HERHAALD " + configurations[(int)animalsInCart]);
            }
            if (split[0].Equals("q"))
            {
                Console.WriteLine("Aantal " + huidigeAantal + " Gewicht " + huidigeGewicht);
            }
        }
    }
}
