using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace We_Doku.Models.Interfaces
{
    public interface IGameSpace
    {
        //Create 
        Task CreateGameSpaces(GameSpaces gameSpaces);

        //Delete
        Task DeleteGameSpaces(int id);

        //Read
        Task<GameSpaces> GetGameSpaces(int? id);
        Task <IEnumerable<GameSpaces>> GetGameSpaces();

        //Update/Edit
        Task UpdateGameSpace(GameSpaces gamespaces);

        // Save
        Task SaveAsync(GameSpaces gameSpaces);

        //Check if Exists
        bool GameSpacesExist(int id);

    }
}
