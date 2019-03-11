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

        public DbSet<GameBoard> GameBoard { get; set; }

        public DbSet<GameSpaces> GameSpaces { get; set; }
    }
}
