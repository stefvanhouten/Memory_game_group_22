using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    class Memory
    {
        public int Rows { get; private set; }
        public int Collumns { get; private set; }

        public Player PlayerOne;
        public Player PlayerTwo;

        public List<Card> Deck { get; private set; }

        public Memory()
        {

        }

        public void StartGame()
        {

        }
    }
}
