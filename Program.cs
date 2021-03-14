using System;

namespace ConsoleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ConsoleCalculator");
            Console.WriteLine("Note: You might want to try using '.' or ',' when counting float");

            void Ask()
            {
                Console.BackgroundColor = ConsoleColor.DarkMagenta;

                Console.Write("First number: ");
                float firstCount = float.Parse(Console.ReadLine());

                Console.Write("Add +, subtract -, multiply *, divide / ");
                string way = Console.ReadLine();

                Console.Write("Second number: ");
                float secondCount = float.Parse(Console.ReadLine());

                Console.BackgroundColor = ConsoleColor.DarkRed;

                switch (way)
                {
                    case "+":
                        Console.Write("Result: ");
                        Console.WriteLine(firstCount + secondCount);
                        Console.WriteLine("");

                        Ask();
                        break;

                    case "-":
                        Console.Write("Result: ");
                        Console.WriteLine(firstCount - secondCount);
                        Console.WriteLine("");

                        Ask();
                        break;

                    case "*":
                        Console.Write("Result: ");
                        Console.WriteLine(firstCount * secondCount);
                        Console.WriteLine("");

                        Ask();
                        break;

                    case "/":
                        Console.Write("Result: ");
                        Console.WriteLine(firstCount / secondCount);
                        Console.WriteLine("");

                        Ask();
                        break;

                    default:
                        Console.WriteLine("Wrong syntax!");

                        Ask();
                        break;
                }
            }

            Ask();
        }
    }
}
