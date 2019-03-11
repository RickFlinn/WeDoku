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

        public async Task CreateGameSpaces(GameSpaces gameSpaces)
        {
            _context.GameSpaces.Add(gameSpaces);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGameSpaces(int? id)
        {
            GameSpaces gameSpaces = _context.GameSpaces.FirstOrDefault();
            _context.GameSpaces.Remove(gameSpaces);
            await _context.SaveChangesAsync();
        }

        public async Task<GameSpaces> GetGameSpaces(int? id)
        {
            return await _context.GameSpaces.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<GameSpaces>> GetGameSpaces()
        {
            return await _context.GameSpaces.ToListAsync();
        }

        public async Task UpdateGameSpace(GameSpaces gameSpaces)
        {
            _context.GameSpaces.Update(gameSpaces);
            await _context.SaveChangesAsync();
        }
    }
}
