using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    /// <summary>
    /// ScoreBoard keeps track of player objects score. 
    /// </summary>
    class ScoreBoard
    {
        public int Score { get; private set; } = 0;
        private int RemoveFromScore { get; set; } = 2;

        public ScoreBoard()
        {
            /*  Constructor from the ScoreBoard class. This is called when a new instance of the ScoreBoard is instantiated. 
             *  In our case this happends when we start a new memory game, just after the players provided their names.
             */
        }

        public void IncreaseScore()
        {
            /* Logic for incrementing the score from the scoreboard should go here.
             * After you are done writing code summarise what this method does and replace this comment.
             * 
             * Methods are already attached and the score will be updated in the game if you make it work :D
             */
            this.Score += 5;
        }

        public void DecreaseScore()
        {
            /* Logic for decremeting the score from the scoreboard should go here. Score shouldn't drop below 0 points!
             * After you are done writing code summarise what this method does and replace this comment.
             */
            if(this.Score >= this.RemoveFromScore)
            {
                this.Score -= this.RemoveFromScore;
            }
            else
            {
                this.Score = 0;
            }
        }
    }
}

