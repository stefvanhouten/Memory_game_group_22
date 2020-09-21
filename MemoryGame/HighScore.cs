using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    class HighScoreListing
    {
        public string Name { get; private set; }
        public int Score { get; private set; }

        public HighScoreListing(string playerName, int playerScore)
        {
            /*  This class is used to store a listing from the HighScore class. 
             *  After the memory game ends I will instantiate this class thus calling this constructor. 
             *  
             *  When this class is instantiated it will recieve a (string)playerName and a (int)playerScore. 
             *  You will have to communicate this with Daniel and Wietze because the highscores should be saved
             *  to a file and loaded from a file. 
             */
        }
    }

    class HighScore
    {
        public HighScore()
        {
          /*  The highscores class is used to populate the table in the HighScoresTab in tabcontrol.
           *  It should at very least contain:
           *  - Player name
           *  - Player score:  ((int)Player.ScoreBoard.Score)
           *
           *  Not sure about time yet since points make more sense than time. Spamming the game to 
           *  complete it fast shouldn't be rewarded. 
           *  
           *  This constructor is called right after the Memory.exe or debugger has been started.
           *  
           *  This class needs a few methods:
           *  - We need to load a highscores.txt file into this class, for each listing we need to instantiate
           *    a HighScoresListing class. You will probably do this with a loop, so after each instantiation 
           *    add the HighScoresListing to the variable (probably a list) keeping track of them. 
           *  - We need to save the current highscores to the highscores.txt file, Daniel & Wietze are
           *    responsible for how it is saved but you guys need to provide them with the data. 
           *  - We need to populate the table in the HighScoresTab page, Since this is pretty hard someone
           *    else will handle the populating for you guys. This method just needs supply us with the variable
           *    that contains all the instances of HighScoresListing
           *  [BONUS]
           *  - Would be nice if we could chance the order of the list, sorting based on score or name?
           *  - We dont want to populate the highscore with all the games that have been played, make a filter that
           *    sorts out the top (x) highest scoring games!
           *    
           */
        }
    }
}
