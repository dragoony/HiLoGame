using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("HiLoGame.Test")]
namespace HiLoGame
{
    internal class Game
    {
        private int _mysteryNumber;
        private List<Player> _players;

        public Game()
        {
            _players = new List<Player>();
        }

        internal void Init(int numOfPlayers, int maxNumber)
        {
            Random number = new Random();
            _mysteryNumber = number.Next(0, maxNumber);

            for (int i = 0; i < numOfPlayers; i++) {
                Player player = new Player()
                {
                    Name = "Player" + i
                };
                _players.Add(player);
            }

            _players[0].isPlaying = true;
            Console.WriteLine(_players.SingleOrDefault(p => p.isPlaying).Name + " is Playing");
        }

        internal ResultEnum Play(int number)
        {
            if (number == _mysteryNumber)
            {
                Console.WriteLine(string.Format("{0} Wins!!!",
                    _players.SingleOrDefault(p => p.isPlaying).Name));
                return ResultEnum.Win;
            }

            if(number < _mysteryNumber)
            {
                Console.WriteLine("Choose a Higher Number");
                _players.SingleOrDefault(p => p.isPlaying).DirectionEnum = DirectionEnum.Higher;
                _players.SingleOrDefault(p => p.isPlaying).LastPlay = number;
            }

            if (number > _mysteryNumber)
            {
                Console.WriteLine("Choose a Smaller Number");
                _players.SingleOrDefault(p => p.isPlaying).DirectionEnum = DirectionEnum.Lower;
                _players.SingleOrDefault(p => p.isPlaying).LastPlay = number;
            }

            ChangePlayer();

            Console.WriteLine(_players.SingleOrDefault(p => p.isPlaying).Name + " is Playing");

            return ResultEnum.Play;
        }

        private void ChangePlayer()
        {
            int index = _players.FindIndex(p => p.isPlaying);

            _players.SingleOrDefault(p => p.isPlaying).isPlaying = false;

            index = index == (_players.Count - 1) ? 0 : index + 1;

            _players[index].isPlaying = true;
        }
    }
}
