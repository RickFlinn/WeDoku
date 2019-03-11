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

        public GameBoardManager(SudokuDbContext context)
        {
            _context = context;
        }

        public async Task CreateGameBoard(GameBoard gameBoard)
        {
            _context.GameBoard.Add(gameBoard);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGameBoard(int? id)
        {
            GameBoard gameBoard = _context.GameBoard.FirstOrDefault(h => h.ID == id);
            _context.GameBoard.Remove(gameBoard);
            await _context.SaveChangesAsync();
        }

        public async Task<GameBoard> GetGameBoard(int? id)
        {
            return await _context.GameBoard
                .Include(gs => gs.GameSpaces)
                .FirstOrDefaultAsync(h => h.ID == id);

        }

        public async Task<IEnumerable<GameBoard>> GetGameBoard()
        {
            return await _context.GameBoard.ToListAsync();
        }

        public async Task UpdateGameSpace(GameBoard gameBoard)
        {
            _context.GameBoard.Update(gameBoard);
            await _context.SaveChangesAsync();
        }
    }
}