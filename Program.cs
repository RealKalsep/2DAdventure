using System;

namespace _2DAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declare settings
            int gridWidth = 60; // Max X119 Y27
            int gridHeight = 20;
            int playerX = 0;
            int playerY = 0;
            int chunkX = 0;
            int chunkY = 0;

            // Do not change
            int maxPlayerX = gridWidth - 1;
            int maxPlayerY = gridHeight - 1;
            int maxGridWidth = gridWidth + 1;
            int maxGridHeight = gridHeight + 1;
            int steps = 0;
            bool justStarted = true;

            Random rand = new Random();
            int color = rand.Next(1, 4);

            void Grid()
            {
                // ▀▄█▌▐░▒▓


                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;

                // Position
                Console.WriteLine($"Position: {playerX} {playerY}   Chunk: {chunkX} {chunkY}   Steps: {steps}");

                // Draw grid
                for (int i = 0; i < maxGridHeight; i++)
                {
                    // Width in each height
                    for (int ib = 0; ib < maxGridWidth; ib++)
                    {
                        // Checks player position
                        if (ib == playerX && i == playerY)
                        {
                            // Player
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("█");
                        }
                        else
                        {
                            // Background
                            switch(color)
                            {
                                case 1:
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    break;

                                case 2:
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    break;

                                case 3:
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    break;
                            }
                            
                            Console.Write("█");
                        }
                    }

                    // Ends the grid
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("");
                }


                if (justStarted == true)
                {
                    Console.WriteLine("Valid input: W, A, S, D");
                    justStarted = false;
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
                            Console.WriteLine("Entering new chunk");
                            playerY = gridHeight;
                            steps++;
                            chunkY--;
                            Grid();
                        } else {
                            playerY--;
                            steps++;
                        }

                        Grid();
                        break;

                    case "a":
                        if (playerX < 1)
                        {
                            Console.WriteLine("Entering new chunk");
                            playerX = gridWidth;
                            steps++;
                            chunkX--;
                            Grid();
                        } else {
                            playerX--;
                            steps++;
                        }

                        Grid();
                        break;

                    case "s":
                        if (playerY > maxPlayerY)
                        {
                            Console.WriteLine("Entering new chunk");
                            playerY = 0;
                            steps++;
                            chunkY++;
                            Grid();
                        } else {
                            playerY++;
                            steps++;
                        }

                        Grid();
                        break;

                    case "d":
                        if (playerX > maxPlayerX)
                        {
                            Console.WriteLine("Entering new chunk");
                            playerX = 0;
                            steps++;
                            chunkX++;
                            Grid();
                        } else {
                            playerX++;
                            steps++;
                        }

                        Grid();
                        break;

                    case "r":
                        void SureInput()
                        {
                            Console.WriteLine("Are you sure you want to respawn? Input: Y, N");
                            string sure = Console.ReadLine();

                            switch (sure)
                            {
                                case "y":
                                    playerX = 0;
                                    playerY = 0;
                                    chunkX = 0;
                                    chunkY = 0;
                                    steps = 0;
                                    Grid();
                                    break;

                                case "n":
                                    Grid();
                                    break;

                                default:
                                    Console.WriteLine("Valid input: Y, N");
                                    SureInput();
                                    break;

                            }
                        }

                        SureInput();
                        break;

                    default:
                        Console.WriteLine("Valid input: W, A, S, D, R");
                        KeyInput();
                        break;
                }
            }

            // Start the app/grid
            Grid();
        }
    }
}
