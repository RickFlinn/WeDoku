using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace We_Doku.Models.Interfaces
{
    public interface IGameSpace
    {
        //Create 
        Task CreateGameSpace (GameSpace gameSpace);

        //Delete
        Task DeleteGameSpace(int? id);

        //Read
        Task<GameSpace> GetGameSpace(int x, int y, int boardID);
        
        Task <IEnumerable<GameSpace>> GetGameSpaces();

        //Update/Edit
        Task UpdateGameSpace(GameSpace gameSpace);

    }
}
