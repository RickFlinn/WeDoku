using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace We_Doku.Models.Helpers
{
    public class SudokuGrid
    {
        public SudokuCell[,] Grid { get; set; } = new SudokuCell[9, 9];

        public SudokuGrid()
        {
            // Fill each coordinate with a new SudokuCell.
            for (int y = 0; y < 9; y++)
            {
                for(int x = 0; x < 9; x++)
                {
                    SudokuCell newCell = new SudokuCell();
                    Grid[y, x] = newCell;
                    newCell.Value = 0;
                    
                }
            }

            // Give each row of cells a shared set of all the available numbers in the row.
            for(int y = 0; y < 9; y++)
            {
                HashSet<int> availableInRow = new HashSet<int>();
                for(int x = 0; x < 9; x++)
                {
                    availableInRow.Add(x + 1);
                    Grid[y, x].AvailableInRow = availableInRow;
                }
            }

            // Give each row of cells a shared set of all the available numbers in the subgrid.
            for (int x = 0; x < 9; x++)
            {
                HashSet<int> availableInColumn = new HashSet<int>();
                for (int y = 0; y < 9; y++)
                {
                    availableInColumn.Add(y + 1);
                    Grid[y, x].AvailableInColumn = availableInColumn;
                }
            }

            // Give each subgrid of cells a shared set of all the available numbers in the subgrid.
            for (int sgy = 0; sgy < 9; sgy += 3)
            {
                for(int sgx = 0; sgx < 9; sgx += 3)
                {
                    HashSet<int> availableInSubGrid = new HashSet<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                    for(int y = sgy; y < sgy + 3; y++)
                    {
                        for(int x = sgx; x < sgx + 3; x++)
                        {
                            Grid[y, x].AvailableInSubGrid = availableInSubGrid;
                        }
                    }

                }
            }
        }


        /// <summary>
        ///     Retrieves the value stored at the given x and y index coordinates. 
        /// </summary>
        /// <param name="x"> x coordinate / column index of value </param>
        /// <param name="y"> y coordinate / row index of value </param>
        /// <returns> Value at given coordinates/index </returns>
        public int Get(int x, int y)
        {
            return Grid[y, x].Value;
        }

        /// <summary>
        ///     Sets the index at the given x and y coordinates to the given value, and removes that value
        ///     from the sets of available values in its row, column, and subgrid.
        /// </summary>
        /// <param name="x"> x coordinate / column index to place value at </param>
        /// <param name="y"> y coordinate / row index to place value at </param>
        /// <param name="value"> value to set at given coordinates/index </param>
        public void Set(int x, int y, int value)
        {
            SudokuCell cell = Grid[y, x];
            cell.Value = value;
            cell.AvailableInRow.Remove(value);
            cell.AvailableInColumn.Remove(value);
            cell.AvailableInSubGrid.Remove(value);
        }

        /// <summary>
        ///     "Resets" a space, adding its assigned value back to the sets of available values for its row, column and subgrid,
        ///      and then setting its value to zero.
        /// </summary>
        /// <param name="x"> x coordinate of value to reset </param>
        /// <param name="y"> y coordinate of value to reset </param>
        public void Reset(int x, int y)
        {
            SudokuCell cell = Grid[y, x];
            int value = cell.Value;
            if(value > 0)
            {
                cell.AvailableInRow.Add(value);
                cell.AvailableInColumn.Add(value);
                cell.AvailableInSubGrid.Add(value);
            }
            cell.Value = 0;
        }



        /// <summary>
        ///     Returns a list of all possible "sudoku-legal" moves. 
        ///     Begins with a set of all legal sudoku values (1-9), and then looks through all values
        ///      in the same column, row and subgrid, removing any values found from the set of possible moves.
        ///     Then, returns the set of possible moves, as an array.
        /// </summary>
        /// <param name="x"> x coordinate to evaluate possible moves for </param>
        /// <param name="y"> y coordinate to evaluate possible moves for </param>
        /// <returns> All possible legal values that can be placed at the given coordinates </returns>
        public int[] LegalValues(int x, int y)
        {
            if (Get(x, y) != 0)
            {
                // An item already exists at that location. No values should be placed here; an empty array is returned.
                return new int[0];
            }

            SudokuCell cell = Grid[y, x];

            HashSet<int> possibleMoves = new HashSet<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            possibleMoves.IntersectWith(cell.AvailableInRow);
            possibleMoves.IntersectWith(cell.AvailableInColumn);
            possibleMoves.IntersectWith(cell.AvailableInSubGrid);

            return possibleMoves.ToArray();

            // Remove all values in the same row from the set of possible moves.
            //for (int ix = 0; ix < 9; ix++)
            //{
            //    if (possibleMoves.Contains(Get(ix, y)))
            //    {
            //        possibleMoves.Remove(Get(ix, y));
            //    }
            //}

            //// Remove all values in the same column from the set of possible moves.
            //for (int iy = 0; iy < 9; iy++)
            //{
            //    if (possibleMoves.Contains(Get(x, iy)))
            //    {
            //        possibleMoves.Remove(Get(x, iy));
            //    }
            //}

            //// Remove all values in the same subgrid from the set of possible moves.
            //int subGridTopX = (x / 3) * 3; // Finds x coordinate of top left coord within subgrid
            //int subGridTopY = (y / 3) * 3; // Finds y coordinate of top left coord within subgrid
            //for (int i = subGridTopX; i < subGridTopX + 3; i++)
            //{
            //    for (int j = subGridTopY; j < subGridTopY + 3; j++)
            //    {
            //        if (possibleMoves.Contains(Get(i, j)))
            //        {
            //            possibleMoves.Remove(Get(i, j));
            //        }
            //    }
            //}

            // Return the set of all remaining possible moves at this position, as an array.
            //return possibleMoves.ToArray();
        }
       
        

        /// <summary>
        ///     Clones the values from the given SudokuGrid. 
        /// </summary>
        /// <param name="original"> SudokuGrid to copy coordinate values from. </param>
        public void CloneFrom(SudokuGrid original)
        {
            for(int y = 0; y < 9; y++)
            {
                for(int x = 0; x < 9; x++)
                {
                    Set(x, y, original.Get(x, y));
                }
            }
        }

        /// <summary>
        ///     Copies the values from each coordinate in the given array to the corresponding SudokuCell in this SudokuGrid.
        /// </summary>
        /// <param name="grid"></param>
        public void CopyFromGrid(int[,] grid)
        {
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    Set(x, y, grid[y,x]);
                }
            }
        }

        /*----------- Unused after refactor --------------*/


        /// <summary>
        ///     Checks to see whether a given value can be placed at the given coordinates.
        ///       Returns false if the value exists in the same row, column or subgrid, or if
        ///       that value already exists at the given coordinate.
        /// </summary>
        /// <param name="x"> x coordinate to check </param>
        /// <param name="y"> y coordinate to check </param>
        /// <param name="value"> value to check </param>
        /// <returns> boolean indicating whether the given value can be placed at the given coordinates </returns>
        public bool CanPlace(int x, int y, int value)
        {
            if (Get(x, y) != 0)
                return false;


            // Check the row for duplicate values.
            for (int ix = 0; ix < 9; ix++)
            {
                if (Get(ix, y) != 0 && Get(ix, y) == value)
                    return false;

            }

            // Check the column for duplicate values.
            for (int iy = 0; iy < 9; iy++)
            {
                if (Get(x, iy) != 0 && Get(x, iy) == value)
                    return false;
            }

            // Check the subgrid for duplicate values.
            int subGridTopX = (x / 3) * 3; // Finds x coordinate of top left coord within subgrid
            int subGridTopY = (y / 3) * 3; // Finds y coordinate of top left coord within subgrid
            for (int i = subGridTopX; i < subGridTopX + 3; i++)
            {
                for (int j = subGridTopY; j < subGridTopY + 3; j++)
                {
                    if (Get(i, j) != 0 && Get(i, j) == value)
                        return false;
                }
            }
            return true;
        }


        /// <summary>
        ///     Attempts to place a value at the given x,y coordinates in the grid.
        ///     If no duplicates of that value occur in the same row/column/subgrid, the value is placed, and method returns true.
        ///     Otherwise, returns false.
        /// </summary>
        /// <param name="x"> X coordinate to place a value </param>
        /// <param name="y"> Y coordinate to place a value </param>
        /// <param name="value"> Value to place at the specified coordinates in the grid </param>
        /// <returns> Boolean indicating whether placement was successful </returns>
        public bool TryPlace(int x, int y, int value)
        {
            if (CanPlace(x, y, value))
            {
                Set(x, y, value);
                return true;
            }
            return false;
        }
    }


}
