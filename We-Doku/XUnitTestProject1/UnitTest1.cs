using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using We_Doku.Data;
using We_Doku.Models;
using We_Doku.Models.Services;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public async void CanCreateGameBoard()
        {
            Microsoft.EntityFrameworkCore.DbContextOptions<SudokuDbContext> options = new
                DbContextOptionsBuilder<SudokuDbContext>().UseInMemoryDatabase
                ("CreateGameBoard").Options;

            using (SudokuDbContext context = new SudokuDbContext(options))
            {
                //Arrange
                GameBoard gameboard = new GameBoard();
                gameboard.ID = 1;
                gameboard.Placed = 2;

                //Act
                GameBoardManager GBM = new GameBoardManager(context);
                await GBM.CreateGameBoard(gameboard);

                var result = context.GameBoards.FirstOrDefault(g => g.ID == g.ID);

                Assert.Equal(gameboard, result);
            }

        }
    }
}
