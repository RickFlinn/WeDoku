using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace We_Doku.Models.Helpers
{
    public class SudokuCell
    {
        public int Value { get; set; }
        public HashSet<int> AvailableInRow { get; set; }
        public HashSet<int> AvailableInColumn { get; set; }
        public HashSet<int> AvailableInSubGrid { get; set; }
    }
}
