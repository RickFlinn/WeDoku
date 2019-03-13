using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace We_Doku.Models.Helpers
{
    public class GridBuilder
    {
        public SudokuGrid Solution { get; set; } = new SudokuGrid();
        public SudokuGrid Puzzle { get; set; } = new SudokuGrid();

        
        public GridBuilder()
        {
            GenerateSolution();
            GeneratePuzzle();
        }

        public GridBuilder(int masked)
        {
            GenerateSolutionRecursively();
            GeneratePuzzle(masked);
        }

        public GridBuilder(int maxAttempts, int masked)
        {
            GenerateSolution(maxAttempts);
            GeneratePuzzle(masked);
        }

        /// <summary>
        ///     Generates a new 9x9 array representing a solved Sudoku board, and saves it as this GridBuilder's Solution grid.
        /// </summary>
        /// <returns> 9x9 integer array representing a new sudoku solution</returns>
        private void GenerateSolution()
        {
            // Placeholder solution
            Solution.Grid = new int[9, 9]
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
        ///   Attempts to generate a new, solved, randomized SudokuGrid to represent the Sudoku solution,
        ///    and saves it as this GridBuilder's Solution.
        ///   Takes in an integer representing the number of attempts to generate a solution before a placeholder grid will be used.
        /// </summary>
        /// <param name="attemptMax"> Number of failed attempts to generate a board allowed before a placeholder will be used. </param>
        private void GenerateSolution(int maxAttempts)
        {
            HashSet<Tuple<int, int>> EmptyCoords = new HashSet<Tuple<int, int>>();
            for(int i = 0; i < 9; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    EmptyCoords.Add(new Tuple<int, int>(i, j));
                }
            }

            if (EmptyCoords.Count != 81)
                throw new Exception("Problem generating possible coordinates in GenerateSolution.");
            
            Solution = new SudokuGrid();
            int placed = 0;
            
            Random rand = new Random();

            while (EmptyCoords.Count > 0)
            {
                Tuple<int, int> randCoord = EmptyCoords.ElementAt(rand.Next(EmptyCoords.Count));
                int rx = randCoord.Item1;
                int ry = randCoord.Item2;
                
                int[] possibleValues = Solution.LegalValues(rx, ry);

                if(possibleValues.Length > 0)
                {
                    int rval = possibleValues[rand.Next(0, possibleValues.Length - 1)];
                    Solution.Set(rx, ry, rval);
                    placed++;

                    EmptyCoords.Remove(randCoord);

                } else // No possible moves at this coordinate.
                {
                    if(maxAttempts > 0)
                    {
                        GenerateSolution(maxAttempts - 1);

                    } else
                    {
                        GenerateSolution();
                    }
                }
            }
            Console.Write("ay");
        }

        public void GenerateSolutionRecursively()
        {
            Solution = new SudokuGrid();

            HashSet<Tuple<int, int>> AllCoords = new HashSet<Tuple<int, int>>();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    AllCoords.Add(new Tuple<int, int>(i, j));
                }
            }

            Queue<Tuple<int, int>> emptySpaces = new Queue<Tuple<int, int>>();
            Random rand = new Random();
            while (AllCoords.Count > 0)
            {
                Tuple<int, int> randCoord = AllCoords.ElementAt(rand.Next(AllCoords.Count));
                AllCoords.Remove(randCoord);
                emptySpaces.Enqueue(randCoord);
            }


            if (!GenSolutionRec(emptySpaces))
                throw new Exception("It asplode");
        }

        public bool GenSolutionRec(Queue<Tuple<int, int>> emptySpaces)
        {
            
            Random rand = new Random();
            Tuple<int, int> randCoord = emptySpaces.Dequeue();
            int rx = randCoord.Item1;
            int ry = randCoord.Item2;
            

            int[] possibleValues = Solution.LegalValues(rx, ry);

            if(possibleValues.Length > 0)
            {

                if (emptySpaces.Count < 1)
                {   // Base case found - we completed the board! This should return true all the way up the chain, signaling that we've done it.
                    Solution.Set(rx, ry, possibleValues[0]);
                    return true;
                }  
                
                foreach (int val in possibleValues)
                {
                    Solution.Set(rx, ry, val);
                    
                    // Okay, we need to keep adding values to our board. Make a recursive call. If it returns true, somewhere down the line we've found our 
                    //  "solved" base case - keep passing true back up!
                    if (GenSolutionRec(emptySpaces))
                    {   
                        return true;
                    }
                }
                
            }
            // No possible solutions with this board state could be found; add the coordinate back to the set of empties, reset that coordinate on the solution grid,
            //    and return false (go back).
            emptySpaces.Enqueue(randCoord);
            Solution.Set(rx, ry, 0);
            return false;
        }


        /// <summary>
        ///     Generates and saves a new 9x9 solution board. Corresponds to the prebuilt placeholder created by GenerateSolution.
        /// </summary>
        private void GeneratePuzzle()
        {
            // Logic to generate puzzle board using solution
            Puzzle.Grid = new int[9, 9]
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

        /// <summary>
        ///    Takes in an integer representing the number of items to randomly mask. 
        ///    Copies the Solution grid to a new Puzzle grid, and then randomly selects the specified number of values
        ///     to mask (change to value of zero) to build a puzzle sudoku board.
        ///    Sets this newly created SudokuGrid as the Puzzle grid for this builder. 
        /// </summary>
        /// <param name="masked"> Number of items to randomly mask </param>
        private void GeneratePuzzle(int masked)
        {
            HashSet<Tuple<int, int>> UnmaskedCoords = new HashSet<Tuple<int, int>>();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    UnmaskedCoords.Add(new Tuple<int, int>(i, j));
                }
            }

            Puzzle = new SudokuGrid();
            Array.Copy(Solution.Grid, Puzzle.Grid, 81);
            Random rand = new Random();

            for(int m = 0; m < masked; m++)
            {
                Tuple<int, int> randCoord = UnmaskedCoords.ElementAt(rand.Next(UnmaskedCoords.Count)); // picks a random coordinate that hasnt yet been emptied
                int rx = randCoord.Item1;
                int ry = randCoord.Item2;

                UnmaskedCoords.Remove(randCoord);
                Puzzle.Set(rx, ry, 0);
            }
        }

        /// <summary>
        ///  Constructs a new GameBoard object populated with GameSpaces.
        ///   Populates the GameBoard with GameSpaces with values and coordinates responding to the values in the Solution SudokuGrid,
        ///    and marks them as masked if the corresponding Solution grid has a value of zero (is marked as masked). 
        /// </summary>
        /// <returns> A gameboard built using the Solution and Puzzle SudokuGrids.</returns>
        public GameBoard BuildGameBoard(int id)
        {
            GameBoard newboard = new GameBoard() { Placed = 81, ID = id };
            newboard.GameSpaces = new List<GameSpace>();

            for (int iy = 0; iy < 9; iy++)
            {
                for (int ix = 0; ix < 9; ix++)
                {
                    GameSpace newSpace = new GameSpace()
                    {
                        GameBoardID = id,
                        X = ix,
                        Y = iy,
                        Value = Solution.Get(ix, iy),
                        Masked = false
                    };

                    if (Puzzle.Get(ix, iy) == 0)
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
