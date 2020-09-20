using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    class Player
    {
        public string Name { get; private set; }
        public ScoreBoard ScoreBoard { get; private set; }

        public Player(string name)
        {
            this.Name = name;
            this.ScoreBoard = new ScoreBoard();
        }
    }
}
