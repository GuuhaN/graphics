using System;
using System.Collections.Generic;

namespace nemo
{
    class Program
    {
        static Dictionary<int, byte> animalsInCart = new Dictionary<int, byte>();
        int maxWeight = 0;
        static void Main(string[] args)
        {
            ReadInput();
        }

        static void ReadInput()
        {
            string firstLine = Console.ReadLine();
            string animalLine = Console.ReadLine().Replace(" ", "");
            Console.WriteLine(Convert.ToUInt32(animalLine));
            while(true)
            {
                string commandLine = Console.ReadLine();
                if (commandLine[0].Equals("e"))
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
                Console.WriteLine("COMMAND P - ANIMALWEIGHT: " + animalKey);

            }
            if (split[0].Equals("l"))
            {
                int animalKey = Convert.ToInt32(split[1]);
                Console.WriteLine("COMMAND L - ANIMALWEIGHT: " + animalKey);
                //if (!animals[animalKey])
                //    return;

                //animals.Remove(animalKey);
            }
        }
    }
}
