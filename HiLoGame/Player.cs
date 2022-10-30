using System;
using System.Collections.Generic;
using System.Text;

namespace HiLoGame
{
    internal class Player
    {
        internal string Name { get; set; }
        internal int LastPlay { get; set; }
        internal bool isPlaying { get; set; }
        internal DirectionEnum DirectionEnum { get; set; }
    }
}
