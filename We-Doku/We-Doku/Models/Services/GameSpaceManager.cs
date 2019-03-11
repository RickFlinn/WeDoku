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

        public Task CreateGameSpaces(GameSpaces gameSpaces)
        {
            throw new NotImplementedException();
        }

        public Task DeleteGameSpaces(int id)
        {
            throw new NotImplementedException();
        }

        public bool GameSpacesExist(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GameSpaces> GetGameSpaces(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GameSpaces>> GetGameSpaces()
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(GameSpaces gameSpaces)
        {
            throw new NotImplementedException();
        }

        public Task UpdateGameSpace(GameSpaces gamespaces)
        {
            throw new NotImplementedException();
        }
    }
}
