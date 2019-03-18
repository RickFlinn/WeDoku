using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using We_Doku.Models;
using We_Doku.Models.Helpers;

namespace We_Doku.Data
{
    public class SudokuDbContext : DbContext
    {

        /// <summary>
        /// This method initializes our sudoku board db
        /// </summary>
        /// <param name="options">sudoku board db</param>
        public SudokuDbContext (DbContextOptions<SudokuDbContext> options): base(options)
        {

        }

        /// <summary>
        /// This mehtod intitializes the game board model to stroe in our database
        /// </summary>
        /// <param name="builder">Model builder</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<GameSpace>().HasKey(gs => new { gs.GameBoardID, gs.X, gs.Y });

            GridBuilder gridBuilder = new GridBuilder();
            GameBoard newBoard = gridBuilder.BuildGameBoard(1);
            builder.Entity<GameSpace>().HasData(newBoard.GameSpaces);
            newBoard.GameSpaces = null;
            builder.Entity<GameBoard>().HasData(newBoard);

        }

        /// <summary>
        /// Game Board Table
        /// </summary>
        public DbSet<GameBoard> GameBoards { get; set; }
        /// <summary>
        /// GameSpaes table
        /// </summary>
        public DbSet<GameSpace> GameSpaces { get; set; }
    }
}
