using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace We_Doku.Models.Interfaces
{
    public interface IGameBoard
    {
        //Create 
        Task CreateGameBoard(GameBoard gameBoard);

        //Delete
        Task DeleteGameBoard(int? id);

        //Read
        Task<GameBoard> GetGameBoard(int? id);
        Task<IEnumerable<GameBoard>> GetGameBoard();

        //Update/Edit
        Task UpdateGameSpace(GameBoard gameBoard);
    }
}
