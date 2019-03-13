using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using We_Doku.Models;
using We_Doku.Models.Helpers;
using We_Doku.Models.Interfaces;

namespace We_Doku.Hubs
{
    public class GameHub : Hub
    {
        private readonly IGameBoard _boardManager;
        private readonly IGameSpace _gsManager;

        public GameHub(IGameBoard boardManager, IGameSpace gsManager)
        {
            _boardManager = boardManager;
            _gsManager = gsManager;
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task SendCoordinate(string x, string y, string boardID, string value)
        {
            int input = int.Parse(value);
            int bID = int.Parse(boardID);
            int xCoord = int.Parse(x);
            int yCoord = int.Parse(y);

            if (input < 10 && input > 0)
            {
                GameSpace spaceToUpdate = await _gsManager.GetGameSpace(xCoord, yCoord, bID);
                if (input == spaceToUpdate.Value)
                {
                    spaceToUpdate.Masked = false;
                    await _gsManager.UpdateGameSpace(spaceToUpdate);
                    GameBoard board = await _boardManager.GetJustBoard(bID);
                    board.Placed++;
                    if (board.Placed >= 31)
                    {
                        // board completion logic
                        GridBuilder builder = new GridBuilder();
                        board = builder.BuildGameBoard(bID);
                        await _boardManager.UpdateGameBoard(board);
                        await Clients.All.SendAsync("UpdateSpace", x, y, value);
                        await Clients.All.SendAsync("BoardComplete");
                    }
                    else
                    {
                        await _boardManager.UpdateGameBoard(board);
                        await Clients.All.SendAsync("UpdateSpace", x, y, value);
                    }
                }
                else
                {
                    await Clients.Caller.SendAsync("ErrorMessage", x, y, value, "Incorrect! Try again.");
                }

            }
            else
            {
                await Clients.Caller.SendAsync("ErrorMessage", x, y, value, "Value was not within valid range. Values must be integers between 1 and 9");

            }
        }

    }
}
