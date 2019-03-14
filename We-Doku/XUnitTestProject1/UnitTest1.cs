using Microsoft.EntityFrameworkCore;
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
        public async void CanCreateMoreThanOneGameBoard()
        {
            Microsoft.EntityFrameworkCore.DbContextOptions<SudokuDbContext> options = new
                DbContextOptionsBuilder<SudokuDbContext>().UseInMemoryDatabase
                ("CreateMultipleGameBoards").Options;

            using (SudokuDbContext context = new SudokuDbContext(options))
            {
                //Arrange
                GameBoard gameboard = new GameBoard();
                gameboard.ID = 1;
                gameboard.Placed = 2;

                //Act
                GameBoardManager GBM = new GameBoardManager(context);
                await GBM.CreateGameBoard(gameboard);
                await GBM.GetGameBoards();

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
        public async void CanGetJustGameBoard()
        {
            Microsoft.EntityFrameworkCore.DbContextOptions<SudokuDbContext> options = new
                DbContextOptionsBuilder<SudokuDbContext>().UseInMemoryDatabase
                ("JustGameBoard").Options;

            using (SudokuDbContext context = new SudokuDbContext(options))
            {
                //Arrange
                GameBoard gameboard = new GameBoard();
                gameboard.ID = 1;
                gameboard.Placed = 2;

                //Act
                GameBoardManager GBM = new GameBoardManager(context);
                await GBM.CreateGameBoard(gameboard);
                await GBM.GetJustBoard(1);

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
        public async void CanCreateMoreThanOneGameSpace()
        {
            Microsoft.EntityFrameworkCore.DbContextOptions<SudokuDbContext> options = new
                DbContextOptionsBuilder<SudokuDbContext>().UseInMemoryDatabase
                ("CreateMultipleGameSpaces").Options;

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
                await GSM.GetGameSpaces();

                var result = context.GameSpaces.FirstOrDefault(g => g.X == 1 && g.Y == 2 && g.Value == 3 && g.Masked && g.GameBoardID == 1);

                Assert.Equal(gameSpace, result);
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

        [Fact]
        public void CanSetGameBoardID()
        {
            GameBoard gameBoard = new GameBoard();
            gameBoard.ID = 2;
            gameBoard.ID = 1;

            GameBoard.Equals(1, gameBoard.ID);
        }

        [Fact]
        public void CanGetGameBoardPlaced()
        {
            GameBoard gameBoard = new GameBoard();

            gameBoard.Placed = 1;

            GameBoard.Equals(1, gameBoard.Placed);
        }

        [Fact]
        public void CanSetGameBoardPlaced()
        {
            GameBoard gameBoard = new GameBoard();
            gameBoard.Placed = 2;
            gameBoard.Placed = 1;

            GameBoard.Equals(1, gameBoard.Placed);
        }

        [Fact]
        public void CanGetGameSpaceX()
        {
            GameSpace gameSpace = new GameSpace();
            gameSpace.X = 1;

            GameSpace.Equals(1, gameSpace.X);
        }

        [Fact]
        public void CanSetGameSpaceX()
        {
            GameSpace gameSpace = new GameSpace();
            gameSpace.X = 2;
            gameSpace.X = 1;

            GameSpace.Equals(1, gameSpace.X);
        }

        [Fact]
        public void CanGetGameSpaceY()
        {
            GameSpace gameSpace = new GameSpace();
            gameSpace.Y = 1;

            GameSpace.Equals(1, gameSpace.Y);
        }

        [Fact]
        public void CanSetGameSpaceY()
        {
            GameSpace gameSpace = new GameSpace();
            gameSpace.Y = 2;
            gameSpace.Y = 1;

            GameSpace.Equals(1, gameSpace.Value);
        }

        [Fact]
        public void CanGetGameSpaceValue()
        {
            GameSpace gameSpace = new GameSpace();
            gameSpace.Value = 2;

            GameSpace.Equals(2, gameSpace.Value);
        }

        [Fact]
        public void CanSetGameSpaceValue()
        {
            GameSpace gameSpace = new GameSpace();
            gameSpace.Value = 2;
            gameSpace.Value = 1;

            GameSpace.Equals(1, gameSpace.Value);
        }

        [Fact]
        public void CanGetGameSpacemMasked()
        {
            GameSpace gameSpace = new GameSpace();
            gameSpace.Masked = true;

            GameSpace.Equals(true, gameSpace.Masked);
        }

        [Fact]
        public void CanSetGameSpaceMaksked()
        {
            GameSpace gameSpace = new GameSpace();
            gameSpace.Masked = true;
            gameSpace.Masked = false;
            
            GameSpace.Equals(false, gameSpace.Masked);
        }

    }
}
