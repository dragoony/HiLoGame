using System;

namespace HiLoGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose Number of Players");
            int numOfPlayers = ReadNumber();

            Console.WriteLine("Choose Max Number to Play");
            int maxNumToPlay = ReadNumber();

            Game loHiGame = new Game();
            loHiGame.Init(numOfPlayers, maxNumToPlay);

            var result = ResultEnum.Start;

            Console.WriteLine("Choose a number");

            while (result != ResultEnum.Win)
            {
                result = loHiGame.Play(ReadNumber());
            }

            return;
        }

        private static int ReadNumber()
        {
            int number;
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.Write("This is not valid input. Please enter an integer value: ");
            }

            return number;
        }
    }
}
