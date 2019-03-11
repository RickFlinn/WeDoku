using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace We_Doku.Models.Helpers
{
    public class GridBuilder
    {
        public int[,] Solution { get; set; } = new int[9, 9];
        public int[,] Puzzle { get; set; } = new int[9, 9];

        
        public GridBuilder()
        {
            GeneratePuzzle();
        }

        /// <summary>
        ///     Generates and returns a new 9x9 array representing a solved Sudoku board.
        /// </summary>
        /// <returns> 9x9 integer array representing a new sudoku solution</returns>
        public void GenerateSolution()
        {
            // Placeholder solution
            Solution = new int[9, 9]
            {
                { 5, 3, 4, 6, 7, 8, 9, 1, 2 },
                { 6, 7, 2, 1, 9, 5, 3, 4, 8 },
                { 1, 9, 8, 3, 4, 2, 5, 6, 7 },
                { 8, 5, 9, 7, 6, 1, 4, 2, 3 },
                { 4, 2, 6, 8, 5, 3, 7, 9, 1 },
                { 7, 1, 3, 9, 2, 4, 8, 5, 6 },
                { 9, 6, 1, 5, 3, 7, 2, 8, 4 },
                { 2, 8, 7, 4, 1, 9, 6, 3, 5 },
                { 3, 4, 5, 2, 8, 6, 1, 7, 9 }
            };
        }

        /// <summary>
        ///     Generates and saves a new 9x9 solution board.
        /// </summary>
        public void GeneratePuzzle()
        {
            GenerateSolution();
            // Logic to generate puzzle board using solution
            Puzzle = new int[9,9]
            {
                { 5, 3, 0, 0, 7, 0, 0, 0, 0 },
                { 6, 0, 0, 1, 9, 5, 0, 0, 0 },
                { 0, 9, 8, 0, 0, 0, 0, 6, 0 },
                { 8, 0, 0, 0, 6, 0, 0, 0, 3 },
                { 4, 0, 0, 8, 0, 3, 0, 0, 1 },
                { 7, 0, 0, 0, 2, 0, 0, 0, 6 },
                { 0, 6, 0, 0, 0, 0, 2, 8, 0 },
                { 0, 0, 0, 4, 1, 9, 0, 0, 5 },
                { 0, 0, 0, 0, 8, 0, 0, 7, 9 }
            };
            
        }
    }
}
