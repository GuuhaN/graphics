using System;

namespace koelkast
{
    class Program
    {
        static char[,] map;
        enum OutputForm { Length, Path };
        static OutputForm outputForm;
        static void Main(string[] args)
        {
            ReadMap();
        }

        static void ReadMap()
        {
            string[] firstInputs = Console.ReadLine().Split();
            map = new char[Convert.ToInt32(firstInputs[0]), Convert.ToInt32(firstInputs[1])];
            outputForm = firstInputs[2] == "L" ? OutputForm.Length : OutputForm.Path;
            for (int i = 0; i < Convert.ToInt32(firstInputs[0]); i++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int j = 0; j < Convert.ToInt32(firstInputs[1]); j++)
                {
                    map[i, j] = input[j];
                }
            }
        }
    }
}
