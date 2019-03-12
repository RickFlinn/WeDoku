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

        public SudokuDbContext (DbContextOptions<SudokuDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<GameSpace>().HasKey(gs => new { gs.GameBoardID, gs.X, gs.Y });

            GridBuilder gridBuilder = new GridBuilder();
            GameBoard newBoard = gridBuilder.BuildGameBoard(1);
            builder.Entity<GameSpace>().HasData(newBoard.GameSpaces);
            newBoard.GameSpaces = null;
            builder.Entity<GameBoard>().HasData(newBoard);

        }

        public DbSet<GameBoard> GameBoards { get; set; }

        public DbSet<GameSpace> GameSpaces { get; set; }
    }
}
