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
            GenerateSolution();
            GeneratePuzzle();
        }

        /// <summary>
        ///     Generates and returns a new 9x9 array representing a solved Sudoku board.
        /// </summary>
        /// <returns> 9x9 integer array representing a new sudoku solution</returns>
        private void GenerateSolution()
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

        public GameBoard BuildGameBoard()
        {
            GameBoard newboard = new GameBoard() { Placed = 81 };

            for (int iy = 0; iy < 9; iy++)
            {
                for (int ix = 0; ix < 9; ix++)
                {
                    GameSpace newSpace = new GameSpace()
                    {
                        X = ix,
                        Y = iy,
                        Value = Solution[iy, ix],
                        Masked = false
                    };

                    if (Puzzle[iy, ix] == 0)
                    {
                        newSpace.Masked = true;
                        newboard.Placed--;
                    }

                    newboard.GameSpaces.Add(newSpace);
                }
            }
            
            return newboard;
        }
    }
}
