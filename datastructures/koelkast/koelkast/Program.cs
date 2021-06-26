using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace koelkast
{
    class Program
    {
        class Player
        {
            public uint x, y;
        }

        class Koelkast
        {
            public uint x, y;
        }

        class End
        {
            public int x, y;
        }

        static char[,] map;
        static int mapX, mapY;
        static Player player = new Player();
        static Koelkast koelkast = new Koelkast();
        static Dictionary<uint, uint> visited;
        static End end = new End();
        static uint lastPos;

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
                    if (map[j,i] == '!')
                    {
                        koelkast.x = (uint)j; // 0-8
                        koelkast.y = (uint)i << 8; // 8-16
                    }
                    if (map[j, i] == '+')
                    {
                        player.x = (uint)j << 16; // 16-24
                        player.y = (uint)i << 24; // 24-32
                    }
                    if (map[j, i] == '?')
                    {
                        end.x = j;
                        end.y = i;
                    }
                }
            }

            uint playerKoelkast = koelkast.x + koelkast.y + player.x + player.y;
            string lol = SolveKoelkast(playerKoelkast);

            int length = 0;
            string pathDirections = "";
            if(lol != "No solution")
            {
                while (true)
                {
                    uint temp = visited[lastPos];
                    uint player = temp >> 16;
                    uint playerX = player - ((player >> 8) << 8);
                    uint playerY = player >> 8;

                    uint lastPos2 = lastPos >> 16;
                    uint lastPos2X = lastPos2 - ((lastPos2 >> 8) << 8);
                    uint lastPos2Y = lastPos2 >> 8;


                    if (temp == lastPos)
                        break;

                    if (playerY - 1 == lastPos2Y)
                    {
                        pathDirections = "N" + pathDirections;
                    }
                    if (playerX + 1 == lastPos2X)
                    {
                        pathDirections = "E" + pathDirections;
                    }
                    if (playerX - 1 == lastPos2X)
                    {
                        pathDirections = "W" + pathDirections;
                    }
                    if (playerY + 1 == lastPos2Y)
                    {
                        pathDirections = "S" + pathDirections;
                    }

                    lastPos = temp;
                    length++;
                }
                Console.WriteLine(length);
                if (outputForm == OutputForm.Path)
                {
                    Console.WriteLine(pathDirections);
                }
            }
            else
            {
                Console.WriteLine("No solution");
            }
        }

        static bool IsSolved(uint x, uint y)
        {
            if (x == end.x && y == end.y)
                return true;

            return false;
        }

        static string SolveKoelkast(uint playerKoelkast)
        {
            Queue<uint> queue = new Queue<uint>();
            visited = new Dictionary<uint, uint>();
            queue.Enqueue(playerKoelkast);
            visited.Add(playerKoelkast, playerKoelkast);
            while (queue.Count > 0)
            {
                uint temp = queue.Dequeue();
                uint newTemp = temp;

                uint player = temp >> 16;
                uint playerX = player - ((player >> 8) << 8);
                uint playerY = player >> 8;

                uint koelkast = temp - ((temp >> 16) << 16);
                uint koelkastX = koelkast - ((koelkast >> 8) << 8);
                uint koelkastY = koelkast >> 8; // 5


                if (!char.IsUpper(map[playerX, playerY - 1])) // NORTH
                {
                    uint playerY2 = playerY;
                    uint koelkastY2 = koelkastY;

                    if (playerX == koelkastX && (playerY2 - 1) == koelkastY2 && !char.IsUpper(map[koelkastX, koelkastY2 - 1]))
                    {
                        koelkastY2 = koelkastY - 1;
                        koelkastY2 = koelkastY2 << 8; 
                        playerY2 = playerY - 1;
                        newTemp = koelkastX + koelkastY2 + (playerX << 16) + (playerY2 << 24);
                    }
                    else if (playerX != koelkastX && (playerY2 - 1) != koelkastY2)
                    {
                        playerY2 = playerY - 1;
                        newTemp = koelkastX + (koelkastY << 8) + (playerX << 16) + (playerY2 << 24);
                    }
                    if (!visited.ContainsKey(newTemp))
                    {
                        queue.Enqueue(newTemp);
                        visited.Add(newTemp, temp);
                        if (IsSolved(koelkastX, (koelkastY2 >> 8)))
                        {
                            lastPos = newTemp;
                            return "";
                        }
                    }
                }
                if (!char.IsUpper(map[playerX, playerY + 1])) // SOUTH
                {
                    uint playerY2 = playerY;
  
                    uint koelkastY2 = koelkastY;

                    if (playerX == koelkastX && (playerY2 + 1) == koelkastY2 && !char.IsUpper(map[koelkastX, koelkastY2 + 1]))
                    {
                        koelkastY2 = koelkastY + 1; // 4
                        koelkastY2 = koelkastY2 << 8; // 4 << 8
                        playerY2 = playerY + 1;
                        newTemp = koelkastX + koelkastY2 + (playerX << 16) + (playerY2 << 24);
                    }
                    else if (playerX != koelkastX && (playerY2 + 1) != koelkastY2)
                    {
                        playerY2 = playerY + 1;
                        newTemp = koelkastX + (koelkastY << 8) + (playerX << 16) + (playerY2 << 24);
                    }

                    if (!visited.ContainsKey(newTemp))
                    {
                        queue.Enqueue(newTemp);
                        visited.Add(newTemp, temp);
                        if (IsSolved(koelkastX, (koelkastY2 >> 8)))
                        {
                            lastPos = newTemp;
                            return "";
                        }
                    }
                }
                if (!char.IsUpper(map[playerX + 1, playerY])) // EAST
                {
                    uint playerX2 = playerX;

                    uint koelkastX2 = koelkastX;
                    if ((playerX2 + 1) == koelkastX2 && playerY == koelkastY && !char.IsUpper(map[koelkastX2 + 1, koelkastY]))
                    {
                        koelkastX2 = koelkastX + 1; // 4
                        playerX2 = playerX + 1;
                        newTemp = koelkastX2 + (koelkastY << 8) + (playerX2 << 16) + (playerY << 24);
                    }
                    else if (map[playerX + 1, playerY] == '.')
                    {
                        playerX2 = playerX + 1;
                        newTemp = koelkastX + (koelkastY << 8) + (playerX2 << 16) + (playerY << 24);
                    }

                    if (!visited.ContainsKey(newTemp))
                    {
                        queue.Enqueue(newTemp);
                        visited.Add(newTemp, temp);
                        if (IsSolved(koelkastX2, koelkastY))
                        {
                            lastPos = newTemp;
                            return "";
                        }
                    }
                }
                if (!char.IsUpper(map[playerX - 1, playerY])) // WEST
                {
                    uint playerX2 = playerX;

                    uint koelkastX2 = koelkastX;
                    if (playerX2 - 1 == koelkastX2 && playerY == koelkastY && !char.IsUpper(map[koelkastX2 - 1, koelkastY]))
                    {
                        koelkastX2 = koelkastX - 1; // 4
                        playerX2 = playerX - 1;
                        newTemp = koelkastX2 + (koelkastY << 8) + (playerX2 << 16) + (playerY << 24);
                    }
                    else if (map[playerX - 1, playerY] == '.')
                    {
                        playerX2 = playerX - 1;
                        newTemp = koelkastX + (koelkastY << 8) + (playerX2 << 16) + (playerY << 24);
                    }
                    if (!visited.ContainsKey(newTemp))
                    {
                        queue.Enqueue(newTemp);
                        visited.Add(newTemp, temp);
                        if (IsSolved(koelkastX2, koelkastY))
                        {
                            lastPos = newTemp;
                            return "";
                        }
                    }
                }
            }
            return "No solution";
        }
    }
}
