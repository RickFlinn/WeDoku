using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace We_Doku.Models
{
    public class GameSpace
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Value { get; set; }
        public bool Masked { get; set; }



        // Nav properties
        public int GameBoardID { get; set; }
        public GameBoard GameBoard { get; set; }
    }
}
