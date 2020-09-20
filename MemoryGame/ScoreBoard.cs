using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    class ScoreBoard
    {
        public int Score { get; private set; } = 0;

        public ScoreBoard()
        {
            /*  Constructor from the ScoreBoard class. This is called when a new instance of the ScoreBoard is instantiated. 
             *  In our case this happends when we start a new memory game, just after the players provided their names.
             */
        }

        public void Add()
        {
            /* Logic for incrementing the score from the scoreboard should go here.
             * After you are done writing code summarise what this method does and replace this comment.
             */
            this.Score += 30;
        }
    }
}
