using System;

namespace _2DAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declare settings
            int gridWidth = 40;
            int gridHeight = 20;
            int playerX = 0;
            int playerY = 0;

            // Do not change
            int maxPlayerX = gridWidth - 1;
            int maxPlayerY = gridHeight - 1;
            int maxGridWidth = gridWidth + 1;
            int maxGridHeight = gridHeight + 1;
            int steps = 0;

            void Grid()
            {
                // ▀▄█▌▐░▒▓


                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;

                // Position
                Console.WriteLine(playerX.ToString() + " " + playerY.ToString() + "   Steps: " + steps);

                // Draw grid
                for (int i = 0; i < maxGridHeight; i++)
                {
                    // Width in each height
                    for (int ib = 0; ib < maxGridWidth; ib++)
                    {
                        // Checks player position
                        if (ib == playerX && i == playerY)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("█");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("█");
                        }
                    }

                    // Ends the grid
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("");
                }

                KeyInput();
            }

            void KeyInput()
            {
                string key = Console.ReadLine();

                switch(key)
                {
                    case "w":
                        if (playerY < 1)
                        {
                            Console.WriteLine("Out of bounds");
                        } else {
                            playerY--;
                            steps++;
                        }

                        Grid();
                        break;

                    case "a":
                        if (playerX < 1)
                        {
                            Console.WriteLine("Out of bounds");
                        } else {
                            playerX--;
                            steps++;
                        }

                        Grid();
                        break;

                    case "s":
                        if (playerY > maxPlayerY)
                        {
                            Console.WriteLine("Out of bounds");
                        } else {
                            playerY++;
                            steps++;
                        }

                        Grid();
                        break;

                    case "d":
                        if (playerX > maxPlayerX)
                        {
                            Console.WriteLine("Out of bounds");
                        } else {
                            playerX++;
                            steps++;
                        }

                        Grid();
                        break;

                    default:
                        Console.WriteLine("Valid input: W, A, S, D");
                        KeyInput();
                        break;
                }
            }

            // Start the app/grid
            Grid();
        }
    }
}
