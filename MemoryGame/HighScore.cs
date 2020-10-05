using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Security;

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
            /*
             * Add to the highscores list
             */
            HighScoreListing listing = new HighScoreListing { Name = player.Name, Score = player.ScoreBoard.Score };
            this.HighScores.Add(listing);

            /*
             * Convert the list to JSON
             */
            string json = JsonConvert.SerializeObject(this.HighScores, Formatting.Indented);

            /*
             * Encrypt the JSON file
             */
            Encryptor EncryptorObj = new Encryptor();
            string encryptedJson = EncryptorObj.Encrypt(json);

            /*
             * Create the filepath and write the encrypted JSON format to file
             */
            Files.Create(Path.Combine(Directory.GetCurrentDirectory(),"highscores.txt"));
            Files.WriteToFile(Path.Combine(Directory.GetCurrentDirectory(), "highscores.txt"), encryptedJson, true);
        }

        /*
         * this.HighScores is populated with the file its contents (and can be accessed)
         * You get the List returned in case any mutation is required or any specific handling of the List is required
         * If not needed, don't catch it, if required, you can catch it and handle it in the way you want
         */
        public List<HighScoreListing> GetHighScores(int limit)
        {
            /*
             * Get the content of the file (highscores)
             */
            string moppie = Files.GetFileContent(Path.Combine(Directory.GetCurrentDirectory(), "highscores.txt"));
            /*
             * If the content of the file isn't empty, decode it
             */
            if(moppie.Length > 0)
            {
                /*
                 * Decrypt the JSON file
                 */
                Encryptor EncryptorObj = new Encryptor();
                EncryptorObj.Decrypt(moppie);

                /*
                 * Decode the JSON and assign it to the LIST
                 */
                this.HighScores = JsonConvert.DeserializeObject<List<HighScoreListing>>(moppie);
            }

            return this.HighScores;
        }

        public void Sort(string Hierarchy)
        {
            /*
             * ascending is rom lowest value to highest value
             * descending is from highest value to lowest value
             */
            if (Hierarchy == "ascending")
            {
                this.HighScores.Sort((x, y) => x.Score.CompareTo(y.Score));
            } else if (Hierarchy == "descending")
            {
                this.HighScores.Sort((x, y) => y.Score.CompareTo(x.Score));
            }
        }
    }
}