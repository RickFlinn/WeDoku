using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using We_Doku.Data;
using We_Doku.Models.Interfaces;

namespace We_Doku.Models.Services
{
    public class GameBoardManager : IGameBoard
    {
        private readonly SudokuDbContext _context;

        /// <summary>
        /// Game manager constructor
        /// </summary>
        /// <param name="context">sudoku db</param>
        public GameBoardManager(SudokuDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// This method creates a gameboard when call
        /// </summary>
        /// <param name="gameBoard">Game board</param>
        /// <returns>Saved game board</returns>
        public async Task CreateGameBoard(GameBoard gameBoard)
        {
            _context.GameBoards.Add(gameBoard);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// This method deletes a game baord
        /// </summary>
        /// <param name="id">game board id to delete</param>
        /// <returns>removed game board</returns>
        public async Task DeleteGameBoard(int? id)
        {
            GameBoard gameBoard = _context.GameBoards.FirstOrDefault(h => h.ID == id);
            _context.GameBoards.Remove(gameBoard);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// This method retrieves a gameboard
        /// </summary>
        /// <param name="id">Game board to retrieve</param>
        /// <returns>game board</returns>
        public async Task<GameBoard> GetGameBoard(int? id)
        {
            return await _context.GameBoards
                .Include(gs => gs.GameSpaces)
                .FirstOrDefaultAsync(h => h.ID == id);

        }

        /// <summary>
        /// Thie method gets an individual board
        /// </summary>
        /// <param name="id">board to retrieve</param>
        /// <returns>Game board</returns>
        public async Task<GameBoard> GetJustBoard(int id)
        {
            return await _context.GameBoards.FirstOrDefaultAsync(b => b.ID == id);
        }

        /// <summary>
        /// This method returns a list of game boards
        /// </summary>
        /// <returns>List of game boards</returns>
        public async Task<IEnumerable<GameBoard>> GetGameBoards()
        {
            return await _context.GameBoards.Include(gs => gs.GameSpaces).ToListAsync();
        }

        /// <summary>
        /// This method updates a current game board
        /// </summary>
        /// <param name="gameBoard">game board to update</param>
        /// <returns>updated game board</returns>
        public async Task UpdateGameBoard(GameBoard gameBoard)
        {
            GameBoard current = await _context.GameBoards.Include(be => be.GameSpaces)
                                                         .FirstOrDefaultAsync(gb => gb.ID == gameBoard.ID);
            current.Placed = gameBoard.Placed;
            current.GameSpaces = gameBoard.GameSpaces;

            _context.GameBoards.Update(current);
            await _context.SaveChangesAsync();


        }

    }
}