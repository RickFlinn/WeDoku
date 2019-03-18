using Microsoft.EntityFrameworkCore;
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

        /// <summary>
        ///     Saves the given GameSpace as a new entry in the database. 
        /// </summary>
        /// <param name="gameSpace"> GameSpace to create </param>
        /// <returns></returns>
        public async Task CreateGameSpace(GameSpace gameSpace)
        {
            _context.GameSpaces.Add(gameSpace);
            await _context.SaveChangesAsync();
        }

        
        /// <summary>
        ///     Retrieves the GameSpace entry with the given x coordinate, y coordinate, and gameboard ID.
        /// </summary>
        /// <param name="x"> X coordinate of the GameSpace </param>
        /// <param name="y"> Y coordinate of the GameSpace </param>
        /// <param name="boardID"> Foreign ID of the GameBoard associated with the GameSpace </param>
        /// <returns> GameSpace entry with the given X coordinate, Y Coordinate, and GameBoardID </returns>
        public async Task<GameSpace> GetGameSpace(int x, int y, int boardID)
        {
            return await _context.GameSpaces.FirstOrDefaultAsync(gs => gs.X == x 
                                                                    && gs.Y == y 
                                                                    && gs.GameBoardID == boardID);
        }

        /// <summary>
        ///     Retrieves all GameSpace entries in the database. 
        /// </summary>
        /// <returns> IEnumerable of all GameSpaces in the database </returns>
        public async Task<IEnumerable<GameSpace>> GetGameSpaces()
        {
            return await _context.GameSpaces.ToListAsync();
        }

        /// <summary>
        ///     Takes in a GameSpace that already exists in the database, and updates it. 
        /// </summary>
        /// <param name="gameSpace"></param>
        /// <returns></returns>
        public async Task UpdateGameSpace(GameSpace gameSpace)
        {
            _context.GameSpaces.Update(gameSpace);
            await _context.SaveChangesAsync();
        }
    }
}
