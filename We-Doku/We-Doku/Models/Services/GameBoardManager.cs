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
            _context.GameBoards.Add(gameBoard);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGameBoard(int? id)
        {
            GameBoard gameBoard = _context.GameBoards.FirstOrDefault(h => h.ID == id);
            _context.GameBoards.Remove(gameBoard);
            await _context.SaveChangesAsync();
        }

        public async Task<GameBoard> GetGameBoard(int? id)
        {
            return await _context.GameBoards
                .Include(gs => gs.GameSpaces)
                .FirstOrDefaultAsync(h => h.ID == id);

        }

        public async Task<GameBoard> GetJustBoard(int id)
        {
            return await _context.GameBoards.FirstOrDefaultAsync(b => b.ID == id);
        }

        public async Task<IEnumerable<GameBoard>> GetGameBoards()
        {
            return await _context.GameBoards.Include(gs => gs.GameSpaces).ToListAsync();
        }

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