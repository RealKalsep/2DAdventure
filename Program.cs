using System;
using System.Threading;

namespace _2DAdventure
{
    class Program
    {
        static void Main()
        {
            // Declare settings
            Console.Title = "2DAdventure";

            int gridWidth = 40; // Max X118 Y26
            int gridHeight = 20;
            int playerX = 0;
            int playerY = 0;

            //bool 
            int objectX = 4;
            int objectY = 5;
            bool _deadly = false;

            int chunkX = 0;
            int chunkY = 0;
            int color;

            // Do not change
            int maxPlayerX = gridWidth - 1;
            int maxPlayerY = gridHeight - 1;
            int maxGridWidth = gridWidth + 1;
            int maxGridHeight = gridHeight + 1;
            int steps = 0;
            int totalSteps = 0;
            bool justStarted = true;

            string validKeys = "Valid input: W, A, S, D, R";

            Random rand = new Random();


            void createObject(int oX, int oY, bool deadly)
            {
                objectX = oX;
                objectY = oY;
                deadly = _deadly;
            }


            void Setup()
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("2DAdventure");

                Console.ForegroundColor = ConsoleColor.White;

                createObject(6, 4, true);

                void SizeInput()
                {
                    Console.WriteLine("Enter width of world (Max 118, min 1) - Warning: Higher = slower!");
                    gridWidth = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter height of world (Max 26, min 1) - Warning: Higher = slower!");
                    gridHeight = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter color (1=red, 2=green, 3-blue, 4=random)");
                    color = Convert.ToInt32(Console.ReadLine());

                    switch(color)
                    {
                        case 1:
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;

                        case 2:
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;

                        case 3:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;

                        case 4:
                            color = rand.Next(1, 4);
                            break;

                        default:
                            Console.WriteLine("Invalid color!");
                            SizeInput();
                            break;
                    }

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

                        // Start drawing the grid
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
                Console.WriteLine($"Position: {playerX} {playerY}   Chunk: {chunkX} {chunkY}   Steps: {steps}   Total steps: {totalSteps}");

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
                        else if (ib == objectX && i == objectY)
                        {
                            // Object
                            // Need to implement chunk identificator too - or scrap the chunks idea
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write("█");
                        }
                        else
                        {
                            // Background
                            switch(color)
                            {
                                case 1:
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    break;

                                case 2:
                                    Console.ForegroundColor = ConsoleColor.Green;
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
                    Console.WriteLine(validKeys);
                    justStarted = false;
                }

                Touching();
                KeyInput();
            }

            void Touching()
            {
                // Needs a more-objects rewrite
                if (playerX == objectX && playerY == objectY)
                {
                    if (_deadly == true)
                    {
                        playerX = 0;
                        playerY = 0;
                        chunkX = 0;
                        chunkY = 0;
                        steps = 0;

                        Console.WriteLine("You died.");
                        Thread.Sleep(2000);

                        Grid();
                    }
                }
            }

            void KeyInput()
            {
                string key = Console.ReadLine().ToLower();

                switch(key)
                {
                    case "w":
                        if (playerY < 1)
                        {
                            Console.WriteLine("Entering new chunk");
                            playerY = gridHeight;
                            steps++;
                            totalSteps++;
                            chunkY--;
                            Grid();
                        } else {
                            playerY--;
                            steps++;
                            totalSteps++;
                        }

                        Grid();
                        break;

                    case "a":
                        if (playerX < 1)
                        {
                            Console.WriteLine("Entering new chunk");
                            playerX = gridWidth;
                            steps++;
                            totalSteps++;
                            chunkX--;
                            Grid();
                        } else {
                            playerX--;
                            steps++;
                            totalSteps++;
                        }

                        Grid();
                        break;

                    case "s":
                        if (playerY > maxPlayerY)
                        {
                            Console.WriteLine("Entering new chunk");
                            playerY = 0;
                            steps++;
                            totalSteps++;
                            chunkY++;
                            Grid();
                        } else {
                            playerY++;
                            steps++;
                            totalSteps++;
                        }

                        Grid();
                        break;

                    case "d":
                        if (playerX > maxPlayerX)
                        {
                            Console.WriteLine("Entering new chunk");
                            playerX = 0;
                            steps++;
                            totalSteps++;
                            chunkX++;
                            Grid();
                        } else {
                            playerX++;
                            steps++;
                            totalSteps++;
                        }

                        Grid();
                        break;

                    case "r":
                        void SureInput()
                        {
                            Console.WriteLine("Are you sure you want to die? Input: Y, N");
                            string sure = Console.ReadLine().ToLower();

                            switch (sure)
                            {
                                case "y":
                                    playerX = 0;
                                    playerY = 0;
                                    chunkX = 0;
                                    chunkY = 0;
                                    steps = 0;

                                    Console.WriteLine("You died.");
                                    Thread.Sleep(2000);

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
                        Console.WriteLine(validKeys);
                        KeyInput();
                        break;
                }
            }

            // Start the world setup
            Setup();
        }
    }
}
