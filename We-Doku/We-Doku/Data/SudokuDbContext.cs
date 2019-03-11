using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using We_Doku.Models;

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
        }

        public DbSet<GameBoard> GameBoard { get; set; }

        public DbSet<GameSpace> GameSpace { get; set; }
    }
}
