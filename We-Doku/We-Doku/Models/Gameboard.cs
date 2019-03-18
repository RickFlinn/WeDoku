using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace We_Doku.Models
{
    public class GameBoard
    {
        public int ID { get; set; }
        public int Placed { get; set;}

        // Nav properties
        public List<GameSpace> GameSpaces { get; set; }

    }
}
