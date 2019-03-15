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
        
        /// <summary>
        ///     Takes in a username and message sent by a signal R request, and sends it to all 
        ///     user's chat windows, so the message may be displayed. 
        /// </summary>
        /// <param name="user"> Username of user who sent the message </param>
        /// <param name="message"> Message to display </param>
        /// <returns></returns>
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        /// <summary>
        ///     Contains the game logic for the sudoku board. When connected clients make a request to this
        ///      hub endpoint, they send down an x coordinate, a y coordinate, the ID associated with the board
        ///      they are currently playing on, and the value they are attempting to place on a space. 
        ///      
        ///     All of the given values are first parsed into integers. Then, the GameSpace entry associated with 
        ///     the given boardID and x/y coordinates is located, and its stored value compared to the input value 
        ///     from the user. If the user guessed the value incorrectly, Signal R is used to indicate an incorrect 
        ///     guess on their browser. If the input matches the gamespace's value, and the gamespace is currently masked
        ///     (not displayed, i.e. not played on), the board is updated with the new number of completed spaces, 
        ///     the gamespace entry is updated as being "unmasked", i.e. displayed, and all client browsers are sent a 
        ///     signal r trigger to "unmask" the space and show its value, removing the input form for that space.\
        ///     
        ///     If, after a space is successfully unmasked, the board is completed, i.e. its "placed" value reaches 81, 
        ///     the game is complete. A new gameboard is generated, a trigger is sent to all client browsers to show that
        ///     the board has been completed, displaying a link to reload the page and display the newly updated gameboard.
        ///      
        /// </summary>
        /// <param name="x"> x coordinate of the space a player is trying to fill </param>
        /// <param name="y"> y coordinate of the space a player is trying to fill </param>
        /// <param name="boardID"> ID of the board the user is currently playing on </param>
        /// <param name="value"> value that the user is trying to place on a space </param>
        /// <returns></returns>
        public async Task SendCoordinate(string x, string y, string boardID, string value)
        {
            int input = int.Parse($"{value}");
            int bID = int.Parse($"{boardID}");
            int xCoord = int.Parse($"{x}");
            int yCoord = int.Parse($"{y}");

            if (input < 10 && input > 0)
            {
                GameSpace spaceToUpdate = await _gsManager.GetGameSpace(xCoord, yCoord, bID);
                if (input == spaceToUpdate.Value)
                {
                    if(spaceToUpdate.Masked)
                    {
                        spaceToUpdate.Masked = false;
                       await _gsManager.UpdateGameSpace(spaceToUpdate);
                        GameBoard board = await _boardManager.GetJustBoard(bID);
                        board.Placed++;
                        if (board.Placed >= 81)
                        {
                            await Clients.All.SendAsync("UpdateSpace", x, y, value);

                            await Clients.All.SendAsync("BoardComplete");
                            GridBuilder builder = new GridBuilder(50);
                            board = builder.BuildGameBoard(bID);
                            await _boardManager.UpdateGameBoard(board);
                            await Clients.All.SendAsync("NewBoardReady");

                        }
                        else
                        {   
                            await _boardManager.UpdateGameBoard(board);
                            await Clients.All.SendAsync("UpdateSpace", x, y, value);
                        }
                    } else Console.Write("ayyy");
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
