using System;

namespace koelkast
{
    class Program
    {
        static char[,] map;
        static int mapX, mapY;
        enum OutputForm { Length, Path };
        static OutputForm outputForm;
        static void Main(string[] args)
        {
            ReadMap();
        }

        static void ReadMap()
        {
            string[] firstInputs = Console.ReadLine().Split();
            mapX = Convert.ToInt32(firstInputs[0]);
            mapY = Convert.ToInt32(firstInputs[1]);
            map = new char[mapX, mapY];
            outputForm = firstInputs[2] == "L" ? OutputForm.Length : OutputForm.Path;
            for (int i = 0; i < mapY; i++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int j = 0; j < mapX; j++)
                {
                    map[j, i] = input[j];
                }
            }
        }
    }
}
