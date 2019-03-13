using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        [Fact]
        public async void CanDeleteGameBoard()
        {
            Microsoft.EntityFrameworkCore.DbContextOptions<SudokuDbContext> options = new
                DbContextOptionsBuilder<SudokuDbContext>().UseInMemoryDatabase
                ("DeleteGameBoard").Options;

            using (SudokuDbContext context = new SudokuDbContext(options))
            {
                //Arrange
                GameBoard gameboard = new GameBoard();
                gameboard.ID = 1;
                gameboard.Placed = 2;

                //Act
                GameBoardManager GBM = new GameBoardManager(context);
                await GBM.CreateGameBoard(gameboard);
                await GBM.DeleteGameBoard(1);

                var result = context.GameBoards.FirstOrDefault(g => g.ID == g.ID);

                Assert.Null(result);
            }
        }

        [Fact]
        public async void CanReadGameBoard()
        {
            Microsoft.EntityFrameworkCore.DbContextOptions<SudokuDbContext> options = new
                DbContextOptionsBuilder<SudokuDbContext>().UseInMemoryDatabase
                ("ReadGameBoard").Options;

            using (SudokuDbContext context = new SudokuDbContext(options))
            {
                //Arrange
                GameBoard gameboard = new GameBoard();
                gameboard.ID = 1;
                gameboard.Placed = 2;

                //Act
                GameBoardManager GBM = new GameBoardManager(context);
                await GBM.CreateGameBoard(gameboard);
                await GBM.GetGameBoard(1);

                var result = context.GameBoards.FirstOrDefault(g => g.ID == gameboard.ID);

                Assert.Equal(gameboard, result);
            }

        }

        [Fact]
        public async void CanUpdateGameBoard()
        {
            Microsoft.EntityFrameworkCore.DbContextOptions<SudokuDbContext> options = new
                DbContextOptionsBuilder<SudokuDbContext>().UseInMemoryDatabase
                ("UpdateGameBoard").Options;

            using (SudokuDbContext context = new SudokuDbContext(options))
            {
                //Arrange
                GameBoard gameboard = new GameBoard();
                gameboard.ID = 1;
                gameboard.Placed = 2;

                //Act
                GameBoardManager GBM = new GameBoardManager(context);
                await GBM.CreateGameBoard(gameboard);
                await GBM.UpdateGameBoard(gameboard);

                var result = context.GameBoards.FirstOrDefault(g => g.ID == g.ID);

                Assert.Equal(gameboard, result);
            }
        }

        [Fact]
        public async void CanCreateGameSpace()
        {
            Microsoft.EntityFrameworkCore.DbContextOptions<SudokuDbContext> options = new
                DbContextOptionsBuilder<SudokuDbContext>().UseInMemoryDatabase
                ("CreateGameSpace").Options;

            using (SudokuDbContext context = new SudokuDbContext(options))
            {
                //Arrange
                GameSpace gameSpace = new GameSpace();
                gameSpace.X = 1;
                gameSpace.Y = 2;
                gameSpace.Value = 3;
                gameSpace.Masked = true;

                gameSpace.GameBoardID = 1;

                //Act
                GameSpaceManager GSM = new GameSpaceManager(context);
                await GSM.CreateGameSpace(gameSpace);

                var result = context.GameSpaces.FirstOrDefault(g => g.X == 1 && g.Y == 2 && g.Value == 3 && g.Masked && g.GameBoardID == 1);

                Assert.Equal(gameSpace, result);
            }

        }

        [Fact]
        public async void CanDeleteGameSpace()
        {
            Microsoft.EntityFrameworkCore.DbContextOptions<SudokuDbContext> options = new
                DbContextOptionsBuilder<SudokuDbContext>().UseInMemoryDatabase
                ("DeleteGameSpace").Options;

            using (SudokuDbContext context = new SudokuDbContext(options))
            {
                //Arrange
                GameSpace gameSpace = new GameSpace();
                gameSpace.X = 1;
                gameSpace.Y = 2;
                gameSpace.Value = 3;
                gameSpace.Masked = true;

                gameSpace.GameBoardID = 1;

                //Act
                GameSpaceManager GSM = new GameSpaceManager(context);
                await GSM.CreateGameSpace(gameSpace);
                await GSM.DeleteGameSpace(1);

                var result = context.GameSpaces.FirstOrDefault(g => g.X == 1 && g.Y == 2 && g.Value == 3 && g.Masked && g.GameBoardID == 1);

                Assert.Null(result);
            }

        }

        [Fact]
        public async void CanUpdateGameSpace()
        {
            Microsoft.EntityFrameworkCore.DbContextOptions<SudokuDbContext> options = new
                DbContextOptionsBuilder<SudokuDbContext>().UseInMemoryDatabase
                ("UpdateGameSpace").Options;

            using (SudokuDbContext context = new SudokuDbContext(options))
            {
                //Arrange
                GameSpace gameSpace = new GameSpace();
                gameSpace.X = 1;
                gameSpace.Y = 2;
                gameSpace.Value = 3;
                gameSpace.Masked = true;

                gameSpace.GameBoardID = 1;

                //Act
                GameSpaceManager GSM = new GameSpaceManager(context);
                await GSM.CreateGameSpace(gameSpace);
                await GSM.UpdateGameSpace(gameSpace);

                var result = context.GameSpaces.FirstOrDefault(g => g.X == 1 && g.Y == 2 && g.Value == 3 && g.Masked && g.GameBoardID == 1);

                Assert.Equal(gameSpace, result);
            }

        }

        [Fact]
        public async void CanReadGameSpace()
        {
            Microsoft.EntityFrameworkCore.DbContextOptions<SudokuDbContext> options = new
                DbContextOptionsBuilder<SudokuDbContext>().UseInMemoryDatabase
                ("ReadGameSpace").Options;

            using (SudokuDbContext context = new SudokuDbContext(options))
            {
                //Arrange
                GameSpace gameSpace = new GameSpace();
                gameSpace.X = 1;
                gameSpace.Y = 2;
                gameSpace.Value = 3;
                gameSpace.Masked = true;

                gameSpace.GameBoardID = 1;

                //Act
                GameSpaceManager GSM = new GameSpaceManager(context);
                await GSM.CreateGameSpace(gameSpace);
                GameSpace result = await GSM.GetGameSpace(gameSpace.X, gameSpace.Y, gameSpace.GameBoardID);


                Assert.Equal(gameSpace, result);
            }

        }

        [Fact]
        public void CanGetGameBoardID()
        {
            GameBoard gameBoard = new GameBoard();

            gameBoard.ID = 1;

            GameBoard.Equals(1, gameBoard.ID);
        }




    }
}
