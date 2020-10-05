using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace MemoryGame
{
    /// <summary>
    /// Template for a HighScore listing. 
    /// </summary>
    struct HighScoreListing
    {
        public string Name { get;  set; }
        public int Score { get;  set; }

        //public HighScoreListing(string playerName, int playerScore)
        //{
        //    /*  This class is used to store a listing from the HighScore class. 
        //     *  After the memory game ends I will instantiate this class thus calling this constructor. 
        //     *  
        //     *  When this class is instantiated it will recieve a (string)playerName and a (int)playerScore. 
        //     *  You will have to communicate this with Daniel and Wietze because the highscores should be saved
        //     *  to a file and loaded from a file. 
        //     */
        //    this.Name = playerName;
        //    this.Score = playerScore;
        //}
    }

    /// <summary>
    /// Keeps track of the memory game current highest scoring players.
    /// </summary>
    class HighScore
    {
        private int MaximumEntries;

        public List<HighScoreListing> HighScores { get; set; }
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
            this.HighScores = new List<HighScoreListing>();
            this.GetHighScores(15);
        }

        public void AddToHighScores(Player player)
        {
            HighScoreListing listing = new HighScoreListing { Name = player.Name, Score = player.ScoreBoard.Score };
            this.HighScores.Add(listing);
            string json = JsonConvert.SerializeObject(this.HighScores, Formatting.Indented);

            Encryptor EncryptorObj = new Encryptor();
            string encryptedJson = EncryptorObj.Encrypt(json);

            Files.Create(Path.Combine(Directory.GetCurrentDirectory(),"highscores.txt"));
            Files.WriteToFile(Path.Combine(Directory.GetCurrentDirectory(), "highscores.txt"), encryptedJson, true);
        }

        //is going to need a return type, for now void for the sake of it
        public void GetHighScores(int limit)
        {
            string moppie = Files.GetFileContent(Path.Combine(Directory.GetCurrentDirectory(), "highscores.txt"));
            this.HighScores = JsonConvert.DeserializeObject<List<HighScoreListing>>(moppie);
            //retrieve the contents of the file with HighScore.HighScorePath.GetFileContent
            //store the returned value in a variable
            //decode the JSON variable and append to this.highScores
            //if called this.ReArrangeHighScores(limit); re-arranges the list...
            // and returns 0 to limit
            //return the "returned" value of this.ReArrangeHighScores(limit);
        }

        private void ReArrangeHighScores(int limit)
        {
            //this will need a return type as well, but for now, first create the method
            // Re-arrange the HighScores from high to low or low to high
            //int limit returns the highscores from 0 to "limit"
        }
    }
}