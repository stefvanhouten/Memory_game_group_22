using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    class GameOptions
    {
        public string Name { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int CardsRequired
        {
            get
            {
                return this.Rows * this.Columns;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
