using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using We_Doku.Data;
using We_Doku.Models.Interfaces;

namespace We_Doku.Models.Services
{
    public class GameSpaceManager : IGameSpace
    {
        private readonly SudokuDbContext _context;

        public GameSpaceManager(SudokuDbContext context)
        {
            _context = context;
        }

        public async Task CreateGameSpace(GameSpace gameSpace)
        {
            _context.GameSpaces.Add(gameSpace);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGameSpace(int? id)
        {
            GameSpace gameSpace = _context.GameSpaces.FirstOrDefault();
            _context.GameSpaces.Remove(gameSpace);
            await _context.SaveChangesAsync();
        }

        public async Task<GameSpace> GetGameSpace(int x, int y, int boardID)
        {
            return await _context.GameSpaces.FirstOrDefaultAsync(gs => gs.X == x 
                                                                    && gs.Y == y 
                                                                    && gs.GameBoardID == boardID);
        }

        public async Task<IEnumerable<GameSpace>> GetGameSpaces()
        {
            return await _context.GameSpaces.ToListAsync();
        }

        public async Task UpdateGameSpace(GameSpace gameSpace)
        {
            _context.GameSpaces.Update(gameSpace);
            await _context.SaveChangesAsync();
        }
    }
}
