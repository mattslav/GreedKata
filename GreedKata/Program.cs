using System;
using GreedKata.Interface; 

namespace GreedKata
{
    class Program
    {
        private const string RollCommand = "roll";

        static void Main()
        {
            try
            {
                var game = new Locator().Game;

                while (true)
                {
                    var input = GetInputFromUser();

                    if (input != RollCommand)
                        return;

                    var result = game.Roll();

                    DisplayResultToUser(result);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static string GetInputFromUser()
        {
            Console.WriteLine("Type 'roll' or any key to exit");
            return Console.ReadLine();
        }

        private static void DisplayResultToUser(Result result)
        {
            Console.WriteLine("The result is: " + Environment.NewLine + result + Environment.NewLine);
        }

    }
}
