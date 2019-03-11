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
        Task<GameSpace> GetGameSpace(int? id);
        Task <IEnumerable<GameSpace>> GetGameSpace();

        //Update/Edit
        Task UpdateGameSpace(GameSpace gameSpace);

    }
}
