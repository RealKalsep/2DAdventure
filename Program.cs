using System;

namespace _2DAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declare settings
            Console.Title = "2DAdventure";

            int gridWidth = 40; // Max X118 Y26
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



            void Setup()
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("2DAdventure");

                Console.ForegroundColor = ConsoleColor.White;

                void SizeInput()
                {
                    Console.WriteLine("Enter width of world (Max 118, min 1) - Warning: Higher = slower!");
                    string setupWidth = Console.ReadLine();
                    gridWidth = int.Parse(setupWidth);

                    Console.WriteLine("Enter height of world (Max 26, min 1) - Warning: Higher = slower!");
                    string setupHeight = Console.ReadLine();
                    gridHeight = int.Parse(setupHeight);

                    if (gridWidth > 118 || gridWidth < 1 || gridHeight > 26 || gridHeight < 1)
                    {
                        Console.WriteLine("Invalid size!");
                        SizeInput();
                    }
                    else
                    {
                        maxPlayerX = gridWidth - 1;
                        maxPlayerY = gridHeight - 1;
                        maxGridWidth = gridWidth + 1;
                        maxGridHeight = gridHeight + 1;

                        Grid();
                    }
                }
                
                SizeInput();
            }

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
                    Console.WriteLine("Valid input: W, A, S, D, R");
                    justStarted = false;
                }

                KeyInput();
            }

            void KeyInput()
            {
                string key = Console.ReadLine();

                switch(key)
                {
                    // Need to find a way to do it in one line instead of two lines
                    case "w":
                    case "W":
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
                    case "A":
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
                    case "S":
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
                    case "D":
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
                    case "R":
                        void SureInput()
                        {
                            Console.WriteLine("Are you sure you want to respawn? Input: Y, N");
                            string sure = Console.ReadLine();

                            switch (sure)
                            {
                                case "y":
                                case "Y":
                                    playerX = 0;
                                    playerY = 0;
                                    chunkX = 0;
                                    chunkY = 0;
                                    steps = 0;
                                    Grid();
                                    break;

                                case "n":
                                case "N":
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
            Setup();
        }
    }
}
