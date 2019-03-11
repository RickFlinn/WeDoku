using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace We_Doku.Models
{
    public class GameSpaces
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Value { get; set; }
        public bool Masked { get; set; }



        // Nav properties
        public int GameboardID { get; set; }
        public GameBoard GameBoard { get; set; }
    }
}
